using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.Notify
{
	public class WXNotify
	{
		#region Public Properties

		public string sendOpenid
		{
			get; set;
		}

		public string title
		{
			get; set;
		}

		public string contentBody
		{
			get; set;
		}

		public string keyWords
		{
			get; set;
		}

		public string platform
		{
			get; set;
		}

		public string masterID
		{
			get; set;
		}

		public string masterType
		{
			get; set;
		}

		public string keyword1
		{
			get; set;
		}

		public string keyword2
		{
			get; set;
		}

		public string keyword3
		{
			get; set;
		}

		public string keyword4
		{
			get; set;
		}

		public string keyword5
		{
			get; set;
		}

		public string url
		{
			get; set;
		}

		public string flowStatus
		{
			get; set;
		}

		#endregion Public Properties

	}

	public class SendVerifyCode
	{
		#region Public Properties
		[Required]
		public string countryCode
		{
			get; set;
		}
		[Required]
		public string phone
		{
			get; set;
		}

		public string verifyCode
		{
			get; set;
		}
		[Required]
		public string language
		{
			get; set;
		}
		[Required]
		public string application
		{
			get; set;
		}

		#endregion Public Properties

	}

	public class CheckVerifyCode
	{
		#region Public Properties

		public string phone
		{
			get; set;
		}

		public string verifyCode
		{
			get; set;
		}

		public string application
		{
			get; set;
		}

		#endregion Public Properties

	}

	public class SendAlarmMessage
	{
		#region Public Properties
		[Required]
		public string countryCode
		{
			get; set;
		}
		[Required]
		public string phone
		{
			get; set;
		}
		[Required]
		public string application
		{
			get; set;
		}
		public string machineName
		{
			get; set;
		}
		public string alarmInfo
		{
			get; set;
		}

		public int type
		{
			get; set;
		}

		#endregion Public Properties

	}
}
