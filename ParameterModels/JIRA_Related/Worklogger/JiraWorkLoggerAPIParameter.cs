
namespace SyntecITWebAPI.ParameterModels.JIRA_Related.WorkLogger
{

	public class JiraWorkLog
	{
		public string issueID
		{
			get; set;
		}
		public string Username
		{
			get; set;
		}
		public string Password
		{
			get; set;
		}
		public string comment
		{
			get; set;
		}
		public string started
		{
			get; set;
		}
		public int timeSpentSeconds
		{
			get; set;
		}
		public string JQL
		{
			get; set;
		}
		public string BasicAuth
		{
			get; set;
		}
		public string JsessionID
		{
			get; set;
		}
	}
	public class JiraWorkLogRelatedIssueAllField
	{
		public string issueID
		{
			get; set;
		}
		public string summary
		{
			get; set;
		}
		public string type
		{
			get; set;
		}
		public string components
		{
			get; set;
		}
		public string labels
		{
			get; set;
		}
		public string assignee
		{
			get; set;
		}
		public string duedate
		{
			get; set;
		}
		public string status
		{
			get; set;
		}
		public int originalEstimate
		{
			get; set;
		}
		public string BasicAuth
		{
			get; set;
		}

		public string ProjectKey
		{
			get; set;
		}
		public string NeedToCheckProjectKeys
		{
			get; set;
		}
	}
	public class UpsertJiraWorkLogRelatedIssue : JiraWorkLogRelatedIssueAllField
	{

	}
	public class CheckIssueUpdateTime : JiraWorkLogRelatedIssueAllField
	{

	}


	public class JiraWorkLogsAllField
	{
		public string issueID
		{
			get; set;
		}
		public string empID
		{
			get; set;
		}
		public string workLogID
		{
			get; set;
		}
		public string timeSpentSeconds
		{
			get; set;
		}
		public string created
		{
			get; set;
		}
		public string started
		{
			get; set;
		}
		public string type
		{
			get; set;
		}
		public string tags
		{
			get; set;
		}
		public string comment
		{
			get; set;
		}
		public int spendDay
		{
			get; set;
		}
		public int spendHour
		{
			get; set;
		}
		public int spendMinute
		{
			get; set;
		}
		public string BasicAuth
		{
			get; set;
		}
	}
	public class GetSumSpentSeconds : JiraWorkLogsAllField
	{

	}


	public class InsertWorkLogs : JiraWorkLogsAllField
	{

	}
	public class JiraProjectTagsAllField
	{
		public int No
		{
			get; set;
		}		
		public string projectKey
		{
			get; set;
		}
		public string tagGroup
		{
			get; set;
		}
		
		public string tagName
		{
			get; set;
		}
		
	}

	public class GetProjectTags : JiraProjectTagsAllField
	{

	}
	public class UpsertProjectTag : JiraProjectTagsAllField
	{

	}
	public class DeleteProjectTag : JiraProjectTagsAllField
	{

	}

	public class GetEmpInfo
	{
		public string empID
		{
			get; set;
		}
	}


	
	public class JiraWorkLoggerAccessAllField
	{
		public int No
		{
			get; set;
		}
		public string projectKey
		{
			get; set;
		}
		public string SuperDeptName
		{
			get; set;
		}
		public string Managers
		{
			get; set;
		}
		public string Viewers
		{
			get; set;
		}
	}
	public class GetJiraWorkLoggerAccess : JiraWorkLoggerAccessAllField
	{

	}
	public class UpdateJiraWorkLoggerAccess : JiraWorkLoggerAccessAllField
	{

	}
	public class GetSuperDeptOfWorkLogs : JiraWorkLoggerAccessAllField
	{

	}

	public class ActionLogTableAllField
	{
		
		public string Action
		{
			get; set;
		}
		public string ActionContent
		{
			get; set;
		}
		public string Memo
		{
			get; set;
		}
		public string EmpID
		{
			get; set;
		}
	}

	public class InsertActionLog : ActionLogTableAllField
	{

	}


}
