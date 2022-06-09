using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SyntecITWebAPI.ParameterModels.GAS.ApplyDorm
{
	
		
	public class GetEmpDormStatusData

	{
		public string EmpID
		{
			get;set;
		}
		
	}

	public class GetDormApplicationsMaster_SZ

	{
		public string EmpID
		{
			get; set;
		}
		public string Finished
		{
			get; set;
		}
	}

	public class InsertDormApplicationsMaster 
	{
		public string EmpID
		{ get;set;
		}

		public string ApplicationDate
		{get;set;
		}

		public string Dorm
		{get;set;
		}

		public string RoomNum
		{get;set;
		}

		public string ReservationTime
		{get;set;
		}
		public string Finished
		{get;set;
		}

		public string LeaveDate
		{
			get; set;
		}
		public string EmpRemarks
		{
			get; set;
		}
		public string ApplicationType
		{
			get; set;
		}
		public string EmpName
		{
			get; set;
		}
		public string RoomCompany
		{
			get; set;
		}
	}

	public class UpdateDormApplicationsMaster
	{
		public string EmpID
		{
			get; set;
		}		
		public string Finished
		{
			get; set;
		}		
		public string ApplicationType
		{
			get; set;
		}
		public string Remarks
		{
			get; set;
		}
	}

	public class DormInfo_SZAllField
	{
		
		public string DormInfo_SZID
		{
			get; set;
		}
		
		public string DormInfo_SZDorm
		{
			get; set;
		}
		
		
		public string DormInfo_SZRoomNum
		{
			get; set;
		}
		
		
		public string DormInfo_SZEmpID
		{
			get; set;
		}
		public string DormInfo_SZEmpName
		{
			get; set;
		}

	}
	public class UpsertDormInfo_SZ : DormInfo_SZAllField
	{

	}
	public class DeleteDormInfo_SZ : DormInfo_SZAllField
	{

	}	
	public class GetDormInfo_SZ : DormInfo_SZAllField
	{

	}



}