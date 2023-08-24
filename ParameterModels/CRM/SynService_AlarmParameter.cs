using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.CRM
{
	public class SynService_Alarm
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public long time
		{
			get; set;
		}

		public string alarm_id
		{
			get; set;
		}

		public string alarm_info
		{
			get; set;
		}

		public int duration
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class SynService_CNCStateLog
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public long time
		{
			get; set;
		}

		public int state_type_id
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class SynService_CRM
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public string crm_number
		{
			get; set;
		}

		public int first_class_id
		{
			get; set;
		}

		public int second_class_id
		{
			get; set;
		}

		public long crm_start_time
		{
			get; set;
		}

		public long crm_end_time
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}


	public class SynService_UnStableIndex
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public long time
		{
			get; set;
		}

		public int unstable_type_id
		{
			get; set;
		}

		public string detail_json
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class SynService_EventTypeList
	{
		#region Public Properties

		public int event_type_id
		{
			get; set;
		}

		public string event_type
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class SynService_StopTypeList
	{
		#region Public Properties

		public int stop_type_id
		{
			get; set;
		}

		public string stop_type
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class SynService_AlarmHistory
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public long start_time
		{
			get; set;
		}

		public long end_time
		{
			get; set;
		}

		public string alarm_id
		{
			get; set;
		}

		public string alarm_info
		{
			get; set;
		}

		public string alarm_trigger
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class SynService_EventHistory
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public long start_time
		{
			get; set;
		}

		public long end_time
		{
			get; set;
		}

		public string event_type_id
		{
			get; set;
		}

		public string stop_type_id
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class GetCRMOSSFileLink
	{
		#region Public Properties

		public string crmid
		{
			get; set;
		}

		public string jiraid
		{
			get; set;
		}

		public string start_time
		{
			get; set;
		}

		public string end_time
		{
			get; set;
		}

		public string url
		{
			get; set;
		}

		public string title
		{
			get; set;
		}

		#endregion Public Properties

	}

	public class SynService_UnStableIndexV2
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public long time
		{
			get; set;
		}

		public int is_bootup
		{
			get; set;
		}

		public long bootup_time
		{
			get; set;
		}

		public string cnc_version
		{
			get; set;
		}

		public string first_driver_version
		{
			get; set;
		}

		public string second_driver_version
		{
			get; set;
		}

		public string detail_json
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class SynService_MachineInfo
	{
		#region Public Properties

		public string crm_number
		{
			get; set;
		}
		public string serial_number
		{
			get; set;
		}
		public string machine_model
		{
			get; set;
		}
		public string machine_type
		{
			get; set;
		}
		public string cnc_version
		{
			get; set;
		}
		public string prd_version
		{
			get; set;
		}
		public string cpu_board
		{
			get; set;
		}
		public string fpga
		{
			get; set;
		}
		public string image_version
		{
			get; set;
		}
		public string option
		{
			get; set;
		}
		public string machine_id
		{
			get; set;
		}
		public string maker_model
		{
			get; set;
		}
		public string maker_sn
		{
			get; set;
		}
		public string maker_date
		{
			get; set;
		}
		public string developer_sn
		{
			get; set;
		}
		public string phone
		{
			get; set;
		}
		public string use_limit
		{
			get; set;
		}
		public string maker_id
		{
			get; set;
		}
		public string plc_version
		{
			get; set;
		}
		public string axis
		{
			get; set;
		}
		public string drive_model
		{
			get; set;
		}
		public string drive_version
		{
			get; set;
		}
		public string motor_model
		{
			get; set;
		}
		public string enc_model
		{
			get; set;
		}
		public string enc_version
		{
			get; set;
		}
		public string enc_resolution
		{
			get; set;
		}
		public string enc2_model
		{
			get; set;
		}
		public string enc2_version
		{
			get; set;
		}
		public string enc2_resolution
		{
			get; set;
		}
		public string addon_model
		{
			get; set;
		}
		public string addon_version
		{
			get; set;
		}
		public string drive_sn
		{
			get; set;
		}
		public string motor_sn
		{
			get; set;
		}
		public string enc_sn
		{
			get; set;
		}
		public string enc2_sn
		{
			get; set;
		}
		public string addon_sn
		{
			get; set;
		}
		public long cons_date
		{
			get; set;
		}
		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class SynService_DailyRecord
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public int sequence
		{
			get; set;
		}

		public long time
		{
			get; set;
		}

		public string detail_json
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}
		public string crm_number
		{
			get; set;
		}

		public string drv_model
		{
			get; set;
		}
		public string drv_SN
		{
			get; set;
		}

		#endregion Public Properties

	}

	public class SynSerivce_Encryption
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public int sequence
		{
			get; set;
		}

		public string oplog_encryption_time
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}


	public class SynService_HardwareInfo
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}
		public long boot_time
		{
			get; set;
		}
		public string axis_name
		{
			get; set;
		}
		public string drv_type
		{
			get; set;
		}
		public string drv_sn
		{
			get; set;
		}
		public string motor_sn
		{
			get; set;
		}
		public string first_enc_sn
		{
			get; set;
		}
		public string second_enc_sn
		{
			get; set;
		}
		public string cpu_board
		{
			get; set;
		}
		public string fpga
		{
			get; set;
		}
		public string cnc_ver
		{
			get; set;
		}
		public string image_ver
		{
			get; set;
		}
		public string drv_ver
		{
			get; set;
		}
		public string first_enc_ver
		{
			get; set;
		}
		public string second_enc_ver
		{
			get; set;
		}
		#endregion Public Properties

	}

	public class SynService_AlarmRecordEvent
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}
		public string file_name
		{
			get; set;
		}
		public long time
		{
			get; set;
		}
		public string alarm_id
		{
			get; set;
		}
		#endregion Public Properties

	}

	public class SynService_AlarmRecordData
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}
		public string file_name
		{
			get; set;
		}
		public long time
		{
			get; set;
		}
		public string detail_json
		{
			get; set;
		}
		#endregion Public Properties

	}

	public class SynService_ExceptionLog
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public int type
		{
			get; set;
		}

		public int sub_type
		{
			get; set;
		}

		public string version
		{
			get; set;
		}

		public long time
		{
			get; set;
		}

		public string exception_info
		{
			get; set;
		}

		public long physical_memory
		{
			get; set;
		}

		public long diskA_space
		{
			get; set;
		}

		public long diskC_space
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class GetUsedTime
	{

		public string SN
		{
			get; set;
		}
		public string Date
		{
			get; set;
		}

	}

	public class SynService_CRMUpload
	{
		#region Public Properties

		public string crm_id
		{
			get; set;
		}
		public string serial_number
		{
			get; set;
		}
		public long used_time
		{
			get; set;
		}
		public string cons_date
		{
			get; set;
		}
		public string modi_date
		{
			get; set;
		}
		#endregion Public Properties

	}

	public class SynService_CRMPARA
	{
		#region Public Properties

		public string crm_number
		{
			get; set;
		}
		public string serial_number
		{
			get; set;
		}
		public string axis_id
		{
			get; set;
		}
		public string axis_name
		{
			get; set;
		}
		public string detail_json
		{
			get; set;
		}
		public string cons_date
		{
			get; set;
		}
		public string modi_date
		{
			get; set;
		}
		#endregion Public Properties

	}

	public class SynService_FunctionLog
	{
		#region Public Properties

		public string crm_number
		{
			get; set;
		}

		public string serial_number
		{
			get; set;
		}

		public int function_no
		{
			get; set;
		}

		public int usage_count
		{
			get; set;
		}

		public string final_setting
		{
			get; set;
		}

		public string final_setting_time
		{
			get; set;
		}

		public string setting_logs
		{
			get; set;
		}

		public long cons_date
		{
			get; set;
		}

		public long modi_date
		{
			get; set;
		}


		#endregion Public Properties

	}

	public class Fields
	{
		public string customfield_13340
		{
			get; set;
		}
	}

	public class Issue
	{
		public string expand
		{
			get; set;
		}
		public string id
		{
			get; set;
		}
		public string self
		{
			get; set;
		}
		public string key
		{
			get; set;
		}
		public Fields fields
		{
			get; set;
		}
	}

	public class Root
	{
		public string expand
		{
			get; set;
		}
		public int startAt
		{
			get; set;
		}
		public int maxResults
		{
			get; set;
		}
		public int total
		{
			get; set;
		}
		public List<Issue> issues
		{
			get; set;
		}
	}

}
