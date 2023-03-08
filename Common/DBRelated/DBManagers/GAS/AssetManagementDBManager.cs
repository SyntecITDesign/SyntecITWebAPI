using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.AssetManagement;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class AssetManagementDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public AssetManagementDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}

		internal bool InsertAssetInfo(InsertAssetInfo InsertAssetInfoParameter)
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[AssetManagement]([AssetNo],[AssetName],[Spec],[AssetType],[Property],[GetDate],[GetCost],[Quantity],[ManagerID],[CostCenter],[Storage],[FirmName],[FirmTel],[FirmContactWindow])
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
				InsertAssetInfoParameter.AssetManagementQuantity,
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
			string sql = $@"DELETE [{m_gas}].[dbo].[AssetManagement]
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
				DeleteAssetInfoParameter.AssetManagementQuantity,
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
			string sql = $@"UPDATE [{m_gas}].[dbo].[AssetManagement]
							set [AssetName]=@Parameter1,[Spec]=@Parameter2,[GetDate]=@Parameter5,[GetCost]=@Parameter6,[Quantity]=@Parameter7,[ManagerID]=@Parameter8,[CostCenter]=@Parameter9,[Storage]=@Parameter10,[FirmName]=@Parameter11,[FirmTel]=@Parameter12,[FirmContactWindow]=@Parameter13, [Memo]=@Parameter14, [IsScrap]=@Parameter15, [SAPNo]=@Parameter16, [PRNo]=@Parameter17, [PONo]=@Parameter18, [Branch]=@Parameter20, [State]=@Parameter21
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
				UpdateAssetInfoParameter.AssetManagementQuantity,
				UpdateAssetInfoParameter.AssetManagementManagerID,
				UpdateAssetInfoParameter.AssetManagementCostCenter,
				UpdateAssetInfoParameter.AssetManagementStorage,
				UpdateAssetInfoParameter.AssetManagementFirmName,
				UpdateAssetInfoParameter.AssetManagementFirmTel,
				UpdateAssetInfoParameter.AssetManagementFirmContactWindow,
				UpdateAssetInfoParameter.AssetManagementMemo,
				UpdateAssetInfoParameter.AssetManagementIsScrap,
				UpdateAssetInfoParameter.AssetManagementSAPNo,
				UpdateAssetInfoParameter.AssetManagementPRNo,
				UpdateAssetInfoParameter.AssetManagementPONo,
				UpdateAssetInfoParameter.AssetManagementLimit,
				UpdateAssetInfoParameter.AssetManagementBranch,
				UpdateAssetInfoParameter.AssetManagementState

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal DataTable GetAssetInfo(GetAssetInfo GetAssetInfoParameter)
		{
			string sql = $@"SELECT Asset.[AssetNo],Asset.[AssetName]
							  ,Asset.[Spec],Asset.[AssetType]
							  ,Asset.[Property],Asset.[GetDate]
							  ,Asset.[GetCost],Asset.[Quantity]
							  ,Asset.[ManagerID],Asset.[CostCenter]
							  ,Asset.[Storage],Asset.[FirmName]
							  ,Asset.[FirmTel],Asset.[FirmContactWindow]
							  ,Asset.[Memo],Asset.[IsScrap]
							  ,Asset.[SAPNo],Asset.[PRNo]
							  ,Asset.[PONo],Asset.[Limit],Asset.[Branch]
							  ,Emp.EmpName,Emp.DeptName
							  ,Asset.[EquipmentNo],Asset.[LicenceAccount],Asset.[State],Asset.[Warranty],Asset.[Status]
						  FROM [{m_gas}].[dbo].[AssetManagement] as Asset
						  left join [syntecbarcode].[dbo].[TEMP_NAME] as Emp
						  on Emp.EmpID COLLATE Chinese_Taiwan_Stroke_CI_AS =Asset.ManagerID COLLATE Chinese_Taiwan_Stroke_CI_AS
						WHERE Asset.[AssetNo] LIKE @Parameter0 or Asset.[EquipmentNo] LIKE @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				GetAssetInfoParameter.AssetManagementAssetNo,
				GetAssetInfoParameter.AssetManagementAssetName,
				GetAssetInfoParameter.AssetManagementSpec,
				GetAssetInfoParameter.AssetManagementaAsetType,
				GetAssetInfoParameter.AssetManagementProperty,
				GetAssetInfoParameter.AssetManagementGetDate,
				GetAssetInfoParameter.AssetManagementGetCost,
				GetAssetInfoParameter.AssetManagementQuantity,
				GetAssetInfoParameter.AssetManagementManagerID,
				GetAssetInfoParameter.AssetManagementCostCenter,
				GetAssetInfoParameter.AssetManagementStorage,
				GetAssetInfoParameter.AssetManagementFirmName,
				GetAssetInfoParameter.AssetManagementFirmTel,
				GetAssetInfoParameter.AssetManagementFirmContactWindow,
				GetAssetInfoParameter.AssetManagementWarranty,
				GetAssetInfoParameter.AssetManagementStatus
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
		
		internal bool UpdateITInfo( UpdateITInfo UpdateITInfoParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[AssetManagement]
							set [Warranty]=@Parameter5,[EquipmentNo]=@Parameter2,[LicenceAccount]=@Parameter3,[Status]=@Parameter6
							where [AssetNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateITInfoParameter.AssetManagementAssetNo,
				UpdateITInfoParameter.AssetManagementLimit,
				UpdateITInfoParameter.AssetManagementEquipmentNo,
				UpdateITInfoParameter.AssetManagementLicenceAccount,
				UpdateITInfoParameter.AssetManagementState,
				UpdateITInfoParameter.AssetManagementWarranty,
				UpdateITInfoParameter.AssetManagementStatus
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}


		internal bool InsertAssetSpecList( InsertAssetSpecList InsertAssetSpecListParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[AssetSpecList]([Usage],[No],[Name])
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
			string sql = $@"DELETE [{m_gas}].[dbo].[AssetSpecList]
								where [ID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteAssetSpecListParameter.AssetSpecListID,
				DeleteAssetSpecListParameter.AssetSpecListUsage,
				DeleteAssetSpecListParameter.AssetSpecListNo,
				DeleteAssetSpecListParameter.AssetSpecListName
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateAssetSpecList( UpdateAssetSpecList UpdateAssetSpecListParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[AssetSpecList]
							set [Name]=@Parameter3
							where [ID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateAssetSpecListParameter.AssetSpecListID,
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
						FROM [{m_gas}].[dbo].[AssetSpecList]
						WHERE [Usage] LIKE @Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				GetAssetSpecListParameter.AssetSpecListID,
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

		internal bool InsertAssetInventory( InsertAssetInventory InsertAssetInventoryParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[AssetInventory]([AssetNo],[AssetName],[Quantity],[ManagerID],[CostCenter],[Storage],[Memo],[CheckID])
								VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter7)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertAssetInventoryParameter.AssetInventoryAssetNo,
				InsertAssetInventoryParameter.AssetInventoryAssetName,
				InsertAssetInventoryParameter.AssetInventoryQuantity,
				InsertAssetInventoryParameter.AssetInventoryManagerID,
				InsertAssetInventoryParameter.AssetInventoryCostCenter,
				InsertAssetInventoryParameter.AssetInventoryStorage,
				InsertAssetInventoryParameter.AssetInventoryMemo,
				InsertAssetInventoryParameter.AssetInventoryCheckID

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteAssetInventory( DeleteAssetInventory DeleteAssetInventoryParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[AssetInventory]
								where [AssetNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteAssetInventoryParameter.AssetInventoryAssetNo,
				DeleteAssetInventoryParameter.AssetInventoryAssetName,
				DeleteAssetInventoryParameter.AssetInventoryQuantity,
				DeleteAssetInventoryParameter.AssetInventoryManagerID,
				DeleteAssetInventoryParameter.AssetInventoryCostCenter,
				DeleteAssetInventoryParameter.AssetInventoryStorage,
				DeleteAssetInventoryParameter.AssetInventoryMemo,
				DeleteAssetInventoryParameter.AssetInventoryCheckID

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateAssetInventory( UpdateAssetInventory UpdateAssetInventoryParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[AssetInventory]
							set [AssetName]=@Parameter1,[Quantity]=@Parameter2,[ManagerID]=@Parameter3,[CostCenter]=@Parameter4,[Storage]=@Parameter5,[Memo]=@Parameter6,[CheckID]=@Parameter7
							where [AssetNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateAssetInventoryParameter.AssetInventoryAssetNo,
				UpdateAssetInventoryParameter.AssetInventoryAssetName,
				UpdateAssetInventoryParameter.AssetInventoryQuantity,
				UpdateAssetInventoryParameter.AssetInventoryManagerID,
				UpdateAssetInventoryParameter.AssetInventoryCostCenter,
				UpdateAssetInventoryParameter.AssetInventoryStorage,
				UpdateAssetInventoryParameter.AssetInventoryMemo,
				UpdateAssetInventoryParameter.AssetInventoryCheckID

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetAssetInventory( GetAssetInventory GetAssetInventoryParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[AssetInventory]
						WHERE [AssetNo] LIKE @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				GetAssetInventoryParameter.AssetInventoryAssetNo,
				GetAssetInventoryParameter.AssetInventoryAssetName,
				GetAssetInventoryParameter.AssetInventoryQuantity,
				GetAssetInventoryParameter.AssetInventoryManagerID,
				GetAssetInventoryParameter.AssetInventoryCostCenter,
				GetAssetInventoryParameter.AssetInventoryStorage,
				GetAssetInventoryParameter.AssetInventoryMemo,
				GetAssetInventoryParameter.AssetInventoryCheckID
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

		internal bool InsertAssetLogTable( InsertAssetLogTable InsertAssetLogTableParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[AssetLogTable]([AssetNo],[EmpID],[ChangeDate],[Before],[After],[Memo])
						    VALUES (@Parameter1, @Parameter2, @Parameter4, @Parameter5, @Parameter6, @Parameter7)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertAssetLogTableParameter.AssetLogTableLogNo,
				InsertAssetLogTableParameter.AssetLogTableAssetNo,
				InsertAssetLogTableParameter.AssetLogTableEmpID,
				InsertAssetLogTableParameter.AssetLogTableEmpName,
				InsertAssetLogTableParameter.AssetLogTableChangeDate,
				InsertAssetLogTableParameter.AssetLogTableBefore,
				InsertAssetLogTableParameter.AssetLogTableAfter,
				InsertAssetLogTableParameter.AssetLogTableMemo

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetAssetLogTable( GetAssetLogTable GetAssetLogTableParameter )
		{
			string sql = $@"SELECT [LogNo],[AssetNo],[AssetLogTable].[EmpID],Emp.EmpName,[ChangeDate]
							,[Before],[After],[Memo]
							FROM [{m_gas}].[dbo].[AssetLogTable]
							inner join [syntecbarcode].[dbo].[TEMP_NAME] as Emp
							on Emp.EmpID COLLATE Chinese_Taiwan_Stroke_CI_AS =AssetLogTable.EmpID COLLATE Chinese_Taiwan_Stroke_CI_AS
							WHERE [AssetNo] LIKE @Parameter1
							Order by [LogNo] desc";
			List<object> SQLParameterList = new List<object>()
			{
				GetAssetLogTableParameter.AssetLogTableLogNo,
				GetAssetLogTableParameter.AssetLogTableAssetNo,
				GetAssetLogTableParameter.AssetLogTableEmpID,
				GetAssetLogTableParameter.AssetLogTableEmpName,
				GetAssetLogTableParameter.AssetLogTableChangeDate,
				GetAssetLogTableParameter.AssetLogTableBefore,
				GetAssetLogTableParameter.AssetLogTableAfter,
				GetAssetLogTableParameter.AssetLogTableMemo
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
