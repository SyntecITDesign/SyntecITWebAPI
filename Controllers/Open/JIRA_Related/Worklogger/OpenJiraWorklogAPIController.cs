using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.ParameterModels.JIRA_Related.Worklogger;
using System;
using System.Linq;
using Syntec.JiraHelper;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using SyntecITWebAPI.Models.JiraAPI_Related.Worklogger;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Controllers.Open.JIRA_Related.Worklogger
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/JIRA_Related/Worklogger" )]
	[ApiController]
	public class OpenJIRA_RelatedController : ControllerBase
	{

		#region Public Methods
		[Route( "JiraLogin" )]
		[HttpPost]
		public IActionResult JiraLogin( [FromBody] JiraWorkLog JiraWorkLogParameter )
		{
			try
			{
				var content = m_publicJiraWorklogAPIHandler.JiraLogin( JiraWorkLogParameter );

				m_responseHandler.Content = content;

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "GetJiraIssues" )]
		[HttpPost]
		public IActionResult GetJiraIssues( [FromBody] JiraWorkLog JiraWorkLogParameter )
		{
			try
			{
				var content = m_publicJiraWorklogAPIHandler.GetJiraIssues( JiraWorkLogParameter );

				m_responseHandler.Content = content;

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "AddWorklog" )]
		[HttpPost]
		public IActionResult AddWorklog( [FromBody] JiraWorkLog JiraWorkLogParameter )
		{
			try
			{
				var content = m_publicJiraWorklogAPIHandler.AddWorklog( JiraWorkLogParameter );

				m_responseHandler.Content = content;

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		

		#endregion Public Methods

		#region Private Fields

		public ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicJiraWorklogAPIHandler m_publicJiraWorklogAPIHandler = new PublicJiraWorklogAPIHandler();

		#endregion Private Fields

		
	}
	
}
