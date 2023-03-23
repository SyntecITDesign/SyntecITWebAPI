using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.JIRA_Related.Worklogger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Syntec.JiraHelper;
using System.Net.Http;
using System.Text;


namespace SyntecITWebAPI.Models.JiraAPI_Related.Worklogger
{

	internal class PublicJiraWorklogAPIHandler
	{
		#region

		#endregion

		#region Internal Methods
		//登入Jira
		internal JObject JiraLogin( JiraWorkLog JiraWorkLogParameter )
		{
			HttpClient client = new HttpClient();

			//登入後取得驗證secction
			HttpContent LogInHContent = new StringContent( "{\"username\": \"" + JiraWorkLogParameter.Username + "\", \"password\": \"" + JiraWorkLogParameter.Password + "\"}", Encoding.UTF8, "application/json" );
			string targetUrl = "https://jira.syntecclub.com/rest/auth/1/session";
			HttpResponseMessage LogInResponse = client.PostAsync( targetUrl, LogInHContent ).Result;

			JObject LogInResponseJson = JObject.Parse( LogInResponse.Content.ReadAsStringAsync().Result );

			return LogInResponseJson;
		}


		internal List<string> GetJiraIssues( JiraWorkLog JiraWorkLogParameter )
		{
			HttpClient client = new HttpClient();

			int startAt = 0;
			int maxResults = 50;
			int total = 1;
			List<string> Allissuekey = new List<string>();

			while( total >= startAt )
			{
				string JIRAIssues_pre = "";

				JIRAIssues_pre = JiraHelper.GetIssuesByJQL( "issuerobot", "Syntec1234", JiraWorkLogParameter.JQL + "&maxResults=" + maxResults + "&startAt=" + startAt, maxResults );

				JObject jobjectRI_pre = JObject.Parse( JIRAIssues_pre );

				total = (int)jobjectRI_pre[ "total" ];

				for( int i = 0; i < jobjectRI_pre[ "issues" ].Count(); i++ )
				{
					Allissuekey.Add( jobjectRI_pre[ "issues" ][ i ][ "key" ].ToString() + " " + jobjectRI_pre[ "issues" ][ i ][ "fields" ][ "summary" ].ToString() );
				}

				startAt += 49;
			}

			return Allissuekey;
		}


		//新增JIRA議題工作日誌
		internal JObject AddWorklog( JiraWorkLog JiraWorkLogParameter )
		{
			HttpClient client = new HttpClient();

			HttpContent AddWorklogHContent = new StringContent( "{\"comment\":\"" + JiraWorkLogParameter.comment + "\", \"started\":\"" + JiraWorkLogParameter.started + "\",\"timeSpentSeconds\":" + JiraWorkLogParameter.timeSpentSeconds + "}", Encoding.UTF8, "application/json" );

			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + JiraWorkLogParameter.issueID + "/worklog";
			//Basic Authentication
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", JiraWorkLogParameter.BasicAuth );
			//將登入取得的secction加到cookie參數
			//AddWorklogHContent.Headers.Add( "JSESSIONID", JiraWorkLogParameter.JsessionID );
			HttpResponseMessage response = client.PostAsync( targetUrl, AddWorklogHContent ).Result;

			JObject jobjectRI = JObject.Parse( response.Content.ReadAsStringAsync().Result );

			//for( int j = 0; j < jobjectRI[ "fields" ][ "issuelinks" ].Count(); j++ )
			//{
			//}

			return jobjectRI;
		}


		#endregion Internal Methods

		#region Private Fields


		#endregion Private Fields
	}
}

