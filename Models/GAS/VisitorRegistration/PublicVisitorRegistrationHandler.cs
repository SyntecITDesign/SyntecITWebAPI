using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.VisitorRegistration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.VisitorRegistration
{

	internal class PublicVisitorRegistrationHandler
	{
		#region Internal Methods

		//in use--
		internal bool InsertVisitorApplication( InsertVisitorApplication InsertVisitorApplicationParameter )
		{

			bool bResult = m_VisitorRegistrationDBManager.InsertVisitorApplication( InsertVisitorApplicationParameter );

			return bResult;
		}
		internal JArray GetVisitorRecord()
		{

			DataTable dtResult = m_VisitorRegistrationDBManager.GetVisitorRecord();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool DeleteRecord( DeleteRecord DeleteRecordParameter )
		{

			bool bResult = m_VisitorRegistrationDBManager.DeleteRecord( DeleteRecordParameter );

			return bResult;
		}
		internal bool UpdateRecord( UpdateRecord UpdateRecordParameter )
		{

			bool bResult = m_VisitorRegistrationDBManager.UpdateRecord( UpdateRecordParameter );

			return bResult;
		}
		//--

		internal bool InsertVisitorRegistrationApplicationsMaster( InsertVisitorRegistrationApplicationsMaster InsertVisitorRegistrationApplicationsMasterParameter )
		{

			bool bResult = m_VisitorRegistrationDBManager.InsertVisitorRegistrationApplicationsMaster( InsertVisitorRegistrationApplicationsMasterParameter );

			return bResult;
		}
		internal bool UpdateVisitorRegistrationApplicationsMaster( UpdateVisitorRegistrationApplicationsMaster UpdateGuestReceptionApplicationsMasterParameter )
		{

			bool bResult = m_VisitorRegistrationDBManager.UpdateVisitorRegistrationApplicationsMaster( UpdateGuestReceptionApplicationsMasterParameter );

			return bResult;
		}

		internal JArray GetVisitorRegistrationApplicationsMaster( GetVisitorRegistrationApplicationsMaster GetGuestReceptionApplicationsMasterParameter )
		{

			DataTable dtResult = m_VisitorRegistrationDBManager.GetVisitorRegistrationApplicationsMaster( GetGuestReceptionApplicationsMasterParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool VisitorCheckIn( VisitorCheckIn VisitorCheckInParameter )
		{

			bool bResult = m_VisitorRegistrationDBManager.VisitorCheckIn( VisitorCheckInParameter );

			return bResult;
		}
		internal bool VisitorCheckOut( VisitorCheckOut VisitorCheckOutParameter )
		{

			bool bResult = m_VisitorRegistrationDBManager.VisitorCheckOut( VisitorCheckOutParameter );

			return bResult;
		}

		#endregion Internal Methods

		#region Private Fields

		private VisitorRegistrationDBManager m_VisitorRegistrationDBManager = new VisitorRegistrationDBManager();

		#endregion Private Fields
	}
}


