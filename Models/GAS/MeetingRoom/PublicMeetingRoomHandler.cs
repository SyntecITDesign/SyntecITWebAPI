using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.GAS.MeetingRoom;
using System.Data;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Models.GAS.MeetingRoom
{
	internal class PublicStationBookingHandler
	{
		#region Internal Methods

		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url
		internal JArray GetMeetingRoom()
		{

			DataTable dtResult = m_publicMeetingRoomDBManager.GetMeetingRoom();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray GetMeetingRoom_SZ()
		{

			DataTable dtResult = m_publicMeetingRoomDBManager.GetMeetingRoom_SZ();

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertMeetingRoom( UpsertMeetingRoom UpsertMeetingRoomParameter )
		{

			bool bResult = m_publicMeetingRoomDBManager.UpsertMeetingRoom( UpsertMeetingRoomParameter );

			return bResult;
		}

		internal bool DeleteMeetingRoom( DeleteMeetingRoom DeleteMeetingRoomParameter )
		{

			bool bResult = m_publicMeetingRoomDBManager.DeleteMeetingRoom( DeleteMeetingRoomParameter );

			return bResult;
		}

		internal bool InsertMeetingRoomApplicationsMaster( InsertMeetingRoomApplicationsMaster InsertMeetingRoomApplicationsMasterParameter )
		{

			bool bResult = m_publicMeetingRoomDBManager.InsertMeetingRoomApplicationsMaster( InsertMeetingRoomApplicationsMasterParameter );

			return bResult;
		}
		internal bool DeleteMeetingRoomApplicationsMaster( DeleteMeetingRoomApplicationsMaster DeleteMeetingRoomApplicationsMasterParameter )
		{

			bool bResult = m_publicMeetingRoomDBManager.DeleteMeetingRoomApplicationsMaster( DeleteMeetingRoomApplicationsMasterParameter );

			return bResult;
		}
		internal bool UpdateMeetingRoomApplicationsMaster( UpdateMeetingRoomApplicationsMaster UpdateMeetingRoomApplicationsMasterParameter )
		{

			bool bResult = m_publicMeetingRoomDBManager.UpdateMeetingRoomApplicationsMaster( UpdateMeetingRoomApplicationsMasterParameter );

			return bResult;
		}
		internal JArray GetMeetingRoomApplicationsMaster( GetMeetingRoomApplicationsMaster GetMeetingRoomApplicationsMasterParameter )
		{

			DataTable dtResult = m_publicMeetingRoomDBManager.GetMeetingRoomApplicationsMaster( GetMeetingRoomApplicationsMasterParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool InsertMRBS( InsertMRBS InsertMRBSParameter )
		{

			bool bResult = m_publicMeetingRoomDBManager.InsertMRBS( InsertMRBSParameter );

			return bResult;
		}
		internal bool DeleteMRBS( DeleteMRBS DeleteMRBSParameter )
		{

			bool bResult = m_publicMeetingRoomDBManager.DeleteMRBS( DeleteMRBSParameter );

			return bResult;
		}
		internal JArray GetMRBS( GetMRBS GetMRBSParameter )
		{

			DataTable dtResult = m_publicMeetingRoomDBManager.GetMRBS( GetMRBSParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool UpdateMRBS( UpdateMRBS UpdateMRBSParameter )
		{

			bool bResult = m_publicMeetingRoomDBManager.UpdateMRBS( UpdateMRBSParameter );

			return bResult;
		}

		internal JArray GetUsingMeetingRoom( GetUsingMeetingRoom GetUsingMeetingRoomParameter )
		{

			DataTable dtResult = m_publicMeetingRoomDBManager.GetUsingMeetingRoom( GetUsingMeetingRoomParameter );

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

		private PublicMeetingRoomDBManager m_publicMeetingRoomDBManager = new PublicMeetingRoomDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
