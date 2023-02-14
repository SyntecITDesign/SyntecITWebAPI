using Newtonsoft.Json;

namespace SyntecITWebAPI.ParameterModels.DeviceManangement.RegInfo
{
	public class RegistInfoTableData
	{
		#region Public Properties

		[JsonProperty( "companyName" )]
		public string CompanyName
		{
			get; set;
		}

		[JsonProperty( "companyTel" )]
		public string CompanyTel
		{
			get; set;
		}

		[JsonProperty( "endUserCity" )]
		public string EndUserCity
		{
			get; set;
		}

		[JsonProperty( "endUserCountry" )]
		public string EndUserCountry
		{
			get; set;
		}

		[JsonProperty( "endUserName" )]
		public string EndUserName
		{
			get; set;
		}

		[JsonProperty( "endUserProvince" )]
		public string EndUserProvince
		{
			get; set;
		}

		[JsonProperty( "machineIndustry" )]
		public string MachineIndustry
		{
			get; set;
		}

		[JsonProperty( "machineType" )]
		public string MachineType
		{
			get; set;
		}

		[JsonProperty( "mainMachineType" )]
		public string MainMachineType
		{
			get; set;
		}

		[JsonProperty( "productSN" )]
		public string ProductSN
		{
			get; set;
		}

		[JsonProperty( "registerData" )]
		public string RegisterDate
		{
			get; set;
		}

		#endregion Public Properties
	}
}
