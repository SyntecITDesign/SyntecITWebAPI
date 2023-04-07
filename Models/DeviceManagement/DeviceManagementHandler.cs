using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.ParameterModels.DeviceManangement;
using SyntecITWebAPI.ParameterModels.DeviceManangement.CRMRepairList.Return;
using SyntecITWebAPI.ParameterModels.DeviceManangement.Overview;
using SyntecITWebAPI.ParameterModels.DeviceManangement.Overview.Return;
using SyntecITWebAPI.ParameterModels.DeviceManangement.RegAnalysis.Return;
using SyntecITWebAPI.ParameterModels.DeviceManangement.RegInfo;
using SyntecITWebAPI.Static;
using SyntecITWebAPI.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TQMLibrary;

namespace SyntecITWebAPI.Models.DeviceManagement
{
	public class DeviceManagementHandler
	{
		#region Internal Methods

		internal JObject CNCBackupDownload( CNCBackupDownloadParameter parameter )
		{
			//回傳格式 : ErrorCodeList,content
			JObject result = new JObject();
			SCloudAPIProxy cloudAPIProxy = new SCloudAPIProxy();

			//檢查使用者是否有此CNC的備份權限
			if( IsUserHasCNCRight( parameter.userID, parameter.productSN ) == false )
			{
				result.Add( nameof( ErrorCodeList ), ErrorCodeList.Auth_Error.ToString() );
				return result;
			}

			//取得SCloud Token
			ResponseHandler tokenResult = cloudAPIProxy.TryGetToken( SystemSetting.SCLOUD_FLOW_ACCOUNT, SystemSetting.SCLOUD_FLOW_PASSWORD ).Result;
			JObject tokenJson = ( (JObject)( tokenResult.Content ) );
			JToken cloudAccessToken = null;

			if( tokenResult.Code != ErrorCodeList.Success )
			{
				result.Add( nameof( ErrorCodeList ), tokenResult.Code.ToString() );
				return result;
			}
			else
			{
				if( tokenJson.TryGetValue( "access_token", out cloudAccessToken ) == false )
				{
					result.Add( nameof( ErrorCodeList ), ErrorCodeList.API_Internet_Error.ToString() );
					return result;
				}
				else
				{
					if( string.IsNullOrEmpty( cloudAccessToken.ToString() ) )
					{
						result.Add( nameof( ErrorCodeList ), ErrorCodeList.API_Internet_Error.ToString() );
						return result;
					}
				}
			}
			//使用SCloud 的 Parameter Call 下載CNC backup API
			Stream downloadResult = cloudAPIProxy.TryDownloadFileStream( parameter, cloudAccessToken.ToString() ).Result;

			if( downloadResult is null )
			{
				result.Add( nameof( ErrorCodeList ), ErrorCodeList.API_Internet_Error.ToString() );
				return result;
			}
			else
			{
				result.Add( nameof( ErrorCodeList ), ErrorCodeList.Success.ToString() );
				
				return result;
			}
		}

		internal JObject CNCBackupList( BackupListParameter parameter )
		{
			//回傳格式 : ErrorCodeList,content
			JObject result = new JObject();
			SCloudAPIProxy cloudAPIProxy = new SCloudAPIProxy();

			//檢查使用者是否有此CNC的備份權限
			if( IsUserHasCNCRight( parameter.userID, parameter.productSN ) == false )
			{
				result.Add( nameof( ErrorCodeList ), ErrorCodeList.Auth_Error.ToString() );
				return result;
			}

			//取得SCloud Token
			ResponseHandler tokenResult = cloudAPIProxy.TryGetToken( SystemSetting.SCLOUD_FLOW_ACCOUNT, SystemSetting.SCLOUD_FLOW_PASSWORD ).Result;
			JObject tokenJson = ( (JObject)( tokenResult.Content ) );
			JToken cloudAccessToken = null;

			if( tokenResult.Code != ErrorCodeList.Success )
			{
				result.Add( nameof( ErrorCodeList ), tokenResult.Code.ToString() );
				return result;
			}
			else
			{
				if( tokenJson.TryGetValue( "access_token", out cloudAccessToken ) == false )
				{
					result.Add( nameof( ErrorCodeList ), ErrorCodeList.API_Internet_Error.ToString() );
					return result;
				}
				else
				{
					if( string.IsNullOrEmpty( cloudAccessToken.ToString() ) )
					{
						result.Add( nameof( ErrorCodeList ), ErrorCodeList.API_Internet_Error.ToString() );
						return result;
					}
				}
			}

			//使用SCloud 的 Parameter Call 取得CNC List API
			ResponseHandler getCNCListResult = cloudAPIProxy.TryGetCNCFileList( parameter, cloudAccessToken.ToString() ).Result;
			JObject getCNCListResultJson = ( (JObject)( getCNCListResult.Content ) );
			CNCBackupList backupList = null;
			if( getCNCListResult.Code != ErrorCodeList.Success ) //call api 時就出錯了
			{
				result.Add( nameof( ErrorCodeList ), tokenResult.Code.ToString() );
				return result;
			}
			else
			{
				try //將SCloud api 取得的JObject map 到 CNCBackList物件
				{
					backupList = GetCNCBackupListFromJObject( getCNCListResultJson );
				}
				catch
				{
					result.Add( nameof( ErrorCodeList ), ErrorCodeList.System_Error.ToString() );
					return result;
				}

				//success
				result.Add( nameof( ErrorCodeList ), ErrorCodeList.Success.ToString() );
				result.Add( nameof( result ), JObject.FromObject( backupList ) );
				return result;
			}
		}

		internal JObject GetOverview( OverviewParameter parameter )
		{
			string apiKey = parameter.userID.ITKeyEncode();

			string serviceResult = SNServiceGetSNRegistrationInfoByUser( parameter, apiKey ).Result;

			//檢查Result 是否成功並從回傳Json中取得需要的欄位
			string[] dataColumnNameArray = { "GetSNRegistrationInfoByUser", "Data" };
			JToken dataResult = serviceResult.ParseITJsonResult( dataColumnNameArray );

			string[] totalColumnNameArray = { "GetSNRegistrationInfoByUser", "Total" };
			JToken totalResult = serviceResult.ParseITJsonResult( totalColumnNameArray );

			if( dataResult == null || totalResult == null )//取得欄位值失敗
			{
				return null;
			}
			else
			{
				List<OverviewData> dataList = GetOverviewDatasFromJObject( dataResult.ToObject<List<JObject>>() );
				JObject result = new JObject();
				result.Add( "totalCount", totalResult );
				result.Add( "overviewData", JArray.FromObject( dataList ) );

				return result;
			}
		}

		internal JObject GetSNRegAnalysis( string userID )
		{
			//回傳格式 : ErrorCodeList,content
			JObject result = new JObject();
			string tqmResult = m_productSN.GetSNRegAnalysis( userID );
			JObject tqmResultJson = JObject.Parse( tqmResult );
			string successCode = "0000";

			if( !tqmResultJson.ContainsKey( successCode ) )
			{
				result.Add( ErrorCodeList.API_Internet_Error );
				return result;
			}
			else
			{
				JObject successInfo = (JObject)tqmResultJson.GetValue( successCode );
				if( successInfo.TryGetValue( "GetSNRegAnalysis", out JToken getSNRegAnalysisResult ) )
				{
					JObject regAnalysisInfo = (JObject)getSNRegAnalysisResult;

					RegAnalysisReturnParameter returnParameter = GetRegAnalysisResult( regAnalysisInfo );

					return JObject.FromObject( returnParameter );
				}
				else
				{
					result.Add( ErrorCodeList.System_Error );
					return result;
				}
			}
		}

		internal JObject GetSNRegInfo( string productSN, string userID, SyntecOrganizationList org )
		{
			string machineCode = null;
			//若為機械廠，取機械廠代碼
			if( org.Equals( SyntecOrganizationList.Machine_Manufacturer ) || org.Equals( SyntecOrganizationList.Machine_Manufacturer_Branch ) )
			{
				UserHandler userHandler = new UserHandler();
				JObject machineCodeResult = userHandler.GetMachineCodeByID( userID );

				machineCode = machineCodeResult.GetValue( nameof( machineCode ) ).ToString();
			}

			DataTable tqmResult = m_productSN.GetSNRegistrationInfo( machineCode, productSN );

			//若有取得資料  將從TQM取得的DataTable轉成回傳格式的物件
			SNDataList snDataList = null;
			RegistInfoTableData registInfoTableData = null;
			JObject result = null;
			if( tqmResult.Rows.Count > 0 )
			{
				snDataList = GetSNDataListFromDataTable( tqmResult );
				registInfoTableData = GetRegistInfoFromDataTable( tqmResult, productSN );

				result = new JObject
				{
					{nameof(registInfoTableData), JObject.FromObject( registInfoTableData ) },
					{nameof(snDataList.snTableData), JArray.FromObject( snDataList.snTableData) }
				};
			}
			else
			{
				result = new JObject
				{
					{nameof(registInfoTableData), null },
					{nameof(snDataList.snTableData), null }
				};
			}

			return result;
		}

		internal JObject GetSNRepairList( string userID, string productSN )
		{
			string apiKey = userID.ITKeyEncode();

			string serviceResult = CRMServiceGetCRMListBySN( apiKey, productSN ).Result;

			//檢查Result 是否成功並從回傳Json中取得需要的欄位
			string[] columnNameArray = { "GetCRMListBySN", userID };
			JToken itParseResult = serviceResult.ParseITJsonResult( columnNameArray );
			if( itParseResult == null )//取得欄位值失敗
			{
				return null;
			}
			else
			{
				List<CRMRepairData> dataList = GetCRMRepairDataFromJObject( itParseResult.ToObject<List<JObject>>() );
				JObject result = new JObject();

				result.Add( "repairData", JArray.FromObject( dataList ) );

				return result;
			}
		}

		#endregion Internal Methods

		#region Private Fields

		private static MapperConfiguration m_configuration = AutoMapperConfig.Instance;

		private readonly ProductSN m_productSN = new ProductSN();

		#endregion Private Fields

		#region Private Methods

		private async Task<string> CRMServiceGetCRMListBySN( string apiKey, string productSN )
		{
			//call CRM service GetCRMListBySN Function
			var client = WebServiceSetting.CRM_SERVICE_CLIENT;
			Task<string> task = client.GetCRMListBySNAsync( apiKey, productSN );

			return await task;
		}

		private CNCBackupList GetCNCBackupListFromJObject( JObject apiResult )
		{
			IMapper mapper = m_configuration.CreateMapper();

			CNCBackupList backupList = mapper.Map<JObject, CNCBackupList>( apiResult );

			return backupList;
		}

		private List<CRMRepairData> GetCRMRepairDataFromJObject( List<JObject> apiResult )
		{
			IMapper mapper = m_configuration.CreateMapper();
			List<CRMRepairData> dataList = mapper.Map<List<JObject>, List<CRMRepairData>>( apiResult );
			return dataList;
		}

		private List<OverviewData> GetOverviewDatasFromJObject( List<JObject> apiResult )
		{
			IMapper mapper = m_configuration.CreateMapper();
			List<OverviewData> dataList = mapper.Map<List<JObject>, List<OverviewData>>( apiResult );
			return dataList;
		}

		private List<RegAnalysisCityParameter> GetRegAnalysisCities( List<RegAnalysisMapParameter> mapperResult )
		{
			return mapperResult.SelectMany( a => a.CutomerCitys ).ToList();
		}

		private List<RegAnalysisProvinceParameter> GetRegAnalysisProvinces( List<RegAnalysisMapParameter> mapperResult )
		{
			return mapperResult.Select( a => new RegAnalysisProvinceParameter { ProvinceName = a.ProvinceName, Value = a.Value } ).ToList();
		}

		private RegAnalysisReturnParameter GetRegAnalysisResult( JObject regAnalysisInfo )
		{
			JArray countryData = regAnalysisInfo[ "Map" ].ToObject<JArray>();
			IMapper mapper = m_configuration.CreateMapper();
			RegAnalysisReturnParameter returnParameter = new RegAnalysisReturnParameter();

			//若回傳國家有 CN
			if( countryData.Any( t => t.Value<string>( "CustomerCompanyCountry" ) == "CN" ) )
			{
				// ChinaMapData
				List<JObject> chinaMapData = countryData
					.Where( a => a[ "CustomerCompanyCountry" ].ToString() == "CN" )
					.Select( c => c[ "Children" ] )
					.FirstOrDefault()
					.ToObject<List<JObject>>();

				// 將ChinaData轉為List<RegAnalysisParameter>

				List<RegAnalysisMapParameter> mapResult = mapper.Map<List<JObject>, List<RegAnalysisMapParameter>>( chinaMapData );
				returnParameter.customerProvince = GetRegAnalysisProvinces( mapResult );
				returnParameter.customerCity = GetRegAnalysisCities( mapResult );
			}
			else
			{
				returnParameter.customerProvince = null;
				returnParameter.customerCity = null;
			}

			//Industry
			List<JObject> industryData = regAnalysisInfo[ "Industry" ].ToObject<List<JObject>>();
			List<RegAnalysisIndustryParameter> industryResult = mapper.Map<List<JObject>, List<RegAnalysisIndustryParameter>>( industryData );
			returnParameter.customerIndustry = industryResult;

			return returnParameter;
		}

		// 將DataTable map to registInfoTableData
		private RegistInfoTableData GetRegistInfoFromDataTable( DataTable tqmResult, string productSN )
		{
			DataRow dataRow = tqmResult.Select( $"ProductSN = '{productSN}' " ).First();

			IMapper registMapper = m_configuration.CreateMapper();

			RegistInfoTableData registInfoTableData = registMapper.Map<DataRow, RegistInfoTableData>( dataRow );

			return registInfoTableData;
		}

		// 將DataTable map to snTableData
		private SNDataList GetSNDataListFromDataTable( DataTable tqmResult )
		{
			SNDataList snDataList = new SNDataList();

			IMapper snMapper = m_configuration.CreateMapper();

			List<DataRow> dataRowsList = tqmResult.AsEnumerable().ToList();

			snDataList.snTableData = snMapper.Map<List<DataRow>, List<SNData>>( dataRowsList );

			return snDataList;
		}

		private bool IsUserHasCNCRight( string userID, string productSN )
		{
			//call sn service CheckSNListAvailable Function
			var client = WebServiceSetting.SN_SERVICE_CLIENT;
			Task<string> CheckSNListAvailableTask = client.CheckSNListAvailableAsync( userID, new string[] { productSN } );
			string result = CheckSNListAvailableTask.Result;

			const string WEB_SERVICE_FUNCTION = "CheckSNListAvailable";
			const string IT_SUCCESS_KEY = "0000";
			if( result.IndexOf( IT_SUCCESS_KEY ) < 0 )  //沒有成功呼叫WS
			{
				return false;
			}
			else
			{
				Dictionary<string, object> wsResultDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>( result );
				JObject CompareResult = (JObject)wsResultDictionary[ IT_SUCCESS_KEY ];
				bool[] CompareArray = CompareResult[ WEB_SERVICE_FUNCTION ][ userID ].ToObject<bool[]>();
				if( Array.Exists( CompareArray, element => element == false ) ) // 若回傳權限為false
				{
					return false;
				}
				//回傳權限為true
				else
				{
					return true;
				}
			}
		}

		private async Task<string> SNServiceGetSNRegistrationInfoByUser( OverviewParameter parameter, string apiKey )
		{
			//call sn service GetSNRegistrationInfoByUser Function
			var client = WebServiceSetting.SN_SERVICE_CLIENT;
			Task<string> task = client.GetSNRegistrationInfoByUserAsync(
				apiKey,
				parameter.queryStartTime.ToString(),
				parameter.queryEndTime.ToString(),
				parameter.queryStartIndex.ToString(),
				( (int)parameter.queryType ).ToString(),
				parameter.queryMaxNumber.ToString(),
				parameter.customerName
				);

			return await task;
		}

		#endregion Private Methods
	}
}
