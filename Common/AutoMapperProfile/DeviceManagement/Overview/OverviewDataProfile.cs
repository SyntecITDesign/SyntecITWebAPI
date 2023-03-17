using AutoMapper;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.DeviceManangement.Overview.Return;

namespace SyntecITWebAPI.Common.AutoMapperProfile
{
	public class OverviewDataProfile : Profile
	{
		#region Public Constructors + Destructors

		public OverviewDataProfile()
		{
			IMappingExpression<JObject, OverviewData> mappingExpressionToMap = CreateMap<JObject, OverviewData>();

			mappingExpressionToMap.ForMember( d => d.machineSN, o => o.MapFrom( s => s[ "TypeName" ] ) );
			mappingExpressionToMap.ForMember( d => d.machineType, o => o.MapFrom( s => s[ "MainMachineType" ] ) );
			mappingExpressionToMap.ForMember( d => d.companyName, o => o.MapFrom( s => s[ "CustomerCompanyName" ] ) );
			mappingExpressionToMap.ForMember( d => d.companyContact, o => o.MapFrom( s => s[ "CustomerCompanyContact" ] ) );
			mappingExpressionToMap.ForMember( d => d.companyCountry, o => o.MapFrom( s => s[ "CustomerCompanyCountry" ] ) );
			mappingExpressionToMap.ForMember( d => d.machineIndustry, o => o.MapFrom( s => s[ "MachineIndustry" ] ) );
			mappingExpressionToMap.ForMember( d => d.productSN, o => o.MapFrom( s => s[ "ProductSN" ] ) );
			mappingExpressionToMap.ForMember( d => d.registerDate, o => o.MapFrom( s => s[ "RegisterDate" ] ) );
			mappingExpressionToMap.ForMember( d => d.warrantyDate, o => o.MapFrom( s => s[ "WarrantyDate" ] ) );
			mappingExpressionToMap.ForMember( d => d.dueDate, o => o.MapFrom( s => s[ "DueDate" ] ) );
		}

		#endregion Public Constructors + Destructors
	}
}
