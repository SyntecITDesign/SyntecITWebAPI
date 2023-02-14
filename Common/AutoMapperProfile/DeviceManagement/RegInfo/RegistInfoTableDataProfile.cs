using AutoMapper;
using SyntecITWebAPI.ParameterModels.DeviceManangement.RegInfo;
using System.Data;

namespace SyntecITWebAPI.Common.AutoMapperProfile
{
	public class RegistInfoTableDataProfile : Profile
	{
		#region Public Constructors + Destructors

		// for mapping datarow to RegistInfoTable
		public RegistInfoTableDataProfile()
		{
			IMappingExpression<DataRow, RegistInfoTableData> mappingExpression = CreateMap<DataRow, RegistInfoTableData>();

			mappingExpression.ForMember( d => d.ProductSN, o => o.MapFrom( s => s[ "ProductSN" ] ) );
			mappingExpression.ForMember( d => d.CompanyName, o => o.MapFrom( s => s[ "CompanyName" ] ) );
			mappingExpression.ForMember( d => d.CompanyTel, o => o.MapFrom( s => s[ "CompanyTel" ] ) );
			mappingExpression.ForMember( d => d.MachineType, o => o.MapFrom( s => s[ "MachineType" ] ) );
			mappingExpression.ForMember( d => d.MainMachineType, o => o.MapFrom( s => s[ "MainMachineType" ] ) );
			mappingExpression.ForMember( d => d.MachineIndustry, o => o.MapFrom( s => s[ "MachineIndustry" ] ) );
			mappingExpression.ForMember( d => d.RegisterDate, o => o.MapFrom( s => s[ "RegisterDate" ] ) );
			mappingExpression.ForMember( d => d.EndUserName, o => o.MapFrom( s => s[ "CustomerCompanyContact" ] ) );
			mappingExpression.ForMember( d => d.EndUserCountry, o => o.MapFrom( s => s[ "CustomerCompanyCountry" ] ) );
			mappingExpression.ForMember( d => d.EndUserProvince, o => o.MapFrom( s => s[ "CustomerCompanyProvince" ] ) );
			mappingExpression.ForMember( d => d.EndUserCity, o => o.MapFrom( s => s[ "CustomerCompanyCity" ] ) );
		}

		#endregion Public Constructors + Destructors
	}
}
