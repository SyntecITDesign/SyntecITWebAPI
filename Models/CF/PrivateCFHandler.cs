using Newtonsoft.Json.Linq;
using Syntec.Notifier;
using SyntecITWebAPI.ParameterModels.CF;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SyntecITWebAPI.Models
{
	internal class PrivateCFHandler
	{
		#region Internal Methods

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

		}

		#endregion Internal Constructors + Destructors
	}
}
