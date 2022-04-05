using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.StationBooking
{


	public class StationApplicationsMasterAllField
	{
		public int StationApplicationsMasterRequisitionID
		{
			get; set;
		}
		public string StationApplicationsMasterFillerID
		{
			get; set;
		}
		public string StationApplicationsMasterFillerName
		{
			get; set;
		}
		public string StationApplicationsMasterApplicationDate
		{
			get; set;
		}
		public string StationApplicationsMasterApplicantID
		{
			get; set;
		}
		public string StationApplicationsMasterApplicantName
		{
			get; set;
		}
		public string StationApplicationsMasterApplicantDept
		{
			get; set;
		}		
		public string StationApplicationsMasterApplyType
		{
			get; set;
		}
		public string StationApplicationsMasterStartDate
		{
			get; set;
		}
		public string StationApplicationsMasterEndDate
		{
			get; set;
		}
		public string StationApplicationsMasterMemo
		{
			get; set;
		}
		public bool StationApplicationsMasterFinished
		{
			get; set;
		}
		
		public bool StationApplicationsMasterIsCancel
		{
			get; set;
		}
		public string StationApplicationsMasterStation
		{
			get; set;
		}
	}
	public class InsertStationApplicationsMaster : StationApplicationsMasterAllField
	{

	}
	public class DeleteStationApplicationsMaster : StationApplicationsMasterAllField
	{

	}
	public class UpdateStationApplicationsMaster : StationApplicationsMasterAllField
	{

	}
	public class GetStationApplicationsMaster : StationApplicationsMasterAllField
	{

	}



	public class GetUsingStation
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
