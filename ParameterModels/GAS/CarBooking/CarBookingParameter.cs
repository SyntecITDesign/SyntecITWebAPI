using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.ParameterModels.GAS.CarBooking
{

	

	public class UpsertCarInfo
	{
		#region Public Properties
		public string CarID
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class UpdateCarTakeInfo
	{
		#region Public Properties
		public string EmpID
		{
			get; set;
		}
		public string CarNumber
		{
			get; set;
		}
		public string AcutalStartTime
		{
			get; set;
		}
		#endregion Public Properties
	}


	public class UpdateCarBackInfo
	{
		#region Public Properties
		public string EmpID
		{
			get; set;
		}
		public string CarNumber
		{
			get; set;
		}
		public string StartMile
		{
			get; set;
		}

		public string EndMile
		{
			get; set;
		}

		public string ErrorMemo
		{
			get; set;
		}
		public string AcutalEndTime
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class InserBlackListInfo
	{
		#region Public Properties
		public string EmpID
			{ get;set;
			}
		public string Reason
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class BlacktoWhite
	{
		#region Public Properties
		public string EmpID
		{
			get; set;
		}
	
		#endregion Public Properties
	}
}
