using System.Collections.Generic;

namespace SyntecITWebAPI.ParameterModels.DeviceManangement.RegAnalysis.Return
{
	public class RegAnalysisCityParameter
	{
		#region Public Properties

		public string CityName
		{
			get; set;
		}

		public string Value
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class RegAnalysisMapParameter : RegAnalysisProvinceParameter
	{
		#region Public Properties

		public List<RegAnalysisCityParameter> CutomerCitys
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class RegAnalysisProvinceParameter
	{
		#region Public Properties

		public string ProvinceName
		{
			get; set;
		}

		public string Value
		{
			get; set;
		}

		#endregion Public Properties
	}
}
