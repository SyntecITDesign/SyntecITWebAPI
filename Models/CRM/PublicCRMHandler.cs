﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.CRM;
using SyntecITWebAPI.Common.MailRelated;
using SyntecITWebAPI.Common.MailRelated.User;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.ParameterModels.Mail;
using SyntecITWebAPI.ParameterModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using SyntecITWebAPI.ParameterModels.GAS.PersonnelInfo;

namespace SyntecITWebAPI.Models
{
	internal class PublicCRMHandler
	{
		#region Internal Methods

		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url
		internal JArray GetCRMOSSFileLink(GetCRMOSSFileLink GetCRMOSSFileLinkParameter)
		{

			DataTable dtResult = m_publicCRMDBManager.GetCRMOSSFileLink(GetCRMOSSFileLinkParameter);

			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}

		internal bool UpsertAlarm(SynService_Alarm SynService_AlarmParameter)
		{

			bool bResult = m_publicCRMDBManager.UpsertAlarm(SynService_AlarmParameter);

			return bResult;
		}

		internal bool UpsertCNCStateLog(SynService_CNCStateLog SynService_CNCStateLogParameter)
		{

			bool bResult = m_publicCRMDBManager.UpsertCNCStateLog(SynService_CNCStateLogParameter);

			return bResult;
		}

		internal bool UpsertCRM(SynService_CRM SynService_CRMParameter)
		{

			bool bResult = m_publicCRMDBManager.UpsertCRM(SynService_CRMParameter);

			return bResult;
		}

		internal bool UpsertExceptionLog(SynService_ExceptionLog SynService_ExceptionLogParameter)
		{

			bool bResult = m_publicCRMDBManager.UpsertExceptionLog(SynService_ExceptionLogParameter);

			return bResult;
		}

		internal bool UpsertUnStableIndex(SynService_UnStableIndex SynService_UnStableIndexParameter)
		{

			bool bResult = m_publicCRMDBManager.UpsertUnStableIndex(SynService_UnStableIndexParameter);

			return bResult;
		}

		internal bool UpsertUnStableIndexV2( SynService_UnStableIndexV2 SynService_UnStableIndexV2Parameter )
		{

			bool bResult = m_publicCRMDBManager.UpsertUnStableIndexV2( SynService_UnStableIndexV2Parameter );

			return bResult;
		}

		internal bool UpsertEventTypeList(SynService_EventTypeList SynService_EventTypeListParameter)
		{

			bool bResult = m_publicCRMDBManager.UpsertEventTypeList(SynService_EventTypeListParameter);

			return bResult;
		}

		internal bool UpsertStopTypeList(SynService_StopTypeList SynService_StopTypeListParameter)
		{

			bool bResult = m_publicCRMDBManager.UpsertStopTypeList(SynService_StopTypeListParameter);

			return bResult;
		}

		internal bool UpsertAlarmHistory(SynService_AlarmHistory SynServiceAlarmHistoryParameter)
		{

			bool bResult = m_publicCRMDBManager.UpsertAlarmHistory(SynServiceAlarmHistoryParameter);

			return bResult;
		}

		internal bool UpsertEventHistory(SynService_EventHistory SynServiceEventHistoryParameter)
		{

			bool bResult = m_publicCRMDBManager.UpsertEventHistory(SynServiceEventHistoryParameter);

			return bResult;
		}

        internal JArray GetCRMOSSFileLink(GetPersonDept getPersonDeptParameter)
        {
            throw new NotImplementedException();
        }

		internal bool UpsertMachineInfo( SynService_MachineInfo SynService_MachineInfoParameter )
		{

			bool bResult = m_publicCRMDBManager.UpsertMachineInfo( SynService_MachineInfoParameter );

			return bResult;
		}

		internal bool UpsertDailyRecord( SynService_DailyRecord SynService_DailyRecordParameter )
		{

			bool bResult = m_publicCRMDBManager.UpsertDailyRecord( SynService_DailyRecordParameter );

			return bResult;
		}

		internal bool UpsertEncryption( SynSerivce_Encryption SynService_EncryptionParameter )
		{

			bool bResult = m_publicCRMDBManager.UpsertEncryption( SynService_EncryptionParameter );

			return bResult;
		}
		internal bool UpsertHardwareInfo( SynService_HardwareInfo SynService_HardwareInfoParameter )
		{

			bool bResult = m_publicCRMDBManager.UpsertHardwareInfo( SynService_HardwareInfoParameter );

			return bResult;
		}

		internal bool UpsertAlarmRecordEvent( SynService_AlarmRecordEvent SynService_AlarmRecordEventParameter )
		{

			bool bResult = m_publicCRMDBManager.UpsertAlarmRecordEvent( SynService_AlarmRecordEventParameter );

			return bResult;
		}

		internal bool UpsertAlarmRecordData( SynService_AlarmRecordData SynService_AlarmRecordDataParameter )
		{

			bool bResult = m_publicCRMDBManager.UpsertAlarmRecordData( SynService_AlarmRecordDataParameter );

			return bResult;
		}

		internal JArray GetUsedTime( GetUsedTime GetUsedTimeParameter )
		{

			DataTable dtResult = m_publicCRMDBManager.GetUsedTime( GetUsedTimeParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertCRMUploadList( SynService_CRMUpload SynService_CRMUploadListParameter )
		{

			bool bResult = m_publicCRMDBManager.UpsertCRMUploadList( SynService_CRMUploadListParameter );

			return bResult;
		}

		internal bool UpsertCRMPARA( SynService_CRMPARA SynService_CRMPARAParameter )
		{

			bool bResult = m_publicCRMDBManager.UpsertCRMPARA( SynService_CRMPARAParameter );

			return bResult;
		}

		internal bool UpsertFunctionLog( SynService_FunctionLog SynService_FunctionLogParameter )
		{

			bool bResult = m_publicCRMDBManager.UpsertFunctionLog( SynService_FunctionLogParameter );

			return bResult;
		}

		#endregion Internal Methods

		#region Private Fields

		private PublicCRMDBManager m_publicCRMDBManager = new PublicCRMDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
