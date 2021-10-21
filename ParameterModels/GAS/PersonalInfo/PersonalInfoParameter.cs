using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.PersonalInfo
{


	public class GetPersonalInfo
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class GetFuzzyPersonalInfo
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}

		#endregion Public Properties
	}
	public class GetPersonalInfoByNameOrg
	{
		#region Public Properties

		public string EmpName
		{
			get; set;
		}
		public string DeptName
		{
			get; set;
		}

		#endregion Public Properties
	}
	public class GetPersonalGASInfo
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class UpsertPersonalGASInfo
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}
		public string ExtensionNum
		{
			get; set;
		}
		public string DoorCardNum
		{
			get; set;
		}
		public string MotorLicense
		{
			get; set;
		}
		public string CarLicense
		{
			get; set;
		}
		public string CarLicense_Syntec
		{
			get; set;
		}
		public string DoorCardNum2
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class InsertFreshmanGASInfo
	{
		#region Public Properties

		public string EmpName
		{
			get; set;
		}
		public string MotorLicense
		{
			get; set;
		}
		public string CarLicense
		{
			get; set;
		}
		
		#endregion Public Properties
	}

	public class GetProcessingInfo
	{
		#region Public Properties

		public string ApplicantID
		{
			get; set;
		}

		public string ApplyString
		{
			get;set;
		}

		#endregion Public Properties
	}

	public class GetParkingProcessingInfo
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}


		#endregion Public Properties
	}

	public class GetMeetingRoomProcessingInfo
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}


		#endregion Public Properties
	}
}
