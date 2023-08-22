using Newtonsoft.Json.Linq;
using OldUserService;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Static;
using SyntecITWebAPI.Utility;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models
{
	internal class LoginHandler
	{
		#region Internal Constructors + Destructors

		internal LoginHandler( string userID, string userPassword )
		{
			this.userID = userID;
			this.userPassword = userPassword;
		}

		#endregion Internal Constructors + Destructors

		#region Internal Methods

		internal string GetWeChatID( string userID )
		{
			return m_userDBManager.GetWeChatByID( userID );
		}

		internal ResponseHandler Login()
		{
			ResponseHandler responseHandler = new ResponseHandler();
			JObject identityResult;

			//old option service
			try
			{
				var loginResult = UserServiceLoginPlatformOption( userID, userPassword );
				var jsonLoginResult = JObject.Parse( loginResult );

				//get login result code like "E004" or "0000"
				var loginResultCode = jsonLoginResult.Properties().Select( p => p.Name ).FirstOrDefault();

				// select errorCode according to the error code from previous login web service
				switch( loginResultCode )
				{
					case "E004":
						responseHandler.Code = Enums.ErrorCodeList.Auth_Error;
						responseHandler.Detail = "請先至email信箱進行帳號認證 Please verify your account in email.";
						break;

					case "E005":
						responseHandler.Code = Enums.ErrorCodeList.Password_Need_Change;
						responseHandler.Detail = "請先更改密碼後再進行登入 Password need to be changed.";
						break;

					case "E006":
						responseHandler.Code = Enums.ErrorCodeList.Auth_Error;
						responseHandler.Detail = "您帳號尚未被授權使用解密網站，請聯繫系統管理員 Your account are not authorized to access option system, please contact system administrator.";
						break;

					case "E001":
						responseHandler.Code = Enums.ErrorCodeList.Password_Wrong;
						responseHandler.Detail = "帳號密碼錯誤 Account or password wrong";
						break;
					case "E011":
						responseHandler.Code = Enums.ErrorCodeList.Password_Need_Change;
						responseHandler.Detail = "超過六個月未更換密碼 Password wrong need to change.";
						break;

					case "0000":
						if( loginResult.IndexOf( "Website" ) >= 0 )
						{
							responseHandler.Code = Enums.ErrorCodeList.UserID_UnExist;
							responseHandler.Detail = "您尚未註冊解密網站，請先完成註冊動作 You have not registered option system, please register first.";
						}
						else//Success 取得身份別
						{
							identityResult = IdentityHandler( jsonLoginResult );
							responseHandler.Content = identityResult;
						}
						break;

					default:
						responseHandler.Code = Enums.ErrorCodeList.System_Error;
						responseHandler.Detail = "系統異常，請聯繫系統管理員 please contact system administrator.";
						break;
				}
			}
			catch( Exception ex )
			{
				responseHandler.Code = Enums.ErrorCodeList.System_Error;
				responseHandler.Detail = ex.ToString();
			}

			return responseHandler;
		}

		internal string UserServiceLoginPlatformOption( string userID, string userPassword )
		{
			var callClient = WebServiceSetting.USER_SERVICE_CLIENT;

			Task<LoginProcessPlatformOPTIONResponse> loginProcessPlatformOPTIONResponseTask = callClient.LoginProcessPlatformOPTIONAsync( new LoginProcessPlatformOPTIONRequest( userID, userPassword, (int)Syntec.Meta.ICTPlatform.GEM ) );

			LoginProcessPlatformOPTIONResponse response = loginProcessPlatformOPTIONResponseTask.Result;

			string result = response.LoginProcessPlatformOPTIONResult;

			return result;
		}

		#endregion Internal Methods

		#region Private Fields

		private BarcodeDBManager m_barcodeDBManager = new BarcodeDBManager();
		private UserDBManager m_userDBManager = new UserDBManager();
		private string userID;

		private string userPassword;

		#endregion Private Fields

		#region Private Methods

		private JObject IdentityHandler( JObject loginResult )
		{
			JObject result = new JObject();
			//若登入不成功
			if( !loginResult.ContainsKey( "0000" ) )
				return null;

			//取得json From的值 => 從內部orOption的身分登入
			JToken loginSourse = null;
			if( !loginResult.TryGetValue( "From", out loginSourse ) )
				return null;

			switch( loginSourse.ToString() )
			{
				//機械廠或機械廠子帳號
				case "Option":
					result.Add( "orgCode", (int)SyntecOrganizationList.Machine_Manufacturer );
					string characterCode;
					if( m_userDBManager.IsOptionUserMother( userID ) == true )
						characterCode = SyntecOrganizationList.Machine_Manufacturer.GetDescriptionText();
					else
						characterCode = SyntecOrganizationList.Machine_Manufacturer_Branch.GetDescriptionText();

					result.Add( nameof( characterCode ), characterCode );

					break;

				//新代內部
				case "SYNTECINSIDE":
					//取得組織代碼
					JToken orgID = null;
					if( !loginResult.TryGetValue( "Org", out orgID ) )
						return null;
					else
					{
						//取得資料庫的orgType 並 cast 成 enum
						string orgType = m_barcodeDBManager.GetOrgTypeByOrgID( orgID.ToString() );
						SyntecOrganizationList org = (SyntecOrganizationList)Int32.Parse( orgType );

						result.Add( "orgCode", (int)org );
						result.Add( "characterCode", org.GetDescriptionText() );
					}

					break;

				default:
					return null;
			}

			return result;
		}

		#endregion Private Methods
	}
}
