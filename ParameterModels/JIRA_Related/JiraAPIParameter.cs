
namespace SyntecITWebAPI.ParameterModels.JIRA_Related
{
	public class JiraIssueTransition
	{
		public string issueID
		{
			get; set;
		}
		public string transitionID
		{
			get; set;
		}
	}
	public class JiraIssueLinkCreate
	{
		public string issueID
		{
			get; set;
		}
		public string RelatedIssues
		{
			get; set;
		}
		public string linkType
		{
			get; set;
		}
	}
	

	public class CreateJiraIssue
	{
		public string projectID
		{
			get; set;
		}
		public string reporter
		{
			get; set;
		}
		public string assignee
		{
			get; set;
		}
		public string status
		{
			get; set;
		}
		public string summary
		{
			get; set;
		}
		public string description
		{
			get; set;
		}
		public string duedate
		{
			get; set;
		}
		public string issuetype
		{
			get; set;
		}
		public string priority
		{
			get; set;
		}
		public string createDept
		{
			get; set;
		}
	}

	public class EditJiraIssue
	{
		public string transitionID
		{
			get; set;
		}
		public string issueID
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
		public string teamMembers
		{
			get; set;
		}
		public string teamLeader
		{
			get; set;
		}
		public string teamLeaderDept
		{
			get; set;
		}
		public string problemAnalysis
		{
			get; set;
		}
		public string shortTermPlan
		{
			get; set;
		}
		public string shortTermDueDate
		{
			get; set;
		}
		public string relatedIssue
		{
			get; set;
		}
		public string shortTermExecuteResponding
		{
			get; set;
		}
		public string shortTermExecuteResolutiondate
		{
			get; set;
		}
		public string longTermPlan
		{
			get; set;
		}
		public string longTermDueDate
		{
			get; set;
		}
		public string avoidancePolicy
		{
			get; set;
		}
		public string longTermExecuteResponding
		{
			get; set;
		}
		public string longTermExecuteResolutiondate
		{
			get; set;
		}
		public string avoidancePolicyExecuteResponding
		{
			get; set;
		}

	}

	public class CloseJiraIssue
	{
		public string transitionID
		{
			get; set;
		}
		public string issueID
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
		public string reviewExplain
		{
			get; set;
		}
		public string closeDate
		{
			get; set;
		}
		public string resolution
		{
			get; set;
		}
	}
}
