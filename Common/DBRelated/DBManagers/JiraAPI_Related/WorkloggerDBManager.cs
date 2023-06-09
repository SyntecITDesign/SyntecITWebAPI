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
							"[ProjectKey]=@Parameter9," +
							"[WorkloggerUpdateTime]=getdate() " +
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
		internal DataTable CheckIssueUpdateTime( UpsertJiraWorkLogRelatedIssue UpsertJiraWorkLogRelatedIssue )
		{
			string sql = $@"SELECT [IssueID],[WorkloggerUpdateTime] FROM [WorkLogger].[dbo].[JiraWorkLogRelatedIssues] where DATEDIFF(DAY,[WorkloggerUpdateTime],GETDATE()) > 0 and [ProjectKey] in ('"+ UpsertJiraWorkLogRelatedIssue.NeedToCheckProjectKeys + "') and [Status] != '已結案'";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertJiraWorkLogRelatedIssue.NeedToCheckProjectKeys
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
						ORDER BY [TagGroup],[No]";

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
		internal bool UpsertProjectTag( UpsertProjectTag UpsertProjectTagParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [{m_JiraWorkLogger}].[dbo].[JiraProjectTags] WHERE [No]=@Parameter0)
								UPDATE [{m_JiraWorkLogger}].[dbo].[JiraProjectTags] SET [TagGroup]=@Parameter3, [TagName]=@Parameter1 WHERE [No]=@Parameter0
							ELSE
								INSERT INTO [{m_JiraWorkLogger}].[dbo].[JiraProjectTags]([TagName],[ProjectKey],[TagGroup]) VALUES (@Parameter1,@Parameter2,@Parameter3)";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertProjectTagParameter.No,
				UpsertProjectTagParameter.tagName,
				UpsertProjectTagParameter.projectKey,
				UpsertProjectTagParameter.tagGroup
			};
			bool bResult = m_JiraWorkLoggerdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DeleteProjectTag( DeleteProjectTag DeleteProjectTagParameter )
		{
			string sql = $@"DELETE FROM [{m_JiraWorkLogger}].[dbo].[JiraProjectTags] WHERE [No]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteProjectTagParameter.No,
				DeleteProjectTagParameter.tagName,
				DeleteProjectTagParameter.projectKey,
				DeleteProjectTagParameter.tagGroup
			};
			bool bResult = m_JiraWorkLoggerdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetEmpInfo( GetEmpInfo GetEmpInfoParameter )
		{
			string sql = $@"SELECT [EmpID],[EmpName],[DeptName],[Dept50],[DeptNo],[Title],[BjDept],[SuperDeptName],[Email],[OrgID_SAP] FROM [{m_barcode}].[dbo].[TEMP_NAME],[rds_ex_bpm.syntecclub.com,1433].[BPMPro].[dbo].[FSe7en_Org_DeptMapping] WHERE ([EmpID] like @Parameter0 or [EmpName] like @Parameter0) and (QuitDate is null)  and [FSe7en_Org_DeptMapping].[DeptID] = [TEMP_NAME].[OrgID_SAP] COLLATE Chinese_PRC_CI_AS + [TEMP_NAME].[DeptNo] COLLATE Chinese_PRC_CI_AS";
			
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

		internal DataTable GetSumSpentSeconds( GetSumSpentSeconds GetSumSpentSecondsParameter )
		{
			string sql = $@"SELECT [EmpID] ,sum([TimeSpentSeconds]) as sumSpentSeconds FROM [{m_JiraWorkLogger}].[dbo].[JiraWorkLogs] where CONVERT(varchar(100), [Started], 23) = @Parameter1 and EmpID = @Parameter0 group by [EmpID]";

			List<object> SQLParameterList = new List<object>()
			{
				GetSumSpentSecondsParameter.empID,
				GetSumSpentSecondsParameter.started
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

		internal DataTable GetJiraWorkLoggerAccess( GetJiraWorkLoggerAccess GetJiraWorkLoggerAccessParameter )
		{
			string sql_where = "";
			if( GetJiraWorkLoggerAccessParameter.Managers != null )
			{
				sql_where = "Worklogger.[Managers] like @Parameter3";
			}
			else
			{
				sql_where = "[EmpID] = @Parameter4";
			}
			string sql = $@"ALTER DATABASE [syntecbarcode] SET COMPATIBILITY_LEVEL = 130; SELECT [EmpID],[EmpName],Worklogger.[SuperDeptName],[ProjectKey],[Managers],[No],(case when [Viewers] is null then '' else [Viewers] end) as 'Viewers' FROM [{m_barcode}].[dbo].[TEMP_NAME],(SELECT [ProjectKey],[SuperDeptName],[Managers],[Viewers],value,[No] FROM [rm-bp1oo0b1btai11by5.sqlserver.rds.aliyuncs.com,3433].[{m_JiraWorkLogger}].[dbo].[JiraWorkloggerAccess] OUTER APPLY STRING_SPLIT([Managers]+','+(case when [Viewers] is null then '' else [Viewers] end), ',')) as Worklogger WHERE " + sql_where + " and Worklogger.value = [TEMP_NAME].[EmpID] COLLATE Chinese_PRC_CI_AS order by Worklogger.[ProjectKey]";

			List<object> SQLParameterList = new List<object>()
			{
				GetJiraWorkLoggerAccessParameter.No,
				GetJiraWorkLoggerAccessParameter.projectKey,
				GetJiraWorkLoggerAccessParameter.SuperDeptName,
				GetJiraWorkLoggerAccessParameter.Managers,
				GetJiraWorkLoggerAccessParameter.Viewers
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

		internal DataTable GetSuperDeptOfWorkLogs( GetSuperDeptOfWorkLogs GetSuperDeptOfWorkLogsParameter )
		{
			string sql = $@"SELECT [SuperDeptName] FROM [rm-bp1oo0b1btai11by5.sqlserver.rds.aliyuncs.com,3433].[{m_JiraWorkLogger}].[dbo].[JiraWorkLogs] INNER JOIN (SELECT [EmpID],[SuperDeptName] FROM [{m_barcode}].[dbo].[TEMP_NAME]) AS TEMP_NAME ON TEMP_NAME.[EmpID] COLLATE Chinese_PRC_CI_AS  = [JiraWorkLogs].[EmpID] WHERE SUBSTRING([IssueID],1,CHARINDEX('-',[IssueID])-1) in ('" + GetSuperDeptOfWorkLogsParameter.projectKey + "') GROUP BY [SuperDeptName]";

			List<object> SQLParameterList = new List<object>()
			{
				GetSuperDeptOfWorkLogsParameter.No,
				GetSuperDeptOfWorkLogsParameter.projectKey,
				GetSuperDeptOfWorkLogsParameter.SuperDeptName,
				GetSuperDeptOfWorkLogsParameter.Managers,
				GetSuperDeptOfWorkLogsParameter.Viewers
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




		internal bool UpdateJiraWorkLoggerAccess( UpdateJiraWorkLoggerAccess UpdateJiraWorkLoggerAccessParameter )
		{
			string sql = $@"UPDATE [{m_JiraWorkLogger}].[dbo].[JiraWorkLoggerAccess] SET [Viewers]=@Parameter4 WHERE [ProjectKey]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateJiraWorkLoggerAccessParameter.No,
				UpdateJiraWorkLoggerAccessParameter.projectKey,
				UpdateJiraWorkLoggerAccessParameter.SuperDeptName,
				UpdateJiraWorkLoggerAccessParameter.Managers,
				UpdateJiraWorkLoggerAccessParameter.Viewers
			};
			bool bResult = m_JiraWorkLoggerdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}


		internal bool InsertActionLog( InsertActionLog InsertActionLogParameter )
		{
			string sql = $@"INSERT INTO [{m_JiraWorkLogger}].[dbo].[ActionLogTable] ([Action],[ActionContent],[Memo],[EmpID]) VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertActionLogParameter.Action,
				InsertActionLogParameter.ActionContent,
				InsertActionLogParameter.Memo,
				InsertActionLogParameter.EmpID
			};
			bool bResult = m_JiraWorkLoggerdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DeleteJiraWorkLog( DeleteJiraWorkLog DeleteJiraWorkLogParameter )
		{
			string sql = $@"UPDATE [{m_JiraWorkLogger}].[dbo].[JiraWorkLogs] SET [TimeSpentSeconds] =1,[Memo] = '作廢' WHERE [IssueID]=@Parameter0 AND  [WorkLogID]=@Parameter1";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteJiraWorkLogParameter.issueID,
				DeleteJiraWorkLogParameter.workLogID
			};
			bool bResult = m_JiraWorkLoggerdbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		

	}
	#endregion Internal Methods
}
