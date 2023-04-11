using System.Collections.Generic;

namespace SyntecITWebAPI.ParameterModels.Mail
{
	internal class MailParameter
	{
		#region Internal Properties

		internal Dictionary<string, object> mailAttachParameter { get; set; } = null; //optional

		internal string userEmail
		{
			get; set;
		}

		internal string userID { get; set; } = null; //optional

		internal string userLang { get; set; } = null; //optional
		internal string userName { get; set; } = null;

		#endregion Internal Properties

		//optional
	}
}
