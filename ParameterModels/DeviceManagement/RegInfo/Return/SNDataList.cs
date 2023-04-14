using Newtonsoft.Json;
using System.Collections.Generic;

namespace SyntecITWebAPI.ParameterModels.DeviceManangement.RegInfo
{
	public class SNData
	{
		#region Public Properties

		[JsonProperty( "productName" )]
		public string ProductName
		{
			get; set;
		}

		[JsonProperty( "productSN" )]
		public string ProductSN
		{
			get; set;
		}

		[JsonProperty( "warrantyPeriod" )]
		public string WarrantyPeriod
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class SNDataList
	{
		#region Public Properties

		public List<SNData> snTableData
		{
			get; set;
		}

		#endregion Public Properties
	}
}
