using SyntecITWebAPI.ParameterModels.DeviceManangement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SyntecITWebAPI.Common
{
	public class SCloudAPIProxy : IWebAccess
	{
		#region Public Methods

		public async Task<ResponseHandler> TryDownloadMultipleFile( CNCBackupDownloadParameter parameter, string accessToken )
		{
			MultipleDownloadCNCParameter multipleDownloadCNCParameter = new MultipleDownloadCNCParameter();
			multipleDownloadCNCParameter.AccessToken = accessToken;
			multipleDownloadCNCParameter.BrandInfo = SystemSetting.SYNTEC_BRANDNAME;
			multipleDownloadCNCParameter.SerialNumber = parameter.productSN;
			multipleDownloadCNCParameter.FileName = parameter.downloadFileName;
			multipleDownloadCNCParameter.FileNames = parameter.fileNameList;
			multipleDownloadCNCParameter.FileType = parameter.fileType;

			ResponseHandler responseHandler = new ResponseHandler();
			IInternalAPIParameter internalParameterAPI = multipleDownloadCNCParameter;
			Dictionary<string, string> headers = internalParameterAPI.GetHeaders();
			string uri = AlibabaAPISetting.GetDefalutURLString( nameof( TryDownloadMultipleFile ) );
			Uri apiUri = internalParameterAPI.GetDefaultUri( uri );

			return await m_httpHandler.PostDownloadFileAsync( headers, apiUri, multipleDownloadCNCParameter.GetJsonStringBody(), multipleDownloadCNCParameter.FileName );
		}

		public async Task<Stream> TryDownloadFileStream( CNCBackupDownloadParameter parameter, string accessToken )
		{
			MultipleDownloadCNCParameter multipleDownloadCNCParameter = new MultipleDownloadCNCParameter();
			multipleDownloadCNCParameter.AccessToken = accessToken;
			multipleDownloadCNCParameter.BrandInfo = SystemSetting.SYNTEC_BRANDNAME;
			multipleDownloadCNCParameter.SerialNumber = parameter.productSN;
			multipleDownloadCNCParameter.FileName = parameter.downloadFileName;
			multipleDownloadCNCParameter.FileNames = parameter.fileNameList;
			multipleDownloadCNCParameter.FileType = parameter.fileType;

			ResponseHandler responseHandler = new ResponseHandler();
			IInternalAPIParameter internalParameterAPI = multipleDownloadCNCParameter;
			Dictionary<string, string> headers = internalParameterAPI.GetHeaders();
			string uri = AlibabaAPISetting.GetDefalutURLString( nameof( TryDownloadMultipleFile ) );
			Uri apiUri = internalParameterAPI.GetDefaultUri( uri );
			return await m_httpHandler.PostDownloadFileStreamAsync( headers, apiUri, multipleDownloadCNCParameter.GetJsonStringBody(), multipleDownloadCNCParameter.FileName );
		}

		public async Task<ResponseHandler> TryGetCNCFileList( BackupListParameter backupListParameter, string accessToken )
		{
			//use Scloud paratmer
			GetCNCFileListParameter getCNCFileListParameter = new GetCNCFileListParameter();
			getCNCFileListParameter.AccessToken = accessToken;
			getCNCFileListParameter.BrandInfo = SystemSetting.SYNTEC_BRANDNAME;
			getCNCFileListParameter.SerialNumber = backupListParameter.productSN;
			getCNCFileListParameter.FileType = backupListParameter.fileType;

			ResponseHandler responseHandler = new ResponseHandler();
			IInternalAPIParameter internalParameterAPI = getCNCFileListParameter;
			Dictionary<string, string> headers = internalParameterAPI.GetHeaders();
			string uri = AlibabaAPISetting.GetDefalutURLString( nameof( TryGetCNCFileList ) );
			Uri apiUri = internalParameterAPI.GetDefaultUri( uri );

			return await m_httpHandler.PostJsonRequestAsync( headers, apiUri, getCNCFileListParameter.GetJsonStringBody() );
		}

		public async Task<ResponseHandler> TryGetToken( string account, string password )
		{
			ResponseHandler responseHandler = new ResponseHandler();

			Encoding constEncoding = Encoding.UTF8;
			account = ParameterSimpleXOR( constEncoding, account );
			password = ParameterSimpleXOR( constEncoding, password );
			account = HttpUtility.UrlEncode( account, constEncoding );
			password = HttpUtility.UrlEncode( password, constEncoding );

			Dictionary<string, string> headers = new Dictionary<string, string>()
			{
				{nameof(account) , account },
				{nameof(password) , password }
			};

			Uri tokenUri = AlibabaAPISetting.GetDefaultUri( nameof( TryGetToken ) );

			return await m_httpHandler.GetRequestAsync( headers, tokenUri );
		}

		#endregion Public Methods

		#region Private Fields

		private HttpHandler m_httpHandler = HttpHandler.Instance;

		#endregion Private Fields

		#region Private Methods

		private string ParameterSimpleXOR( Encoding PersonalEncoding, string szText )
		{
			StringBuilder EncodeStringBuilder = new StringBuilder();
			byte[] TextByteArray = PersonalEncoding.GetBytes( szText );

			foreach( byte TextSingleByte in TextByteArray )
			{
				int nEncodeByteNumber = TextSingleByte ^ 240;
				EncodeStringBuilder.Append( Convert.ToString( nEncodeByteNumber, 2 ).PadLeft( 8, '0' ) );
			}

			string szNewEncodeBitString = EncodeStringBuilder.ToString();

			List<byte> EncodeBitStringByteList = new List<byte>();

			for( int i = 0; i < szNewEncodeBitString.Length; i += 8 )
			{
				byte TempByte = Convert.ToByte( szNewEncodeBitString.Substring( i, 8 ), 2 );
				EncodeBitStringByteList.Add( TempByte );
			}

			byte[] EncodeStringByteArray = EncodeBitStringByteList.ToArray();

			string szFinalEncodeString = "";

			foreach( byte bb in EncodeStringByteArray )
			{
				szFinalEncodeString += (char)bb;
			}
			return szFinalEncodeString;
		}

		#endregion Private Methods
	}

	internal static class AlibabaAPISetting
	{
		#region Public Constructors + Destructors

		static AlibabaAPISetting()
		{
		}

		#endregion Public Constructors + Destructors

		#region Public Methods

		static public string GetDefalutURLString( string szKey )
		{
			string szHost = $"{domainName}:{port}";
			string szReturnURL = "";

			if( !APITemplate.TryGetValue( szKey, out szReturnURL ) )
			{
				return null;
			}
			szReturnURL = szReturnURL.Replace( "<host>", szHost );

			return szReturnURL;
		}

		static public Uri GetDefaultUri( string szKey )
		{
			string szReturnURL = "";
			szReturnURL = GetDefalutURLString( szKey );
			Uri UriAddress = new Uri( szReturnURL );
			return UriAddress;
		}

		#endregion Public Methods

		#region Private Fields

		private static Dictionary<string, string> APITemplate = new Dictionary<string, string>
		{
			{nameof(SCloudAPIProxy.TryGetToken), "https://<host>/SyntecSCloudWebAPI/Authorization/Token" },
			{nameof(SCloudAPIProxy.TryGetCNCFileList ),"https://<host>/SyntecSCloudWebAPI/User/File/CNC/GetFileList/<BrandInfo>/<SerialNumber>/<FileType>" },
			{nameof(SCloudAPIProxy.TryDownloadMultipleFile ),"https://<host>/SyntecSCloudWebAPI/User/File/CNC/GetMultipleFile/<BrandInfo>/<SerialNumber>/<FileType>/"},
		};

		private static string domainName = "servicescloud.syntecclub.com";
		private static string port = "443";

		#endregion Private Fields

		// Default:443, Develop Test:5488
	}
}
