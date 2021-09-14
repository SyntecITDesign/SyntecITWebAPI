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
									WHERE [Type]=@Parameter0 and [Items]=@Parameter1 and [Unit]=@Parameter4
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
			string sql = $@"SELECT [MaintainQuantityInfo].[Type],[MaintainQuantityInfo].[Items],[MaintainQuantityInfo].[Quantity],[MaintainQuantityInfo].[AlertQuantity],[MaintainQuantityInfo].[Unit],[MaintainTypeInfo].[Type] as 'TypeName'
									FROM [SyntecGAS].[dbo].[MaintainQuantityInfo]
									INNER JOIN[SyntecGAS].[dbo].[MaintainTypeInfo]
									ON[MaintainQuantityInfo].[Type] =[MaintainTypeInfo].[No]
									WHERE [MaintainQuantityInfo].[Type] like @Parameter0
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
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MaintainOrderList] ([OrderDate],[Usage],[Memo])
								VALUES (@Parameter1,@Parameter2,@Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMaintainOrderParameter.MaintainOrderListNo,
				InsertMaintainOrderParameter.MaintainOrderDate,
				InsertMaintainOrderParameter.MaintainUsage,
				InsertMaintainOrderParameter.MaintainMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool InsertMaintainOrderListDetail( InsertMaintainOrderListDetail InsertMaintainOrderListDetailParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MaintainOrderListDetail] ([OrderList],[Type],[Items],[Price],[Quantity],[Unit])
								VALUES (@Parameter0,@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMaintainOrderListDetailParameter.MaintainOrderListNo,
				InsertMaintainOrderListDetailParameter.MaintainTypeNo,
				InsertMaintainOrderListDetailParameter.MaintainItems,
				InsertMaintainOrderListDetailParameter.MaintainOrderPrice,
				InsertMaintainOrderListDetailParameter.MaintainQuantity,
				InsertMaintainOrderListDetailParameter.MaintainUnit
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
							  INNER JOIN (SELECT [MaintainTypeInfo].[Type] as 'TypeName',[MaintainQuantityInfo].[AlertQuantity], [MaintainTypeInfo].[No],[MaintainQuantityInfo].[Items],[MaintainQuantityInfo].[Quantity] as 'QuantitySoFar'
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
							set [Ok]=@Parameter2, [Memo]=@Parameter3
							where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateMaintainOrderParameter.MaintainOrderListNo,
				UpdateMaintainOrderParameter.MaintainOrderDate,
				UpdateMaintainOrderParameter.MaintainOk,
				UpdateMaintainOrderParameter.MaintainMemo

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
				GetCleanStaffTypeParameter.CleanStaffType,
				GetCleanStaffTypeParameter.CleanStaffColor
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
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[CleanStaffType] ([Type],[Color])
								VALUES (@Parameter1,@Parameter2)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertCleanStaffTypeParameter.CleanStaffTypeNo,
				InsertCleanStaffTypeParameter.CleanStaffType,
				InsertCleanStaffTypeParameter.CleanStaffColor
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteCleanStaffType( DeleteCleanStaffType DeleteCleanStaffTypeParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[CleanStaffType]
								where [No]=@Parameter0";
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
							set [Type]=@Parameter1,[Color]=@Parameter2
							where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateCleanStaffTypeParameter.CleanStaffTypeNo,
				UpdateCleanStaffTypeParameter.CleanStaffType,
				UpdateCleanStaffTypeParameter.CleanStaffColor
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCleanAreaPlan( GetCleanAreaPlan GetCleanAreaPlanParameter )
		{
			string sql = $@"SELECT [CleanAreaPlan].*,[CleanAreaInfo].[Color]
									FROM [SyntecGAS].[dbo].[CleanAreaPlan]
									left JOIN[SyntecGAS].[dbo].[CleanAreaInfo]
									ON [CleanAreaInfo].[AreaNo] =[CleanAreaPlan].[AreaPlan]
									WHERE [Floor] Like @Parameter3 and [AreaPlan] <> 0
									ORDER BY [Yaxis],[Xaxis],[Floor]";

			List<object> SQLParameterList = new List<object>()
			{
				GetCleanAreaPlanParameter.CleanAreaPlanXaxis,
				GetCleanAreaPlanParameter.CleanAreaPlanYaxis,
				GetCleanAreaPlanParameter.CleanAreaPlanAreaPlan,
				GetCleanAreaPlanParameter.CleanAreaPlanFloor
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
		internal bool InsertCleanAreaPlan( InsertCleanAreaPlan InsertCleanAreaPlanParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[CleanAreaPlan] ([Xaxis], [Yaxis], [AreaPlan], [Floor])
								VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertCleanAreaPlanParameter.CleanAreaPlanXaxis,
				InsertCleanAreaPlanParameter.CleanAreaPlanYaxis,
				InsertCleanAreaPlanParameter.CleanAreaPlanAreaPlan,
				InsertCleanAreaPlanParameter.CleanAreaPlanFloor
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteCleanAreaPlan( DeleteCleanAreaPlan DeleteCleanAreaPlanParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[CleanAreaPlan]
								where [Xaxis]=@Parameter0 and [Yaxis]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteCleanAreaPlanParameter.CleanAreaPlanXaxis,
				DeleteCleanAreaPlanParameter.CleanAreaPlanYaxis,
				DeleteCleanAreaPlanParameter.CleanAreaPlanAreaPlan
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateCleanAreaPlan( UpdateCleanAreaPlan UpdateCleanAreaPlanParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[CleanAreaPlan]
							set [AreaPlan]=@Parameter2
							where [Xaxis]=@Parameter0 and [Yaxis]=@Parameter1 and [Floor]=@Parameter3";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateCleanAreaPlanParameter.CleanAreaPlanXaxis,
				UpdateCleanAreaPlanParameter.CleanAreaPlanYaxis,
				UpdateCleanAreaPlanParameter.CleanAreaPlanAreaPlan,
				UpdateCleanAreaPlanParameter.CleanAreaPlanFloor
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCleanStaffInfo( GetCleanStaffInfo GetCleanStaffInfoParameter )
		{
			string sql = $@"SELECT*
									FROM(SELECT [CleanStaffInfo].[ID],[CleanStaffInfo].[Name],[CleanStaffInfo].[Tel],[CleanStaffInfo].[Cell],[CleanStaffInfo].[Address],FirmInfo.[Firm],[CleanStaffInfo].[Firm] as 'FirmNo',FirmInfo.[Type],[CleanStaffInfo].[Type] as 'TypeNo',FirmInfo.[TypeColor],[CleanStaffInfo].[BirthDate]
									FROM [SyntecGAS].[dbo].[CleanStaffInfo]
									INNER JOIN (SELECT TypeInfo.[StaffID],TypeInfo.[Type],[CleanFirmInfo].[Firm],TypeInfo.[TypeColor]
														FROM[SyntecGAS].[dbo].[CleanFirmInfo]
														INNER JOIN(SELECT [CleanStaffInfo].[ID] as 'StaffID',[CleanStaffInfo].[Firm] as 'FirmNo',[CleanStaffType].[Type],[CleanStaffType].[Color] as 'TypeColor'
																			FROM[SyntecGAS].[dbo].[CleanStaffInfo]
																			INNER JOIN[SyntecGAS].[dbo].[CleanStaffType]
																			ON[CleanStaffInfo].[Type] =[CleanStaffType].[No]) as TypeInfo
														ON[CleanFirmInfo].[No] =TypeInfo.[FirmNo]) as FirmInfo
									ON[CleanStaffInfo].[ID] = FirmInfo.[StaffID]) as StaffInfo
									Left JOIN[SyntecGAS].[dbo].[CleanAreaInfo]
									ON StaffInfo.[ID] =[CleanAreaInfo].[CleanStaff]
									ORDER BY [ID]";

			List<object> SQLParameterList = new List<object>()
			{
				GetCleanStaffInfoParameter.CleanStaffInfoID,
				GetCleanStaffInfoParameter.CleanStaffInfoName,
				GetCleanStaffInfoParameter.CleanStaffInfoTel,
				GetCleanStaffInfoParameter.CleanStaffInfoCell,
				GetCleanStaffInfoParameter.CleanStaffInfoAddress,
				GetCleanStaffInfoParameter.CleanStaffInfoFirm,
				GetCleanStaffInfoParameter.CleanStaffInfoType,
				GetCleanStaffInfoParameter.CleanStaffInfoBirthDate
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
		internal bool InsertCleanStaffInfo( InsertCleanStaffInfo InsertCleanStaffInfoParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[CleanStaffInfo] ([ID],[Name],[Tel],[Cell],[Address],[Firm],[Type],[BirthDate])
								VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertCleanStaffInfoParameter.CleanStaffInfoID,
				InsertCleanStaffInfoParameter.CleanStaffInfoName,
				InsertCleanStaffInfoParameter.CleanStaffInfoTel,
				InsertCleanStaffInfoParameter.CleanStaffInfoCell,
				InsertCleanStaffInfoParameter.CleanStaffInfoAddress,
				InsertCleanStaffInfoParameter.CleanStaffInfoFirm,
				InsertCleanStaffInfoParameter.CleanStaffInfoType,
				InsertCleanStaffInfoParameter.CleanStaffInfoBirthDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteCleanStaffInfo( DeleteCleanStaffInfo DeleteCleanStaffInfoParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[CleanStaffInfo]
								where [ID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteCleanStaffInfoParameter.CleanStaffInfoID,
				DeleteCleanStaffInfoParameter.CleanStaffInfoName,
				DeleteCleanStaffInfoParameter.CleanStaffInfoTel,
				DeleteCleanStaffInfoParameter.CleanStaffInfoCell,
				DeleteCleanStaffInfoParameter.CleanStaffInfoAddress,
				DeleteCleanStaffInfoParameter.CleanStaffInfoFirm,
				DeleteCleanStaffInfoParameter.CleanStaffInfoType,
				DeleteCleanStaffInfoParameter.CleanStaffInfoBirthDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateCleanStaffInfo( UpdateCleanStaffInfo UpdateCleanStaffInfoParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[CleanStaffInfo]
							set [Name]=@Parameter1,[Tel]=@Parameter2,[Cell]=@Parameter3,[Address]=@Parameter4,[Firm]=@Parameter5,[Type]=@Parameter6,[BirthDate]=@Parameter7
							where [ID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateCleanStaffInfoParameter.CleanStaffInfoID,
				UpdateCleanStaffInfoParameter.CleanStaffInfoName,
				UpdateCleanStaffInfoParameter.CleanStaffInfoTel,
				UpdateCleanStaffInfoParameter.CleanStaffInfoCell,
				UpdateCleanStaffInfoParameter.CleanStaffInfoAddress,
				UpdateCleanStaffInfoParameter.CleanStaffInfoFirm,
				UpdateCleanStaffInfoParameter.CleanStaffInfoType,
				UpdateCleanStaffInfoParameter.CleanStaffInfoBirthDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetCleanAreaInfo( GetCleanAreaInfo GetCleanAreaInfoParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[CleanAreaInfo]
						ORDER BY [AreaNo]";

			List<object> SQLParameterList = new List<object>()
			{
				GetCleanAreaInfoParameter.CleanAreaInfoAreaNo,
				GetCleanAreaInfoParameter.CleanAreaInfoAreaName,
				GetCleanAreaInfoParameter.CleanAreaInfoCleanStaff,
				GetCleanAreaInfoParameter.CleanAreaInfoColor
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
		internal bool InsertCleanAreaInfo( InsertCleanAreaInfo InsertCleanAreaInfoParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[CleanAreaInfo] ([AreaName], [CleanStaff], [Color])
								VALUES (@Parameter1,@Parameter2,@Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertCleanAreaInfoParameter.CleanAreaInfoAreaNo,
				InsertCleanAreaInfoParameter.CleanAreaInfoAreaName,
				InsertCleanAreaInfoParameter.CleanAreaInfoCleanStaff,
				InsertCleanAreaInfoParameter.CleanAreaInfoColor
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteCleanAreaInfo( DeleteCleanAreaInfo DeleteCleanAreaInfoParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[CleanAreaInfo]
								where [AreaNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteCleanAreaInfoParameter.CleanAreaInfoAreaNo,
				DeleteCleanAreaInfoParameter.CleanAreaInfoAreaName,
				DeleteCleanAreaInfoParameter.CleanAreaInfoCleanStaff,
				DeleteCleanAreaInfoParameter.CleanAreaInfoColor
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateCleanAreaInfo( UpdateCleanAreaInfo UpdateCleanAreaInfoParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[CleanAreaInfo]
							set [AreaName]=@Parameter1,[CleanStaff]=@Parameter2,[Color]=@Parameter3
							where [AreaNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateCleanAreaInfoParameter.CleanAreaInfoAreaNo,
				UpdateCleanAreaInfoParameter.CleanAreaInfoAreaName,
				UpdateCleanAreaInfoParameter.CleanAreaInfoCleanStaff,
				UpdateCleanAreaInfoParameter.CleanAreaInfoColor
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetMaintainRecordItemInfo( GetMaintainRecordItemInfo GetMaintainRecordItemInfoParameter )
		{
			string sql = $@"SELECT *
									FROM [SyntecGAS].[dbo].[MaintainRecordItemInfo]
									ORDER BY [No]";

			List<object> SQLParameterList = new List<object>()
			{
				GetMaintainRecordItemInfoParameter.MaintainRecordItemInfoNo,
				GetMaintainRecordItemInfoParameter.MaintainRecordItemInfoItems
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
		internal bool InsertMaintainRecordItem( InsertMaintainRecordItem InsertMaintainRecordItemParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MaintainRecordItemInfo] ([Items])
								VALUES (@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMaintainRecordItemParameter.MaintainRecordItemInfoNo,
				InsertMaintainRecordItemParameter.MaintainRecordItemInfoItems
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteMaintainRecordItem( DeleteMaintainRecordItem DeleteMaintainRecordItemParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[MaintainRecordItemInfo]
								where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMaintainRecordItemParameter.MaintainRecordItemInfoNo,
				DeleteMaintainRecordItemParameter.MaintainRecordItemInfoItems
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateMaintainRecordItemInfo( UpdateMaintainRecordItemInfo UpdateMaintainRecordItemInfoParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[MaintainRecordItemInfo]
							set [Items]=@Parameter1
							where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateMaintainRecordItemInfoParameter.MaintainRecordItemInfoNo,
				UpdateMaintainRecordItemInfoParameter.MaintainRecordItemInfoItems
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
	
		internal DataTable GetMaintainRecordTypeInfo( GetMaintainRecordTypeInfo GetMaintainRecordTypeInfoParameter )
		{
			string sql = $@"SELECT [MaintainRecordTypeInfo].[No],
												[MaintainRecordTypeInfo].[Items] as 'ItemsNo',
												[MaintainRecordTypeInfo].[Type],
												[MaintainRecordTypeInfo].[Period],
												[MaintainRecordTypeInfo].[StartDate],
												[MaintainRecordTypeInfo].[EndDate],
												[MaintainRecordItemInfo].[Items]
									FROM [SyntecGAS].[dbo].[MaintainRecordTypeInfo]
									INNER JOIN [SyntecGAS].[dbo].[MaintainRecordItemInfo]
									ON [MaintainRecordTypeInfo].[Items]=[MaintainRecordItemInfo].[No]
WHERE [MaintainRecordTypeInfo].[Items] LIKE @Parameter1";

			List<object> SQLParameterList = new List<object>()
			{
				GetMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoNo,
				GetMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoItems,
				GetMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoType,
				GetMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoPeriod,
				GetMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoStartDate,
				GetMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoEndDate
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
		internal bool InsertMaintainRecordType( InsertMaintainRecordType InsertMaintainRecordTypeParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MaintainRecordTypeInfo] ([Items],[Type])
								VALUES (@Parameter1,@Parameter2)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMaintainRecordTypeParameter.MaintainRecordTypeInfoNo,
				InsertMaintainRecordTypeParameter.MaintainRecordTypeInfoItems,
				InsertMaintainRecordTypeParameter.MaintainRecordTypeInfoType,
				InsertMaintainRecordTypeParameter.MaintainRecordTypeInfoPeriod,
				InsertMaintainRecordTypeParameter.MaintainRecordTypeInfoStartDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteMaintainRecordType( DeleteMaintainRecordType DeleteMaintainRecordTypeParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[MaintainRecordTypeInfo]
								where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMaintainRecordTypeParameter.MaintainRecordTypeInfoNo,
				DeleteMaintainRecordTypeParameter.MaintainRecordTypeInfoItems,
				DeleteMaintainRecordTypeParameter.MaintainRecordTypeInfoType,
				DeleteMaintainRecordTypeParameter.MaintainRecordTypeInfoPeriod,
				DeleteMaintainRecordTypeParameter.MaintainRecordTypeInfoStartDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateMaintainRecordTypeInfo( UpdateMaintainRecordTypeInfo UpdateMaintainRecordTypeInfoParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[MaintainRecordTypeInfo]
							set [Period]=@Parameter3,[StartDate]=@Parameter4,[EndDate]=@Parameter5
							where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoNo,
				UpdateMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoItems,
				UpdateMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoType,
				UpdateMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoPeriod,
				UpdateMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoStartDate,
				UpdateMaintainRecordTypeInfoParameter.MaintainRecordTypeInfoEndDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetMaintainRecordDetailList( GetMaintainRecordDetailList GetMaintainRecordDetailListParameter )
		{
			string sql = $@"SELECT *
									FROM [SyntecGAS].[dbo].[MaintainRecordDetailList]
									ORDER BY [Date] DESC,[No] DESC";

			List<object> SQLParameterList = new List<object>()
			{
				GetMaintainRecordDetailListParameter.MaintainRecordDetailListNo,
				GetMaintainRecordDetailListParameter.MaintainRecordDetailListItems,
				GetMaintainRecordDetailListParameter.MaintainRecordDetailListType,
				GetMaintainRecordDetailListParameter.MaintainRecordDetailListMemo,
				GetMaintainRecordDetailListParameter.MaintainRecordDetailListDate
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
		internal bool InsertMaintainRecordDetailList( InsertMaintainRecordDetailList InsertMaintainRecordDetailListParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MaintainRecordDetailList] ([Items],[Type],[Memo],[Date])
								VALUES (@Parameter1,@Parameter2,@Parameter3,@Parameter4)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMaintainRecordDetailListParameter.MaintainRecordDetailListNo,
				InsertMaintainRecordDetailListParameter.MaintainRecordDetailListItems,
				InsertMaintainRecordDetailListParameter.MaintainRecordDetailListType,
				InsertMaintainRecordDetailListParameter.MaintainRecordDetailListMemo,
				InsertMaintainRecordDetailListParameter.MaintainRecordDetailListDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteMaintainRecordDetailList( DeleteMaintainRecordDetailList DeleteMaintainRecordDetailListParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[MaintainRecordDetailList]
								where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMaintainRecordDetailListParameter.MaintainRecordDetailListNo,
				DeleteMaintainRecordDetailListParameter.MaintainRecordDetailListItems,
				DeleteMaintainRecordDetailListParameter.MaintainRecordDetailListType,
				DeleteMaintainRecordDetailListParameter.MaintainRecordDetailListMemo,
				DeleteMaintainRecordDetailListParameter.MaintainRecordDetailListDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateMaintainRecordDetailList( UpdateMaintainRecordDetailList UpdateMaintainRecordDetailListParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[MaintainRecordDetailListInfo]
							set [Items]=@Parameter1,[Type]=@Parameter2,[Period]=@Parameter3,[StartDate]=@Parameter4
							where [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateMaintainRecordDetailListParameter.MaintainRecordDetailListNo,
				UpdateMaintainRecordDetailListParameter.MaintainRecordDetailListItems,
				UpdateMaintainRecordDetailListParameter.MaintainRecordDetailListType,
				UpdateMaintainRecordDetailListParameter.MaintainRecordDetailListMemo,
				UpdateMaintainRecordDetailListParameter.MaintainRecordDetailListDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
	

	}
	#endregion Internal Methods
}
