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
				GetMenuParameter.MenuPrice
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
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[Menu] ([ResNo], [Items], [Price])
								VALUES (@Parameter0, @Parameter1, @Parameter2)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMenuItemsParameter.MenuResNo,
				InsertMenuItemsParameter.MenuItems,
				InsertMenuItemsParameter.MenuPrice
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
				DeleteMenuItemsParameter.MenuPrice
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool UpdateMenu(UpdateMenu UpdateMenuParameter)
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[Menu]
							set [Price]=@Parameter2
							where [ResNo]=@Parameter0 AND [Items]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateMenuParameter.MenuResNo,
				UpdateMenuParameter.MenuItems,
				UpdateMenuParameter.MenuPrice
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
	}
	#endregion Internal Methods
}

