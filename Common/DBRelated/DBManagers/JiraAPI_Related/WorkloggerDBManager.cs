using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.JIRA_Related.Worklogger;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.JIRA_Related
{
	internal class WorkloggerDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_dwh;
		public WorkloggerDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_dwh = configuration[ "dwh" ].Trim();
		}
		
		internal bool UpsertJiraWorkLogRelatedIssue( UpsertJiraWorkLogRelatedIssue UpsertJiraWorkLogRelatedIssueParameter )
		{
			string sql = $@"IF EXISTS( SELECT* FROM [{m_dwh}].[dbo].[JiraWorkLogRelatedIssues] WHERE[IssueID]= @Parameter0 ) " +
						$@"UPDATE [{m_dwh}].[dbo].[JiraWorkLogRelatedIssues] " +
						"SET [Summary]=@Parameter1,	" +
							"[Type]=@Parameter2," +
							"[Components]=@Parameter3," +
							"[Labels]=@Parameter4," +
							"[Assignee]=@Parameter5," +
							"[Duedate]=@Parameter6," +
							"[OriginalEstimate]=@Parameter7 " +
						"WHERE  [IssueID]=@Parameter0" +
						$@" ELSE INSERT INTO [{m_dwh}].[dbo].[JiraWorkLogRelatedIssues] ([IssueID],[Summary],[Type],[Components],[Labels],[Assignee],[Duedate],[OriginalEstimate]) VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7)";
			List<object> SQLParameterList = new List<object>()
			{
				UpsertJiraWorkLogRelatedIssueParameter.issueID,
				UpsertJiraWorkLogRelatedIssueParameter.summary,
				UpsertJiraWorkLogRelatedIssueParameter.type,
				UpsertJiraWorkLogRelatedIssueParameter.components,
				UpsertJiraWorkLogRelatedIssueParameter.labels,
				UpsertJiraWorkLogRelatedIssueParameter.assignee,
				UpsertJiraWorkLogRelatedIssueParameter.duedate,
				UpsertJiraWorkLogRelatedIssueParameter.originalEstimate
			};
			bool bResult = m_DWHdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool InsertWorkLogs( InsertWorkLogs InsertWorkLogsParameter )
		{
			string sql = $@"INSERT INTO [{m_dwh}].[dbo].[JiraWorkLogs]([EmpID],[IssueID],[WorkLogID],[TimeSpentSeconds],[Created],[Started],[Type],[Tags],[Comment]) VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertWorkLogsParameter.empID,
				InsertWorkLogsParameter.issueID,
				InsertWorkLogsParameter.workLogID,
				InsertWorkLogsParameter.timeSpentSeconds,
				InsertWorkLogsParameter.created,
				InsertWorkLogsParameter.started,
				InsertWorkLogsParameter.type,
				InsertWorkLogsParameter.tags,
				InsertWorkLogsParameter.comment
			};
			bool bResult = m_DWHdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool InsertJiraProjects( InsertJiraProjects InsertJiraProjectsParameter )
		{
			string sql = $@"INSERT INTO [{m_dwh}].[dbo].[JiraProjects]([ProjectID],[ProjectKey],[ProjectName],[ProjectTypeKey]) VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertJiraProjectsParameter.projectID,
				InsertJiraProjectsParameter.projectKey,
				InsertJiraProjectsParameter.projectName,
				InsertJiraProjectsParameter.projectTypeKey
			};
			bool bResult = m_DWHdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool InsertProjectTag( InsertProjectTag InsertProjectTagParameter )
		{
			string sql = $@"INSERT INTO [{m_dwh}].[dbo].[JiraProjectTags]([ProjectID],[TagName]) VALUES (@Parameter2,@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertProjectTagParameter.No,
				InsertProjectTagParameter.tagName,
				InsertProjectTagParameter.projectID
			};
			bool bResult = m_DWHdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DeleteProjectTag( DeleteProjectTag DeleteProjectTagParameter )
		{
			string sql = $@"DELETE FROM [{m_dwh}].[dbo].[JiraProjectTags] WHERE [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteProjectTagParameter.No
			};
			bool bResult = m_DWHdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
	}
	#endregion Internal Methods
}
