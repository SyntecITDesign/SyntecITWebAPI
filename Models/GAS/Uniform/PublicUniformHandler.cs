using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.GAS.Uniform;
using System.Data;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Models.GAS.Uniform
{
	internal class PublicUniformHandler
	{
		#region Internal Methods

		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url
		internal JArray QueryUniformSize(GetUniformSize GetUniformSizeParameter)
		{

			DataTable dtResult = m_publicUniformDBManager.GetUniformSize(GetUniformSizeParameter);

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
		internal bool UpsertUniformSize( UpsertUniformSize UpsertUniformSizeParameter )
		{

			bool bResult = m_publicUniformDBManager.UpsertUniformSize( UpsertUniformSizeParameter );

			return bResult;
		}
		#endregion Internal Methods

		#region Private Fields

		private PublicUniformDBManager m_publicUniformDBManager = new PublicUniformDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
