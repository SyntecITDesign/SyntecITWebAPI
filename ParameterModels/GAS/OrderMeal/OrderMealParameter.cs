using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.OrderMeal
{
    public class RestaurantInfoAllField
    {
        public int RestaurantInfoResNo { get; set; }
        public string RestaurantInfoResName { get; set; }
        public string RestaurantInfoResTel { get; set; }
        public bool RestaurantInfoIsBlacklist { get; set; }
        public string RestaurantInfoResBranch { get; set; }      
    }
    public class InsertRestaurant : RestaurantInfoAllField
    {
    }
    public class DeleteRestaurant : RestaurantInfoAllField
    {
    }
    public class UpdateRestaurantInfo : RestaurantInfoAllField
    {
    }
    public class GetRestaurantInfo : RestaurantInfoAllField
    {
    }

    public class MenuAllField
    {
        public int MenuResNo { get; set; }
        public string MenuItems { get; set; }
        public string MenuPrice { get; set; }
        public int MenuFat { get; set; }
	}
	public class InsertMenuItems : MenuAllField
    {
    }
    public class DeleteMenuItems : MenuAllField
    {
    }
    public class UpdateMenu : MenuAllField
    {
    }
    public class GetMenu : MenuAllField
    {
    }

    public class RestaurantMemoAllField
    {
        public int MemoResNo { get; set; }
        public string MemoContent { get; set; }
        public int MemoNo { get; set; }
        public string MemoInsertDate { get; set; }
        public string MemoEmpID { get; set; }

    }
    public class InsertMemo : RestaurantMemoAllField
    {
    }
    public class DeleteMemo : RestaurantMemoAllField
    {
    }
    public class UpdateMemo : RestaurantMemoAllField
    {
    }
    public class GetMemo : RestaurantMemoAllField
    {
    }

    public class MealCalendarAllField
    {
        public int MealCalendarResNo { get; set; }
        public string MealCalendarResName { get; set; }
        public string MealCalendarItems { get; set; }
        public string MealCalendarInsertDate { get; set; }
    }
    public class InsertMealCalendar : MealCalendarAllField
    {
    }
    public class DeleteMealCalendar : MealCalendarAllField
    {
    }
    public class UpdateMealCalendar : MealCalendarAllField
    {
    }
    public class GetMealCalendar : MealCalendarAllField
    {
    }

    public class AreaInfoAllField
    {
        public int AreaInfoAreaNo { get; set; }
        public string AreaInfoAreaName { get; set; }
    }
    public class InsertAreaInfo : AreaInfoAllField
    {
    }
    public class DeleteAreaInfo : AreaInfoAllField
    {
    }
    public class UpdateAreaInfo : AreaInfoAllField
    {
    }
    public class GetAreaInfo : AreaInfoAllField
    {
    }

	public class OrderMealApplicationsMasterAllField
	{
		public int OrderMealApplicationsMasterRequisitionID
		{
			get; set;
		}
		public string OrderMealApplicationsMasterFillerID
		{
			get; set;
		}
		public string OrderMealApplicationsMasterFillerName
		{
			get; set;
		}
		public string OrderMealApplicationsMasterApplicationDate
		{
			get; set;
		}
	}
	public class InsertOrderMealApplicationsMaster : OrderMealApplicationsMasterAllField
	{
	}
	public class UpdateOrderMealApplicationsMaster : OrderMealApplicationsMasterAllField
	{
	}
	public class DeleteOrderMealApplicationsMaster : OrderMealApplicationsMasterAllField
	{
	}
	public class GetOrderMealApplicationsMaster : OrderMealApplicationsMasterAllField
	{
	}

	public class OrderMealApplicationsDetailAllField
	{
		public int OrderMealApplicationsDetailRequisitionID
		{
			get; set;
		}
		public string OrderMealApplicationsDetailApplicantID
		{
			get; set;
		}
		public string OrderMealApplicationsDetailApplicantName
		{
			get; set;
		}
		public string OrderMealApplicationsDetailStore
		{
			get; set;
		}
		public string OrderMealApplicationsDetailMeal
		{
			get; set;
		}
		public int OrderMealApplicationsDetailPrice
		{
			get; set;
		}
		public string OrderMealApplicationsDetailAreaName
		{
			get; set;
		}
		public bool OrderMealApplicationsDetailIsCancel
		{
			get; set;
		}
		public string OrderMealApplicationsDetailOrderDate
		{
			get; set;
		}
		public string OrderMealApplicationsDetailType
		{
			get; set;
		}
		public bool OrderMealApplicationsDetailFinished
		{
			get; set;
		}
		public int OrderMealApplicationsDetailDetailID
		{
			get; set;
		}
	}
	public class InsertOrderMealApplicationsDetail : OrderMealApplicationsDetailAllField
	{
	}
	public class UpdateOrderMealApplicationsDetail : OrderMealApplicationsDetailAllField
	{
	}
	public class GetOrderMealApplicationsDetail : OrderMealApplicationsDetailAllField
	{
	}
	public class DeleteOrderMealApplicationsDetail : OrderMealApplicationsDetailAllField
	{
	}
}
