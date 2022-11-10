using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.GuestGift;
using SyntecITWebAPI.Models.GAS.GuestGift;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.GuestGift
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/GuestGift" )]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route( "InsertGuestGiftType" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertGuestGiftType( [FromBody] InsertGuestGiftType InsertGuestGiftTypeParameter )
		{

			bool bResult = m_publicGuestGiftHandler.InsertGuestGiftType( InsertGuestGiftTypeParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}
		[Route( "DeleteGuestGiftType" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteGuestGiftType( [FromBody] DeleteGuestGiftType DeleteGuestGiftTypeParameter )
		{

			bool bResult = m_publicGuestGiftHandler.DeleteGuestGiftType( DeleteGuestGiftTypeParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}
		[Route( "UpdateGuestGiftTypeInfo" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateGuestGiftTypeInfo( [FromBody] UpdateGuestGiftTypeInfo UpdateGuestGiftTypeInfoParameter )
		{

			bool bResult = m_publicGuestGiftHandler.UpdateGuestGiftTypeInfo( UpdateGuestGiftTypeInfoParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}
		[Route( "GetGuestGiftTypeInfo" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetGuestGiftTypeInfo( [FromBody] GetGuestGiftTypeInfo GetGuestGiftTypeInfoParameter )
		{

			JArray result = m_publicGuestGiftHandler.GetGuestGiftTypeInfo( GetGuestGiftTypeInfoParameter );

			if( result == null )
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "UpsertGuestGiftQuantityInfo" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertGuestGiftQuantityInfo( [FromBody] UpsertGuestGiftQuantityInfo UpsertGuestGiftQuantityInfoParameter )
		{

			bool bResult = m_publicGuestGiftHandler.UpsertGuestGiftQuantityInfo( UpsertGuestGiftQuantityInfoParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}
		[Route( "DeleteGuestGiftQuantity" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteGuestGiftQuantity( [FromBody] DeleteGuestGiftQuantity DeleteGuestGiftQuantityParameter )
		{

			bool bResult = m_publicGuestGiftHandler.DeleteGuestGiftQuantity( DeleteGuestGiftQuantityParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}
		[Route( "GetGuestGiftQuantityInfo" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetGuestGiftQuantityInfo( [FromBody] GetGuestGiftQuantityInfo GetGuestGiftQuantityInfoParameter )
		{

			JArray result = m_publicGuestGiftHandler.GetGuestGiftQuantityInfo( GetGuestGiftQuantityInfoParameter );

			if( result == null )
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "InsertGuestGiftOrder" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertGuestGiftOrder( [FromBody] InsertGuestGiftOrder InsertGuestGiftOrderParameter )
		{

			bool bResult = m_publicGuestGiftHandler.InsertGuestGiftOrder( InsertGuestGiftOrderParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}
		[Route( "GetGuestGiftOrderList" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetGuestGiftOrderList( [FromBody] GetGuestGiftOrderList GetGuestGiftOrderListParameter )
		{

			JArray result = m_publicGuestGiftHandler.GetGuestGiftOrderList( GetGuestGiftOrderListParameter );

			if( result == null )
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}
		[Route( "DeleteGuestGiftOrder" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteGuestGiftOrder( [FromBody] DeleteGuestGiftOrder DeleteGuestGiftOrderParameter )
		{

			bool bResult = m_publicGuestGiftHandler.DeleteGuestGiftOrder( DeleteGuestGiftOrderParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}
		[Route( "UpdateGuestGiftOrder" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateGuestGiftOrder( [FromBody] UpdateGuestGiftOrder UpdateGuestGiftOrderParameter )
		{

			bool bResult = m_publicGuestGiftHandler.UpdateGuestGiftOrder( UpdateGuestGiftOrderParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "InsertGuestGiftOrderDetail" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertGuestGiftOrderListDetail( [FromBody] InsertGuestGiftOrderListDetail InsertGuestGiftOrderListDetailParameter )
		{

			bool bResult = m_publicGuestGiftHandler.InsertGuestGiftOrderListDetail( InsertGuestGiftOrderListDetailParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}
		[Route( "GetGuestGiftOrderListDetail" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetGuestGiftOrderListDetail( [FromBody] GetGuestGiftOrderListDetail GetGuestGiftOrderListDetailParameter )
		{

			JArray result = m_publicGuestGiftHandler.GetGuestGiftOrderListDetail( GetGuestGiftOrderListDetailParameter );

			if( result == null )
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "InsertGuestReceptionApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertGuestReceptionApplicationsMaster( [FromBody] InsertGuestReceptionApplicationsMaster InsertGuestReceptionApplicationsMasterParameter )
		{

			bool bResult = m_publicGuestGiftHandler.InsertGuestReceptionApplicationsMaster( InsertGuestReceptionApplicationsMasterParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "GetGuestReceptionApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetGuestReceptionApplicationsMaster( [FromBody] GetGuestReceptionApplicationsMaster GetGuestReceptionApplicationsMasterParameter )
		{

			JArray result = m_publicGuestGiftHandler.GetGuestReceptionApplicationsMaster( GetGuestReceptionApplicationsMasterParameter );

			if( result == null )
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "UpdateGuestReceptionApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateGuestReceptionApplicationsMaster( [FromBody] UpdateGuestReceptionApplicationsMaster UpdateGuestReceptionApplicationsMasterParameter )
		{

			bool bResult = m_publicGuestGiftHandler.UpdateGuestReceptionApplicationsMaster( UpdateGuestReceptionApplicationsMasterParameter );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}


		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicVisitorRegistrationHandler m_publicGuestGiftHandler = new PublicVisitorRegistrationHandler();

		#endregion Private Fields
	}
}
