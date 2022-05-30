using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.GASNotify
{

	public class WeComGASNotify
	{
		
		public string WeComGASNotifyKey
		{
			get; set;
		}
		public string WeComGASNotifyContent
		{
			get; set;
		}

	}

	public class EmailGASNotify
	{

		public string EmailGASNotifyTitle
		{
			get; set;
		}
		public string EmailGASNotifyContent
		{
			get; set;
		}
		public string EmailGASNotifyUserEmail
		{
			get; set;
		}
		
	}

}
