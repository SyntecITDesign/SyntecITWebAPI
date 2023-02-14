using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.PersonnelInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.PersonnelInfo
{
	internal class PublicPersonnelInfoHandler
	{
		#region Internal Methods
		internal bool InsertPersonData(InsertPersonData InsertPersonDataParameter)
		{

			bool bResult = m_PersonnelInfoDBManager.InsertPersonData(InsertPersonDataParameter);

			return bResult;
		}

		internal bool DeletePersonData(DeletePersonData DeletePersonDataParameter)
		{

			bool bResult = m_PersonnelInfoDBManager.DeletePersonData(DeletePersonDataParameter);

			return bResult;
		}


		internal bool UpdatePersonDept(UpdatePersonDept UpdatePersonDeptParameter)
		{

			bool bResult = m_PersonnelInfoDBManager.UpdatePersonDept(UpdatePersonDeptParameter);

			return bResult;
		}

		internal JArray GetPersonDept(GetPersonDept GetPersonDeptParameter)
		{

			DataTable dtResult = m_PersonnelInfoDBManager.GetPersonDept(GetPersonDeptParameter);

			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}

		internal JArray GetQuantity(GetQuantity GetQuantityParameter)
		{

			DataTable dtResult = m_PersonnelInfoDBManager.GetQuantity(GetQuantityParameter);

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

		private PersonnelInfoDBManager m_PersonnelInfoDBManager = new PersonnelInfoDBManager();

		#endregion Private Fields
	}
}
