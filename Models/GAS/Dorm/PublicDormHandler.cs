using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.GAS.Dorm;
using System.Data;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Models.GAS.Dorm
{
	internal class PublicDormHandler
	{
		#region Internal Methods

		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url
		internal JArray QueryDormInfo( GetDormInfo GetDormInfoParameter )
		{

			DataTable dtResult = m_publicDormDBManager.GetDormInfo( GetDormInfoParameter );

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

		private PublicDormDBManager m_publicDormDBManager = new PublicDormDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
