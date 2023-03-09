using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.MeetingRoom
{

	public class UpsertMeetingRoom
	{
		#region Public Properties

		public int ID
		{
			get; set;
		}

		public string Floor
		{
			get; set;
		}

		public string MeetingRoom
		{
			get; set;
		}


		#endregion Public Properties
	}

	public class DeleteMeetingRoom
	{
		#region Public Properties


		public int ID
		{
			get; set;
		}


		#endregion Public Properties
	}

	public class MeetingRoomApplicationsMasterAllField
	{
		public int MeetingRoomApplicationsMasterRequisitionID
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterFillerID
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterFillerName
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterApplicationDate
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterApplicantID
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterApplicantName
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterApplicantDept
		{
			get; set;
		}
		public bool MeetingRoomApplicationsMasterIsCancel
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterApplyType
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterStartDate
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterEndDate
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterMemo
		{
			get; set;
		}
		public bool MeetingRoomApplicationsMasterFinished
		{
			get; set;
		}
		public int MeetingRoomApplicationsMasterMRBS_ID
		{
			get; set;
		}
		public string MeetingRoomApplicationsMasterStopDate
		{
			get; set;
		}
	}
	public class InsertMeetingRoomApplicationsMaster : MeetingRoomApplicationsMasterAllField
	{

	}
	public class DeleteMeetingRoomApplicationsMaster : MeetingRoomApplicationsMasterAllField
	{

	}
	public class UpdateMeetingRoomApplicationsMaster : MeetingRoomApplicationsMasterAllField
	{

	}
	public class GetMeetingRoomApplicationsMaster : MeetingRoomApplicationsMasterAllField
	{

	}

	public class MRBSAllField
	{
		public string MRBSID
		{
			get; set;
		}
		public string MRBSMeetingRoom
		{
			get; set;
		}
		public string MRBSEvent
		{
			get; set;
		}
		public string MRBSDate
		{
			get; set;
		}
		public string MRBSPreserveTimeStart
		{
			get; set;
		}
		public string MRBSPreserveTimeEnd
		{
			get; set;
		}
		public string MRBSHolder
		{
			get; set;
		}
		public int MRBSPeopleCounting
		{
			get; set;
		}
		public string MRBSLink
		{
			get; set;
		}
		public string MRBSEmpID
		{
			get; set;
		}
		public string MRBSOrgID
		{
			get; set;
		}
		public string MRBSattendant
		{
			get; set;
		}
		public string MRBSNo
		{
			get; set;
		}
		public string MRBSMemo
		{
			get; set;
		}
		public string MRBSUsage
		{
			get; set;
		}
	}
	public class InsertMRBS : MRBSAllField
	{

	}
	public class DeleteMRBS : MRBSAllField
	{

	}
	public class UpdateMRBS : MRBSAllField
	{

	}
	public class GetMRBS : MRBSAllField
	{

	}

	public class GetUsingMeetingRoom
	{
		public string TimeStart
		{
			get; set;
		}
		public string TimeEnd
		{
			get; set;
		}
		
	}



}
