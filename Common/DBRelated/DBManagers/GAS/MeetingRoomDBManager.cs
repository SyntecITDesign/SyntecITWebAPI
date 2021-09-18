using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.MeetingRoom;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicMeetingRoomDBManager : AbstractDBManager
	{
		#region Internal Methods


		internal DataTable GetMeetingRoom()
		{
			string sql = $@"SELECT * FROM [SyntecGAS].[dbo].[MeetingRoom]";

			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool UpsertMeetingRoom( UpsertMeetingRoom UpsertMeetingRoomParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[MeetingRoom] WHERE [ID]=@Parameter0 )
							UPDATE [SyntecGAS].[dbo].[MeetingRoom] SET [Floor]=@Parameter1, [MeetingRoom]=@Parameter2
							WHERE [ID]=@Parameter0 
						ELSE
						INSERT INTO [SyntecGAS].[dbo].[MeetingRoom] ([Floor],[MeetingRoom]) 
						VALUES (@Parameter1,@Parameter2)";
			List<object> SQLParameterList = new List<object>()
			{
				UpsertMeetingRoomParameter.ID,
				UpsertMeetingRoomParameter.Floor,
				UpsertMeetingRoomParameter.MeetingRoom,
				

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DeleteMeetingRoom( DeleteMeetingRoom DeleteMeetingRoomParameter )
		{
			string sql = $@"DELETE FROM [SyntecGAS].[dbo].[MeetingRoom]
						WHERE [ID] = @Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				DeleteMeetingRoomParameter.ID


			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

	}
	#endregion Internal Methods
}

