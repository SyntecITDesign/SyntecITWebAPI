using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.CleanMaintain;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class CleanMaintainDBManager : AbstractDBManager
	{
		#region Internal Methods

		internal bool InsertMaintainType( InsertMaintainType InsertMaintainTypeParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MaintainTypeInfo] ([Type])
								VALUES (@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMaintainTypeParameter.MaintainTypeInfoNo,
				InsertMaintainTypeParameter.MaintainTypeInfoName
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteMaintainType( DeleteMaintainType DeleteMaintainTypeParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[MaintainQuantityInfo]
								where [Type]=@Parameter0
								DELETE [SyntecGAS].[dbo].[MaintainTypeInfo]
								where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMaintainTypeParameter.MaintainTypeInfoNo,
				DeleteMaintainTypeParameter.MaintainTypeInfoName

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateMaintainTypeInfo( UpdateMaintainTypeInfo UpdateMaintainTypeInfoParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[MaintainTypeInfo]
							set [Type]=@Parameter1
							where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateMaintainTypeInfoParameter.MaintainTypeInfoNo,
				UpdateMaintainTypeInfoParameter.MaintainTypeInfoName

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetMaintainTypeInfo( GetMaintainTypeInfo GetMaintainTypeInfoParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[MaintainTypeInfo]
						ORDER BY [No]";
			List<object> SQLParameterList = new List<object>()
			{
				GetMaintainTypeInfoParameter.MaintainTypeInfoNo,
				GetMaintainTypeInfoParameter.MaintainTypeInfoName
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool UpsertMaintainQuantityInfo( UpsertMaintainQuantityInfo UpsertMaintainQuantityInfoParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[MaintainQuantityInfo] WHERE [Type]=@Parameter0 and [Items]=@Parameter1)
									UPDATE [SyntecGAS].[dbo].[MaintainQuantityInfo] SET [Type]=@Parameter0, [Items]=@Parameter1,[Quantity]=@Parameter2,[AlertQuantity]=@Parameter3,[Unit]=@Parameter4
									WHERE [Type]=@Parameter0 and [Items]=@Parameter1
									ELSE
									INSERT INTO [SyntecGAS].[dbo].[MaintainQuantityInfo] ([Type], [Items], [Quantity], [AlertQuantity], [Unit])
									VALUES (@Parameter0,@Parameter1, @Parameter2, @Parameter3, @Parameter4)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertMaintainQuantityInfoParameter.MaintainTypeNo,
				UpsertMaintainQuantityInfoParameter.MaintainItems,
				UpsertMaintainQuantityInfoParameter.MaintainQuantity,
				UpsertMaintainQuantityInfoParameter.MaintainAlertQuantity,
				UpsertMaintainQuantityInfoParameter.MaintainUnit
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteMaintainQuantity( DeleteMaintainQuantity DeleteMaintainQuantityParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[MaintainQuantityInfo]
								where [Type]=@Parameter0 and [Items]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMaintainQuantityParameter.MaintainTypeNo,
				DeleteMaintainQuantityParameter.MaintainItems,
				DeleteMaintainQuantityParameter.MaintainQuantity,
				DeleteMaintainQuantityParameter.MaintainAlertQuantity

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetMaintainQuantityInfo( GetMaintainQuantityInfo GetMaintainQuantityInfoParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[MaintainQuantityInfo]
						WHERE [Type]=@Parameter0
						ORDER BY [Type],[Items]";
			List<object> SQLParameterList = new List<object>()
			{
				GetMaintainQuantityInfoParameter.MaintainTypeNo,
				GetMaintainQuantityInfoParameter.MaintainItems,
				GetMaintainQuantityInfoParameter.MaintainQuantity,
				GetMaintainQuantityInfoParameter.MaintainAlertQuantity
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool InsertMaintainOrder( InsertMaintainOrder InsertMaintainOrderParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MaintainOrderList] ([OrderDate],[Usage])
								VALUES (@Parameter1,@Parameter2)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMaintainOrderParameter.MaintainOrderListNo,
				InsertMaintainOrderParameter.MaintainOrderDate,
				InsertMaintainOrderParameter.MaintainUsage
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool InsertMaintainOrderListDetail( InsertMaintainOrderListDetail InsertMaintainOrderListDetailParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MaintainOrderListDetail] ([OrderList],[Type],[Items],[Price],[Quantity])
								VALUES (@Parameter0,@Parameter1, @Parameter2, @Parameter3, @Parameter4)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMaintainOrderListDetailParameter.MaintainOrderListNo,
				InsertMaintainOrderListDetailParameter.MaintainTypeNo,
				InsertMaintainOrderListDetailParameter.MaintainItems,
				InsertMaintainOrderListDetailParameter.MaintainOrderPrice,
				InsertMaintainOrderListDetailParameter.MaintainQuantity
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetMaintainOrderList( GetMaintainOrderList GetMaintainOrderListParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[MaintainOrderList]
						WHERE [No] LIKE @Parameter0 and [Ok]=0
						ORDER BY [OrderDate] DESC,[No] DESC";
			List<object> SQLParameterList = new List<object>()
			{
				GetMaintainOrderListParameter.MaintainOrderListNo,
				GetMaintainOrderListParameter.MaintainOrderDate,
				GetMaintainOrderListParameter.MaintainOk
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal DataTable GetMaintainOrderListDetail( GetMaintainOrderListDetail GetMaintainOrderListDetailParameter )
		{
			string sql = $@"SELECT *
							  FROM [SyntecGAS].[dbo].[MaintainOrderListDetail]
							  INNER JOIN (SELECT [MaintainTypeInfo].[Type] as 'TypeName',[MaintainQuantityInfo].[AlertQuantity], [MaintainTypeInfo].[No],[MaintainQuantityInfo].[Items],[MaintainQuantityInfo].[Quantity] as 'QuantitySoFar',[MaintainQuantityInfo].[Unit]
															  FROM[SyntecGAS].[dbo].[MaintainTypeInfo]
															  INNER JOIN[SyntecGAS].[dbo].[MaintainQuantityInfo]
															  ON[MaintainTypeInfo].[No] =[MaintainQuantityInfo].[Type]) as MaintainInfo
							  ON[MaintainOrderListDetail].[Type] = MaintainInfo.[No] and [MaintainOrderListDetail].[Items]=MaintainInfo.[Items]";
			List<object> SQLParameterList = new List<object>()
			{
				GetMaintainOrderListDetailParameter.MaintainOrderListNo,
				GetMaintainOrderListDetailParameter.MaintainTypeNo,
				GetMaintainOrderListDetailParameter.MaintainItems,
				GetMaintainOrderListDetailParameter.MaintainOrderPrice,
				GetMaintainOrderListDetailParameter.MaintainQuantity
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal bool DeleteMaintainOrder( DeleteMaintainOrder DeleteMaintainOrderParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[MaintainOrderListDetail] WHERE [OrderList]=@Parameter0;
								   DELETE [SyntecGAS].[dbo].[MaintainOrderList] WHERE [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMaintainOrderParameter.MaintainOrderListNo,
				DeleteMaintainOrderParameter.MaintainOrderDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateMaintainOrder( UpdateMaintainOrder UpdateMaintainOrderParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[MaintainOrderList]
							set [Ok]=@Parameter2
							where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateMaintainOrderParameter.MaintainOrderListNo,
				UpdateMaintainOrderParameter.MaintainOrderDate,
				UpdateMaintainOrderParameter.MaintainOk

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool InsertCleanFirm( InsertCleanFirm InsertCleanFirmParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[CleanFirmInfo] ([Firm], [Name], [Fax], [Tel], [TaxID],[Address])
								VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertCleanFirmParameter.CleanFirmInfoNo,
				InsertCleanFirmParameter.CleanFirmInfoFirm,
				InsertCleanFirmParameter.CleanFirmInfoName,
				InsertCleanFirmParameter.CleanFirmInfoFax,
				InsertCleanFirmParameter.CleanFirmInfoTel,
				InsertCleanFirmParameter.CleanFirmInfoTaxID,
				InsertCleanFirmParameter.CleanFirmInfoAddress
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteCleanFirm( DeleteCleanFirm DeleteCleanFirmParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[CleanFirmInfo]
								where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteCleanFirmParameter.CleanFirmInfoNo,
				DeleteCleanFirmParameter.CleanFirmInfoFirm,
				DeleteCleanFirmParameter.CleanFirmInfoName,
				DeleteCleanFirmParameter.CleanFirmInfoFax,
				DeleteCleanFirmParameter.CleanFirmInfoTel,
				DeleteCleanFirmParameter.CleanFirmInfoTaxID,
				DeleteCleanFirmParameter.CleanFirmInfoAddress
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateCleanFirmInfo( UpdateCleanFirmInfo UpdateCleanFirmInfoParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[CleanFirmInfo]
							set [Firm]=@Parameter1, [Name]=@Parameter2, [Fax]=@Parameter3,[Tel]=@Parameter4, [TaxID]=@Parameter5, [Address]=@Parameter6
							where No=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				UpdateCleanFirmInfoParameter.CleanFirmInfoNo,
				UpdateCleanFirmInfoParameter.CleanFirmInfoFirm,
				UpdateCleanFirmInfoParameter.CleanFirmInfoName,
				UpdateCleanFirmInfoParameter.CleanFirmInfoFax,
				UpdateCleanFirmInfoParameter.CleanFirmInfoTel,
				UpdateCleanFirmInfoParameter.CleanFirmInfoTaxID,
				UpdateCleanFirmInfoParameter.CleanFirmInfoAddress
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetCleanFirmInfo( GetCleanFirmInfo GetCleanFirmInfoParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[CleanFirmInfo]
						ORDER BY [No]";
			List<object> SQLParameterList = new List<object>()
			{
				GetCleanFirmInfoParameter.CleanFirmInfoNo,
				GetCleanFirmInfoParameter.CleanFirmInfoFirm,
				GetCleanFirmInfoParameter.CleanFirmInfoName,
				GetCleanFirmInfoParameter.CleanFirmInfoFax,
				GetCleanFirmInfoParameter.CleanFirmInfoTel,
				GetCleanFirmInfoParameter.CleanFirmInfoTaxID,
				GetCleanFirmInfoParameter.CleanFirmInfoAddress
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetCleanStaffType( GetCleanStaffType GetCleanStaffTypeParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[CleanStaffType]
						ORDER BY [No]";

			List<object> SQLParameterList = new List<object>()
			{
				GetCleanStaffTypeParameter.CleanStaffTypeNo,
				GetCleanStaffTypeParameter.CleanStaffType
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal bool InsertCleanStaffType( InsertCleanStaffType InsertCleanStaffTypeParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[CleanStaffType] ([Type])
								VALUES (@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertCleanStaffTypeParameter.CleanStaffTypeNo,
				InsertCleanStaffTypeParameter.CleanStaffType
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteCleanStaffType( DeleteCleanStaffType DeleteCleanStaffTypeParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[AreaInfo]
								where [AreaNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteCleanStaffTypeParameter.CleanStaffTypeNo,
				DeleteCleanStaffTypeParameter.CleanStaffType
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateCleanStaffType( UpdateCleanStaffType UpdateCleanStaffTypeParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[CleanStaffType]
							set [Type]=@Parameter1
							where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateCleanStaffTypeParameter.CleanStaffTypeNo,
				UpdateCleanStaffTypeParameter.CleanStaffType
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
	}
	#endregion Internal Methods
}
