using Newtonsoft.Json.Linq;
using Syntec.Notifier;
using SyntecITWebAPI.ParameterModels.CF;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using Aliyun.OSS;
using System.Threading.Tasks;
using SyntecITWebAPI.ParameterModels.GAS.GASNotify;
using System.Linq;

namespace SyntecITWebAPI.Models
{
	internal class PrivateCFHandler
	{
		#region Internal Methods
		

		internal async Task<bool> CFSendPdfEmailNewAsync( CFService_CFSendPdfEmail CFService_CFSendPdfEmailParameter )
		{
			try
			{
				Random randomNumber = new Random();
				filePath = filePath + randomNumber.Next( 1, 1000 ).ToString();
				INotifier mailNotifier = new MailNotifier();
				string contentStr = "請點選以下連結下載";
				mailNotifier.Title = CFService_CFSendPdfEmailParameter.title;
				mailNotifier.UserName = CFService_CFSendPdfEmailParameter.userEmail;
				int attachmentCount = 0;

				
				string Garbled = GetGarbled();
				string CurYear = DateTime.Today.ToString( "yyyy" );
				string CurMonth = DateTime.Today.ToString( "MM" );
				
				

				//download CF PDF by pageID
				foreach(string pageID in CFService_CFSendPdfEmailParameter.pageIDList)
				{
					if(pageID == "")
					{
						continue;
					}
					else
					{
						string fileName = "";
						HttpClient client = new HttpClient();
						client.Timeout = TimeSpan.FromMinutes(10);//最多等待10分鐘，實測20MB需約4分鐘左右

						//get title by pageid
						string targetUrl = "https://confluence.syntecclub.com/rest/api/content/" + pageID;
						var byteArray = Encoding.ASCII.GetBytes( strConfluenceAccount + ":" + strConfluencePassword );
						client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", Convert.ToBase64String( byteArray ) );

						HttpResponseMessage response =  await client.GetAsync( targetUrl ).ConfigureAwait(false);
						if(response.IsSuccessStatusCode)
						{
							// Parse the response body.
							var customerJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
							var result = await response.Content.ReadAsStringAsync().ConfigureAwait( false );
							CFContent CFContent = Newtonsoft.Json.JsonConvert.DeserializeObject<CFContent>( result );
							fileName = CFContent.title + ".pdf";
							fileName = ReplaceText( fileName );
						}
						//download pdf by pageid scope current vs descendants
						string strTemplateID = "0d3b213f-e04a-4d10-820e-765eb051ea04";
						string url = "https://confluence.syntecclub.com/plugins/servlet/scroll-pdf/api/public/1/export-sync?templateId=" + strTemplateID
								+ "&pageId=" + pageID + "&scope=current&os_username=" + strConfluenceAccount + "&os_password=" + strConfluencePassword;

						System.IO.FileStream fs;
						client.DefaultRequestHeaders.Add( "User-Agent", @"Mozilla/5.0 (compatible; Baiduspider/2.0; +http://www.baidu.com/search/spider.html)" ); // add autonomous driving is very important, no detailed study, will be able to download the file does add on
						client.DefaultRequestHeaders.Add( "Accept", @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8" ); // add data format


						//var bytes = await client.GetByteArrayAsync( url ).ConfigureAwait(false);

						Stream test = await client.GetStreamAsync( url ).ConfigureAwait( false );

						System.IO.Directory.CreateDirectory( filePath );
						if(File.Exists( filePath + "//" + fileName ))
						{
							File.Delete( filePath + "//" + fileName );
						}
						fs = new System.IO.FileStream( filePath + "//" + fileName, System.IO.FileMode.CreateNew );
						await test.CopyToAsync( fs );
						//fs.Write( bytes, 0, bytes.Length );
						fs.Close();
						
						//add Email attachment
						string strAttachment = filePath + "//" + fileName;
						//mailNotifier.SetParam( "Attachment" + attachmentCount, strAttachment );
						//attachmentCount++;

						////UploadtoOSS
						OssClient clientOSS = new OssClient( Endpoint, AccessKey, AccessKeySecret );
						clientOSS.CreateBucket( BucketName );
						clientOSS.PutObject( BucketName, CurYear + "/" + CurMonth + "/" + Garbled + "/" + fileName, strAttachment );
						contentStr = contentStr + "<br/> https://" + BucketName+"."+ Endpoint+"/"+ CurYear + "/" + CurMonth + "/" + Garbled + "/" + fileName;
					}
				}
				//send Email
				mailNotifier.Content = contentStr;
				mailNotifier.SetParam( "AttachmentCount", attachmentCount );
				if(mailNotifier.Notify() == false)
				{
					//delete whole folder
					Directory.Delete( filePath, true );
					return false;
				}
				else
				{
					//delete whole folder
					Directory.Delete( filePath, true );
					return true;
				}
			}
			catch(Exception ex)
			{
				//Console.WriteLine( string.Format( ex.ToString() ));

				string strKey = "3ef74208-bf04-4515-9a22-915f064108e8";
				var TotalpageID = (CFService_CFSendPdfEmailParameter.pageIDList).Aggregate( ( a, b ) => a + ", " + b );
				string NotifyContent = CFService_CFSendPdfEmailParameter.userEmail+ " 匯出pageIDList [" + TotalpageID + "] 失敗";
				Syntec.Notifier.WeixinNotifier _WeixinNotifier = new Syntec.Notifier.WeixinNotifier();
				bool checkWeixin = _WeixinNotifier.WeixinTextNotify( strKey, NotifyContent, "@all", "" );
		
				return false;
			}
		}

		internal bool CFSendPdfEmail( CFService_CFSendPdfEmail CFService_CFSendPdfEmailParameter )
		{
			try
			{
				Random randomNumber = new Random();
				filePath = filePath + randomNumber.Next( 1, 1000 ).ToString();
				INotifier mailNotifier = new MailNotifier();
				mailNotifier.Content = CFService_CFSendPdfEmailParameter.content;
				mailNotifier.Title = CFService_CFSendPdfEmailParameter.title;
				mailNotifier.UserName = CFService_CFSendPdfEmailParameter.userEmail;
				int attachmentCount = 0;
				//download CF PDF by pageID
				foreach(string pageID in CFService_CFSendPdfEmailParameter.pageIDList)
				{
					if(pageID == "")
					{
						continue;
					}
					else
					{
						string fileName = "";
						var client = new HttpClient();
						//get title by pageid
						string targetUrl = "https://confluence.syntecclub.com/rest/api/content/" + pageID;
						var byteArray = Encoding.ASCII.GetBytes( strConfluenceAccount + ":" + strConfluencePassword );
						client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", Convert.ToBase64String( byteArray ) );

						HttpResponseMessage response = client.GetAsync( targetUrl ).Result;
						if(response.IsSuccessStatusCode)
						{
							// Parse the response body.
							var customerJsonString = response.Content.ReadAsStringAsync();
							var result = response.Content.ReadAsStringAsync().Result;
							CFContent CFContent = Newtonsoft.Json.JsonConvert.DeserializeObject<CFContent>( result );
							fileName = CFContent.title + ".pdf";
							fileName = ReplaceText( fileName );
						}
						//download pdf by pageid scope current vs descendants
						string strTemplateID = "0d3b213f-e04a-4d10-820e-765eb051ea04";
						string url = "https://confluence.syntecclub.com/plugins/servlet/scroll-pdf/api/public/1/export-sync?templateId=" + strTemplateID
								+ "&pageId=" + pageID + "&scope=current&os_username=" + strConfluenceAccount + "&os_password=" + strConfluencePassword;

						System.IO.FileStream fs;
						client.DefaultRequestHeaders.Add( "User-Agent", @"Mozilla/5.0 (compatible; Baiduspider/2.0; +http://www.baidu.com/search/spider.html)" ); // add autonomous driving is very important, no detailed study, will be able to download the file does add on
						client.DefaultRequestHeaders.Add( "Accept", @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8" ); // add data format
						var bytes = client.GetByteArrayAsync( url ).Result;
						System.IO.Directory.CreateDirectory( filePath );
						if(File.Exists( filePath + "//" + fileName ))
						{
							File.Delete( filePath + "//" + fileName );
						}
						fs = new System.IO.FileStream( filePath + "//" + fileName, System.IO.FileMode.CreateNew );
						fs.Write( bytes, 0, bytes.Length );
						fs.Close();

						//add Email attachment
						string strAttachment = filePath + "//" + fileName;
						mailNotifier.SetParam( "Attachment" + attachmentCount, strAttachment );
						attachmentCount++;
					}
				}
				//send Email
				mailNotifier.SetParam( "AttachmentCount", attachmentCount );
				if(mailNotifier.Notify() == false)
				{
					//delete whole folder
					Directory.Delete( filePath, true );
					return false;
				}
				else
				{
					//delete whole folder
					Directory.Delete( filePath, true );
					return true;
				}
			}
			catch(Exception ex)
			{
				return false;
			}
		}


		internal JArray CheckCFPageIDNotExist( CFService_CFSendPdfEmail CFService_CFSendPdfEmailParameter )
		{
			try
			{
				JArray ja = new JArray();
				foreach(string pageID in CFService_CFSendPdfEmailParameter.pageIDList)
				{
					if(pageID == "")
					{
						continue;
					}
					else
					{
						string fileName = "";
						var client = new HttpClient();
						//get title by pageid
						string targetUrl = "https://confluence.syntecclub.com/rest/api/content/" + pageID;
						var byteArray = Encoding.ASCII.GetBytes( strConfluenceAccount + ":" + strConfluencePassword );
						client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", Convert.ToBase64String( byteArray ) );

						HttpResponseMessage response = client.GetAsync( targetUrl ).Result;
						if(!response.IsSuccessStatusCode)
						{
							ja.Add( pageID );
						}
					}
				}
				return ja;
			}
			catch(Exception ex)
			{
				return null;
			}
		}

		#endregion Internal Methods


		#region Private Fields

		private static string filePath = Environment.CurrentDirectory + "\\";
		private static string strConfluenceAccount;
		private static string strConfluencePassword;
		private static string AccessKey;
		private static string AccessKeySecret;
		private static string BucketName;
		private static string Endpoint;

		#endregion Private Fields

		#region Internal Constructors + Destructors

		internal PrivateCFHandler()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "CFSetting.json", optional: false )
			.Build();

			strConfluenceAccount = configuration["strConfluenceAccount"].Trim();
			strConfluencePassword = configuration["strConfluencePassword"].Trim();


			//OSS configuration
			var configuration_OSS = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "OssSetting.json", optional: false )
			.Build();

			AccessKey = configuration_OSS[nameof( AccessKey )].Trim();
			AccessKeySecret = configuration_OSS[nameof( AccessKeySecret )].Trim();
			BucketName = configuration_OSS[nameof( BucketName )].Trim();
			Endpoint = configuration_OSS[nameof( Endpoint )].Trim();
		}

		#endregion Internal Constructors + Destructors

		#region Private Methods
		private string ReplaceText( string replaceString )
		{
			try
			{
				return replaceString.Replace( "\\", "" ).Replace( "/", "" ).Replace( ":", "" ).Replace( "*", "" ).Replace( "?", "" )
					.Replace( "\"", "" ).Replace( "<", "" ).Replace( ">", "" ).Replace( "|", "" ).Replace( " ", "" ).Trim();
			}
			catch( Exception ex )
			{
				return replaceString;
			}
		}

		#endregion Private Methods

		 public static string GetGarbled(){
			string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
			int passwordLength = 10;//密碼長度
			char[] chars = new char[ passwordLength ];
			Random rd = new Random();

			for( int i = 0; i < passwordLength; i++ )
			{
				//allowedChars -> 這個String ，隨機取得一個字，丟給chars[i]
				chars[ i ] = allowedChars[ rd.Next( 0, allowedChars.Length ) ];
			}

			string pwd = new string( chars );

			return pwd;
		}



		

	}
}
