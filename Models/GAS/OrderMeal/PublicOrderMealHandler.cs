using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.OrderMeal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.OrderMeal
{

	internal class PublicOrderMealHandler
	{
		#region Internal Methods
		internal bool InsertRestaurant(InsertRestaurant InsertRestaurantParameter)
		{
			bool bResult = m_OrderMealDBManager.InsertRestaurant(InsertRestaurantParameter);
			return bResult;
		}
		internal bool DeleteRestaurant(DeleteRestaurant DeleteRestaurantParameter)
		{
			bool bResult = m_OrderMealDBManager.DeleteRestaurant(DeleteRestaurantParameter);
			return bResult;
		}
		internal bool UpdateRestaurantInfo(UpdateRestaurantInfo UpdateRestaurantInfoParameter)
		{
			bool bResult = m_OrderMealDBManager.UpdateRestaurantInfo(UpdateRestaurantInfoParameter);
			return bResult;
		}
		internal JArray GetRestaurantInfo(GetRestaurantInfo GetRestaurantInfoParameter)
		{
			DataTable dtResult = m_OrderMealDBManager.GetRestaurantInfo(GetRestaurantInfoParameter);
			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}

		internal JArray GetMenu(GetMenu GetMenuParameter)
		{
			DataTable dtResult = m_OrderMealDBManager.GetMenu(GetMenuParameter);
			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}
		internal bool InsertMenuItems(InsertMenuItems InsertMenuItemsParameter)
		{
			bool bResult = m_OrderMealDBManager.InsertMenuItems(InsertMenuItemsParameter);
			return bResult;
		}
		internal bool DeleteMenuItems(DeleteMenuItems DeleteMenuItemsParameter)
		{
			bool bResult = m_OrderMealDBManager.DeleteMenuItems(DeleteMenuItemsParameter);
			return bResult;
		}
		internal bool UpdateMenu(UpdateMenu UpdateMenuParameter)
		{
			bool bResult = m_OrderMealDBManager.UpdateMenu(UpdateMenuParameter);
			return bResult;
		}

		internal JArray GetMemo(GetMemo GetMemoParameter)
		{
			DataTable dtResult = m_OrderMealDBManager.GetMemo(GetMemoParameter);
			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}
		internal bool InsertMemo(InsertMemo InsertMemoParameter)
		{
			bool bResult = m_OrderMealDBManager.InsertMemo(InsertMemoParameter);
			return bResult;
		}

		internal bool InsertMealCalendar(InsertMealCalendar InsertMealCalendarParameter)
		{
			bool bResult = m_OrderMealDBManager.InsertMealCalendar(InsertMealCalendarParameter);
			return bResult;
		}
		internal JArray GetMealCalendar(GetMealCalendar GetMealCalendarParameter)
		{
			DataTable dtResult = m_OrderMealDBManager.GetMealCalendar(GetMealCalendarParameter);
			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}
		internal bool DeleteMealCalendar(DeleteMealCalendar DeleteMealCalendarParameter)
		{
			bool bResult = m_OrderMealDBManager.DeleteMealCalendar(DeleteMealCalendarParameter);
			return bResult;
		}

		internal JArray GetAreaInfo(GetAreaInfo GetAreaInfoParameter)
		{
			DataTable dtResult = m_OrderMealDBManager.GetAreaInfo(GetAreaInfoParameter);
			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}
		internal bool InsertAreaInfo(InsertAreaInfo InsertAreaInfoParameter)
		{
			bool bResult = m_OrderMealDBManager.InsertAreaInfo(InsertAreaInfoParameter);
			return bResult;
		}
		internal bool DeleteAreaInfo(DeleteAreaInfo DeleteAreaInfoParameter)
		{
			bool bResult = m_OrderMealDBManager.DeleteAreaInfo(DeleteAreaInfoParameter);
			return bResult;
		}
		internal bool UpdateAreaInfo(UpdateAreaInfo UpdateAreaInfoParameter)
		{
			bool bResult = m_OrderMealDBManager.UpdateAreaInfo(UpdateAreaInfoParameter);
			return bResult;
		}

		#endregion Internal Methods

		#region Private Fields

		private OrderMealDBManager m_OrderMealDBManager = new OrderMealDBManager();

		#endregion Private Fields
	}
}