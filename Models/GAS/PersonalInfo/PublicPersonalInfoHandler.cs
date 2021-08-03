using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.GAS.PersonalInfo;
using System.Data;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Models.GAS.PersonalInfo
{
	internal class PublicPersonalInfoHandler
	{
		#region Internal Methods

		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url
		internal JArray QueryPersonalInfo( GetPersonalInfo GetPersonalInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetPersonalInfo( GetPersonalInfoParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray QueryPersonalGASInfo( GetPersonalGASInfo GetPersonalGASInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetPersonalGASInfo( GetPersonalGASInfoParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertPersonalGASInfo( UpsertPersonalGASInfo UpsertPersonalGASInfoParameter )
		{

			bool bResult = m_publicPersonalInfoDBManager.UpsertPersonalGASInfo( UpsertPersonalGASInfoParameter );

			return bResult;
		}
		internal JArray QueryProcessingInfo( GetProcessingInfo GetProcessingInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetProcessingInfo( GetProcessingInfoParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
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

		private PublicPersonalInfoDBManager m_publicPersonalInfoDBManager = new PublicPersonalInfoDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
