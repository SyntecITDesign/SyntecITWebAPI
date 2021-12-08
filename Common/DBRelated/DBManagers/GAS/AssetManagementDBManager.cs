using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.AssetManagement;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class AssetManagementDBManager : AbstractDBManager
	{
		#region Internal Methods

		internal bool InsertAssetInfo(InsertAssetInfo InsertAssetInfoParameter)
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[AssetManagement]([AssetNo],[AssetName],[Spec],[AssetType],[Property],[GetDate],[GetCost],[Durability],[ManagerID],[CostCenter],[Storage],[FirmName],[FirmTel],[FirmContactWindow])
								VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter7, @Parameter8, @Parameter9, @Parameter10, @Parameter11, @Parameter12, @Parameter13)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertAssetInfoParameter.AssetManagementAssetNo,
				InsertAssetInfoParameter.AssetManagementAssetName,
				InsertAssetInfoParameter.AssetManagementSpec,
				InsertAssetInfoParameter.AssetManagementaAsetType,
				InsertAssetInfoParameter.AssetManagementProperty,
				InsertAssetInfoParameter.AssetManagementGetDate,
				InsertAssetInfoParameter.AssetManagementGetCost,
				InsertAssetInfoParameter.AssetManagementDurability,
				InsertAssetInfoParameter.AssetManagementManagerID,
				InsertAssetInfoParameter.AssetManagementCostCenter,
				InsertAssetInfoParameter.AssetManagementStorage,
				InsertAssetInfoParameter.AssetManagementFirmName,
				InsertAssetInfoParameter.AssetManagementFirmTel,
				InsertAssetInfoParameter.AssetManagementFirmContactWindow

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool DeleteAssetInfo(DeleteAssetInfo DeleteAssetInfoParameter)
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[AssetManagement]
								where [AssetNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteAssetInfoParameter.AssetManagementAssetNo,
				DeleteAssetInfoParameter.AssetManagementAssetName,
				DeleteAssetInfoParameter.AssetManagementSpec,
				DeleteAssetInfoParameter.AssetManagementaAsetType,
				DeleteAssetInfoParameter.AssetManagementProperty,
				DeleteAssetInfoParameter.AssetManagementGetDate,
				DeleteAssetInfoParameter.AssetManagementGetCost,
				DeleteAssetInfoParameter.AssetManagementDurability,
				DeleteAssetInfoParameter.AssetManagementManagerID,
				DeleteAssetInfoParameter.AssetManagementCostCenter,
				DeleteAssetInfoParameter.AssetManagementStorage,
				DeleteAssetInfoParameter.AssetManagementFirmName,
				DeleteAssetInfoParameter.AssetManagementFirmTel,
				DeleteAssetInfoParameter.AssetManagementFirmContactWindow

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool UpdateAssetInfo(UpdateAssetInfo UpdateAssetInfoParameter)
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[AssetManagement]
							set [AssetName]=@Parameter1,[Spec]=@Parameter2,[AssetType]=@Parameter3,[Property]=@Parameter4,[GetDate]=@Parameter5,[GetCost]=@Parameter6,[Durability]=@Parameter7,[ManagerID]=@Parameter8,[CostCenter]=@Parameter9,[Storage]=@Parameter10,[FirmName]=@Parameter11,[FirmTel]=@Parameter12,[FirmContactWindow]=@Parameter13, [Memo]=@Parameter14, [IsScrap]=@Parameter15
							where [AssetNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateAssetInfoParameter.AssetManagementAssetNo,
				UpdateAssetInfoParameter.AssetManagementAssetName,
				UpdateAssetInfoParameter.AssetManagementSpec,
				UpdateAssetInfoParameter.AssetManagementaAsetType,
				UpdateAssetInfoParameter.AssetManagementProperty,
				UpdateAssetInfoParameter.AssetManagementGetDate,
				UpdateAssetInfoParameter.AssetManagementGetCost,
				UpdateAssetInfoParameter.AssetManagementDurability,
				UpdateAssetInfoParameter.AssetManagementManagerID,
				UpdateAssetInfoParameter.AssetManagementCostCenter,
				UpdateAssetInfoParameter.AssetManagementStorage,
				UpdateAssetInfoParameter.AssetManagementFirmName,
				UpdateAssetInfoParameter.AssetManagementFirmTel,
				UpdateAssetInfoParameter.AssetManagementFirmContactWindow,
				UpdateAssetInfoParameter.AssetManagementMemo,
				UpdateAssetInfoParameter.AssetManagementIsScrap

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal DataTable GetAssetInfo(GetAssetInfo GetAssetInfoParameter)
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[AssetManagement]
						WHERE [AssetNo] LIKE @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				GetAssetInfoParameter.AssetManagementAssetNo,
				GetAssetInfoParameter.AssetManagementAssetName,
				GetAssetInfoParameter.AssetManagementSpec,
				GetAssetInfoParameter.AssetManagementaAsetType,
				GetAssetInfoParameter.AssetManagementProperty,
				GetAssetInfoParameter.AssetManagementGetDate,
				GetAssetInfoParameter.AssetManagementGetCost,
				GetAssetInfoParameter.AssetManagementDurability,
				GetAssetInfoParameter.AssetManagementManagerID,
				GetAssetInfoParameter.AssetManagementCostCenter,
				GetAssetInfoParameter.AssetManagementStorage,
				GetAssetInfoParameter.AssetManagementFirmName,
				GetAssetInfoParameter.AssetManagementFirmTel,
				GetAssetInfoParameter.AssetManagementFirmContactWindow
			};
			DataTable result = m_dbproxy.GetDataCMD(sql, SQLParameterList.ToArray());
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if (result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool InsertAssetSpecList( InsertAssetSpecList InsertAssetSpecListParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[AssetSpecList]([Usage],[No],[Name])
								VALUES (@Parameter0, @Parameter1, @Parameter2)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertAssetSpecListParameter.AssetSpecListUsage,
				InsertAssetSpecListParameter.AssetSpecListNo,
				InsertAssetSpecListParameter.AssetSpecListName
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteAssetSpecList( DeleteAssetSpecList DeleteAssetSpecListParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[AssetSpecList]
								where [Usage]=@Parameter0 AND [No]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteAssetSpecListParameter.AssetSpecListUsage,
				DeleteAssetSpecListParameter.AssetSpecListNo,
				DeleteAssetSpecListParameter.AssetSpecListName
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateAssetSpecList( UpdateAssetSpecList UpdateAssetSpecListParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[AssetSpecList]
							set [Name]=@Parameter2
							where [Usage]=@Parameter0 AND [No]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateAssetSpecListParameter.AssetSpecListUsage,
				UpdateAssetSpecListParameter.AssetSpecListNo,
				UpdateAssetSpecListParameter.AssetSpecListName
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetAssetSpecList( GetAssetSpecList GetAssetSpecListParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[AssetSpecList]
						WHERE [Usage] LIKE @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				GetAssetSpecListParameter.AssetSpecListUsage,
				GetAssetSpecListParameter.AssetSpecListNo,
				GetAssetSpecListParameter.AssetSpecListName
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

	}
	#endregion Internal Methods
}
