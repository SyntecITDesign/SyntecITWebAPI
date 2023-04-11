using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.OrderMeal;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{

	internal class OrderMealDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public OrderMealDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}


		internal bool InsertRestaurant(InsertRestaurant InsertRestaurantParameter)
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[RestaurantInfo] ([ResNo], [ResName], [ResTel], [ResBranch])
								VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter4)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertRestaurantParameter.RestaurantInfoResNo,
				InsertRestaurantParameter.RestaurantInfoResName,
				InsertRestaurantParameter.RestaurantInfoResTel,
				InsertRestaurantParameter.RestaurantInfoIsBlacklist,
				InsertRestaurantParameter.RestaurantInfoResBranch
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool DeleteRestaurant(DeleteRestaurant DeleteRestaurantParameter)
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[RestaurantMemo] WHERE [ResNo]=@Parameter0;
								   DELETE [{m_gas}].[dbo].[Menu] WHERE [ResNo]=@Parameter0;
									DELETE [{m_gas}].[dbo].[MealCalendar] WHERE [ResNo]=@Parameter0;
								   DELETE [{m_gas}].[dbo].[RestaurantInfo] WHERE [ResNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteRestaurantParameter.RestaurantInfoResNo,
				DeleteRestaurantParameter.RestaurantInfoResName,
				DeleteRestaurantParameter.RestaurantInfoResTel
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool UpdateRestaurantInfo(UpdateRestaurantInfo UpdateRestaurantInfoParameter)
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[RestaurantInfo]
							set [ResName]=@Parameter1, [ResTel]=@Parameter2, [IsBlacklist]=@Parameter3, [ResBranch]=@Parameter4
							where ResNo=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateRestaurantInfoParameter.RestaurantInfoResNo,
				UpdateRestaurantInfoParameter.RestaurantInfoResName,
				UpdateRestaurantInfoParameter.RestaurantInfoResTel,
				UpdateRestaurantInfoParameter.RestaurantInfoIsBlacklist,
				UpdateRestaurantInfoParameter.RestaurantInfoResBranch
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal DataTable GetRestaurantInfo(GetRestaurantInfo GetRestaurantInfoParameter)
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[RestaurantInfo]
						ORDER BY [ResNo] desc";
			List<object> SQLParameterList = new List<object>()
			{
				GetRestaurantInfoParameter.RestaurantInfoResNo,
				GetRestaurantInfoParameter.RestaurantInfoResName,
				GetRestaurantInfoParameter.RestaurantInfoResTel
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

		internal DataTable GetFuzzyItemInfo( GetMenu GetMenuParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[Menu]
						where [Items] like @Parameter1 and [ResNo] = @Parameter0
						order by Items desc";


			List<object> SQLParameterList = new List<object>()
			{
				GetMenuParameter.MenuResNo,
				"%"+GetMenuParameter.MenuItems+"%",
				GetMenuParameter.MenuPrice,
				GetMenuParameter.MenuFat
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
		internal DataTable GetMenu(GetMenu GetMenuParameter)
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[Menu]
						where ResNo = @Parameter0
						order by Items desc";

			
			List<object> SQLParameterList = new List<object>()
			{
				GetMenuParameter.MenuResNo,
				GetMenuParameter.MenuItems,
				GetMenuParameter.MenuPrice,
				GetMenuParameter.MenuFat
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
		internal bool InsertMenuItems(InsertMenuItems InsertMenuItemsParameter)
		{
			string sql = $@"IF EXISTS (SELECT * FROM [{m_gas}].[dbo].[Menu] WHERE ResNo = @Parameter0 and [Items] = @Parameter1)
								UPDATE [{m_gas}].[dbo].[Menu] SET [Fat]=@Parameter3
								WHERE [ResNo]=@Parameter0 AND [Items]=@Parameter1
							ELSE
								INSERT INTO [{m_gas}].[dbo].[Menu] ([ResNo], [Items], [Price], [Fat])
								VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMenuItemsParameter.MenuResNo,
				InsertMenuItemsParameter.MenuItems,
				InsertMenuItemsParameter.MenuPrice,
				InsertMenuItemsParameter.MenuFat
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool DeleteMenuItems(DeleteMenuItems DeleteMenuItemsParameter)
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[Menu]
								where [MenuNo]=@Parameter4";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMenuItemsParameter.MenuResNo,
				DeleteMenuItemsParameter.MenuItems,
				DeleteMenuItemsParameter.MenuPrice,
				DeleteMenuItemsParameter.MenuFat,
				DeleteMenuItemsParameter.MenuNo
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool UpdateMenu(UpdateMenu UpdateMenuParameter)
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[Menu]
							set [Price]=@Parameter2, [Fat]=@Parameter3
							where [ResNo]=@Parameter0 AND [Items]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateMenuParameter.MenuResNo,
				UpdateMenuParameter.MenuItems,
				UpdateMenuParameter.MenuPrice,
				UpdateMenuParameter.MenuFat
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal DataTable GetMemo(GetMemo GetMemoParameter)
		{
			string sql = $@"SELECT *
									FROM [{m_gas}].[dbo].[RestaurantMemo]
									where ResNo = @Parameter0
									ORDER BY [InsertDate] desc";
			List<object> SQLParameterList = new List<object>()
			{
				GetMemoParameter.MemoResNo,
				GetMemoParameter.MemoNo,
				GetMemoParameter.MemoContent,
				GetMemoParameter.MemoInsertDate,
				GetMemoParameter.MemoEmpID
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
		internal bool InsertMemo(InsertMemo InsertMemoParameter)
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[RestaurantMemo] ([ResNo], [MemoNo], [MemoContent], [EmpID])
								VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter4)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMemoParameter.MemoResNo,
				InsertMemoParameter.MemoNo,
				InsertMemoParameter.MemoContent,
				InsertMemoParameter.MemoInsertDate,
				InsertMemoParameter.MemoEmpID
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool InsertMealCalendar(InsertMealCalendar InsertMealCalendarParameter)
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[MealCalendar] ([ResNo], [Items], [InsertDate])
								VALUES (@Parameter0, @Parameter1, @Parameter2)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMealCalendarParameter.MealCalendarResNo,
				InsertMealCalendarParameter.MealCalendarItems,
				InsertMealCalendarParameter.MealCalendarInsertDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal DataTable GetMealCalendar(GetMealCalendar GetMealCalendarParameter)
		{
			string sql = $@"SELECT [MealCalendar].[ResNo],MealInfo.[ResName],[MealCalendar].[Items],[MealCalendar].[InsertDate],MealInfo.Price,MealInfo.Fat
							FROM [{m_gas}].[dbo].[MealCalendar]
							inner join(SELECT [Menu].ResNo,[Menu].Price,[Menu].Fat,[RestaurantInfo].ResName,[Menu].Items
										FROM [{m_gas}].[dbo].[Menu] 
										inner join [{m_gas}].[dbo].[RestaurantInfo] 
										on [Menu].ResNo=[RestaurantInfo].ResNo) as MealInfo
							on MealInfo.ResNo = [MealCalendar].ResNo and MealInfo.Items = [MealCalendar].Items
							Where Convert(varchar,InsertDate,120) like @Parameter3
							order by InsertDate desc";

			List<object> SQLParameterList = new List<object>()
			{
				GetMealCalendarParameter.MealCalendarResNo,
				GetMealCalendarParameter.MealCalendarResName,
				GetMealCalendarParameter.MealCalendarItems,
				GetMealCalendarParameter.MealCalendarInsertDate
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
		internal bool DeleteMealCalendar(DeleteMealCalendar DeleteMealCalendarParameter)
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[MealCalendar]
								where [ResNo]=@Parameter0 AND [Items]=@Parameter1 AND [InsertDate]=@Parameter2";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMealCalendarParameter.MealCalendarResNo,
				DeleteMealCalendarParameter.MealCalendarItems,
				DeleteMealCalendarParameter.MealCalendarInsertDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal DataTable GetAreaInfo(GetAreaInfo GetAreaInfoParameter)
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[AreaInfo]
						ORDER BY [AreaNo]";

			List<object> SQLParameterList = new List<object>()
			{
				GetAreaInfoParameter.AreaInfoAreaNo,
				GetAreaInfoParameter.AreaInfoAreaName
			};
			DataTable result = m_dbproxy.GetDataCMD(sql, SQLParameterList.ToArray());

			if (result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal bool InsertAreaInfo(InsertAreaInfo InsertAreaInfoParameter)
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[AreaInfo] ([AreaName])
								VALUES (@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertAreaInfoParameter.AreaInfoAreaNo,
				InsertAreaInfoParameter.AreaInfoAreaName
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool DeleteAreaInfo(DeleteAreaInfo DeleteAreaInfoParameter)
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[AreaInfo]
								where [AreaNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteAreaInfoParameter.AreaInfoAreaNo,
				DeleteAreaInfoParameter.AreaInfoAreaName
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool UpdateAreaInfo(UpdateAreaInfo UpdateAreaInfoParameter)
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[AreaInfo]
							set [AreaName]=@Parameter1
							where [AreaNo]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateAreaInfoParameter.AreaInfoAreaNo,
				UpdateAreaInfoParameter.AreaInfoAreaName
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal DataTable GetOrderMealApplicationsMaster( GetOrderMealApplicationsMaster GetOrderMealApplicationsMasterParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[OrderMealApplicationsMaster]
						ORDER BY [RequisitionID] desc";

			List<object> SQLParameterList = new List<object>()
			{
				GetOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterRequisitionID,
				GetOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerID,
				GetOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerName,
				GetOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterApplicationDate
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
		internal bool InsertOrderMealApplicationsMaster( InsertOrderMealApplicationsMaster InsertOrderMealApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[OrderMealApplicationsMaster] ([FillerID],[FillerName],[ApplicationDate])
								VALUES (@Parameter1,@Parameter2,@Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterRequisitionID,
				InsertOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerID,
				InsertOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerName,
				InsertOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterApplicationDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateOrderMealApplicationsMaster( UpdateOrderMealApplicationsMaster UpdateOrderMealApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[OrderMealApplicationsMaster]
							set []=@Parameter1
							where []=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterRequisitionID,
				UpdateOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerID,
				UpdateOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerName,
				UpdateOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterApplicationDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetOrderMealApplicationsDetail( GetOrderMealApplicationsDetail GetOrderMealApplicationsDetailParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[OrderMealApplicationsDetail]
						WHERE [ApplicantID] like @Parameter1 and Convert(varchar,OrderDate,120) like @Parameter8 and [Finished]=@Parameter9";

			List<object> SQLParameterList = new List<object>()
			{
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailRequisitionID,
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailApplicantID,
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailApplicantName,
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailStore,
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailMeal,
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailPrice,
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailAreaName,
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailIsCancel,
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailOrderDate,
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailFinished
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );			

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal bool InsertOrderMealApplicationsDetail( InsertOrderMealApplicationsDetail InsertOrderMealApplicationsDetailParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[OrderMealApplicationsDetail] ([RequisitionID],[ApplicantID],[ApplicantName],[Store],[Meal],[Price],[AreaName],[OrderDate],[Type])
								VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter8,@Parameter9)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailRequisitionID,
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailApplicantID,
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailApplicantName,
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailStore,
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailMeal,
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailPrice,
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailAreaName,
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailIsCancel,
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailOrderDate,
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailType
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateOrderMealApplicationsDetail( UpdateOrderMealApplicationsDetail UpdateOrderMealApplicationsDetailParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[OrderMealApplicationsDetail]
							set [Finished]=@Parameter9,[IsCancel]=@Parameter10
							where [DetailID]=@Parameter11";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailRequisitionID,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailApplicantID,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailApplicantName,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailStore,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailMeal,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailPrice,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailAreaName,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailIsCancel,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailOrderDate,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailFinished,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailIsCancel,
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailDetailID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteOrderMealApplicationsDetail( DeleteOrderMealApplicationsDetail DeleteOrderMealApplicationsDetailParameter )
		{
			string sql = $@"Delete INTO [{m_gas}].[dbo].[OrderMealApplicationsDetail] ([])
								VALUES (@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailRequisitionID,
				DeleteOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailApplicantID,
				DeleteOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailApplicantName,
				DeleteOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailStore,
				DeleteOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailMeal,
				DeleteOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailPrice,
				DeleteOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailAreaName,
				DeleteOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailIsCancel,
				DeleteOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailOrderDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}


		internal DataTable GetOrderMealGAS_DailyLunch( GetOrderMealGAS_DailyLunch GetOrderMealGAS_DailyLunchParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[GAS_DailyLunch]
						order by [UpdateDate] desc";

			List<object> SQLParameterList = new List<object>()
			{
				GetOrderMealGAS_DailyLunchParameter.OrderMealGAS_DailyLunchLunchDate,
				GetOrderMealGAS_DailyLunchParameter.OrderMealGAS_DailyLunchDailySupplyMealNum
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal bool UpsertOrderMealGAS_DailyLunch( UpsertOrderMealGAS_DailyLunch UpsertOrderMealGAS_DailyLunchParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [{m_gas}].[dbo].[GAS_DailyLunch] WHERE [LunchDate]=@Parameter0 )
							UPDATE [{m_gas}].[dbo].[GAS_DailyLunch] SET [DailySupplyMealNum]=@Parameter1
							WHERE [LunchDate]=@Parameter0 
						ELSE
						INSERT INTO [{m_gas}].[dbo].[GAS_DailyLunch] ([LunchDate] ,[DailySupplyMealNum]) 
						VALUES (@Parameter0,@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				UpsertOrderMealGAS_DailyLunchParameter.OrderMealGAS_DailyLunchLunchDate,
				UpsertOrderMealGAS_DailyLunchParameter.OrderMealGAS_DailyLunchDailySupplyMealNum
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetGuestMealsDept()
		{
			string sql = $@"SELECT Distinct [FSe7en_Org_DeptInfo].DisplayName, [FSe7en_Org_DeptStruct].[DeptID] 
FROM [BPMPro].dbo.[FSe7en_Org_DeptInfo],[BPMPro].dbo.[FSe7en_Org_DeptStruct]  
where  [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID = [BPMPro].dbo.[FSe7en_Org_DeptStruct].[DeptID] AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID Like 'TWST%' AND ([BPMPro].dbo.[FSe7en_Org_DeptStruct].[GradeNum]='60' OR [BPMPro].dbo.[FSe7en_Org_DeptStruct].[GradeNum]='70' )AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID = [BPMPro].dbo.[FSe7en_Org_DeptStruct].[DeptID] AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWST111' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWST113' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWST130' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWSTISO' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWSTISOM' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWSTLEAN' AND [BPMPro].dbo.[FSe7en_Org_DeptInfo].DeptID != 'TWST57'
Union
SELECT Distinct [FSe7en_Org_DeptInfo].DisplayName, [FSe7en_Org_DeptStruct].[DeptID] 
FROM [BPMPro].dbo.[FSe7en_Org_DeptInfo],[BPMPro].dbo.[FSe7en_Org_DeptStruct]  
where  [FSe7en_Org_DeptInfo].DeptID = [FSe7en_Org_DeptStruct].[DeptID] AND [FSe7en_Org_DeptInfo].DeptID in ('LEANTECTWLT5010','LEANTEC30','LEANTECTWLT1010')";

			DataTable result = m_BPMdbproxy.GetDataWithNoParaCMD( sql );

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal DataTable GetGuestMealsRecord()
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[GuestMeals]
						where CONVERT( varchar(50), [ApplyTime], 127) > CONVERT( varchar( 50 ), getdate(), 120 )
						order by [ApplyTime] asc";
			
			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql );
			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool InsertLunchGuest( InsertLunchGuest InsertLunchGuestParameter )
		{
			string sql = $@"IF EXISTS 
							(SELECT * FROM  [{m_gas}].[dbo].[GuestMeals] WHERE [ID]=@Parameter7 )
							UPDATE  [{m_gas}].[dbo].[GuestMeals] SET [Company] = @Parameter2
							  ,[Department] = @Parameter3
							  ,[ApplicantID] = @Parameter4
							  ,[Name] = @Parameter5
							  ,[Quantity] = @Parameter6
							WHERE [ID]=@Parameter7
							ELSE
							INSERT INTO [{m_gas}].[dbo].[GuestMeals] ([ApplyTime]
							  ,[VisitorType]
							  ,[Company]
							  ,[Department]
							  ,[ApplicantID]
							  ,[Name]
							  ,[Quantity])
							VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertLunchGuestParameter.ApplyTime,
				InsertLunchGuestParameter.VisitorType,
				InsertLunchGuestParameter.Company,
				InsertLunchGuestParameter.Department,
				InsertLunchGuestParameter.ApplicantID,
				InsertLunchGuestParameter.Name,
				InsertLunchGuestParameter.Quantity,
				InsertLunchGuestParameter.ID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DeleteLunchGuest( GuestMealsAllField GuestMealsAllFieldParameter )
		{
			string sql = $@"DELETE FROM [{m_gas}].[dbo].[GuestMeals]
							WHERE [ID] = @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				GuestMealsAllFieldParameter.ID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
	}
	#endregion Internal Methods
}

