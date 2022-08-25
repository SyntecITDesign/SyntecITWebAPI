using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20160927;
using Microsoft.Extensions.Configuration;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.Notify;
using System;
using System.IO;
using System.Net;
using System.Text;
using SyntecITWebAPI.Enums;

namespace SyntecITWebAPI.Models
{
	internal class PublicNotifyHandler
	{
		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url

		#region Internal Constructors + Destructors

		internal PublicNotifyHandler()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "AliSetting.json", optional: false )
			.Build();

			strRegionId = configuration["strRegionId"].Trim();
			strAccessKeyId = configuration["strAccessKeyId"].Trim();
			strSecret = configuration["strSecret"].Trim();
		}

		#endregion Internal Constructors + Destructors

		#region Internal Methods

		internal bool CheckVerifyCode( CheckVerifyCode CheckVerifyCodeParameter )
		{
			bool bResult = m_publicNotifyDBManager.CheckVerifyCode( CheckVerifyCodeParameter );

			return bResult;
		}

		internal ErrorCodeList SendVerifyCode( SendVerifyCode SendVerifyCodeParameter )
		{
			Random rnd = new Random();
			string verifyCode = rnd.Next( 100000, 999999 ).ToString();
			SendVerifyCodeParameter.verifyCode = verifyCode;
			string application = SendVerifyCodeParameter.application;
			string content = "";
			switch(SendVerifyCodeParameter.language)
			{
				case "zh-TW":
					content = "【新代數控】尊敬的客戶您本次驗證碼為" + verifyCode + "請在10分鐘內使用。";
					break;

				case "en-US":
					content = "【SYNTEC CO.】Dear customer : The verification code is " + verifyCode + ". Please enter the code within 10 minutes.";
					break;

				default://zh-CN
					content = "【新代數控】尊敬的客戶您本次驗證碼為" + verifyCode + "請在10分鐘內使用。";
					break;
			}
			if(SendVerifyCodeParameter.countryCode == "86")//大陸境內
			{
				try
				{
					IClientProfile profile;
					profile = DefaultProfile.GetProfile( strRegionId, strAccessKeyId, strSecret );
					IAcsClient client = new DefaultAcsClient( profile );
					SingleSendSmsRequest request = new SingleSendSmsRequest();

					request.SignName = strSignName;//"管理控制台中配置的短信签名（状态必须是验证通过）"
					request.TemplateCode = CRMChechCode;//管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）"
					request.RecNum = SendVerifyCodeParameter.phone;//"接收号码，多个号码可以逗号分隔"
					request.ParamString = "{\"name\":\"\",\"code\":\"" + verifyCode + "\"}";//短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。"
					SingleSendSmsResponse httpResponse = client.GetAcsResponse( request );
					if(httpResponse.HttpResponse.Status != 200)
					{
						return ErrorCodeList.SMS_Failed;
					}
				}
				catch(Exception ex)
				{
					return ErrorCodeList.SMS_Failed;
				}
			}
			else//發送國際短信
			{
				try
				{
					string phone = SendVerifyCodeParameter.countryCode + Convert.ToInt32( SendVerifyCodeParameter.phone ).ToString();//國際碼+手機號碼去開頭0
					var bytes = Encoding.BigEndianUnicode.GetBytes( content );
					var result = ToHexString( bytes );
					string strTemp = "action=send&&userid=&account=SZGJ00003&password=230AB6B4E96678C32170A42CC3242459";
					strTemp += "&mobile=" + phone + "&code=8&content=" + result + "&sendTime=&extno=";
					string postResult = HttpPost( "https://dx.ipyy.net/I18NSms.aspx", strTemp );//操作成功
					if(postResult.IndexOf( "Faild" ) >= 0)
					{
						return ErrorCodeList.SMS_Failed;
					}
				}
				catch(Exception ex)
				{
					return ErrorCodeList.SMS_Failed;
				}
			}
			bool bResult = m_publicNotifyDBManager.SendVerifyCode( SendVerifyCodeParameter );
			if(bResult != true)
			{
				return ErrorCodeList.Param_Error;
			}
			else
			{
				return ErrorCodeList.Success;
			}
		}

		internal bool SendWXNotify( WXNotify WXNotifyParameter )
		{
			bool bResult = m_publicNotifyDBManager.SendWXNotify( WXNotifyParameter );

			return bResult;
		}

		internal ErrorCodeList SendAlarmMessage( SendAlarmMessage SendAlarmMessageParameter )
		{
			string application = SendAlarmMessageParameter.application;
			string content = "";
			if(SendAlarmMessageParameter.countryCode == "86")//大陸境內-阿里雲
			{
				try
				{
					IClientProfile profile;
					profile = DefaultProfile.GetProfile( strRegionId, strAccessKeyId, strSecret );
					IAcsClient client = new DefaultAcsClient( profile );
					SingleSendSmsRequest request = new SingleSendSmsRequest();

					request.SignName = strSignName;//"管理控制台中配置的短信签名（状态必须是验证通过）"
					switch(SendAlarmMessageParameter.type)
					{
						//管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）"
						case 1://正式版
							request.TemplateCode = alarmMessageCode_Formal;
							break;
						case 2://整合測試
							request.TemplateCode = alarmMessageCode_IntegrationTest;
							break;
						case 3://研發測試
							request.TemplateCode = alarmMessageCode_RdTest;
							break;
						case 4://內部測試
							request.TemplateCode = alarmMessageCode_InnerIntegrationTest;
							break;
						default://搶鮮版
							request.TemplateCode = alarmMessageCode_Beta;
							break;
					}
					request.RecNum = SendAlarmMessageParameter.phone;//"接收号码，多个号码可以逗号分隔"
					request.ParamString = "{\"machineNmae\":\""+ SendAlarmMessageParameter.machineName + "\",\"alarmInfo\":\"" + SendAlarmMessageParameter.alarmInfo + "\"}";//短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。"
					SingleSendSmsResponse httpResponse = client.GetAcsResponse( request );
					if(httpResponse.HttpResponse.Status != 200)
					{
						return ErrorCodeList.SMS_Failed;
					}
				}
				catch(Exception ex)
				{
					return ErrorCodeList.SMS_Failed;
				}
			}
			else//發送國際短信-華信
			{
				try
				{
					string phone = SendAlarmMessageParameter.countryCode + Convert.ToInt32( SendAlarmMessageParameter.phone ).ToString();//國際碼+手機號碼去開頭0
					string alarmMessageUrl = "";
					switch(SendAlarmMessageParameter.type)
					{
						case 1://正式版
							alarmMessageUrl = alarmMessageUrl_Formal;
							break;
						case 2://整合測試
							alarmMessageUrl = alarmMessageUrl_IntegrationTest;
							break;
						case 3://研發測試
							alarmMessageUrl = alarmMessageUrl_RdTest;
							break;
						case 4://內部測試
							alarmMessageUrl = alarmMessageUrl_InnerIntegrationTest;
							break;
						default://搶鮮版
							alarmMessageUrl = alarmMessageUrl_Beta;
							break;
					}
					switch(SendAlarmMessageParameter.countryCode)
					{
						case "886":
							content = "【新代數控】尊敬的客户，您的機台:" + SendAlarmMessageParameter.machineName + "發生警報:"+ SendAlarmMessageParameter.alarmInfo + "，詳情請點選:"+ alarmMessageUrl + "。";
							break;

						default:
							content = "【SYNTEC CO.】Dear customer, your machine: " + SendAlarmMessageParameter.machineName + " has an alarm: " + SendAlarmMessageParameter.alarmInfo + ", for details, please click: "+ alarmMessageUrl + ".";
							break;
					}
					var bytes = Encoding.BigEndianUnicode.GetBytes( content );
					var result = ToHexString( bytes );
					string strTemp = "action=send&&userid=&account=SZGJ00003&password=230AB6B4E96678C32170A42CC3242459";
					strTemp += "&mobile=" + phone + "&code=8&content=" + result + "&sendTime=&extno=";
					string postResult = HttpPost( "https://dx.ipyy.net/I18NSms.aspx", strTemp );//發信成功
					if(postResult.IndexOf( "Faild" ) >= 0)
					{
						return ErrorCodeList.SMS_Failed;
					}
				}
				catch(Exception ex)
				{
					return ErrorCodeList.SMS_Failed;
				}
			}
			bool bResult = m_publicNotifyDBManager.SendAlarmMessage( SendAlarmMessageParameter );
			if(bResult != true)
			{
				return ErrorCodeList.Param_Error;
			}
			else
			{
				return ErrorCodeList.Success;
			}
		}

		#endregion Internal Methods

		#region Private Fields

		private static readonly char[] HexChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

		private static string CRMChechCode = "SMS_56175037";//新代验证码
		private static string alarmMessageCode_Formal = "SMS_244010386";//正式版機台警報訊息
		private static string alarmMessageCode_IntegrationTest = "SMS_249195202";//整合測試機台警報訊息
		private static string alarmMessageCode_RdTest = "SMS_249290160";//研發測試機台警報訊息
		private static string alarmMessageCode_InnerIntegrationTest = "SMS_249085228";//內部測試機台警報訊息
		private static string alarmMessageCode_Beta = "SMS_244850028";//搶鮮版機台警報訊息

		private static string alarmMessageUrl_Formal = "http://syntec.ink/?FnbyzVRe";//正式版網址
		private static string alarmMessageUrl_IntegrationTest = "http://syntec.ink/?iFfqaaU3";//整合測試網址
		private static string alarmMessageUrl_RdTest = "http://syntec.ink/?MuaibEfy";//研發測試網址
		private static string alarmMessageUrl_InnerIntegrationTest = "http://syntec.ink/?BA2bybMI";//內部測試網址
		private static string alarmMessageUrl_Beta = "http://syntec.ink/?7mFnNQYB";//搶鮮版網址

		private static string filePath = Environment.CurrentDirectory + "\\";

		private static string strAccessKeyId;

		private static string strRegionId;

		private static string strSecret;

		//尊敬的客户${name}您本次验证码为${code}请在10分钟内使用。
		private static string strSignName = "新代数控";

		private PublicNotifyDBManager m_publicNotifyDBManager = new PublicNotifyDBManager();

		#endregion Private Fields

		#region Private Methods

		private static string HttpPost( string url, string data )
		{
			HttpWebRequest hwr = WebRequest.Create( url ) as HttpWebRequest;
			hwr.Method = "POST";
			hwr.ContentType = "application/x-www-form-urlencoded";
			byte[] payload;
			payload = System.Text.Encoding.UTF8.GetBytes( data ); //通过UTF-8编码
			hwr.ContentLength = payload.Length;
			Stream writer = hwr.GetRequestStream();
			writer.Write( payload, 0, payload.Length );
			writer.Close();
			var result = hwr.GetResponse() as HttpWebResponse; //此句是获得上面URl返回的数据
			string strMsg = WebResponseGet( result );
			return strMsg;
		}

		private static string ToHexString( byte[] bytes )
		{
			int chArrayLength = bytes.Length * 2;
			var charArray = new char[chArrayLength];
			int index = 0;
			for(var i = 0; i < chArrayLength; i += 2)
			{
				byte b = bytes[index++];
				charArray[i] = HexChars[b / 16];
				charArray[i + 1] = HexChars[b % 16];
			}
			return new String( charArray );
		}

		private static string WebResponseGet( HttpWebResponse webResponse )
		{
			StreamReader responseReader = null;
			string responseData = "";
			try
			{
				responseReader = new StreamReader( webResponse.GetResponseStream() );
				responseData = responseReader.ReadToEnd();
			}
			catch
			{
				throw;
			}
			finally
			{
				webResponse.GetResponseStream().Close();
				responseReader.Close();
				responseReader = null;
			}
			return responseData;
		}

		#endregion Private Methods
	}
}
