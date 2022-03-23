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

			if( result == null || result.Rows.Count <= 0 )
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

		internal bool InsertMeetingRoomApplicationsMaster( InsertMeetingRoomApplicationsMaster InsertMeetingRoomApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MeetingRoomApplicationsMaster] ([FillerID],[FillerName],[ApplicationDate],[ApplicantID],[ApplicantName],[ApplicantDept],[ApplyType],[StartDate],[EndDate],[Memo],[MRBS_ID],[StopDate])
						VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter8, @Parameter9, @Parameter10, @Parameter11, @Parameter13, @Parameter14)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterRequisitionID,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFillerID,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFillerName,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicationDate,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantID,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantName,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantDept,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterIsCancel,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplyType,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterStartDate,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterEndDate,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterMemo,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFinished,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterMRBS_ID,
				InsertMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterStopDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteMeetingRoomApplicationsMaster( DeleteMeetingRoomApplicationsMaster DeleteMeetingRoomApplicationsMasterParameter )
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[MeetingRoomApplicationsMaster]
								where [RequisitionID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterRequisitionID,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFillerID,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFillerName,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicationDate,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantID,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantName,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantDept,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterIsCancel,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplyType,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterStartDate,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterEndDate,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterMemo,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFinished,
				DeleteMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterMRBS_ID

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateMeetingRoomApplicationsMaster( UpdateMeetingRoomApplicationsMaster UpdateMeetingRoomApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[MeetingRoomApplicationsMaster]
							set [Finished]=@Parameter12,[IsCancel]=@Parameter7
							where [RequisitionID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterRequisitionID,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFillerID,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFillerName,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicationDate,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantID,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantName,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantDept,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterIsCancel,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplyType,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterStartDate,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterEndDate,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterMemo,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFinished,
				UpdateMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterMRBS_ID

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetMeetingRoomApplicationsMaster( GetMeetingRoomApplicationsMaster GetMeetingRoomApplicationsMasterParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[MeetingRoomApplicationsMaster]
						right join [SyntecGAS].[dbo].[MRBS]
						on [MRBS].ID=[MeetingRoomApplicationsMaster].MRBS_ID
						WHERE [ApplicantID] like @Parameter4 and [Finished]=@Parameter11
						ORDER BY [RequisitionID] desc";
			List<object> SQLParameterList = new List<object>()
			{

				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterRequisitionID,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFillerID,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFillerName,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicationDate,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantID,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantName,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplicantDept,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterApplyType,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterStartDate,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterEndDate,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterMemo,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterFinished,
				GetMeetingRoomApplicationsMasterParameter.MeetingRoomApplicationsMasterMRBS_ID
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool InsertMRBS( InsertMRBS InsertMRBSParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[MRBS] ([ID],[MeetingRoom],[Event],[Date],[PreserveTimeStart],[PreserveTimeEnd],[Holder],[PeopleCounting],[Link],[EmpID],[OrgID],[attendant])
							VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter7,@Parameter8, @Parameter9, @Parameter10, @Parameter11)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertMRBSParameter.MRBSID,
				InsertMRBSParameter.MRBSMeetingRoom,
				InsertMRBSParameter.MRBSEvent,
				InsertMRBSParameter.MRBSDate,
				InsertMRBSParameter.MRBSPreserveTimeStart,
				InsertMRBSParameter.MRBSPreserveTimeEnd,
				InsertMRBSParameter.MRBSHolder,
				InsertMRBSParameter.MRBSPeopleCounting,
				InsertMRBSParameter.MRBSLink,
				InsertMRBSParameter.MRBSEmpID,
				InsertMRBSParameter.MRBSOrgID,
				InsertMRBSParameter.MRBSattendant
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteMRBS( DeleteMRBS DeleteMRBSParameter )
		{
			string sql = $@"DELETE FROM [SyntecGAS].[dbo].[MRBS]
								WHERE [ID] = @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteMRBSParameter.MRBSID,
				DeleteMRBSParameter.MRBSMeetingRoom,
				DeleteMRBSParameter.MRBSEvent,
				DeleteMRBSParameter.MRBSDate,
				DeleteMRBSParameter.MRBSPreserveTimeStart,
				DeleteMRBSParameter.MRBSPreserveTimeEnd,
				DeleteMRBSParameter.MRBSHolder,
				DeleteMRBSParameter.MRBSPeopleCounting,
				DeleteMRBSParameter.MRBSLink,
				DeleteMRBSParameter.MRBSEmpID,
				DeleteMRBSParameter.MRBSOrgID,
				DeleteMRBSParameter.MRBSattendant

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetMRBS( GetMRBS GetMRBSParameter )
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[MRBS]
						Where [ID] like @Parameter0
						Order by [ID] desc";
			List<object> SQLParameterList = new List<object>()
			{
				GetMRBSParameter.MRBSID,
				GetMRBSParameter.MRBSMeetingRoom,
				GetMRBSParameter.MRBSEvent,
				GetMRBSParameter.MRBSDate,
				GetMRBSParameter.MRBSPreserveTimeStart,
				GetMRBSParameter.MRBSPreserveTimeEnd,
				GetMRBSParameter.MRBSHolder,
				GetMRBSParameter.MRBSPeopleCounting,
				GetMRBSParameter.MRBSLink,
				GetMRBSParameter.MRBSEmpID,
				GetMRBSParameter.MRBSOrgID,
				GetMRBSParameter.MRBSattendant
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal bool UpdateMRBS( UpdateMRBS UpdateMRBSParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[MRBS]
							set [Memo]=@Parameter13
							where [No]=@Parameter12";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateMRBSParameter.MRBSID,
				UpdateMRBSParameter.MRBSMeetingRoom,
				UpdateMRBSParameter.MRBSEvent,
				UpdateMRBSParameter.MRBSDate,
				UpdateMRBSParameter.MRBSPreserveTimeStart,
				UpdateMRBSParameter.MRBSPreserveTimeEnd,
				UpdateMRBSParameter.MRBSHolder,
				UpdateMRBSParameter.MRBSPeopleCounting,
				UpdateMRBSParameter.MRBSLink,
				UpdateMRBSParameter.MRBSEmpID,
				UpdateMRBSParameter.MRBSOrgID,
				UpdateMRBSParameter.MRBSattendant,
				UpdateMRBSParameter.MRBSNo,
				UpdateMRBSParameter.MRBSMemo

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetUsingMeetingRoom( GetUsingMeetingRoom GetUsingMeetingRoomParameter )
		{
			string sql = $@"select * from [SyntecGAS].[dbo].MRBS 
where (CONVERT(datetime,@Parameter0,120) BETWEEN CONVERT(datetime,PreserveTimeStart,120)  AND CONVERT(datetime,PreserveTimeEnd,120) and CONVERT( datetime,@Parameter1,120) BETWEEN CONVERT( datetime, PreserveTimeStart,120)  AND CONVERT( datetime, PreserveTimeEnd,120) ) or ( CONVERT( datetime, @Parameter0, 120 ) BETWEEN CONVERT( datetime, PreserveTimeStart, 120 )  AND CONVERT( datetime, PreserveTimeEnd, 120 ) and  CONVERT( datetime, @Parameter1, 120 ) NOT BETWEEN CONVERT( datetime, PreserveTimeStart, 120 )  AND CONVERT( datetime, PreserveTimeEnd, 120 ) and  CONVERT( datetime, @Parameter0, 120 ) != CONVERT( datetime, PreserveTimeEnd, 120 ) ) or ( CONVERT( datetime, @Parameter0, 120 ) NOT BETWEEN CONVERT( datetime, PreserveTimeStart, 120 )  AND CONVERT( datetime, PreserveTimeEnd, 120 ) and  CONVERT( datetime, @Parameter1, 120 ) BETWEEN CONVERT( datetime, PreserveTimeStart, 120 )  AND CONVERT( datetime, PreserveTimeEnd, 120 ) and  CONVERT( datetime, @Parameter1, 120 ) != CONVERT( datetime, PreserveTimeStart, 120 ) )";
			List<object> SQLParameterList = new List<object>()
			{
				GetUsingMeetingRoomParameter.TimeStart,
				GetUsingMeetingRoomParameter.TimeEnd
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}


	}
	#endregion Internal Methods
}

