using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SyntecITWebAPI.ParameterModels.GAS.ApplyDorm
{
	
		
	public class GetEmpDormStatusData

	{
		public string EmpID
		{get;set;
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
	}
	

}