using SyntecITWebAPI.ParameterModels.DeviceManangement;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Common
{
	internal interface IWebAccess
	{
		#region Public Methods

		Task<ResponseHandler> TryDownloadMultipleFile( CNCBackupDownloadParameter parameter, string accessToken );

		Task<ResponseHandler> TryGetCNCFileList( BackupListParameter backupListParameter, string accessToken );

		Task<ResponseHandler> TryGetToken( string account, string password );

		#endregion Public Methods
	}
}
