using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syntec.DataTransfer;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models
{
	public class WeChatHandler
	{
		#region Internal Fields

		internal string exceptionString;

		#endregion Internal Fields

		#region Internal Constructors + Destructors

		internal WeChatHandler()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "WeChatSetting.json", optional: false )
			.Build();

			appId = configuration[ nameof( appId ) ].Trim();
			appSecret = configuration[ nameof( appSecret ) ].Trim();
			apiUrl = configuration[ nameof( apiUrl ) ].Trim();
			sendApiUrl = configuration[ nameof( sendApiUrl ) ].Trim();
		}

		#endregion Internal Constructors + Destructors

		#region Internal Methods

		internal ErrorCodeList WeChatBind( string openID, string userID )
		{
			//根據userService的input要求做參數轉換
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add( "Key" );
			dataTable.Columns.Add( "Value" );
			dataTable.Rows.Add( "wechatId", openID );
			string jsonParameter = JsonConvert.SerializeObject( dataTable );

			string result = UserServiceBindUserWechat( userID, jsonParameter );
			//因result是兩層json故取0-7 ex {{"0000"}:...}
			if( result.Substring( 0, 7 ).IndexOf( "0000" ) > 0 )
				return ErrorCodeList.Success;
			else
				return ErrorCodeList.System_Error;
		}

		//if OpenID not exist return openID else return tokens
		internal List<object> WeChatLogin( string code, string userIP )
		{
			TokenHandler tokenHandler = new TokenHandler();
			string openID = getOpenIdByCode( code );
			List<object> result = new List<object>();

			if( string.IsNullOrEmpty( openID ) )
			{
				result.Add( ErrorCodeList.WeChat_GetOpenID_Error );
				return result;
			}
			else
			{
				//Get userInfo json from userService with openID
				string userInfoResult = UserServiceGetUserInfo( openID );
				//因result是兩層json故取0-7 ex {{"0000"}:...}
				if( userInfoResult.Substring( 0, 7 ).IndexOf( "0000" ) > 0 )
				{
					//登入成功且非首次登入
					if( userInfoResult.Substring( 0, 30 ).IndexOf( "\"0000\":\"WechatWithoutBinding\"" ) <= 0 )
					{
						DataTable dateTableResult = JsonHelper.JsonToDataTable( userInfoResult, "GetSyntecUserInfoOption" );
						if( dateTableResult != null && dateTableResult.Rows.Count > 0 )
						{
							//Get UserID => Create Token
							string userID = dateTableResult.Rows[ 0 ][ "UserID" ].ToString();
							JObject tokenObject = tokenHandler.CreateAllToken( userID, userIP, "," + openID );
							if( tokenObject != null )
							{
								result.Add( ErrorCodeList.Success );
								result.Add( tokenObject );
								result.Add( userID );

								return result;
							}
							else
							{
								result.Add( ErrorCodeList.Auth_Error );
								return result;
							}
						}
					}
				}
				//首次登入
				result.Add( ErrorCodeList.WeChat_First_Login );
				JObject openIdJson = new JObject
				{
					{nameof(openID),openID }
				};
				result.Add( openIdJson );
				return result;
			}
		}

		internal bool WeChatMessage( string openID, string message )
		{
			Token wechatToken = new Token();
			string accessWeChatToken = wechatToken.getToken( appId, appSecret );
			string url = sendApiUrl.Replace( "ACCESSTOKEN", accessWeChatToken );

			var data = new
			{
				touser = openID,
				msgtype = "text",
				text = new
				{
					content = message
				}
			};

			HTTPReauest httpReauest = new HTTPReauest();
			string result = httpReauest.HttpPost( url, JsonConvert.SerializeObject( data ) );

			Dictionary<string, object> jsonResult = JsonConvert.DeserializeObject<Dictionary<string, object>>( result );

			try
			{
				if( jsonResult[ "errmsg" ] != null && jsonResult[ "errmsg" ].ToString() == "ok" ) //檢查呼叫wechat api 的結果
				{
					return true;
				}
				else
				{
					exceptionString = jsonResult[ "errmsg" ].ToString();
					return false;
				}
			}
			catch( Exception ex )
			{
				exceptionString = ex.Message;
				return false;
			}
		}

		#endregion Internal Methods

		#region Private Fields

		private string apiUrl;
		private string appId;
		private string appSecret;
		private string sendApiUrl;

		#endregion Private Fields

		#region Private Methods

		private string getOpenIdByCode( string code )
		{
			string weixinApiResult = new WebClient().DownloadString(
				apiUrl.Replace( "APPID", appId ).Replace( "SECRET", appSecret ).Replace( "CODE", code )
				);

			Dictionary<string, object> jsonResult = JsonConvert.DeserializeObject<Dictionary<string, object>>( weixinApiResult );
			object openid;
			if( jsonResult.TryGetValue( nameof( openid ), out openid ) )
			{
				if( !string.IsNullOrEmpty( openid.ToString() ) )
					return openid.ToString();
				else
					return null;
			}
			else
				return null;
		}

		private string UserServiceBindUserWechat( string userID, string weChatJsonParameter )
		{
			var client = WebServiceSetting.USER_SERVICE_CLIENT;

			Task<string> BindUserWeChatOptionTask = client.BindUserWechatOptionAsync( userID, "Option", weChatJsonParameter );

			string response = BindUserWeChatOptionTask.Result;

			return response;
		}

		private string UserServiceGetUserInfo( string openId )
		{
			var client = WebServiceSetting.USER_SERVICE_CLIENT;

			Task<string> getSyntecUserInfoOptionTask = client.GetSyntecUserInfoOptionAsync( openId, "Option" );

			string response = getSyntecUserInfoOptionTask.Result;

			return response;
		}

		#endregion Private Methods
	}
}
