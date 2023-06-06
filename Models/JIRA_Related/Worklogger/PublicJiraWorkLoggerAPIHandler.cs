using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.JIRA_Related.WorkLogger;
using SyntecITWebAPI.Common.DBRelated.DBManagers.JIRA_Related;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Syntec.JiraHelper;
using System.Net.Http;
using System.Text;


namespace SyntecITWebAPI.Models.JiraAPI_Related.WorkLogger
{

	internal class PublicJiraWorkLoggerAPIHandler
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

		//取得Jira議題
		internal List<string> GetJiraIssues( JiraWorkLog JiraWorkLogParameter )
		{
			HttpClient client = new HttpClient();
			int startAt = 0;
			int total = 1;
			List<string> Allissuekey = new List<string>();

			while( total >= startAt )
			{
				HttpContent HContent = new StringContent( "{\"jql\": \"" + JiraWorkLogParameter.JQL + "\"}", Encoding.UTF8, "application/json" );
				string targetUrl = "https://jira.syntecclub.com/rest/api/2/search";
				//Basic Authentication
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", JiraWorkLogParameter.BasicAuth );

				HttpResponseMessage Response = client.PostAsync( targetUrl, HContent ).Result;

				JObject jobjectRI_pre = JObject.Parse( Response.Content.ReadAsStringAsync().Result );

				total = (int)jobjectRI_pre[ "total" ];

				for( int i = 0; i < jobjectRI_pre[ "issues" ].Count(); i++ )
				{
					Allissuekey.Add( jobjectRI_pre[ "issues" ][ i ][ "key" ].ToString() + " " + jobjectRI_pre[ "issues" ][ i ][ "fields" ][ "summary" ].ToString() );
				}

				startAt += 49;
			}

			return Allissuekey;
		}

		//取得Jira議題並更新到DB
		internal bool UpsertJiraWorkLogRelatedIssue( UpsertJiraWorkLogRelatedIssue UpsertJiraWorkLogRelatedIssueParameter )
		{
			HttpClient client = new HttpClient();

			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + UpsertJiraWorkLogRelatedIssueParameter.issueID;
			//Basic Authentication
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", UpsertJiraWorkLogRelatedIssueParameter.BasicAuth );

			HttpResponseMessage response = client.GetAsync( targetUrl ).Result;

			JObject jobjectRI = JObject.Parse( response.Content.ReadAsStringAsync().Result );
			bool bResult = false;
			if( !(jobjectRI[ "fields" ] == null) )
			{

				try
				{
					UpsertJiraWorkLogRelatedIssueParameter.summary = jobjectRI[ "fields" ][ "summary" ].ToString();
				}
				catch
				{
					UpsertJiraWorkLogRelatedIssueParameter.summary = "";
				}

				UpsertJiraWorkLogRelatedIssueParameter.type = jobjectRI[ "fields" ][ "issuetype" ][ "name" ].ToString();
				UpsertJiraWorkLogRelatedIssueParameter.ProjectKey = jobjectRI[ "fields" ][ "project" ][ "key" ].ToString();

				UpsertJiraWorkLogRelatedIssueParameter.status = jobjectRI[ "fields" ][ "status" ][ "name" ].ToString();

				try
				{
					foreach( var component in jobjectRI[ "fields" ][ "components" ] )
					{
						UpsertJiraWorkLogRelatedIssueParameter.components = UpsertJiraWorkLogRelatedIssueParameter.components + component[ "name" ] + ",";
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
						int extimateSec = 0;
						foreach( string extimate in jobjectRI[ "fields" ][ "timetracking" ][ "originalEstimate" ].ToString().Split( " " ) )
						{
							if( extimate.Contains( "w" ) )
							{
								int extimateInt = Convert.ToInt32( extimate.Replace( "w", "" ) );
								extimateSec = extimateSec + extimateSec * 5 * 8 * 60 * 60;
							}
							if( extimate.Contains( "d" ) )
							{
								int extimateInt = Convert.ToInt32( extimate.Replace( "d", "" ) );
								extimateSec = extimateSec + extimateInt * 8 * 60 * 60;
							}
							if( extimate.Contains( "h" ) )
							{
								int extimateInt = Convert.ToInt32( extimate.Replace( "h", "" ) );
								extimateSec = extimateSec + extimateSec * 60 * 60;
							}
						}
						UpsertJiraWorkLogRelatedIssueParameter.originalEstimate = extimateSec;

					}

				}
				catch
				{
					UpsertJiraWorkLogRelatedIssueParameter.originalEstimate = 0;
				}

				bResult = m_WorkLoggerDBManager.UpsertJiraWorkLogRelatedIssue( UpsertJiraWorkLogRelatedIssueParameter );


				return bResult;
			}
			else
			{
				return true;
			}

		}

		//確認是否有一天內沒更新的議題資訊
		internal bool CheckIssueUpdateTime( UpsertJiraWorkLogRelatedIssue UpsertJiraWorkLogRelatedIssueParameter )
		{
			DataTable dtResult = m_WorkLoggerDBManager.CheckIssueUpdateTime( UpsertJiraWorkLogRelatedIssueParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return false;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				bool IssueUpdateOK = true;
				foreach( var issue in ja )
				{
					UpsertJiraWorkLogRelatedIssueParameter.issueID = issue[ "IssueID" ].ToString();
					IssueUpdateOK = UpsertJiraWorkLogRelatedIssue( UpsertJiraWorkLogRelatedIssueParameter );
				}

				return IssueUpdateOK;
			}

		}


		//同步新增的Jira WorkLogsw資料到DB
		internal bool InsertWorkLogs( InsertWorkLogs InsertWorkLogsParameter )
		{
			bool bResult = m_WorkLoggerDBManager.InsertWorkLogs( InsertWorkLogsParameter );


			return bResult;
		}

		//新增JIRA議題工作日誌
		internal JObject AddWorkLog( JiraWorkLog JiraWorkLogParameter )
		{
			HttpClient client = new HttpClient();

			HttpContent AddWorkLogHContent = new StringContent( "{\"comment\":\"" + JiraWorkLogParameter.comment.Replace( "\n", "\\n" ).Replace( "\"", "\'" ) + "\", \"started\":\"" + JiraWorkLogParameter.started + "\",\"timeSpentSeconds\":" + JiraWorkLogParameter.timeSpentSeconds + "}", Encoding.UTF8, "application/json" );

			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + JiraWorkLogParameter.issueID + "/worklog";
			//Basic Authentication
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", JiraWorkLogParameter.BasicAuth );
			//將登入取得的secction加到cookie參數
			//AddWorkLogHContent.Headers.Add( "JSESSIONID", JiraWorkLogParameter.JsessionID );
			HttpResponseMessage response = client.PostAsync( targetUrl, AddWorkLogHContent ).Result;

			JObject jobjectRI = JObject.Parse( response.Content.ReadAsStringAsync().Result );

			return jobjectRI;
		}

		//取得不同project的tag列表
		internal JArray GetProjectTags( GetProjectTags GetProjectTagsParameter )
		{
			DataTable dtResult = m_WorkLoggerDBManager.GetProjectTags( GetProjectTagsParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		//新增各專案報工tag到DB
		internal bool UpsertProjectTag( UpsertProjectTag UpsertProjectTagParameter )
		{
			bool bResult = m_WorkLoggerDBManager.UpsertProjectTag( UpsertProjectTagParameter );
			return bResult;
		}

		internal bool DeleteProjectTag( DeleteProjectTag DeleteProjectTagParameter )
		{
			bool bResult = m_WorkLoggerDBManager.DeleteProjectTag( DeleteProjectTagParameter );
			return bResult;
		}

		//取得員工相關資訊
		internal JArray GetEmpInfo( GetEmpInfo GetEmpInfoParameter )
		{
			DataTable dtResult = m_WorkLoggerDBManager.GetEmpInfo( GetEmpInfoParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		//取得相關報工資訊
		internal JArray GetSumSpentSeconds( GetSumSpentSeconds GetSumSpentSecondsParameter )
		{
			DataTable dtResult = m_WorkLoggerDBManager.GetSumSpentSeconds( GetSumSpentSecondsParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		//取得JiraWorklogger後台權限資訊
		internal JArray GetJiraWorkLoggerAccess( GetJiraWorkLoggerAccess GetJiraWorkLoggerAccessParameter )
		{
			DataTable dtResult = m_WorkLoggerDBManager.GetJiraWorkLoggerAccess( GetJiraWorkLoggerAccessParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		//取得特定project的Worklog部門資訊
		internal JArray GetSuperDeptOfWorkLogs( GetSuperDeptOfWorkLogs GetSuperDeptOfWorkLogsParameter )
		{
			DataTable dtResult = m_WorkLoggerDBManager.GetSuperDeptOfWorkLogs( GetSuperDeptOfWorkLogsParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}


		//更新JiraWorklogger後台權限資訊
		internal bool UpdateJiraWorkLoggerAccess( UpdateJiraWorkLoggerAccess UpdateJiraWorkLoggerAccessParameter )
		{
			bool bResult = m_WorkLoggerDBManager.UpdateJiraWorkLoggerAccess( UpdateJiraWorkLoggerAccessParameter );
			return bResult;
		}


		//新增使用者操作系統log
		internal bool InsertActionLog( InsertActionLog InsertActionLogParameter )
		{
			bool bResult = m_WorkLoggerDBManager.InsertActionLog( InsertActionLogParameter );
			return bResult;
		}


		#endregion Internal Methods

		#region Private Fields

		private WorkLoggerDBManager m_WorkLoggerDBManager = new WorkLoggerDBManager();

		#endregion Private Fields
	}
}

