using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.PersonalInfo;
using SyntecITWebAPI.ParameterModels.GAS.PersonalInfo;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Controllers.Open.GAS.PersonalInfo
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/PersonalInfo" )]
	[ApiController]
	public class OpenPeronsalInfoController : ControllerBase
	{
		#region Public Methods

		[Route( "GetPersonalInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetPersonalInfo( [FromBody] GetPersonalInfo GetPersonalInfoParameter )
		{
			JArray result = m_publicPersonalInfoHandler.QueryPersonalInfo( GetPersonalInfoParameter );

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

		[Route( "GetFuzzyPersonalInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetFuzzyPersonalInfo( [FromBody] GetFuzzyPersonalInfo GetFuzzyPersonalInfoParameter )
		{
			JArray result = m_publicPersonalInfoHandler.GetFuzzyPersonalInfo( GetFuzzyPersonalInfoParameter );

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

		[Route( "GetPersonalInfoByNameOrg" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetPersonalInfoByNameOrg( [FromBody] GetPersonalInfoByNameOrg GetPersonalInfoByNameOrgParameter )
		{
			JArray result = m_publicPersonalInfoHandler.GetPersonalInfoByNameOrg( GetPersonalInfoByNameOrgParameter );

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

		[Route( "GetPersonalGASInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetPersonalGASInfo( [FromBody] GetPersonalGASInfo GetPersonalGASInfoParameter )
		{
			JArray result = m_publicPersonalInfoHandler.QueryPersonalGASInfo( GetPersonalGASInfoParameter );

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

		[Route( "UpsertPersonalGASInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertPersonalGASInfo( [FromBody] UpsertPersonalGASInfo UpsertPersonalGASInfoParameter )
		{

			bool bResult = m_publicPersonalInfoHandler.UpsertPersonalGASInfo( UpsertPersonalGASInfoParameter );

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

		[Route( "InsertFreshmanGASInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertFreshmanGASInfo( [FromBody] InsertFreshmanGASInfo InsertFreshmanGASInfoParameter )
		{

			bool bResult = m_publicPersonalInfoHandler.InsertFreshmanGASInfo( InsertFreshmanGASInfoParameter );

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

		[Route( "GetProcessingInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetProcessingInfo( [FromBody] GetProcessingInfo GetProcessingInfoParameter )
		{
			JArray result = m_publicPersonalInfoHandler.QueryProcessingInfo( GetProcessingInfoParameter );

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


		[Route( "GetParkingProcessingInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetParkingProcessingInfo( [FromBody] GetParkingProcessingInfo GetParkingProcessingInfoParameter )
		{
			JArray result = m_publicPersonalInfoHandler.GetParkingProcessingInfo( GetParkingProcessingInfoParameter );

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

		[Route( "GetMeetingRoomProcessingInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetMeetingRoomProcessingInfo( [FromBody] GetMeetingRoomProcessingInfo GetMeetingRoomProcessingInfoParameter )
		{
			JArray result = m_publicPersonalInfoHandler.GetMeetingRoomProcessingInfo( GetMeetingRoomProcessingInfoParameter );

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

		[Route( "GetGuestVisitProcessingInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetGuestVisitProcessingInfo( [FromBody] GetGuestVisitProcessingInfo GetGuestVisitProcessingInfoParameter )
		{
			JArray result = m_publicPersonalInfoHandler.GetGuestVisitProcessingInfo( GetGuestVisitProcessingInfoParameter );

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
		private PublicPersonalInfoHandler m_publicPersonalInfoHandler = new PublicPersonalInfoHandler();

		#endregion Private Fields
	}
}
