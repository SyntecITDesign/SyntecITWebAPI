
namespace SyntecITWebAPI.ParameterModels.JIRA_Related.Worklogger
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
	}
	

}
