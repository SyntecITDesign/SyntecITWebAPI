using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.JIRA_Related.Worklogger;
using SyntecITWebAPI.Common.DBRelated.DBManagers.JIRA_Related;
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

		internal bool UpsertJiraWorkLogRelatedIssue( UpsertJiraWorkLogRelatedIssue UpsertJiraWorkLogRelatedIssueParameter )
		{

			HttpClient client = new HttpClient();

			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + UpsertJiraWorkLogRelatedIssueParameter.issueID;
			//Basic Authentication
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );

			HttpResponseMessage response = client.GetAsync( targetUrl).Result;

			JObject jobjectRI = JObject.Parse( response.Content.ReadAsStringAsync().Result );


			UpsertJiraWorkLogRelatedIssueParameter.summary = jobjectRI[ "fields" ][ "summary" ].ToString();


			UpsertJiraWorkLogRelatedIssueParameter.type = jobjectRI[ "fields" ][ "issuetype" ][ "name" ].ToString();


			try
			{
				foreach( var component in jobjectRI[ "fields" ][ "components" ] )
				{
					UpsertJiraWorkLogRelatedIssueParameter.components = UpsertJiraWorkLogRelatedIssueParameter.components  + component[ "name" ]+ ",";
				}
			}
			catch
			{
				UpsertJiraWorkLogRelatedIssueParameter.components = "";
			}

			try
			{
				foreach( var label in jobjectRI[ "fields" ][ "labels" ] )
				{
					UpsertJiraWorkLogRelatedIssueParameter.labels = UpsertJiraWorkLogRelatedIssueParameter.labels + label.ToString() + ",";
				}				
			}
			catch
			{
				UpsertJiraWorkLogRelatedIssueParameter.labels = "";
			}

			try
			{
				UpsertJiraWorkLogRelatedIssueParameter.assignee = jobjectRI[ "fields" ][ "assignee" ][ "name" ].ToString();
			}
			catch
			{
				UpsertJiraWorkLogRelatedIssueParameter.assignee = "";
			}

			try
			{
				UpsertJiraWorkLogRelatedIssueParameter.duedate = jobjectRI[ "fields" ][ "duedate" ].ToString();
			}
			catch
			{
				UpsertJiraWorkLogRelatedIssueParameter.duedate = "";
			}



			try
			{
				if( jobjectRI[ "fields" ][ "timetracking" ][ "originalEstimate" ] != null )
				{
				UpsertJiraWorkLogRelatedIssueParameter.originalEstimate = jobjectRI[ "fields" ][ "timetracking" ][ "originalEstimate" ].ToString();
				}
			}
			catch
			{
				UpsertJiraWorkLogRelatedIssueParameter.originalEstimate = "";
			}

			bool bResult = m_WorkloggerDBManager.UpsertJiraWorkLogRelatedIssue( UpsertJiraWorkLogRelatedIssueParameter );

			
			return bResult;
		}

		internal bool InsertWorkLogs( InsertWorkLogs InsertWorkLogsParameter )
		{
			bool bResult = m_WorkloggerDBManager.InsertWorkLogs( InsertWorkLogsParameter );


			return bResult;
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

			return jobjectRI;
		}

		//新增JIRA專案到DB
		internal bool InsertJiraProjects( InsertJiraProjects InsertJiraProjectsParameter )
		{
			HttpClient client = new HttpClient();

			string targetUrl = "https://jira.syntecclub.com/rest/api/2/project";
			//Basic Authentication
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );

			HttpResponseMessage response = client.GetAsync( targetUrl ).Result;

			bool bResult = false;
			foreach( var project in response.Content.ReadAsStringAsync().Result.Replace( "[{", "" ).Replace( "}]", "" ).Split( "},{" ) )
			{
				JObject jobjectRI = JObject.Parse( "{"+project+"}" );

				InsertJiraProjectsParameter.projectID = jobjectRI[ "id" ].ToString();
				InsertJiraProjectsParameter.projectKey = jobjectRI[ "key" ].ToString();
				InsertJiraProjectsParameter.projectName = jobjectRI[ "name" ].ToString();
				InsertJiraProjectsParameter.projectTypeKey = jobjectRI[ "projectTypeKey" ].ToString();
				bResult = m_WorkloggerDBManager.InsertJiraProjects( InsertJiraProjectsParameter );
			}
			return bResult;
		}
		//新增各專案報工tag到DB
		internal bool InsertProjectTag( InsertProjectTag InsertProjectTagParameter )
		{
			bool bResult = m_WorkloggerDBManager.InsertProjectTag( InsertProjectTagParameter );
			return bResult;
		}
		internal bool DeleteProjectTag( DeleteProjectTag DeleteProjectTagParameter )
		{
			bool bResult = m_WorkloggerDBManager.DeleteProjectTag( DeleteProjectTagParameter );
			return bResult;
		}
		#endregion Internal Methods

		#region Private Fields

		private WorkloggerDBManager m_WorkloggerDBManager = new WorkloggerDBManager();

		#endregion Private Fields
	}
}

