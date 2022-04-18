using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.ApplyCarBooking;
using SyntecITWebAPI.ParameterModels.GAS.ApplyCarBooking;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.ApplyCarBooking
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/ApplyCarBooking" )]
	[ApiController]
	public class OpenApplyCarBookingController : ControllerBase
	{
		#region Public Methods

		[Route( "GetCarBookingApplicationsMaster" )]
		[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetCarBookingApplicationsMaster( [FromBody] GetCarBookingApplicationsMaster GetCarBookingApplicationsMasterParameter )
		{
			JArray result = m_publicCarBookingHandler.GetCarBookingApplicationsMaster( GetCarBookingApplicationsMasterParameter );

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

		[Route( "InsertCarBookingApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertCarBookingApplicationsMaster( [FromBody] InsertCarBookingApplicationsMaster InsertCarBookingApplicationsMasterParameter )
		{

			bool bResult = m_publicCarBookingHandler.InsertCarBookingApplicationsMaster( InsertCarBookingApplicationsMasterParameter );

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

		[Route( "DeleteCarBookingApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteCarBookingApplicationsMaster( [FromBody] DeleteCarBookingApplicationsMaster DeleteCarBookingApplicationsMasterParameter )
		{

			bool bResult = m_publicCarBookingHandler.DeleteCarBookingApplicationsMaster( DeleteCarBookingApplicationsMasterParameter );

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
		private PublicApplyCarBookingHandler m_publicCarBookingHandler = new PublicApplyCarBookingHandler();

		#endregion Private Fields
	}
}
