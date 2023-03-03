using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.Module;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.Module
{

	internal class PublicJiraAPIHandler
	{
		#region Internal Methods
		internal bool InsertFeatures(InsertFeatures InsertFeaturesParameter)
		{

			bool bResult = m_ModuleDBManagerDBManager.InsertFeatures(InsertFeaturesParameter);

			return bResult;
		}

		internal bool DeleteFeatures(DeleteFeatures DeleteFeaturesParameter)
		{

			bool bResult = m_ModuleDBManagerDBManager.DeleteFeatures(DeleteFeaturesParameter);

			return bResult;
		}


		internal bool UpdateFeatures(UpdateFeatures UpdateFeaturesParameter)
		{

			bool bResult = m_ModuleDBManagerDBManager.UpdateFeatures(UpdateFeaturesParameter);

			return bResult;
		}

		internal JArray GetFeatures1(GetFeatures1 GetFeatures1Parameter)
		{

			DataTable dtResult = m_ModuleDBManagerDBManager.GetFeatures1(GetFeatures1Parameter);

			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}

        internal JArray GetFeatures2(GetFeatures2 GetFeatures2Parameter)
        {

            DataTable dtResult = m_ModuleDBManagerDBManager.GetFeatures2(GetFeatures2Parameter);

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

        private ModuleDBManager m_ModuleDBManagerDBManager = new ModuleDBManager();

		#endregion Private Fields
	}
}