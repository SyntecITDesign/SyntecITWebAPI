using AutoMapper;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.DeviceManangement;
using System.Linq;

namespace SyntecITWebAPI.Common.AutoMapperProfile
{
	public class CNCBackupListProfile : Profile
	{
		#region Public Constructors + Destructors

		// https://stackoverflow.com/questions/57182386/how-to-map-nested-json-to-class-object-using-auto-mapper-in-c-sharp
		public CNCBackupListProfile()
		{
			IMappingExpression<JObject, CNCBackupList> mappingExpressionToCNCBackupList = CreateMap<JObject, CNCBackupList>();

			mappingExpressionToCNCBackupList.ForMember( d => d.totalCount, o => o.MapFrom( s => s[ "totalCount" ] ) );
			mappingExpressionToCNCBackupList.ForMember( d => d.dataList, o => o.MapFrom( s => s[ "dataList" ].Cast<JObject>() ) );

			IMappingExpression<JObject, SingleFileData> mappingExpressionToSingleFileData = CreateMap<JObject, SingleFileData>();
			mappingExpressionToSingleFileData.ForMember( d => d.fileName, o => o.MapFrom( s => s[ "file_name" ] ) );
			mappingExpressionToSingleFileData.ForMember( d => d.fileSize, o => o.MapFrom( s => s[ "file_size" ] ) );
			mappingExpressionToSingleFileData.ForMember( d => d.fileExtension, o => o.MapFrom( s => s[ "file_extension" ] ) );
			mappingExpressionToSingleFileData.ForMember( d => d.fileTime, o => o.MapFrom( s => s[ "file_time" ] ) );
		}

		#endregion Public Constructors + Destructors
	}
}
