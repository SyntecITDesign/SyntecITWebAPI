using CRMService;
using OldUserService;
using System.ServiceModel;

namespace SyntecITWebAPI.Static
{
	public class WebServiceSetting
	{
		#region Public Properties

		public static dynamic CLOUD_SERVICE_CLIENT
		{
			get
			{
				return new CloudService.CloudServiceSoapClient( new BasicHttpBinding(), new EndpointAddress( CLOUD_SERVICE_URL ) );
			}
		}

		public static dynamic CRM_SERVICE_CLIENT
		{
			get
			{
				return new CRMServiceSoapClient( new BasicHttpBinding(), new EndpointAddress( CRM_SERVICE_URL ) );
			}
		}

		public static dynamic SN_SERVICE_CLIENT
		{
			get
			{
				return new SNService.SNServiceSoapClient( new BasicHttpBinding(), new EndpointAddress( SN_SERVICE_URL ) );
			}
		}

		public static dynamic USER_SERVICE_CLIENT
		{
			get
			{
				return new UserServiceSoapClient( new BasicHttpBinding(), new EndpointAddress( USER_SERVICE_URL ) );
			}
		}

		#endregion Public Properties

		#region Private Fields

		private static string CLOUD_SERVICE_URL = "http://ws.syntecclub.com.tw:3788/CloudService.asmx";
		private static string CRM_SERVICE_URL = "http://ws.syntecclub.com.tw:3789/CRMService.asmx";
		private static string SN_SERVICE_URL = "http://ws.syntecclub.com.tw:3789/SNService.asmx";
		private static string USER_SERVICE_URL = "http://ws.syntecclub.com.tw:3789/UserService.asmx";

		#endregion Private Fields
	}
}
