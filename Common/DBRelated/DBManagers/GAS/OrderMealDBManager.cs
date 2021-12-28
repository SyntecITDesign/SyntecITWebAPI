using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.OrderMeal;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{


	internal class OrderMealDBManager : AbstractDBManager
	{
		#region Internal Methods

		internal bool InsertRestaurant(InsertRestaurant InsertRestaurantParameter)
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[RestaurantInfo] ([ResNo], [ResName], [ResTel], [ResBranch])
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
			string sql = $@"DELETE [SyntecGAS].[dbo].[RestaurantMemo] WHERE [ResNo]=@Parameter0;
								   DELETE [SyntecGAS].[dbo].[Menu] WHERE [ResNo]=@Parameter0;
									DELETE [SyntecGAS].[dbo].[MealCalendar] WHERE [ResNo]=@Parameter0;
								   DELETE [SyntecGAS].[dbo].[RestaurantInfo] WHERE [ResNo]=@Parameter0";
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
			string sql = $@"UPDATE [SyntecGAS].[dbo].[RestaurantInfo]
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
						FROM [SyntecGAS].[dbo].[RestaurantInfo]
						ORDER BY [ResNo]";
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

		internal DataTable GetMenu(GetMenu GetMenuParameter)
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[Menu]
						where ResNo = @Parameter0";

			
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
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[Menu] ([ResNo], [Items], [Price], [Fat])
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
			string sql = $@"DELETE [SyntecGAS].[dbo].[Menu]
								where [ResNo]=@Parameter0 AND [Items]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMenuItemsParameter.MenuResNo,
				DeleteMenuItemsParameter.MenuItems,
				DeleteMenuItemsParameter.MenuPrice,
				DeleteMenuItemsParameter.MenuFat
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool UpdateMenu(UpdateMenu UpdateMenuParameter)
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[Menu]
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
									FROM [SyntecGAS].[dbo].[RestaurantMemo]
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
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[RestaurantMemo] ([ResNo], [MemoNo], [MemoContent], [EmpID])
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
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MealCalendar] ([ResNo], [Items], [InsertDate])
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
			string sql = $@"SELECT [MealCalendar].[ResNo],[RestaurantInfo].[ResName],[MealCalendar].[Items],[MealCalendar].[InsertDate]
									FROM [SyntecGAS].[dbo].[MealCalendar] inner join [SyntecGAS].[dbo].[RestaurantInfo] on [MealCalendar].ResNo=[RestaurantInfo].ResNo";

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
			string sql = $@"DELETE [SyntecGAS].[dbo].[MealCalendar]
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
						FROM [SyntecGAS].[dbo].[AreaInfo]
						ORDER BY [AreaNo]";

			List<object> SQLParameterList = new List<object>()
			{
				GetAreaInfoParameter.AreaInfoAreaNo,
				GetAreaInfoParameter.AreaInfoAreaName
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
		internal bool InsertAreaInfo(InsertAreaInfo InsertAreaInfoParameter)
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[AreaInfo] ([AreaName])
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
			string sql = $@"DELETE [SyntecGAS].[dbo].[AreaInfo]
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
			string sql = $@"UPDATE [SyntecGAS].[dbo].[AreaInfo]
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
						FROM [SyntecGAS].[dbo].[OrderMealApplicationsMaster]
						ORDER BY [RequisitionID] desc";

			List<object> SQLParameterList = new List<object>()
			{
				GetOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterRequisitionID,
				GetOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerID,
				GetOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerName,
				GetOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterApplicationDate,
				GetOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterOrderState,
				GetOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterType
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
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[OrderMealApplicationsMaster] ([])
								VALUES (@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterRequisitionID,
				InsertOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerID,
				InsertOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerName,
				InsertOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterApplicationDate,
				InsertOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterOrderState,
				InsertOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterType
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateOrderMealApplicationsMaster( UpdateOrderMealApplicationsMaster UpdateOrderMealApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[OrderMealApplicationsMaster]
							set []=@Parameter1
							where []=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterRequisitionID,
				UpdateOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerID,
				UpdateOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterFillerName,
				UpdateOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterApplicationDate,
				UpdateOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterOrderState,
				UpdateOrderMealApplicationsMasterParameter.OrderMealApplicationsMasterType
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetOrderMealApplicationsDetail( GetOrderMealApplicationsDetail GetOrderMealApplicationsDetailParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[OrderMealApplicationsDetail]
						ORDER BY [RequisitionID] desc";

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
				GetOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailOrderDate
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
		internal bool InsertOrderMealApplicationsDetail( InsertOrderMealApplicationsDetail InsertOrderMealApplicationsDetailParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[OrderMealApplicationsDetail] ([])
								VALUES (@Parameter1)";
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
				InsertOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailOrderDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateOrderMealApplicationsDetail( UpdateOrderMealApplicationsDetail UpdateOrderMealApplicationsDetailParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[OrderMealApplicationsDetail]
							set []=@Parameter1
							where []=@Parameter0";
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
				UpdateOrderMealApplicationsDetailParameter.OrderMealApplicationsDetailOrderDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
	}
	#endregion Internal Methods
}

