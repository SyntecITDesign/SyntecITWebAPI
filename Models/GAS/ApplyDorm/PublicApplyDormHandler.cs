using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.ApplyDorm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.ApplyDorm
{

	internal class PublicApplyDormHandler
	{
		#region Internal Methods
		internal JArray GetEmpDormStatusData( GetEmpDormStatusData GetEmpDormStatusDataParameter )
		{

			DataTable dtResult = m_ApplyDormDBManager.GetEmpDormStatusData( GetEmpDormStatusDataParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertDormApplicationsMaster( InsertDormApplicationsMaster InsertDormApplicationsMasterParameter )
		{

			bool bResult = m_ApplyDormDBManager.InsertDormApplicationsMaster( InsertDormApplicationsMasterParameter );

			return bResult;
		}



		#endregion Internal Methods

		#region Private Fields

		private ApplyDormDBManager m_ApplyDormDBManager = new ApplyDormDBManager();

		#endregion Private Fields
	}
}