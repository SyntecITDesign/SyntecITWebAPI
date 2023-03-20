using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.JIRA_Related;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Syntec.JiraHelper;
using System.Net.Http;
using System.Text;


namespace SyntecITWebAPI.Models.JiraAPI_Related
{

	internal class PublicJiraWorklogAPIHandler
	{
		#region

		#endregion

		#region Internal Methods
		//JIRA議題狀態設定
		internal string CreateJiraIssueLinks( JiraIssueLinkCreate JiraIssueLinkCreateParameter )
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );
			string results = "";

			//取得Issue各欄位
				string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + JiraIssueLinkCreateParameter.issueID;
			HttpResponseMessage Response = client.GetAsync( targetUrl ).Result;
			JObject jobjectRI = JObject.Parse( Response.Content.ReadAsStringAsync().Result );

			for( int j = 0; j < jobjectRI[ "fields" ][ "issuelinks" ].Count(); j++ )
			{
				HttpResponseMessage DeleteResponse = client.DeleteAsync( "https://jira.syntecclub.com/rest/api/2/issueLink/" + jobjectRI[ "fields" ][ "issuelinks" ][ j ][ "id" ].ToString() ).Result;
				results = DeleteResponse.Content.ReadAsStringAsync().Result;
			}

			foreach( var outwardIssue in JiraIssueLinkCreateParameter.RelatedIssues.Split( ',' ) )
			{
				//
				HttpContent HContent = new StringContent( "{\"inwardIssue\": {\"key\": \"" + JiraIssueLinkCreateParameter.issueID + "\"},\"outwardIssue\": {\"key\": \"" + outwardIssue + "\"},\"type\": {\"id\": \"" + JiraIssueLinkCreateParameter.linkType + "\"}}", Encoding.UTF8, "application/json" );

				targetUrl = "https://jira.syntecclub.com/rest/api/2/issueLink";
				HttpResponseMessage insertLinkResponse = client.PostAsync( targetUrl, HContent ).Result;
				results = insertLinkResponse.Content.ReadAsStringAsync().Result;
			}

			return results.ToString();
		}


		//JIRA議題狀態設定
		internal string UpdateJiraIssueStatu( JiraIssueTransition JiraIssueTransitionParameter )
		{
			HttpClient client = new HttpClient();

			//變更議題狀態
			HttpContent issueTransitionHContent = new StringContent( "{\"transition\": {" +
				"\"id\":\"" + JiraIssueTransitionParameter.transitionID + "\"" + //工作流程id
				"}}", Encoding.UTF8, "application/json" );

			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + JiraIssueTransitionParameter.issueID + "/transitions";
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );
			HttpResponseMessage issueTransitionresponse = client.PostAsync( targetUrl, issueTransitionHContent ).Result;
			return issueTransitionresponse.Content.ReadAsStringAsync().Result;
		}

		//審核通過後，需建立對應之危機處理CM Jira議題
		internal string CreateJiraIssue( CreateJiraIssue CreateJiraIssueParameter )
		{
			HttpClient client = new HttpClient();
			HttpContent HContent = new StringContent( "{\"fields\": {" +
					"\"project\": {\"id\": \"15590\" }," + //危機處理測試專區 project id:15590；危機處理專區 project id:15390
					"\"reporter\": {\"name\": \"" + CreateJiraIssueParameter.reporter + "\" }," +  //報告人
					"\"customfield_17121\":  {\"value\":\"" + CreateJiraIssueParameter.createDept + "\"}," +  //發起單位
					"\"summary\": \"" + CreateJiraIssueParameter.summary + "\"," + //摘要
					"\"description\": \"" + CreateJiraIssueParameter.description + "\"," + //描述
					"\"assignee\": {\"name\": \"" + CreateJiraIssueParameter.assignee + "\" }," + //負責人
					"\"duedate\": \"" + CreateJiraIssueParameter.duedate + "\"," + //到期日
					"\"issuetype\": {\"name\": \"故事\" }," + //類型
					"\"priority\": {\"id\": \"1\" }," + //嚴重程度
					"\"components\": [{\"name\": \"危機處理\" }]" + //模組
				"}}", Encoding.UTF8, "application/json" );

			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue";
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );

			HttpResponseMessage response = client.PostAsync( targetUrl, HContent ).Result;

			//JIRA議題監看者設定為報告人
			var JResult = JObject.Parse( response.Content.ReadAsStringAsync().Result.ToString() );
			HttpContent AddWatcherHContent = new StringContent( "\"" + CreateJiraIssueParameter.reporter + "\"", Encoding.UTF8, "application/json" );

			targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + JResult[ "key" ].ToString() + "/watchers";
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );

			HttpResponseMessage AddWatcherResponse = client.PostAsync( targetUrl, AddWatcherHContent ).Result;


			return response.Content.ReadAsStringAsync().Result;
		}

		//危機處理議題派工
		internal string EditJiraIssueForShortTermCreate( EditJiraIssue EditJiraIssueParameter )
		{
			HttpClient client = new HttpClient();
			//變更議題欄位內容
			HttpContent HContent = new StringContent( "{\"fields\": {" +
					"\"assignee\": {\"name\": \"" + EditJiraIssueParameter.teamLeader + "\" }," + //負責人
					"\"duedate\": \"" + EditJiraIssueParameter.duedate + "\"," + //到期日
					"\"customfield_16827\":  {\"value\":\"" + EditJiraIssueParameter.teamLeaderDept + "\"}," + //當責單位
					"\"customfield_17021\": \"" + EditJiraIssueParameter.teamMembers + "\"" + //危機小組成員
				"}}", Encoding.UTF8, "application/json" );
			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + EditJiraIssueParameter.issueID;
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );

			HttpResponseMessage response = client.PutAsync( targetUrl, HContent ).Result;

			return response.ToString();
		}

		//短期對策擬定
		internal string EditJiraIssueForShortTermPlan( EditJiraIssue EditJiraIssueParameter )
		{
			HttpClient client = new HttpClient();
			//變更議題欄位內容
			HttpContent HContent = new StringContent( "{\"fields\": {" +
					"\"assignee\": {\"name\": \"" + EditJiraIssueParameter.teamLeader + "\" }," + //負責人
					"\"customfield_17123\":  {\"value\":\"" + EditJiraIssueParameter.teamLeaderDept + "\"}," + //短期對策處理單位
					"\"customfield_16827\":  {\"value\":\"" + EditJiraIssueParameter.teamLeaderDept + "\"}," + //當責單位
					"\"customfield_17023\": \"" + EditJiraIssueParameter.problemAnalysis + "\"," + //問題標定
					"\"customfield_16829\": \"" + EditJiraIssueParameter.shortTermPlan + "\"," + //短期對策策劃
					"\"customfield_16837\": \"" + EditJiraIssueParameter.shortTermDueDate + "\"" + //短期對策預計完成日
				"}}", Encoding.UTF8, "application/json" );
			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + EditJiraIssueParameter.issueID;
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );

			HttpResponseMessage response = client.PutAsync( targetUrl, HContent ).Result;

			return response.ToString();
		}

		//短期對策執行
		internal string EditJiraIssueForShortTermExecute( EditJiraIssue EditJiraIssueParameter )
		{
			var client = new HttpClient();
			//變更議題欄位內容
			HttpContent HContent = new StringContent( "{\"fields\": {" +
					"\"duedate\": \"" + EditJiraIssueParameter.duedate + "\"," + //到期日
					"\"customfield_16835\": \"" + EditJiraIssueParameter.shortTermExecuteResponding + "\"," + //短期執行回覆
					"\"customfield_17024\": \"" + EditJiraIssueParameter.shortTermExecuteResolutiondate + "\"" + //短期對策實際完成日
				"}}", Encoding.UTF8, "application/json" );
			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + EditJiraIssueParameter.issueID;
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );

			HttpResponseMessage response = client.PutAsync( targetUrl, HContent ).Result;

			return response.ToString();
		}

		//長期對策擬定
		internal string EditJiraIssueForLongTermPlan( EditJiraIssue EditJiraIssueParameter )
		{
			var client = new HttpClient();
			//變更議題欄位內容
			HttpContent HContent = new StringContent( "{\"fields\": {" +
					"\"assignee\": {\"name\": \"" + EditJiraIssueParameter.teamLeader + "\" }," + //負責人
					"\"customfield_17124\":  {\"value\":\"" + EditJiraIssueParameter.teamLeaderDept + "\"}," + //長期對策處理單位
					"\"customfield_16827\":  {\"value\":\"" + EditJiraIssueParameter.teamLeaderDept + "\"}," + //當責單位
					"\"customfield_17026\": \"" + EditJiraIssueParameter.problemAnalysis + "\"," + //真因分析
					"\"customfield_16830\": \"" + EditJiraIssueParameter.longTermPlan + "\"," + //長期對策策劃
					"\"customfield_16840\": \"" + EditJiraIssueParameter.longTermDueDate + "\"," + //長期對策預計完成日
					"\"customfield_16925\": \"" + EditJiraIssueParameter.avoidancePolicy + "\"" + //防治再發措施
				"}}", Encoding.UTF8, "application/json" );
			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + EditJiraIssueParameter.issueID;
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );

			HttpResponseMessage response = client.PutAsync( targetUrl, HContent ).Result;

			return response.ToString();
		}

		//長期對策執行
		internal string EditJiraIssueForLongTermExecute( EditJiraIssue EditJiraIssueParameter )
		{
			var client = new HttpClient();
			//變更議題欄位內容
			HttpContent HContent = new StringContent( "{\"fields\": {" +
					"\"duedate\": \"" + EditJiraIssueParameter.duedate + "\"," + //到期日
					"\"customfield_16838\": \"" + EditJiraIssueParameter.longTermExecuteResponding + "\"," + //長期執行回覆
					"\"customfield_17031\": \"" + EditJiraIssueParameter.longTermExecuteResolutiondate + "\"," + //長期對策實際完成日
					"\"customfield_16926\": \"" + EditJiraIssueParameter.avoidancePolicyExecuteResponding + "\"" + //防治再發執行回覆
				"}}", Encoding.UTF8, "application/json" );
			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + EditJiraIssueParameter.issueID;
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );

			HttpResponseMessage response = client.PutAsync( targetUrl, HContent ).Result;

			return response.ToString();
		}

		//歸檔
		internal string CloseJiraIssue( CloseJiraIssue CloseJiraIssueParameter )
		{
			var client = new HttpClient();
			//變更議題欄位內容
			HttpContent HContent = new StringContent( "{\"fields\": {" +
					"\"assignee\": {\"name\": \"" + CloseJiraIssueParameter.assignee + "\" }," + //負責人
					"\"duedate\": \"" + CloseJiraIssueParameter.duedate + "\"," + //到期日
					"\"customfield_17032\": \"" + CloseJiraIssueParameter.reviewExplain + "\"," + //品保審查說明
					"\"customfield_17033\": \"" + CloseJiraIssueParameter.closeDate + "\"," + //結案日
					"\"customfield_16841\": {\"id\": \"" + CloseJiraIssueParameter.resolution + "\" }" + //危機處理解決方式id:18466[長短期對策皆已完成], 18467[短期已完成但無須長期對策], 18468[誤判不處理]  
				"}}", Encoding.UTF8, "application/json" );
			string targetUrl = "https://jira.syntecclub.com/rest/api/2/issue/" + CloseJiraIssueParameter.issueID;
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", "aXNzdWVyb2JvdDpTeW50ZWMxMjM0" );

			HttpResponseMessage response = client.PutAsync( targetUrl, HContent ).Result;

			return response.ToString();
		}


		#endregion Internal Methods

		#region Private Fields


		#endregion Private Fields
	}
}

