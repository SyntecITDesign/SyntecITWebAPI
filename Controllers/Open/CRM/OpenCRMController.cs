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
using System.Collections.Generic;

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

		[Route( "UpsertUnStableIndexV2" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertUnStableIndexV2( [FromBody] SynService_UnStableIndexV2 SynService_UnStableIndexV2Parameter )
		{

			bool bResult = m_publicCRMHandler.UpsertUnStableIndexV2( SynService_UnStableIndexV2Parameter );

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

		[Route( "UpsertMachineInfo" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertMachineInfo( [FromBody] SynService_MachineInfo SynService_MachineInfoParameter )
		{

			bool bResult = m_publicCRMHandler.UpsertMachineInfo( SynService_MachineInfoParameter );

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

		[Route( "UpsertDailyRecord" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertDailyRecord( [FromBody] List<SynService_DailyRecord> SynService_DailyRecordParameterList )
		{
			string errorList = "";
			foreach(var SynService_DailyRecordParameter in SynService_DailyRecordParameterList)
			{
				bool bResult = m_publicCRMHandler.UpsertDailyRecord( SynService_DailyRecordParameter );
				if(!bResult)
				{
					//m_responseHandler.Code = ErrorCodeList.Param_Error;
					errorList += SynService_DailyRecordParameter.serial_number + ",";
				}
			}

			if(errorList != "")
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
				m_responseHandler.Content = errorList;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "UpsertEncryption" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertEncryption( [FromBody] SynSerivce_Encryption SynService_EncryptionParameter )
		{

			bool bResult = m_publicCRMHandler.UpsertEncryption( SynService_EncryptionParameter );

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


		[Route( "UpsertHardwareInfo" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertHardwareInfo( [FromBody] List<SynService_HardwareInfo> SynService_HardwareInfoParameterList )
		{
			string errorList = "";
			foreach(var SynService_HardwareInfoParameter in SynService_HardwareInfoParameterList)
			{
				bool bResult = m_publicCRMHandler.UpsertHardwareInfo( SynService_HardwareInfoParameter );
				if(!bResult)
				{
					//m_responseHandler.Code = ErrorCodeList.Param_Error;
					errorList += SynService_HardwareInfoParameter.serial_number + ",";
				}
			}

			if(errorList != "")
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
				m_responseHandler.Content = errorList;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "UpsertAlarmRecordEvent" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertAlarmRecordEvent( [FromBody] List<SynService_AlarmRecordEvent> SynService_AlarmRecordEventParameterList )
		{
			string errorList = "";
			foreach(var SynService_AlarmRecordEventParameter in SynService_AlarmRecordEventParameterList)
			{
				bool bResult = m_publicCRMHandler.UpsertAlarmRecordEvent( SynService_AlarmRecordEventParameter );
				if(!bResult)
				{
					//m_responseHandler.Code = ErrorCodeList.Param_Error;
					errorList += SynService_AlarmRecordEventParameter.serial_number + ",";
				}
			}

			if(errorList != "")
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
				m_responseHandler.Content = errorList;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "UpsertAlarmRecordData" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertAlarmRecordData( [FromBody] List<SynService_AlarmRecordData> SynService_AlarmRecordDataParameterList )
		{
			string errorList = "";
			foreach(var SynService_AlarmRecordDataParameter in SynService_AlarmRecordDataParameterList)
			{
				bool bResult = m_publicCRMHandler.UpsertAlarmRecordData( SynService_AlarmRecordDataParameter );
				if(!bResult)
				{
					//m_responseHandler.Code = ErrorCodeList.Param_Error;
					errorList += SynService_AlarmRecordDataParameter.serial_number + ",";
				}
			}

			if(errorList != "")
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
				m_responseHandler.Content = errorList;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}



		[Route( "UpsertExceptionLog" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertExceptionLog( [FromBody] List<SynService_ExceptionLog> SynService_ExceptionLogParameterList )
		{
			string errorList = "";
			foreach(var SynService_ExceptionLogParameter in SynService_ExceptionLogParameterList)
			{
				bool bResult = m_publicCRMHandler.UpsertExceptionLog( SynService_ExceptionLogParameter );
				if(!bResult)
				{
					//m_responseHandler.Code = ErrorCodeList.Param_Error;
					errorList += SynService_ExceptionLogParameter.serial_number + ",";
				}
			}

			if(errorList != "")
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
				m_responseHandler.Content = errorList;
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
		private PublicCRMHandler m_publicCRMHandler = new PublicCRMHandler();

		#endregion Private Fields
	}
}
