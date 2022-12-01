using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.HealthManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.HealthManagement
{

	internal class PublicHealthManagementHandler
	{
		#region Internal Methods
		internal bool InsertHealthExaminationInfo( InsertHealthExaminationInfo InsertHealthExaminationInfoParameter )
		{
			bool bResult = m_HealthManagementDBManager.InsertHealthExaminationInfo( InsertHealthExaminationInfoParameter );
			return bResult;
		}
		internal bool DeleteHealthExaminationInfo( DeleteHealthExaminationInfo DeleteHealthExaminationInfoParameter )
		{
			bool bResult = m_HealthManagementDBManager.DeleteHealthExaminationInfo( DeleteHealthExaminationInfoParameter );
			return bResult;
		}
		internal bool UpdateHealthExaminationInfo(UpdateHealthExaminationInfo UpdateHealthExaminationInfoParameter)
		{
			bool bResult = m_HealthManagementDBManager.UpdateHealthExaminationInfo(UpdateHealthExaminationInfoParameter);
			return bResult;
		}
		internal JArray GetHealthExaminationInfo(GetHealthExaminationInfo GetHealthExaminationInfoParameter)
		{
			DataTable dtResult = m_HealthManagementDBManager.GetHealthExaminationInfo(GetHealthExaminationInfoParameter);
			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}

		internal bool InsertHealthExaminationProjects( InsertHealthExaminationProjects InsertHealthExaminationProjectsParameter )
		{
			bool bResult = m_HealthManagementDBManager.InsertHealthExaminationProjects( InsertHealthExaminationProjectsParameter );
			return bResult;
		}
		internal bool DeleteHealthExaminationProjects( DeleteHealthExaminationProjects DeleteHealthExaminationProjectsParameter )
		{
			bool bResult = m_HealthManagementDBManager.DeleteHealthExaminationProjects( DeleteHealthExaminationProjectsParameter );
			return bResult;
		}
		internal bool UpdateHealthExaminationProjects( UpdateHealthExaminationProjects UpdateHealthExaminationProjectsParameter )
		{
			bool bResult = m_HealthManagementDBManager.UpdateHealthExaminationProjects( UpdateHealthExaminationProjectsParameter );
			return bResult;
		}
		internal JArray GetHealthExaminationProjects( GetHealthExaminationProjects GetHealthExaminationProjectsParameter )
		{
			DataTable dtResult = m_HealthManagementDBManager.GetHealthExaminationProjects( GetHealthExaminationProjectsParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool InsertHealthExaminationItems( InsertHealthExaminationItems InsertHealthExaminationItemsParameter )
		{
			bool bResult = m_HealthManagementDBManager.InsertHealthExaminationItems( InsertHealthExaminationItemsParameter );
			return bResult;
		}
		internal bool DeleteHealthExaminationItems( DeleteHealthExaminationItems DeleteHealthExaminationItemsParameter )
		{
			bool bResult = m_HealthManagementDBManager.DeleteHealthExaminationItems( DeleteHealthExaminationItemsParameter );
			return bResult;
		}
		internal bool UpdateHealthExaminationItems( UpdateHealthExaminationItems UpdateHealthExaminationItemsParameter )
		{
			bool bResult = m_HealthManagementDBManager.UpdateHealthExaminationItems( UpdateHealthExaminationItemsParameter );
			return bResult;
		}
		internal JArray GetHealthExaminationItems( GetHealthExaminationItems GetHealthExaminationItemsParameter )
		{
			DataTable dtResult = m_HealthManagementDBManager.GetHealthExaminationItems( GetHealthExaminationItemsParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool InsertHealthExaminationOptions( InsertHealthExaminationOptions InsertHealthExaminationOptionsParameter )
		{
			bool bResult = m_HealthManagementDBManager.InsertHealthExaminationOptions( InsertHealthExaminationOptionsParameter );
			return bResult;
		}
		internal bool DeleteHealthExaminationOptions( DeleteHealthExaminationOptions DeleteHealthExaminationOptionsParameter )
		{
			bool bResult = m_HealthManagementDBManager.DeleteHealthExaminationOptions( DeleteHealthExaminationOptionsParameter );
			return bResult;
		}
		internal bool UpdateHealthExaminationOptions( UpdateHealthExaminationOptions UpdateHealthExaminationOptionsParameter )
		{
			bool bResult = m_HealthManagementDBManager.UpdateHealthExaminationOptions( UpdateHealthExaminationOptionsParameter );
			return bResult;
		}
		internal JArray GetHealthExaminationOptions( GetHealthExaminationOptions GetHealthExaminationOptionsParameter )
		{
			DataTable dtResult = m_HealthManagementDBManager.GetHealthExaminationOptions( GetHealthExaminationOptionsParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetHealthExaminationEmpInfo( GetHealthExaminationEmpInfo GetHealthExaminationEmpInfoParameter )
		{
			DataTable dtResult = m_HealthManagementDBManager.GetHealthExaminationEmpInfo( GetHealthExaminationEmpInfoParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}



		internal bool InsertHealthExaminationApplicationsMaster( InsertHealthExaminationApplicationsMaster InsertHealthExaminationApplicationsMasterParameter )
		{
			bool bResult = m_HealthManagementDBManager.InsertHealthExaminationApplicationsMaster( InsertHealthExaminationApplicationsMasterParameter );
			return bResult;
		}
		internal bool DeleteHealthExaminationApplicationsMaster( DeleteHealthExaminationApplicationsMaster DeleteHealthExaminationApplicationsMasterParameter )
		{
			bool bResult = m_HealthManagementDBManager.DeleteHealthExaminationApplicationsMaster( DeleteHealthExaminationApplicationsMasterParameter );
			return bResult;
		}
		internal bool UpdateHealthExaminationApplicationsMaster( UpdateHealthExaminationApplicationsMaster UpdateHealthExaminationApplicationsMasterParameter )
		{
			bool bResult = m_HealthManagementDBManager.UpdateHealthExaminationApplicationsMaster( UpdateHealthExaminationApplicationsMasterParameter );
			return bResult;
		}
		internal JArray GetHealthExaminationApplicationsMaster( GetHealthExaminationApplicationsMaster GetHealthExaminationApplicationsMasterParameter )
		{
			DataTable dtResult = m_HealthManagementDBManager.GetHealthExaminationApplicationsMaster( GetHealthExaminationApplicationsMasterParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}


		internal bool InsertHealthExaminationApplicationsDetail( InsertHealthExaminationApplicationsDetail InsertHealthExaminationApplicationsDetailParameter )
		{
			bool bResult = m_HealthManagementDBManager.InsertHealthExaminationApplicationsDetail( InsertHealthExaminationApplicationsDetailParameter );
			return bResult;
		}
		internal bool DeleteHealthExaminationApplicationsDetail( DeleteHealthExaminationApplicationsDetail DeleteHealthExaminationApplicationsDetailParameter )
		{
			bool bResult = m_HealthManagementDBManager.DeleteHealthExaminationApplicationsDetail( DeleteHealthExaminationApplicationsDetailParameter );
			return bResult;
		}
		internal bool UpdateHealthExaminationApplicationsDetail( UpdateHealthExaminationApplicationsDetail UpdateHealthExaminationApplicationsDetailParameter )
		{
			bool bResult = m_HealthManagementDBManager.UpdateHealthExaminationApplicationsDetail( UpdateHealthExaminationApplicationsDetailParameter );
			return bResult;
		}
		internal JArray GetHealthExaminationApplicationsDetail( GetHealthExaminationApplicationsDetail GetHealthExaminationApplicationsDetailParameter )
		{
			DataTable dtResult = m_HealthManagementDBManager.GetHealthExaminationApplicationsDetail( GetHealthExaminationApplicationsDetailParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool InsertHealthExaminationReports( InsertHealthExaminationReports InsertHealthExaminationReportsParameter )
		{
			bool bResult = m_HealthManagementDBManager.InsertHealthExaminationReports( InsertHealthExaminationReportsParameter );
			return bResult;
		}
		internal bool DeleteHealthExaminationReports( DeleteHealthExaminationReports DeleteHealthExaminationReportsParameter )
		{
			bool bResult = m_HealthManagementDBManager.DeleteHealthExaminationReports( DeleteHealthExaminationReportsParameter );
			return bResult;
		}
		internal bool UpdateHealthExaminationReports( UpdateHealthExaminationReports UpdateHealthExaminationReportsParameter )
		{
			bool bResult = m_HealthManagementDBManager.UpdateHealthExaminationReports( UpdateHealthExaminationReportsParameter );
			return bResult;
		}
		internal JArray GetHealthExaminationReports( GetHealthExaminationReports GetHealthExaminationReportsParameter )
		{
			DataTable dtResult = m_HealthManagementDBManager.GetHealthExaminationReports( GetHealthExaminationReportsParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetHealthExaminationCheckLists( GetHealthExaminationCheckLists GetHealthExaminationCheckListsParameter )
		{
			DataTable dtResult = m_HealthManagementDBManager.GetHealthExaminationCheckLists( GetHealthExaminationCheckListsParameter );
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

		private HealthManagementDBManager m_HealthManagementDBManager = new HealthManagementDBManager();

		#endregion Private Fields
	}
}