using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.Parking
{

	public class GetParkingInfo
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}

		#endregion Public Properties
	}
	public class UpsertParkingInfo
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}

		public string ParkingSpaceNum
		{
			get; set;
		}


		#endregion Public Properties
	}

	public class InsertCarNumBatch
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}
		public string MotorLicense
		{
			get; set;
		}
		public string MotorLicense_Syntec
		{
			get; set;
		}
		//public string CarLicense
		//{
		//	get; set;
		//}
		//public string CarLicense_Syntec
		//{
		//	get; set;
		//}
		#endregion Public Properties
	}

}
