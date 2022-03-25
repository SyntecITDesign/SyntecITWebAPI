using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.LatestNews;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.CRM;
using Syntec.JiraHelper;
using System.Net;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicCRMDBManager : AbstractDBManager
	{
		#region Internal Methods


		internal DataTable GetCRMOSSFileLink(GetCRMOSSFileLink GetCRMOSSFileLinkParameter)
		{
			int startAt = 0;
			int maxResults = 1000;
			string allCRMTickets = "('";
			while(true)
			{
				string jqlResult = JiraHelper.GetIssueByJQL( "CRM_ROBOT", "Syntec1234", "project = CRM  AND status changed from 服務處理中 to closed during (\"" + GetCRMOSSFileLinkParameter.start_time + "\",\"" + GetCRMOSSFileLinkParameter.end_time + "\")  and 服務類別 !~  \"业务拜访\"&maxResults=" + maxResults + "&startAt=" + startAt + "&fields=customfield_13340" );
				Root jo = JsonConvert.DeserializeObject<Root>( jqlResult );
				foreach(var CSNumber in jo.issues)
				{
					allCRMTickets += CSNumber.fields.customfield_13340 + "','";
				}
				//檢查是否maxResults > total
				maxResults = jo.maxResults;
				startAt = jo.startAt;
				int total = jo.total;
				if(total > (maxResults + startAt))
				{
					//修改startAt繼續往下跑JQL
					startAt += maxResults;
					continue;
				}
				else 
				{
					allCRMTickets = allCRMTickets.Substring( 0, allCRMTickets.Length - 3 );//去掉最後一個','
					allCRMTickets += "')";
					break;
				}
			}
			string sql = m_dbSQL.GetCRMOSSFileLink.Replace( "{CRMID_REPLACE}", allCRMTickets );
			List<object> SQLParameterList = new List<object>()
			{
				"%"+GetCRMOSSFileLinkParameter.title+"%"
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray());
			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool UpsertAlarm(SynService_Alarm SynService_AlarmParameter)
		{
			string sql = m_dbSQL.UpsertAlarm;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_AlarmParameter.serial_number,
				SynService_AlarmParameter.time,
				SynService_AlarmParameter.alarm_id,
				SynService_AlarmParameter.alarm_info,
				SynService_AlarmParameter.duration
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpsertCNCStateLog(SynService_CNCStateLog SynService_CNCStateLogParameter)
		{
			string sql = m_dbSQL.UpsertCNCStateLog;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_CNCStateLogParameter.serial_number,
				SynService_CNCStateLogParameter.time,
				SynService_CNCStateLogParameter.state_type_id
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpsertCRM(SynService_CRM SynService_CRMParameter)
		{
			string sql = m_dbSQL.UpsertCRM;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_CRMParameter.serial_number,
				SynService_CRMParameter.crm_number,
				SynService_CRMParameter.first_class_id,
				SynService_CRMParameter.second_class_id,
				SynService_CRMParameter.crm_start_time,
				SynService_CRMParameter.crm_end_time
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpsertExceptionLog(SynService_ExceptionLog SynService_ExceptionLogParameter)
		{
			string sql = m_dbSQL.UpsertExceptionLog;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_ExceptionLogParameter.serial_number,
				SynService_ExceptionLogParameter.exception_type_id,
				SynService_ExceptionLogParameter.version,
				SynService_ExceptionLogParameter.time,
				SynService_ExceptionLogParameter.exception_info,
				SynService_ExceptionLogParameter.physical_memory,
				SynService_ExceptionLogParameter.diskA_space,
				SynService_ExceptionLogParameter.diskC_space
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpsertUnStableIndex(SynService_UnStableIndex SynService_UnStableIndexParameter)
		{
			string sql = m_dbSQL.UpsertUnStableIndex;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_UnStableIndexParameter.serial_number,
				SynService_UnStableIndexParameter.time,
				SynService_UnStableIndexParameter.unstable_type_id,
				SynService_UnStableIndexParameter.detail_json
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpsertUnStableIndexV2( SynService_UnStableIndexV2 SynService_UnStableIndexV2Parameter )
		{
			string sql = m_dbSQL.UpsertUnStableIndexV2;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_UnStableIndexV2Parameter.serial_number,
				SynService_UnStableIndexV2Parameter.time,
				SynService_UnStableIndexV2Parameter.is_bootup,
				SynService_UnStableIndexV2Parameter.bootup_time,
				SynService_UnStableIndexV2Parameter.cnc_version,
				SynService_UnStableIndexV2Parameter.first_driver_version,
				SynService_UnStableIndexV2Parameter.second_driver_version,
				SynService_UnStableIndexV2Parameter.detail_json
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool UpsertEventTypeList(SynService_EventTypeList SynService_EventTypeListParameter)
		{
			string sql = m_dbSQL.UpsertEventTypeList;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_EventTypeListParameter.event_type_id,
				SynService_EventTypeListParameter.event_type
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpsertStopTypeList(SynService_StopTypeList SynService_StopTypeListParameter)
		{
			string sql = m_dbSQL.UpsertStopTypeList;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_StopTypeListParameter.stop_type_id,
				SynService_StopTypeListParameter.stop_type
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpsertAlarmHistory(SynService_AlarmHistory SynServiceAlarmHistoryParameter)
		{
			string sql = m_dbSQL.UpsertAlarmHistory;
			List<object> SQLParameterList = new List<object>()
			{
				SynServiceAlarmHistoryParameter.serial_number,
				SynServiceAlarmHistoryParameter.start_time,
				SynServiceAlarmHistoryParameter.end_time,
				SynServiceAlarmHistoryParameter.alarm_id,
				SynServiceAlarmHistoryParameter.alarm_info,
				SynServiceAlarmHistoryParameter.alarm_trigger
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpsertEventHistory(SynService_EventHistory SynServiceEventHistoryParameter)
		{
			string sql = m_dbSQL.UpsertEventHistory;
			List<object> SQLParameterList = new List<object>()
			{
				SynServiceEventHistoryParameter.serial_number,
				SynServiceEventHistoryParameter.start_time,
				SynServiceEventHistoryParameter.end_time,
				SynServiceEventHistoryParameter.event_type_id,
				SynServiceEventHistoryParameter.stop_type_id
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpsertMachineInfo( SynService_MachineInfo SynService_MachineInfoParameter )
		{
			string sql = m_dbSQL.UpsertMachineInfo;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_MachineInfoParameter.crm_number,
				SynService_MachineInfoParameter.serial_number,
				SynService_MachineInfoParameter.machine_model,
				SynService_MachineInfoParameter.machine_type,
				SynService_MachineInfoParameter.cnc_version,
				SynService_MachineInfoParameter.prd_version,
				SynService_MachineInfoParameter.cpu_board,
				SynService_MachineInfoParameter.fpga,
				SynService_MachineInfoParameter.image_version,
				SynService_MachineInfoParameter.option,
				SynService_MachineInfoParameter.machine_id,
				SynService_MachineInfoParameter.maker_model,
				SynService_MachineInfoParameter.maker_sn,
				SynService_MachineInfoParameter.maker_date,
				SynService_MachineInfoParameter.developer_sn,
				SynService_MachineInfoParameter.phone,
				SynService_MachineInfoParameter.use_limit,
				SynService_MachineInfoParameter.maker_id,
				SynService_MachineInfoParameter.plc_version,
				SynService_MachineInfoParameter.axis,
				SynService_MachineInfoParameter.drive_model,
				SynService_MachineInfoParameter.drive_version,
				SynService_MachineInfoParameter.motor_model,
				SynService_MachineInfoParameter.enc_model,
				SynService_MachineInfoParameter.enc_version,
				SynService_MachineInfoParameter.enc_resolution,
				SynService_MachineInfoParameter.enc2_model,
				SynService_MachineInfoParameter.enc2_version,
				SynService_MachineInfoParameter.enc2_resolution,
				SynService_MachineInfoParameter.addon_model,
				SynService_MachineInfoParameter.addon_version,
				SynService_MachineInfoParameter.drive_sn,
				SynService_MachineInfoParameter.motor_sn,
				SynService_MachineInfoParameter.enc_sn,
				SynService_MachineInfoParameter.enc2_sn,
				SynService_MachineInfoParameter.addon_sn
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool UpsertDailyRecord( SynService_DailyRecord SynService_DailyRecordParameter )
		{
			string sql = m_dbSQL.UpsertDailyRecord;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_DailyRecordParameter.serial_number,
				SynService_DailyRecordParameter.time,
				SynService_DailyRecordParameter.detail_json,
				SynService_DailyRecordParameter.crm_number,
				SynService_DailyRecordParameter.drv_model,
				SynService_DailyRecordParameter.drv_SN
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool UpsertEncryption( SynSerivce_Encryption SynService_EncryptionParameter )
		{
			string sql = m_dbSQL.UpsertEncryption;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_EncryptionParameter.serial_number,
				SynService_EncryptionParameter.oplog_encryption_time
			};
			bool bResult = m_DWHdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool UpsertHardwareInfo( SynService_HardwareInfo SynService_HardwareInfoParameter )
		{
			string sql = m_dbSQL.UpsertHardwareInfo;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_HardwareInfoParameter.serial_number,
				SynService_HardwareInfoParameter.boot_time,
				SynService_HardwareInfoParameter.axis_name,
				SynService_HardwareInfoParameter.drv_type,
				SynService_HardwareInfoParameter.drv_sn,
				SynService_HardwareInfoParameter.motor_sn,
				SynService_HardwareInfoParameter.first_enc_sn,
				SynService_HardwareInfoParameter.second_enc_sn,
				SynService_HardwareInfoParameter.cpu_board,
				SynService_HardwareInfoParameter.fpga,
				SynService_HardwareInfoParameter.cnc_ver,
				SynService_HardwareInfoParameter.image_ver,
				SynService_HardwareInfoParameter.drv_ver,
				SynService_HardwareInfoParameter.first_enc_ver,
				SynService_HardwareInfoParameter.second_enc_ver,


			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool UpsertAlarmRecordEvent( SynService_AlarmRecordEvent SynService_AlarmRecordEventParameter )
		{
			string sql = m_dbSQL.UpsertAlarmRecordEvent;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_AlarmRecordEventParameter.serial_number,
				SynService_AlarmRecordEventParameter.file_name,
				SynService_AlarmRecordEventParameter.time,
				SynService_AlarmRecordEventParameter.alarm_id

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool UpsertAlarmRecordData( SynService_AlarmRecordData SynService_AlarmRecordDataParameter )
		{
			string sql = m_dbSQL.UpsertAlarmRecordData;
			List<object> SQLParameterList = new List<object>()
			{
				SynService_AlarmRecordDataParameter.serial_number,
				SynService_AlarmRecordDataParameter.file_name,
				SynService_AlarmRecordDataParameter.time,
				SynService_AlarmRecordDataParameter.detail_json

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		#endregion Internal Methods
	}
}
