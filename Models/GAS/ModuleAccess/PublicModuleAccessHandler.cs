using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.GAS.ModuleAccess;
using SyntecITWebAPI.Common.MailRelated;
using SyntecITWebAPI.Common.MailRelated.User;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.ParameterModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Models.GAS.ModuleAccess
{
	internal class PublicModuleAccessHandler
	{
		#region Internal Methods


		internal JArray GetModuleAccess( GetModuleAccess GetModuleAccessParameter )
		{
			DataTable dtResult = m_publicModuleAccessDBManager.GetModuleAccess( GetModuleAccessParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}


		#endregion Internal Methods

		#region Private Fields

		private PublicModuleAccessDBManager m_publicModuleAccessDBManager = new PublicModuleAccessDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
