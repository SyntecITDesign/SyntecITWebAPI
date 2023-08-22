using AutoMapper;
using SyntecITWebAPI.ParameterModels.DeviceManangement.RegInfo;
using System.Data;

namespace SyntecITWebAPI.Common.AutoMapperProfile
{
	public class SNDataProfile : Profile
	{
		#region Public Constructors + Destructors

		// for mapping datarow to SNData
		public SNDataProfile()
		{
			IMappingExpression<DataRow, SNData> mappingExpression;

			mappingExpression = CreateMap<DataRow, SNData>();
			mappingExpression.ForMember( d => d.ProductSN, o => o.MapFrom( s => s[ "ProductSN" ] ) );
			mappingExpression.ForMember( d => d.ProductName, o => o.MapFrom( s => s[ "TypeName" ] ) );
			mappingExpression.ForMember( d => d.WarrantyPeriod, o => o.MapFrom( s => s[ "WarrantyDate" ] ) );
		}

		#endregion Public Constructors + Destructors
	}
}
