using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.ApplyUniform;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.ApplyUniform
{

	internal class PublicApplyUniformHandler
	{
		#region Internal Methods
		internal bool InsertUniformStyle(InsertUniformStyle InsertUniformStyleParameter)
		{

			bool bResult = m_ApplyUniformDBManager.InsertUniformStyle(InsertUniformStyleParameter);

			return bResult;
		}

		internal bool DeleteUniformInfo(DeleteUniformInfo DeleteUniformInfoParameter)
		{

			bool bResult = m_ApplyUniformDBManager.DeleteUniformInfo(DeleteUniformInfoParameter);

			return bResult;
		}


		internal bool UpdateUniformInfo(UpdateUniformInfo UpdateUniformInfoParameter)
		{

			bool bResult = m_ApplyUniformDBManager.UpdateUniformInfo(UpdateUniformInfoParameter);

			return bResult;
		}

		internal JArray GetUniformInfo(GetUniformInfo GetUniformInfoParameter)
		{

			DataTable dtResult = m_ApplyUniformDBManager.GetUniformInfo(GetUniformInfoParameter);

			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}


        #endregion Internal Methods

        #region Private Fields

        private ApplyUniformDBManager m_ApplyUniformDBManager = new ApplyUniformDBManager();

		#endregion Private Fields
	}
}