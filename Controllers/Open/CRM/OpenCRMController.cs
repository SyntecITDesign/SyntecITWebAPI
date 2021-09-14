using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models;
using SyntecITWebAPI.Filter;
using SyntecITWebAPI.Static;
using SyntecITWebAPI.Utility;
using SyntecITWebAPI.ParameterModels.CRM;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Open.User
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/CRM" )]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route("GetCRMOSSFileLink")]
		[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetCRMOSSFileLink([FromBody] GetCRMOSSFileLink GetCRMOSSFileLinkParameter)
		{

			JArray result = m_publicCRMHandler.GetCRMOSSFileLink(GetCRMOSSFileLinkParameter);

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

		[Route("UpsertAlarm")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertAlarm([FromBody] SynService_Alarm SynService_AlarmParameter)
		{

			bool bResult = m_publicCRMHandler.UpsertAlarm(SynService_AlarmParameter);

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

		[Route("UpsertCNCStateLog")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertCNCStateLog([FromBody] SynService_CNCStateLog SynService_CNCStateLogParameter)
		{

			bool bResult = m_publicCRMHandler.UpsertCNCStateLog(SynService_CNCStateLogParameter);

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

		[Route("UpsertCRM")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertCRM([FromBody] SynService_CRM SynService_CRMParameter)
		{

			bool bResult = m_publicCRMHandler.UpsertCRM(SynService_CRMParameter);

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
		
		[Route("UpsertExceptionLog")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertExceptionLog([FromBody] SynService_ExceptionLog SynService_ExceptionLogParameter)
		{

			bool bResult = m_publicCRMHandler.UpsertExceptionLog(SynService_ExceptionLogParameter);

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

		[Route("UpsertUnStableIndex")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertUnStableIndex([FromBody] SynService_UnStableIndex SynService_UnStableIndexParameter)
		{

			bool bResult = m_publicCRMHandler.UpsertUnStableIndex(SynService_UnStableIndexParameter);

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

		[Route("UpsertEventTypeList")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertEventTypeList([FromBody] SynService_EventTypeList SynService_EventTypeListParameter)
		{

			bool bResult = m_publicCRMHandler.UpsertEventTypeList(SynService_EventTypeListParameter);

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

		[Route("UpsertStopTypeList")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertStopTypeList([FromBody] SynService_StopTypeList SynService_StopTypeListParameter)
		{

			bool bResult = m_publicCRMHandler.UpsertStopTypeList(SynService_StopTypeListParameter);

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

		[Route("UpsertAlarmHistory")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertAlarmHistory([FromBody] SynService_AlarmHistory SynServiceAlarmHistoryParameter)
		{

			bool bResult = m_publicCRMHandler.UpsertAlarmHistory(SynServiceAlarmHistoryParameter);

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

		[Route("UpsertEventHistory")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertEventHistory([FromBody] SynService_EventHistory SynServiceEventHistoryParameter)
		{

			bool bResult = m_publicCRMHandler.UpsertEventHistory(SynServiceEventHistoryParameter);

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
		private PublicCRMHandler m_publicCRMHandler = new PublicCRMHandler();

		#endregion Private Fields
	}
}
