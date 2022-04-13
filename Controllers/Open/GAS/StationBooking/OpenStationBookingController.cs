using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.StationBooking;
using SyntecITWebAPI.ParameterModels.GAS.StationBooking;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Controllers.Open.GAS.StationBooking
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/StationBooking" )]
	[ApiController]
	public class OpenModuleAccessController : ControllerBase
	{
		#region Public Methods

		
		[Route( "InsertStationApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertStationApplicationsMaster( [FromBody] InsertStationApplicationsMaster InsertStationApplicationsMasterParameter )
		{

			bool bResult = m_publicStationBookingHandler.InsertStationApplicationsMaster( InsertStationApplicationsMasterParameter );

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
		[Route( "DeleteStationApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteStationApplicationsMaster( [FromBody] DeleteStationApplicationsMaster DeleteStationApplicationsMasterParameter )
		{

			bool bResult = m_publicStationBookingHandler.DeleteStationApplicationsMaster( DeleteStationApplicationsMasterParameter );

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
		[Route( "UpdateStationApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateStationApplicationsMaster( [FromBody] UpdateStationApplicationsMaster UpdateStationApplicationsMasterParameter )
		{

			bool bResult = m_publicStationBookingHandler.UpdateStationApplicationsMaster( UpdateStationApplicationsMasterParameter );

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
		[Route( "GetStationApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetStationApplicationsMaster( [FromBody] GetStationApplicationsMaster GetStationApplicationsMasterParameter )
		{

			JArray result = m_publicStationBookingHandler.GetStationApplicationsMaster( GetStationApplicationsMasterParameter );

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

		[Route( "GetUsingStation" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUsingMeetingRoom( [FromBody] GetUsingStation GetUsingStationParameter )
		{

			JArray result = m_publicStationBookingHandler.GetUsingStation( GetUsingStationParameter );

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

		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicStationBookingHandler m_publicStationBookingHandler = new PublicStationBookingHandler();

		#endregion Private Fields
	}
}
