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

		internal JArray GetFuzzyItemInfo( GetMenu GetMenuParameter )
		{
			DataTable dtResult = m_OrderMealDBManager.GetFuzzyItemInfo( GetMenuParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
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

		internal JArray GetOrderMealApplicationsMaster( GetOrderMealApplicationsMaster GetOrderMealApplicationsMasterParameter )
		{
			DataTable dtResult = m_OrderMealDBManager.GetOrderMealApplicationsMaster( GetOrderMealApplicationsMasterParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertOrderMealApplicationsMaster( InsertOrderMealApplicationsMaster InsertOrderMealApplicationsMasterParameter )
		{
			bool bResult = m_OrderMealDBManager.InsertOrderMealApplicationsMaster( InsertOrderMealApplicationsMasterParameter );
			return bResult;
		}
		internal bool UpdateOrderMealApplicationsMaster( UpdateOrderMealApplicationsMaster UpdateOrderMealApplicationsMasterParameter )
		{
			bool bResult = m_OrderMealDBManager.UpdateOrderMealApplicationsMaster( UpdateOrderMealApplicationsMasterParameter );
			return bResult;
		}
		
		internal JArray GetOrderMealApplicationsDetail( GetOrderMealApplicationsDetail GetOrderMealApplicationsDetailParameter )
		{
			DataTable dtResult = m_OrderMealDBManager.GetOrderMealApplicationsDetail( GetOrderMealApplicationsDetailParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertOrderMealApplicationsDetail( InsertOrderMealApplicationsDetail InsertOrderMealApplicationsDetailParameter )
		{
			bool bResult = m_OrderMealDBManager.InsertOrderMealApplicationsDetail( InsertOrderMealApplicationsDetailParameter );
			return bResult;
		}
		internal bool UpdateOrderMealApplicationsDetail( UpdateOrderMealApplicationsDetail UpdateOrderMealApplicationsDetailParameter )
		{
			bool bResult = m_OrderMealDBManager.UpdateOrderMealApplicationsDetail( UpdateOrderMealApplicationsDetailParameter );
			return bResult;
		}
		internal bool DeleteOrderMealApplicationsDetail( DeleteOrderMealApplicationsDetail DeleteOrderMealApplicationsDetailParameter )
		{
			bool bResult = m_OrderMealDBManager.DeleteOrderMealApplicationsDetail( DeleteOrderMealApplicationsDetailParameter );
			return bResult;
		}

		internal JArray GetOrderMealGAS_DailyLunch( GetOrderMealGAS_DailyLunch GetOrderMealGAS_DailyLunchParameter )
		{
			DataTable dtResult = m_OrderMealDBManager.GetOrderMealGAS_DailyLunch( GetOrderMealGAS_DailyLunchParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool UpsertOrderMealGAS_DailyLunch( UpsertOrderMealGAS_DailyLunch UpsertOrderMealGAS_DailyLunchParameter )
		{
			bool bResult = m_OrderMealDBManager.UpsertOrderMealGAS_DailyLunch( UpsertOrderMealGAS_DailyLunchParameter );
			return bResult;
		}
		internal JArray GetGuestMealsDept()
		{
			DataTable dtResult = m_OrderMealDBManager.GetGuestMealsDept();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray GetGuestMealsRecord()
		{
			DataTable dtResult = m_OrderMealDBManager.GetGuestMealsRecord();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertLunchGuest( InsertLunchGuest InsertLunchGuestParameter )
		{
			bool bResult = m_OrderMealDBManager.InsertLunchGuest( InsertLunchGuestParameter );
			return bResult;
		}
		internal bool DeleteLunchGuest( GuestMealsAllField GuestMealsAllFieldParameter )
		{
			bool bResult = m_OrderMealDBManager.DeleteLunchGuest( GuestMealsAllFieldParameter );
			return bResult;
		}
		#endregion Internal Methods

		#region Private Fields

		private OrderMealDBManager m_OrderMealDBManager = new OrderMealDBManager();

		#endregion Private Fields
	}
}