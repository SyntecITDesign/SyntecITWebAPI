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

		[Route( "InsertMeetingRoomApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMeetingRoomApplicationsMaster( [FromBody] InsertMeetingRoomApplicationsMaster InsertMeetingRoomApplicationsMasterParameter )
		{

			bool bResult = m_publicMeetigRoomHandler.InsertMeetingRoomApplicationsMaster( InsertMeetingRoomApplicationsMasterParameter );

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
		[Route( "DeleteMeetingRoomApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMeetingRoomApplicationsMaster( [FromBody] DeleteMeetingRoomApplicationsMaster DeleteMeetingRoomApplicationsMasterParameter )
		{

			bool bResult = m_publicMeetigRoomHandler.DeleteMeetingRoomApplicationsMaster( DeleteMeetingRoomApplicationsMasterParameter );

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
		[Route( "UpdateMeetingRoomApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateMeetingRoomApplicationsMaster( [FromBody] UpdateMeetingRoomApplicationsMaster UpdateMeetingRoomApplicationsMasterParameter )
		{

			bool bResult = m_publicMeetigRoomHandler.UpdateMeetingRoomApplicationsMaster( UpdateMeetingRoomApplicationsMasterParameter );

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
		[Route( "GetMeetingRoomApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMeetingRoomApplicationsMaster( [FromBody] GetMeetingRoomApplicationsMaster GetMeetingRoomApplicationsMasterParameter )
		{

			JArray result = m_publicMeetigRoomHandler.GetMeetingRoomApplicationsMaster( GetMeetingRoomApplicationsMasterParameter );

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
		[Route( "InsertMRBS" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMRBS( [FromBody] InsertMRBS InsertMRBSParameter )
		{

			bool bResult = m_publicMeetigRoomHandler.InsertMRBS( InsertMRBSParameter );

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
		[Route( "DeleteMRBS" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMRBS( [FromBody] DeleteMRBS DeleteMRBSParameter )
		{

			bool bResult = m_publicMeetigRoomHandler.DeleteMRBS( DeleteMRBSParameter );

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
		[Route( "GetMRBS" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMRBS( [FromBody] GetMRBS GetMRBSParameter )
		{

			JArray result = m_publicMeetigRoomHandler.GetMRBS( GetMRBSParameter );

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

		[Route( "UpdateMRBS" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateMRBS( [FromBody] UpdateMRBS UpdateMRBSParameter )
		{

			bool bResult = m_publicMeetigRoomHandler.UpdateMRBS( UpdateMRBSParameter );

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

		[Route( "GetUsingMeetingRoom" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUsingMeetingRoom( [FromBody] GetUsingMeetingRoom GetUsingMeetingRoomParameter )
		{

			JArray result = m_publicMeetigRoomHandler.GetUsingMeetingRoom( GetUsingMeetingRoomParameter );

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
		private PublicMeetingRoomHandler m_publicMeetigRoomHandler = new PublicMeetingRoomHandler();

		#endregion Private Fields
	}
}
