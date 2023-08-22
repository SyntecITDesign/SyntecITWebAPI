using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.Homepage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.Homepage
{

	internal class PublicHomepageHandler
	{
		#region Internal Methods
		internal bool InsertHomepageAlertEvents(InsertHomepageAlertEvents InsertHomepageAlertEventsParameter)
		{

			bool bResult = m_HomepageDBManager.InsertHomepageAlertEvents(InsertHomepageAlertEventsParameter);

			return bResult;
		}
		internal bool DeleteHomepageAlertEvents(DeleteHomepageAlertEvents DeleteHomepageAlertEventsParameter)
		{

			bool bResult = m_HomepageDBManager.DeleteHomepageAlertEvents(DeleteHomepageAlertEventsParameter);

			return bResult;
		}
		internal bool UpdateHomepageAlertEvents(UpdateHomepageAlertEvents UpdateHomepageAlertEventsParameter)
		{

			bool bResult = m_HomepageDBManager.UpdateHomepageAlertEvents(UpdateHomepageAlertEventsParameter);

			return bResult;
		}
		internal JArray GetHomepageAlertEvents_SZ( GetHomepageAlertEvents_SZ GetHomepageAlertEventsParameter_SZ )
		{

			DataTable dtResult = m_HomepageDBManager.GetHomepageAlertEvents_SZ( GetHomepageAlertEventsParameter_SZ );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray GetHomepageAlertEvents(GetHomepageAlertEvents GetHomepageAlertEventsParameter)
		{

			DataTable dtResult = m_HomepageDBManager.GetHomepageAlertEvents(GetHomepageAlertEventsParameter);

			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}

		internal bool InsertHomepageFinishEvents( InsertHomepageFinishEvents InsertHomepageFinishEventsParameter )
		{

			bool bResult = m_HomepageDBManager.InsertHomepageFinishEvents( InsertHomepageFinishEventsParameter );

			return bResult;
		}
		internal bool DeleteHomepageFinishEvents( DeleteHomepageFinishEvents DeleteHomepageFinishEventsParameter )
		{

			bool bResult = m_HomepageDBManager.DeleteHomepageFinishEvents( DeleteHomepageFinishEventsParameter );

			return bResult;
		}
		internal bool UpdateHomepageFinishEvents( UpdateHomepageFinishEvents UpdateHomepageFinishEventsParameter )
		{

			bool bResult = m_HomepageDBManager.UpdateHomepageFinishEvents( UpdateHomepageFinishEventsParameter );

			return bResult;
		}
		internal JArray GetHomepageFinishEvents( GetHomepageFinishEvents GetHomepageFinishEventsParameter )
		{

			DataTable dtResult = m_HomepageDBManager.GetHomepageFinishEvents( GetHomepageFinishEventsParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		#endregion Internal Methods

		#region Private Fields

		private HomepageDBManager m_HomepageDBManager = new HomepageDBManager();

		#endregion Private Fields
	}
}