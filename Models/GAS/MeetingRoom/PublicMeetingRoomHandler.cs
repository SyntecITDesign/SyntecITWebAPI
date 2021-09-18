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
	internal class PublicMeetingRoomHandler
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
		#endregion Internal Methods

		#region Private Fields

		private PublicMeetingRoomDBManager m_publicMeetingRoomDBManager = new PublicMeetingRoomDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
