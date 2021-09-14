using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.Notify;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using SyntecITWebAPI.ParameterModels.GAS.PersonnelInfo;

namespace SyntecITWebAPI.Models
{
	internal class PublicNotifyHandler
	{
		#region Internal Methods

		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url

		internal bool SendWXNotify( WXNotify WXNotifyParameter )
		{

			bool bResult = m_publicNotifyDBManager.SendWXNotify( WXNotifyParameter );

			return bResult;
		}


        #endregion Internal Methods

        #region Private Fields

        private PublicNotifyDBManager m_publicNotifyDBManager = new PublicNotifyDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
