﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.OrderMeal;
using SyntecITWebAPI.Models.GAS.OrderMeal;
namespace SyntecITWebAPI.Controllers.Open.GAS.OrderMeal
{
	[EnableCors("AllowAllPolicy")]
	[Route("Open/GAS/OrderMeal")]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route("InsertRestaurant")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertRestaurant([FromBody] InsertRestaurant InsertRestaurantParameter)
		{

			bool bResult = m_publicOrderMealHandler.InsertRestaurant(InsertRestaurantParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("DeleteRestaurant")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteRestaurant([FromBody] DeleteRestaurant DeleteRestaurantParameter)
		{

			bool bResult = m_publicOrderMealHandler.DeleteRestaurant(DeleteRestaurantParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("UpdateRestaurantInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateRestaurantInfo([FromBody] UpdateRestaurantInfo UpdateRestaurantInfoParameter)
		{

			bool bResult = m_publicOrderMealHandler.UpdateRestaurantInfo(UpdateRestaurantInfoParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("GetRestaurantInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetRestaurantInfo([FromBody] GetRestaurantInfo GetRestaurantInfoParameter)
		{

			JArray result = m_publicOrderMealHandler.GetRestaurantInfo(GetRestaurantInfoParameter);

			if (result == null)
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok(m_responseHandler.GetResult());
		}

		[Route("GetMenu")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMenu([FromBody] GetMenu GetMenuParameter)
		{

			JArray result = m_publicOrderMealHandler.GetMenu(GetMenuParameter);

			if (result == null)
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("InsertMenuItems")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMenuItems([FromBody] InsertMenuItems InsertMenuItemsParameter)
		{

			bool bResult = m_publicOrderMealHandler.InsertMenuItems(InsertMenuItemsParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("DeleteMenuItems")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMenuItems([FromBody] DeleteMenuItems DeleteMenuItemsParameter)
		{

			bool bResult = m_publicOrderMealHandler.DeleteMenuItems(DeleteMenuItemsParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("UpdateMenu")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateMenu([FromBody] UpdateMenu UpdateMenuParameter)
		{

			bool bResult = m_publicOrderMealHandler.UpdateMenu(UpdateMenuParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}

		[Route("GetMemo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMemo([FromBody] GetMemo GetMemoParameter)
		{

			JArray result = m_publicOrderMealHandler.GetMemo(GetMemoParameter);

			if (result == null)
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("InsertMemo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMemo([FromBody] InsertMemo InsertMemoParameter)
		{

			bool bResult = m_publicOrderMealHandler.InsertMemo(InsertMemoParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}

		[Route("InsertMealCalendar")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMealCalendar([FromBody] InsertMealCalendar InsertMealCalendarParameter)
		{

			bool bResult = m_publicOrderMealHandler.InsertMealCalendar(InsertMealCalendarParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("GetMealCalendar")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMealCalendar([FromBody] GetMealCalendar GetMealCalendarParameter)
		{

			JArray result = m_publicOrderMealHandler.GetMealCalendar(GetMealCalendarParameter);

			if (result == null)
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("DeleteMealCalendar")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMealCalendar([FromBody] DeleteMealCalendar DeleteMealCalendarParameter)
		{
			bool bResult = m_publicOrderMealHandler.DeleteMealCalendar(DeleteMealCalendarParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}

		[Route("GetAreaInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetAreaInfo([FromBody] GetAreaInfo GetAreaInfoParameter)
		{

			JArray result = m_publicOrderMealHandler.GetAreaInfo(GetAreaInfoParameter);

			if (result == null)
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("InsertAreaInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertAreaInfo([FromBody] InsertAreaInfo InsertAreaInfoParameter)
		{

			bool bResult = m_publicOrderMealHandler.InsertAreaInfo(InsertAreaInfoParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("DeleteAreaInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteAreaInfo([FromBody] DeleteAreaInfo DeleteAreaInfoParameter)
		{

			bool bResult = m_publicOrderMealHandler.DeleteAreaInfo(DeleteAreaInfoParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("UpdateAreaInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateAreaInfo([FromBody] UpdateAreaInfo UpdateAreaInfoParameter)
		{
			bool bResult = m_publicOrderMealHandler.UpdateAreaInfo(UpdateAreaInfoParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}

		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicOrderMealHandler m_publicOrderMealHandler = new PublicOrderMealHandler();

		#endregion Private Fields
	}
}