using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.GAS.WorkCalendar;
using System.Data;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Models.GAS.WorkCalendar
{
	internal class PublicWorkCalendarHandler
	{
		#region Internal Methods

		internal JArray GetWorkDayInfo( GetWorkDayInfo GetWorkDayInfoParameter )
		{

			DataTable dtResult = m_publicWorkCalendarDBManager.GetWorkDayInfo( GetWorkDayInfoParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		
		#endregion Internal Methods

		#region Private Fields

		private PublicWorkCalendarDBManager m_publicWorkCalendarDBManager = new PublicWorkCalendarDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
