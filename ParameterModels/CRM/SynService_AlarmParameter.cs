﻿using System.Collections.Generic;
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

	public class SynService_ExceptionLog
	{
		#region Public Properties

		public string serial_number
		{
			get; set;
		}

		public int exception_type_id
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
