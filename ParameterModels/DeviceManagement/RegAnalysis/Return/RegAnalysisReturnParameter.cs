using System.Collections.Generic;

namespace SyntecITWebAPI.ParameterModels.DeviceManangement.RegAnalysis.Return
{
	public class RegAnalysisReturnParameter
	{
		#region Public Properties

		public List<RegAnalysisCityParameter> customerCity
		{
			get; set;
		}

		public List<RegAnalysisIndustryParameter> customerIndustry
		{
			get; set;
		}

		public List<RegAnalysisProvinceParameter> customerProvince
		{
			get; set;
		}

		#endregion Public Properties
	}
}
