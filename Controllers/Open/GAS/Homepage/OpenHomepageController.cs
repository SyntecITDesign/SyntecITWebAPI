using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.Homepage;
using SyntecITWebAPI.Models.GAS.Homepage;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.Homepage
{
	[EnableCors("AllowAllPolicy")]
	[Route("Open/GAS/Homepage")]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route("InsertHomepageAlertEvents")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertHomepageAlertEvents( [FromBody] InsertHomepageAlertEvents InsertHomepageAlertEventsParameter)
		{

			bool bResult = m_publicHomepageHandler.InsertHomepageAlertEvents(InsertHomepageAlertEventsParameter);

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
		[Route("DeleteHomepageAlertEvents")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteHomepageAlertEvents([FromBody] DeleteHomepageAlertEvents DeleteHomepageAlertEventsParameter)
		{

			bool bResult = m_publicHomepageHandler.DeleteHomepageAlertEvents(DeleteHomepageAlertEventsParameter);

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
		[Route("UpdateHomepageAlertEvents")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateHomepageAlertEvents([FromBody] UpdateHomepageAlertEvents UpdateHomepageAlertEventsParameter)
		{

			bool bResult = m_publicHomepageHandler.UpdateHomepageAlertEvents(UpdateHomepageAlertEventsParameter);

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
		[Route( "GetHomepageAlertEvents_SZ" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetHomepageAlertEvents( [FromBody] GetHomepageAlertEvents_SZ GetHomepageAlertEventsParameter_SZ )
		{

			JArray result = m_publicHomepageHandler.GetHomepageAlertEvents_SZ( GetHomepageAlertEventsParameter_SZ );

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
		[Route("GetHomepageAlertEvents")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetHomepageAlertEvents([FromBody] GetHomepageAlertEvents GetHomepageAlertEventsParameter)
		{

			JArray result = m_publicHomepageHandler.GetHomepageAlertEvents(GetHomepageAlertEventsParameter);

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
		
		
		[Route( "InsertHomepageFinishEvents" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertHomepageFinishEvents( [FromBody] InsertHomepageFinishEvents InsertHomepageFinishEventsParameter )
		{

			bool bResult = m_publicHomepageHandler.InsertHomepageFinishEvents( InsertHomepageFinishEventsParameter );

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
		[Route( "DeleteHomepageFinishEvents" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteHomepageFinishEvents( [FromBody] DeleteHomepageFinishEvents DeleteHomepageFinishEventsParameter )
		{

			bool bResult = m_publicHomepageHandler.DeleteHomepageFinishEvents( DeleteHomepageFinishEventsParameter );

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
		[Route( "UpdateHomepageFinishEvents" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateHomepageFinishEvents( [FromBody] UpdateHomepageFinishEvents UpdateHomepageFinishEventsParameter )
		{

			bool bResult = m_publicHomepageHandler.UpdateHomepageFinishEvents( UpdateHomepageFinishEventsParameter );

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
		[Route( "GetHomepageFinishEvents" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetHomepageFinishEvents( [FromBody] GetHomepageFinishEvents GetHomepageFinishEventsParameter )
		{

			JArray result = m_publicHomepageHandler.GetHomepageFinishEvents( GetHomepageFinishEventsParameter );

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


		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicHomepageHandler m_publicHomepageHandler = new PublicHomepageHandler();

		#endregion Private Fields
	}
}
