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
}
