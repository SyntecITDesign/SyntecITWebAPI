using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Syntec.AuthoManager;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Interface;
using SyntecITWebAPI.Models.Decode.DecodeFunction;
using SyntecITWebAPI.Models.Decode.SecretDLL;
using SyntecITWebAPI.ParameterModels.DecodePW;
using SyntecITWebAPI.Static;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TQMLibrary;

namespace SyntecITWebAPI.Models.Decode
{
	internal class DecodePWHandler
	{
		#region Internal Methods

		internal bool CheckUserRights( string userID, string verifyCode ) //檢查子帳號是否有此解密類別權限
		{
			if( m_dbManager.GetOptionIsMother( userID ) == "1" ) //為母帳號
				return true;
			else if( m_barcodeDBManager.CheckSyntecEmpIDExist( userID ) == true )
				return true;
			else if( verifyCode.Length > 4 )
			{
				string roles = m_dbManager.GetOptionRoles( userID );
				string decodeRights = roles.Substring( 4 ); //省略"N,O," 取後面的解密類別權限

				//將檢查代碼第五碼 : 控制器狀態碼轉為Enum形式
				char cncStatusCodeString = verifyCode.Substring( 4, 1 ).ToCharArray()[ 0 ];
				CNCStatusCodeList code;
				try
				{
					code = (CNCStatusCodeList)cncStatusCodeString;
				}
				catch // enum裡面沒有此代碼 : 預設給過
				{
					return true;
				}

				// 處理狀態碼為 (0~9), 直接檢查權限有沒有這個狀態碼
				if( decodeRights.IndexOf( (char)code ) >= 0 )
					return true;

				//處理狀態碼為 : (A,B,C,D,E,F)
				if( code == CNCStatusCodeList.Unlimit_Date_V3_1 || code == CNCStatusCodeList.Unknown_D )
				{
					if( decodeRights.IndexOf( (char)CNCStatusCodeList.Unlimit_Date_Valid_Use ) >= 0 ) // 0
						return true;
				}
				else if( code == CNCStatusCodeList.Limit_Date_Valid_Use_V3_1 || code == CNCStatusCodeList.Unknown_E )
				{
					if( decodeRights.IndexOf( (char)CNCStatusCodeList.Limit_Date_Valid_Use_V3 ) >= 0 ) // 7
						return true;
				}
				else if( code == CNCStatusCodeList.Limit_Date_Invalid_Change_Date_V3_1 || code == CNCStatusCodeList.Unknown_F )
				{
					if( decodeRights.IndexOf( (char)CNCStatusCodeList.Limit_Date_Invalid_Change_Date_V3 ) >= 0 ) // 8
						return true;
				}

				return false;
			}
			else
				return true;
		}

		internal bool CloudServiceSetOptionApply( string sn, string password )
		{
			//Get Cloud Key From Config
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "WebServiceKey.json", optional: false )
			.Build();

			string cloudKey = configuration[ "CloudServiceKey" ].Trim();

			var client = WebServiceSetting.CLOUD_SERVICE_CLIENT;

			Task<string> setOptionApplyTask = client.SetOptionApplyAsync( cloudKey, sn, password );

			string response = setOptionApplyTask.Result;

			if( response.IndexOf( "0000" ) < 0 ) //fail
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		internal string DecodeDate( DecodeDatePWParameter decodeDatePWParameter )
		{
			//check is Date or Unlimit
			IDecodePWFunction decodePWFunction;
			if( decodeDatePWParameter.timeType == "Date" )
			{
				decodePWFunction = new DecodeDateFunction( m_secretDLL );
			}
			else if( decodeDatePWParameter.timeType == "Unlimit" )
			{
				decodePWFunction = new DecodeUnlimitFunction( m_secretDLL );
			}
			else if( decodeDatePWParameter.timeType == "Month" )
			{
				decodePWFunction = new DecodeMonthFunction( m_secretDLL );
			}
			else
				return null;

			PWGenerator generator = new PWGenerator( decodePWFunction );
			string generatePWResult = generator.Generate( decodeDatePWParameter );
			if( string.IsNullOrEmpty( generatePWResult ) )
				return null;

			//WriteLog
			string logDescription = "使用期密碼" + decodeDatePWParameter.decryptionType + "V112_" + decodeDatePWParameter.dueDateDetail + "_" + decodeDatePWParameter.timeType;
			DecodeLogParameter decodeLogParameter = new DecodeLogParameter( decodeDatePWParameter, generatePWResult, LogCodeList.Decode_Date, logDescription );

			if( WriteLog( decodeLogParameter ) == false )
				return null;

			if( m_tqmHandler.TQMWriteToSbc( decodeLogParameter, generatePWResult, "DecodeDate-Day" ) == false )
				return null;

			return generatePWResult;
		}

		internal string DecodeGeneratePwdV1( GeneratePwdV1Parameter parameter )
		{
			m_secretDLL.DLLGetPassEncodeVer( true, parameter.verifyCode ); //getPassEncodeVer(true) 為 密碼產生V1

			PWGenerator generator = new PWGenerator( new GeneratePwdV1Function( m_secretDLL ) );
			string generatePWResult = generator.Generate( parameter );
			if( string.IsNullOrEmpty( generatePWResult ) )
				return null;

			string logDescription = $"密碼產生v1.0_{parameter.dueDateDetail}_{parameter.timeType}";

			//根據過去Option Log格式
			DecodeLogParameter decodeLogParameter = new DecodeLogParameter( parameter, generatePWResult + "/", LogCodeList.Decode_GeneratePW_V1, logDescription );

			if( WriteLog( decodeLogParameter ) == false )
				return null;

			//根據過去TQM Log格式
			string passwordResult = $"{generatePWResult}/{parameter.verifyCode}/";
			decodeLogParameter.logCode = ( (int)LogCodeList.Decode_Date ).ToString(); //TQM 產生密碼的LogCode為 13
			if( m_tqmHandler.TQMWriteToSbc( decodeLogParameter, passwordResult, "DecodePwdGen" ) == false )
				return null;

			return generatePWResult;
		}

		internal JObject DecodeGeneratePwdV2( GeneratePwdV2Parameter parameter )
		{
			string specificKey = null; //V3.1 V3.2需要
			string password = null;

			m_secretDLL.DLLGetPassEncodeVer( false, parameter.verifyCode ); //getPassEncodeVer(false) 為 密碼產生V2/V3
			m_secretDLL.DLLSetLang( parameter.userLang ); //set DLL language

			ArrayList statusArrayList = m_secretDLL.DLLGetCheckNoStatus( parameter.customerCode, parameter.verifyCode );  //取狀態碼

			if( parameter.verifyCode.Length >= 6 ) //密碼產生V3_1,V3_2
			{
				List<string> passwordResult = GeneratePwdV3( parameter );
				if( passwordResult == null )
					return null;
				password = passwordResult[ 0 ];
				specificKey = passwordResult[ 1 ];
			}
			else //密碼產生V2 or V3.0
			{
				password = GeneratePwdV2( parameter );
			}

			if( string.IsNullOrEmpty( password ) )
				return null;

			//寫Log
			string logDescription = $"密碼產生v2.0_{parameter.dueDateDetail}_{parameter.timeType}";
			string logPasswordResult = $"{password}/{specificKey}";

			//根據過去Option Log格式
			DecodeLogParameter decodeLogParameter = new DecodeLogParameter( parameter, logPasswordResult, LogCodeList.Decode_GeneratePW_V2V3, logDescription );
			if( WriteLog( decodeLogParameter ) == false )
				return null;

			//根據過去TQM Log格式
			string tqmLogPasswordResult = $"{password}/{parameter.verifyCode}/{specificKey}";
			decodeLogParameter.logCode = ( (int)LogCodeList.Decode_Date ).ToString(); //TQM 產生密碼V2/V3 的LogCode為 13
			if( m_tqmHandler.TQMWriteToSbc( decodeLogParameter, tqmLogPasswordResult, "DecodePwdGen" ) == false )
				return null;

			if( parameter.cloudDecode == 1 ) //為線上解密
			{
				if( CloudServiceSetOptionApply( parameter.productSN, password ) == false )
					return null;
			}

			JObject result = new JObject
			{
				{nameof(password) , password},
				{"keyState", JToken.FromObject(statusArrayList) }
			};

			return result;
		}

		internal string DecodeHardware( DecodeHWParameter decodeHWParameter )
		{
			PWGenerator generator = new PWGenerator( new DecodeHwFunction( m_secretDLL ) );
			string generatePWResult = generator.Generate( decodeHWParameter );

			if( string.IsNullOrEmpty( generatePWResult ) )
				return null;

			//WriteLog
			string logDescription = "硬體資訊不符";
			DecodeLogParameter decodeLogParameter = new DecodeLogParameter( decodeHWParameter, generatePWResult, LogCodeList.Decode_Hardware, logDescription );
			if( WriteLog( decodeLogParameter ) == false )
				return null;

			if( m_tqmHandler.TQMWriteToSbc( decodeLogParameter, generatePWResult, "DecodeDate-硬體" ) == false )
				return null;

			return generatePWResult;
		}

		internal string DecodeReset( DecodeResetParameter parameter )
		{
			UserHandler userHandler = new UserHandler();
			string result = null;
			string logMachineCode = null;

			switch( parameter.decodeRightType )
			{
				case DecodeResetParameter.RIGHTTYPE_SYNTEC:
					result = AuthoPassword.GetSyntecPassword( parameter.verifyCode );
					break;

				case DecodeResetParameter.RIGHTTYPE_MACHINECOMPANY:
					//Get User MachineCode

					string machineCode = userHandler.GetMachineCodeByID( parameter.userID ).GetValue( nameof( machineCode ) ).ToString();

					if( machineCode == "0000" ) // 為新代員工
					{
						result = AuthoPassword.GetMakerResetPassword( null, parameter.verifyCode );
						logMachineCode = null;
					}
					else //非新代員工
					{
						result = AuthoPassword.GetMakerResetPassword( machineCode, parameter.verifyCode );
						logMachineCode = machineCode;
					}
					break;

				case DecodeResetParameter.RIGHTTYPE_ENDCUSTOMER:
					result = AuthoPassword.GetAdminResetPassword( parameter.verifyCode );
					break;

				default:
					return null;
			}

			//WriteLog
			string logDescription = "控制器登入密碼重置";
			DecodeLogParameter decodeLogParameter = new DecodeLogParameter( parameter, result, LogCodeList.Decode_PW_Reset, logDescription, logMachineCode );
			if( WriteLog( decodeLogParameter ) == false )
				return null;

			return result;
		}

		internal bool DecodeResetCheckRights( string orgCode, string decodeResetRightType )
		{
			if( string.IsNullOrEmpty( orgCode ) )
			{
				return false;
			}
			else
			{
				// cast string to SyntecOrganizationList
				SyntecOrganizationList org = (SyntecOrganizationList)Enum.Parse( typeof( SyntecOrganizationList ), orgCode );

				//取得這個組織代碼可以使用的decodeResetRightType
				HashSet<string> validRightType = DecodeResetRights.ORG_CODE_TO_RESET_RIGHTS( org );

				//若這個組織代碼可以用的重置密碼權限 包含使用者想要用的重置密碼權限 回傳true 否則回傳false
				if( !validRightType.Contains( decodeResetRightType ) )
					return false;
				else
					return true;
			}
		}

		internal string DecodeServo( DecodeServoParameter decodeServoParameter )
		{
			PWGenerator generator = new PWGenerator( new DecodeServoFunction( m_secretDLL ) );
			string generatePWResult = generator.Generate( decodeServoParameter );
			if( string.IsNullOrEmpty( generatePWResult ) )
				return null;

			//WriteLog
			string logDescription = "驅動器密碼產生";

			//因之前Log格式產生此變數
			string passwordResult = $"{generatePWResult} / {Convert.ToUInt32( decodeServoParameter.versionSN )} / {decodeServoParameter.spcSN}";

			DecodeLogParameter decodeLogParameter = new DecodeLogParameter( decodeServoParameter, generatePWResult, LogCodeList.Decode_Servo, logDescription );
			if( WriteLog( decodeLogParameter ) == false )
				return null;

			if( m_tqmHandler.TQMWriteToSbc( decodeLogParameter, passwordResult, "驅動器密碼產生" ) == false )
				return null;

			return generatePWResult;
		}

		internal string GenerateRestoreOptionPassword( SNRestoreParameter parameter, string optionString )
		{
			//轉換OptionNum至DLL所需的型式
			int[] optionArray = new int[ 3 ];

			//轉Decimal to Byte Array => 16個8位元
			byte[] optionByteArray = DecimalToByteArray( parameter.optionNum );

			optionArray[ 2 ] = GetHighBytes( optionByteArray );
			optionArray[ 1 ] = GetMiddleBytes( optionByteArray );
			optionArray[ 0 ] = GetLowBytes( optionByteArray );

			m_secretDLL.DLLPutMachineType( parameter.cncType );
			m_secretDLL.DLLPutAxis( parameter.axis );

			string passwordResult = m_secretDLL.DLLGetRestorePassword( optionArray, parameter.machineModel, parameter.productSN, parameter.verifyCode );

			return passwordResult;
		}

		internal JObject SNRestore( SNRestoreParameter parameter )
		{
			//檢查機型跟控制器類別是否存在
			if( m_barcodeDBManager.CheckCncTypeMachineModelExist( parameter.cncType, parameter.machineModel ) == false )
				return null;

			//檢查SN存在
			if( SNServiceCheckSNExist( parameter.productSN ) == false )
				return null;

			//轉option代碼至所有選配功能字串 為滿足過去規格(1,2,3,) 故最後加一個逗號
			string allOptionString = string.Empty;
			List<int> allOption = OptionConvert( parameter.optionNum );
			if( allOption.Count > 0 )
				allOptionString = string.Join( ",", allOption ) + ",";

			//1 為 ResetOption password
			string newPassword = GenerateRestoreOptionPassword( parameter, allOptionString );

			// 若不為計中測試序號，更新TQM資料
			if( parameter.productSN.IndexOf( "M9A0001" ) < 0 )
			{
				string tqmResult = ( m_productSN.UpdateSNOptionInfo( parameter.productSN, parameter.optionNum.ToString(), parameter.axis.ToString(), allOptionString, parameter.userID ) );
				//若TQM update失敗
				if( tqmResult.IndexOf( "0000" ) < 0 )
					return null;
			}

			string newVerifyCode = m_secretDLL.DLLCalculateCncCheckNo( parameter.productSN, parameter.verifyCode );

			string logDescription = "重設Option密碼";

			//將參數物件的verifyCode設為新產生的verifyCode => 用於寫Log
			parameter.verifyCode = newVerifyCode;
			DecodeLogParameter decodeLogParameter = new DecodeLogParameter( parameter, newPassword, LogCodeList.Reset_Option_Password, logDescription );
			if( WriteLog( decodeLogParameter ) == false )
				return null;

			if( m_tqmHandler.TQMWriteToSbc( decodeLogParameter, newPassword, "ResetOptionCode" ) == false )
				return null;

			JObject result = new JObject
			{
				{"password", newPassword},
				{"verifyCode", newVerifyCode }
			};

			return result;
		}

		internal bool SNServiceCheckSNExist( string sn )
		{
			//Get SN Key From Config
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "WebServiceKey.json", optional: false )
			.Build();

			string snKey = configuration[ "SNServiceKey" ].Trim();

			var client = WebServiceSetting.SN_SERVICE_CLIENT;

			Task<string> checkSnExsitTask = client.CheckSNExistAsync( snKey, sn );

			string response = checkSnExsitTask.Result;

			if( response.IndexOf( "0000" ) < 0 ) //SN not exist
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion Internal Methods

		#region Private Fields

		private BarcodeDBManager m_barcodeDBManager = new BarcodeDBManager();
		private DecodeDBManager m_dbManager = new DecodeDBManager();
		private ProductSN m_productSN = new ProductSN();

		// Release 時更改new的物件 TestSecretDLL => FormalSecretDLL
		private ISecretDLL m_secretDLL = new TestSecretDLL();

		private TQMLogHandler m_tqmHandler = new TQMLogHandler();

		#endregion Private Fields

		#region Private Methods

		private static byte[] DecimalToByteArray( decimal src )
		{
			using( MemoryStream stream = new MemoryStream() )
			{
				using( BinaryWriter writer = new BinaryWriter( stream ) )
				{
					writer.Write( src );
					return stream.ToArray();
				}
			}
		}

		//密碼產生V2/V3 版本V3_1,V3_2 額外做檢查代碼的檢查
		private bool CheckSnVerifyCodeValid( GeneratePwdV2Parameter parameter )
		{
			//從DLL 取得檢查碼
			string fullVerifyCode = $"{parameter.customerCode} {parameter.verifyCode.Trim()}";
			string checkVerifyCode = m_secretDLL.DLLCalculateCncCheckNo( parameter.productSN, fullVerifyCode );

			//我們自行產生的檢查碼，取末碼or末兩碼
			string snCheckNo = string.Empty;

			if( parameter.verifyCode.Length == 6 )
			{
				snCheckNo = parameter.verifyCode.Substring( 5, 1 );
			}
			else if( parameter.verifyCode.Length == 7 )
			{
				snCheckNo = parameter.verifyCode.Substring( 5, 2 );
			}

			//檢查sncheckNo與checkVerifyCode
			if( snCheckNo.CompareTo( checkVerifyCode ) != 0 )
				return false;
			else
				return true;
		}

		//密碼產生V2/V3 版本V2,V3.0 因V3.0的檢查碼長度、Call的DLL Function與V2相同故走同一條路
		private string GeneratePwdV2( GeneratePwdV2Parameter parameter )
		{
			//V2 parameter 轉型至 V1
			var mapConfig = new MapperConfiguration( cfg
				 => cfg.CreateMap<GeneratePwdV2Parameter, GeneratePwdV1Parameter>() );

			var mapper = mapConfig.CreateMapper();
			GeneratePwdV1Parameter generatePwdV1Parameter = mapper.Map<GeneratePwdV1Parameter>( parameter );

			PWGenerator generator = new PWGenerator( new GeneratePwdV1Function( m_secretDLL ) );
			string password = generator.Generate( generatePwdV1Parameter );

			return password;
		}

		//密碼產生V2/V3 版本V3_1,V3_2 回傳 1.密碼 2. specificKey
		private List<string> GeneratePwdV3( GeneratePwdV2Parameter parameter )
		{
			List<string> result = new List<string>();
			if( CheckSnVerifyCodeValid( parameter ) == false )
			{
				return null;
			}

			//從TQM取specificKey => 產生密碼時需要，M9A0001為計中測試專用，方便測試所以固定設0513
			string specificKey = m_productSN.GetSNSpecificKey( parameter.productSN );
			//控制器狀態碼 : 檢查碼第五碼
			string changeTag = parameter.verifyCode.Substring( 4, 1 );

			if( parameter.productSN.IndexOf( "M9A0001" ) >= 0 )
			{
				specificKey = "0513";
				m_productSN.SetSNSpecificKey( parameter.productSN, specificKey );
			}
			else
			{
				//若TQM取不到specificKey，從DLL生成並記錄在TQM
				if( ( specificKey == null || specificKey.Length == 0 ) && ( changeTag.IndexOf( "A" ) >= 0 || changeTag.IndexOf( "D" ) >= 0 ) )
				{
					specificKey = m_secretDLL.DLLGetNewSpecificKey();
					m_productSN.SetSNSpecificKey( parameter.productSN, specificKey );
				}
			}

			m_secretDLL.DLLSetPasswordType( changeTag );

			//檢查 SpecificKey是否運作正常
			if( string.IsNullOrEmpty( specificKey ) )
				return null;

			string password = string.Empty;
			//產生密碼
			if( m_secretDLL.DLLCheckPassVerV3_2() == true ) //(Syntec.Validity.PasswordAPI.m_PassVer == Syntec.Validity.PasswordAPI.PassVer.V3_2)
			{
				password = m_secretDLL.DLLGeneratePwdV3_2( parameter, specificKey );
			}
			else if( m_secretDLL.DLLCheckPassVerV3_1() == true ) //(Syntec.Validity.PasswordAPI.m_PassVer == Syntec.Validity.PasswordAPI.PassVer.V3_1)
			{
				password = m_secretDLL.DLLGeneratePwdV3_1( parameter, specificKey );
			}
			else // 若不是V3_1,V3_2 使用V2密碼產生
			{
				PWGenerator generator = new PWGenerator( new GeneratePwdV1Function( m_secretDLL ) );
				password = generator.Generate( parameter );
			}

			result.Add( password );
			result.Add( specificKey );
			return result;
		}

		//將4個Byte (Byte Array中的第9~12個Byte) 轉為 int
		private int GetHighBytes( byte[] optionByteArray )
		{
			byte[] result = new byte[ 4 ];

			int j = 3;
			for( int i = 11; i >= 8; i-- )
			{
				result[ j ] = optionByteArray[ i ];
				j--;
			}

			return BitConverter.ToInt32( result, 0 );
		}

		//將4個Byte (Byte Array中的第1~4個Byte) 轉為 int
		private int GetLowBytes( byte[] optionByteArray )
		{
			byte[] result = new byte[ 4 ];

			for( int i = 3; i >= 0; i-- )
			{
				result[ i ] = optionByteArray[ i ];
			}
			return BitConverter.ToInt32( result, 0 );
		}

		//將4個Byte (Byte Array中的第5~8個Byte) 轉為 int
		private int GetMiddleBytes( byte[] optionByteArray )
		{
			byte[] result = new byte[ 4 ];

			int j = 3;
			for( int i = 7; i >= 4; i-- )
			{
				result[ j ] = optionByteArray[ i ];
				j--;
			}

			return BitConverter.ToInt32( result, 0 );
		}

		private List<int> OptionConvert( decimal optionNum )
		{
			if( optionNum < 0 )
				return null;
			else
			{
				List<int> result = new List<int>();
				int index = 0;
				while( optionNum > 0 )
				{
					if( optionNum % 2 == 1 )
					{
						result.Add( index + 1 );
					}
					optionNum = Math.Floor( optionNum / 2 );
					index++;
				}
				return result;
			}
		}

		// write log to Syntecoption/History_Record
		private bool WriteLog( DecodeLogParameter decodeLogParameter )
		{
			AbstractDecodePWParameter parameter = decodeLogParameter.decodeparameter;

			bool writeLogResult = m_dbManager.InsertDecodeHistoryRecord
				(
				parameter.productSN,
				parameter.verifyCode,
				decodeLogParameter.decodePassword,
				parameter.userID,
				decodeLogParameter.logCode,
				decodeLogParameter.logDescription,
				decodeLogParameter.logRemark
				);

			if( writeLogResult == false )
				return false;
			else
				return true;
		}

		#endregion Private Methods
	}
}
