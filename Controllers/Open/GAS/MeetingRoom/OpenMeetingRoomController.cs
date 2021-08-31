using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.MeetingRoom;
using SyntecITWebAPI.ParameterModels.GAS.MeetingRoom;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Controllers.Open.GAS.MeetingRoom
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/MeetingRoom" )]
	[ApiController]
	public class OpenStationeryController : ControllerBase
	{
		#region Public Methods

		[Route( "GetMeetingRoom" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetMeetingRoom()
		{
			JArray result = m_publicMeetigRoomHandler.GetMeetingRoom();

			if(result == null)
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "UpsertMeetingRoom" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertMeetingRoom( [FromBody] UpsertMeetingRoom UpsertMeetingRoomParameter )
		{

			bool bResult = m_publicMeetigRoomHandler.UpsertMeetingRoom( UpsertMeetingRoomParameter );

			if(!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "DeleteMeetingRoom" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMeetingRoom( [FromBody] DeleteMeetingRoom DeleteMeetingRoomParameter )
		{

			bool bResult = m_publicMeetigRoomHandler.DeleteMeetingRoom( DeleteMeetingRoomParameter );

			if(!bResult)
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
		private PublicMeetingRoomHandler m_publicMeetigRoomHandler = new PublicMeetingRoomHandler();

		#endregion Private Fields
	}
}
