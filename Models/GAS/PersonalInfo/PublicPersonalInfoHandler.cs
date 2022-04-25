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
		internal JArray GetFuzzyPersonalInfo( GetFuzzyPersonalInfo GetFuzzyPersonalInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetFuzzyPersonalInfo( GetFuzzyPersonalInfoParameter );

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
		internal JArray GetPersonalInfoByNameOrg( GetPersonalInfoByNameOrg GetPersonalInfoByNameOrgParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetPersonalInfoByNameOrg( GetPersonalInfoByNameOrgParameter );

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
		internal JArray GetGASLicenseInfo( GetGASLicenseInfo GetGASLicenseInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetGASLicenseInfo( GetGASLicenseInfoParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
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

		internal bool InsertFreshmanGASInfo( InsertFreshmanGASInfo InsertFreshmanGASInfoParameter )
		{

			bool bResult = m_publicPersonalInfoDBManager.InsertFreshmanGASInfo( InsertFreshmanGASInfoParameter );

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
		internal JArray GetParkingProcessingInfo( GetParkingProcessingInfo GetParkingProcessingInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetParkingProcessingInfo( GetParkingProcessingInfoParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray GetMeetingRoomProcessingInfo( GetMeetingRoomProcessingInfo GetMeetingRoomProcessingInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetMeetingRoomProcessingInfo( GetMeetingRoomProcessingInfoParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetGuestVisitProcessingInfo( GetGuestVisitProcessingInfo GetGuestVisitProcessingInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetGuestVisitProcessingInfo( GetGuestVisitProcessingInfoParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetMealOrderInfo( GetMealOrderInfo GetMealOrderInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetMealOrderInfo( GetMealOrderInfoParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetUniformApplyInfo( GetUniformApplyInfo GetUniformApplyInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetUniformApplyInfo( GetUniformApplyInfoParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetCarBookingInfo( GetCarBookingInfo GetCarBookingInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetCarBookingInfo( GetCarBookingInfoParameter );

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

		internal JArray GetDormInfo( GetDormInfo GetDormInfoParameter )
		{

			DataTable dtResult = m_publicPersonalInfoDBManager.GetDormInfo( GetDormInfoParameter );

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
