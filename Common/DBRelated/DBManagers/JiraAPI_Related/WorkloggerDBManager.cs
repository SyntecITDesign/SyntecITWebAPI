using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.JIRA_Related.WorkLogger;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.JIRA_Related
{
	internal class WorkLoggerDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_barcode;
		public string m_JiraWorkLogger;
		public WorkLoggerDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_barcode = configuration[ "barcode" ].Trim();
			m_JiraWorkLogger = configuration[ "WorkLogger" ].Trim();
		}
		
		internal bool UpsertJiraWorkLogRelatedIssue( UpsertJiraWorkLogRelatedIssue UpsertJiraWorkLogRelatedIssueParameter )
		{
			string sql = $@"IF EXISTS( SELECT* FROM [{m_JiraWorkLogger}].[dbo].[JiraWorkLogRelatedIssues] WHERE[IssueID]= @Parameter0 ) " +
						$@"UPDATE [{m_JiraWorkLogger}].[dbo].[JiraWorkLogRelatedIssues] " +
						"SET [Summary]=@Parameter1,	" +
							"[Type]=@Parameter2," +
							"[Components]=@Parameter3," +
							"[Labels]=@Parameter4," +
							"[Assignee]=@Parameter5," +
							"[Duedate]=@Parameter6," +
							"[OriginalEstimate]=@Parameter7," +
							"[Status]=@Parameter8," +
							"[ProjectKey]=@Parameter9 " +
						"WHERE  [IssueID]=@Parameter0" +
						$@" ELSE INSERT INTO [{m_JiraWorkLogger}].[dbo].[JiraWorkLogRelatedIssues] ([IssueID],[Summary],[Type],[Components],[Labels],[Assignee],[Duedate],[OriginalEstimate],[Status],[ProjectKey]) VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8,@Parameter9)";
			List<object> SQLParameterList = new List<object>()
			{
				UpsertJiraWorkLogRelatedIssueParameter.issueID,
				UpsertJiraWorkLogRelatedIssueParameter.summary,
				UpsertJiraWorkLogRelatedIssueParameter.type,
				UpsertJiraWorkLogRelatedIssueParameter.components,
				UpsertJiraWorkLogRelatedIssueParameter.labels,
				UpsertJiraWorkLogRelatedIssueParameter.assignee,
				UpsertJiraWorkLogRelatedIssueParameter.duedate,
				UpsertJiraWorkLogRelatedIssueParameter.originalEstimate,
				UpsertJiraWorkLogRelatedIssueParameter.status,
				UpsertJiraWorkLogRelatedIssueParameter.ProjectKey
			};
			bool bResult = m_JiraWorkLoggerdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool InsertWorkLogs( InsertWorkLogs InsertWorkLogsParameter )
		{
			string sql = $@"INSERT INTO [{m_JiraWorkLogger}].[dbo].[JiraWorkLogs]([EmpID],[IssueID],[WorkLogID],[TimeSpentSeconds],[Created],[Started],[Type],[Tags],[Comment]) VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8)";
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
			bool bResult = m_JiraWorkLoggerdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetProjectTags( GetProjectTags GetProjectTagsParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_JiraWorkLogger}].[dbo].[JiraProjectTags]
						WHERE [ProjectKey] = @Parameter1
						ORDER BY [No]";

			List<object> SQLParameterList = new List<object>()
			{
				GetProjectTagsParameter.No,
				GetProjectTagsParameter.projectKey,
				GetProjectTagsParameter.tagName
			};
			DataTable result = m_JiraWorkLoggerdbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal bool InsertProjectTag( InsertProjectTag InsertProjectTagParameter )
		{
			string sql = $@"INSERT INTO [{m_JiraWorkLogger}].[dbo].[JiraProjectTags]([ProjectID],[TagName]) VALUES (@Parameter2,@Parameter1)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertProjectTagParameter.No,
				InsertProjectTagParameter.tagName,
				InsertProjectTagParameter.projectKey
			};
			bool bResult = m_JiraWorkLoggerdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DeleteProjectTag( DeleteProjectTag DeleteProjectTagParameter )
		{
			string sql = $@"DELETE FROM [{m_JiraWorkLogger}].[dbo].[JiraProjectTags] WHERE [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteProjectTagParameter.No
			};
			bool bResult = m_JiraWorkLoggerdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetEmpInfo( GetEmpInfo GetEmpInfoParameter )
		{
			string sql = $@"SELECT [EmpID],[EmpName],[DeptName],[DeptNo],[Title],[BjDept],[SuperDeptName],[Email],[OrgID_SAP] FROM [{m_barcode}].[dbo].[TEMP_NAME],[rds_ex_bpm.syntecclub.com,1433].[BPMPro].[dbo].[FSe7en_Org_DeptMapping] WHERE [EmpID] = @Parameter0 and [FSe7en_Org_DeptMapping].[DeptID] = [TEMP_NAME].[OrgID_SAP] COLLATE Chinese_PRC_CI_AS + [TEMP_NAME].[DeptNo] COLLATE Chinese_PRC_CI_AS";
			
			List<object> SQLParameterList = new List<object>()
			{
				GetEmpInfoParameter.empID
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		
	}
	#endregion Internal Methods
}
