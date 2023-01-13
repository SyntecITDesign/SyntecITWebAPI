using AutoMapper;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.DeviceManangement.CRMRepairList.Return;

namespace SyntecITWebAPI.Common.AutoMapperProfile
{
	public class CRMRepairDataProfile : Profile
	{
		#region Public Constructors + Destructors

		public CRMRepairDataProfile()
		{
			IMappingExpression<JObject, CRMRepairData> mappingExpressionToMap = CreateMap<JObject, CRMRepairData>();

			mappingExpressionToMap.ForMember( d => d.serviceID, o => o.MapFrom( s => s[ "Crmid" ] ) );
			mappingExpressionToMap.ForMember( d => d.serviceDate, o => o.MapFrom( s => s[ "Created" ] ) );
			mappingExpressionToMap.ForMember( d => d.status, o => o.MapFrom( s => s[ "Status" ] ) );
			mappingExpressionToMap.ForMember( d => d.customerCompanyName, o => o.MapFrom( s => s[ "CustomerName" ] ) );
			mappingExpressionToMap.ForMember( d => d.customerContactName, o => o.MapFrom( s => s[ "CustomerContact" ] ) );
			mappingExpressionToMap.ForMember( d => d.firstCategory, o => o.MapFrom( s => s[ "Big" ] ) );
			mappingExpressionToMap.ForMember( d => d.secondCategory, o => o.MapFrom( s => s[ "Middle" ] ) );
			mappingExpressionToMap.ForMember( d => d.thirdCategory, o => o.MapFrom( s => s[ "Little" ] ) );
			mappingExpressionToMap.ForMember( d => d.problemDescription, o => o.MapFrom( s => s[ "FaultDescribe" ] ) );
			mappingExpressionToMap.ForMember( d => d.serviceDescription, o => o.MapFrom( s => s[ "ServiceDescription" ] ) );
		}

		#endregion Public Constructors + Destructors
	}
}
