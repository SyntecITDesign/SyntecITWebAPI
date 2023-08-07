using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.Homepage
{
    public class HomepageAlertEventsAllField
	{
        public int HomepageAlertEventsNo{ get; set; }
        public string HomepageAlertEventsTitle{ get; set; }
        public string HomepageAlertEventsStartDate{ get; set; }
        public string HomepageAlertEventsID{ get; set; }
		public string HomepageAlertEventsAlertUrl	{get; set;}

	}
    public class InsertHomepageAlertEvents : HomepageAlertEventsAllField
	{

    }
    public class DeleteHomepageAlertEvents : HomepageAlertEventsAllField
	{

    }
    public class UpdateHomepageAlertEvents : HomepageAlertEventsAllField
	{

    }
    public class GetHomepageAlertEvents : HomepageAlertEventsAllField
	{

    }
	public class GetHomepageAlertEvents_SZ : HomepageAlertEventsAllField
	{

	}

	public class HomepageFinishEventsAllField
	{
		public string HomepageFinishEventsID
		{
			get; set;
		}
		public string HomepageFinishEventsTitle
		{
			get; set;
		}
		public string HomepageFinishEventsAlertDate
		{
			get; set;
		}
		public string HomepageFinishEventsFinishDate
		{
			get; set;
		}
		public string HomepageFinishEventsEmpID
		{
			get; set;
		}

	}
	public class InsertHomepageFinishEvents : HomepageFinishEventsAllField
	{

	}
	public class DeleteHomepageFinishEvents : HomepageFinishEventsAllField
	{

	}
	public class UpdateHomepageFinishEvents : HomepageFinishEventsAllField
	{

	}
	public class GetHomepageFinishEvents : HomepageFinishEventsAllField
	{

	}
}
