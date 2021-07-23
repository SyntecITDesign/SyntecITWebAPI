using AutoMapper;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.DeviceManangement.RegAnalysis.Return;
using System.Linq;

namespace SyntecITWebAPI.Common.AutoMapperProfile
{
	public class RegAnalysisProfile : Profile
	{
		#region Public Constructors + Destructors

		public RegAnalysisProfile()
		{
			// for mapping JObject to RegAnalysisParameter

			IMappingExpression<JObject, RegAnalysisMapParameter> mappingExpressionToMap = CreateMap<JObject, RegAnalysisMapParameter>();

			mappingExpressionToMap.ForMember( d => d.Value, o => o.MapFrom( s => s[ "Count" ] ) );
			mappingExpressionToMap.ForMember( d => d.ProvinceName, o => o.MapFrom( s => s[ "CustomerCompanyProvince" ] ) );
			mappingExpressionToMap.ForMember( d => d.CutomerCitys, o => o.MapFrom( s => s[ "Children" ].Cast<JObject>() ) );

			IMappingExpression<JObject, RegAnalysisCityParameter> mappingExpressionToCity = CreateMap<JObject, RegAnalysisCityParameter>();

			mappingExpressionToCity.ForMember( d => d.Value, o => o.MapFrom( s => s[ "Count" ] ) );
			mappingExpressionToCity.ForMember( d => d.CityName, o => o.MapFrom( s => s[ "CustomerCompanyCity" ] ) );

			// for mapping JObject to RegAnalysisIndustryParameter
			IMappingExpression<JObject, RegAnalysisIndustryParameter> mappingExpressionToIndustry = CreateMap<JObject, RegAnalysisIndustryParameter>();

			mappingExpressionToIndustry.ForMember( d => d.Value, o => o.MapFrom( s => s[ "Count" ] ) );
			mappingExpressionToIndustry.ForMember( d => d.IndustryName, o => o.MapFrom( s => s[ "MachineIndustry" ] ) );
		}

		#endregion Public Constructors + Destructors
	}
}
