using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.ParameterModels.JIRA_Related;
using System;
using System.Linq;
using Syntec.JiraHelper;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using SyntecITWebAPI.Models.JiraAPI_Related;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Controllers.Open.JIRA_Related
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/JIRA_Related" )]
	[ApiController]
	public class OpenJIRA_RelatedController : ControllerBase
	{
		
		#region Public Methods

		[Route( "CreateJiraIssue" )]
		[HttpPost]
		public IActionResult CreateJiraIssue( [FromBody] CreateJiraIssue CreateJiraIssueParameter )
		{
			try
			{
				var content = m_publicJiraAPIHandler.CreateJiraIssue( CreateJiraIssueParameter );

				m_responseHandler.Content = JObject.Parse( content.ToString() );

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}
		
		[Route( "UpdateJiraIssueStatu" )]
		[HttpPost]
		public IActionResult UpdateJiraIssueStatu( [FromBody] JiraIssueTransition JiraIssueTransitionParameter )
		{
			try
			{
				var content = m_publicJiraAPIHandler.UpdateJiraIssueStatu( JiraIssueTransitionParameter );
				m_responseHandler.Content =  content.ToString();
			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "CreateJiraIssueLinks" )]
		[HttpPost]
		public IActionResult CreateJiraIssueLinks( [FromBody] JiraIssueLinkCreate JiraIssueLinkCreateParameter )
		{
			try
			{
				var content = m_publicJiraAPIHandler.CreateJiraIssueLinks( JiraIssueLinkCreateParameter );
				m_responseHandler.Content = content.ToString();
			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "EditJiraIssueForRejectExecute" )]
		[HttpPost]
		public IActionResult EditJiraIssueForRejectExecute( [FromBody] EditJiraIssue EditJiraIssueParameter )
		{
			try
			{
				var content = m_publicJiraAPIHandler.EditJiraIssueForRejectExecute( EditJiraIssueParameter );

				m_responseHandler.Content = content.ToString();

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "EditJiraIssueForShortTermCreate" )]
		[HttpPost]
		public IActionResult EditJiraIssueForShortTermCreate( [FromBody] EditJiraIssue EditJiraIssueParameter )
		{
			try
			{
				var content = m_publicJiraAPIHandler.EditJiraIssueForShortTermCreate( EditJiraIssueParameter );

				m_responseHandler.Content = content.ToString() ;
				
			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "EditJiraIssueForShortTermPlan" )]
		[HttpPost]
		public IActionResult EditJiraIssueForShortTermPlan( [FromBody] EditJiraIssue EditJiraIssueParameter )
		{
			try
			{
				var content = m_publicJiraAPIHandler.EditJiraIssueForShortTermPlan( EditJiraIssueParameter );

				m_responseHandler.Content = content.ToString();
				
			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "EditJiraIssueForShortTermExecute" )]
		[HttpPost]
		public IActionResult EditJiraIssueForShortTermExecute( [FromBody] EditJiraIssue EditJiraIssueParameter )
		{
			try
			{
				var content = m_publicJiraAPIHandler.EditJiraIssueForShortTermExecute( EditJiraIssueParameter );

				m_responseHandler.Content = content.ToString();

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "EditJiraIssueForLongTermPlan" )]
		[HttpPost]
		public IActionResult EditJiraIssueForLongTermPlan( [FromBody] EditJiraIssue EditJiraIssueParameter )
		{
			try
			{
				var content = m_publicJiraAPIHandler.EditJiraIssueForLongTermPlan( EditJiraIssueParameter );

				m_responseHandler.Content = content.ToString();

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}
		
		[Route( "EditJiraIssueForLongTermExecute" )]
		[HttpPost]
		public IActionResult EditJiraIssueForLongTermExecute( [FromBody] EditJiraIssue EditJiraIssueParameter )
		{
			try
			{
				var content = m_publicJiraAPIHandler.EditJiraIssueForLongTermExecute( EditJiraIssueParameter );

				m_responseHandler.Content = content.ToString();

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		
		[Route( "CloseJiraIssue" )]
		[HttpPost]
		public IActionResult CloseJiraIssue( [FromBody] CloseJiraIssue CloseJiraIssueParameter )
		{
			try
			{
				var content = m_publicJiraAPIHandler.CloseJiraIssue( CloseJiraIssueParameter );
				m_responseHandler.Content = content.ToString();

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		#endregion Public Methods

		#region Private Fields

		public ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicJiraWorklogAPIHandler m_publicJiraAPIHandler = new PublicJiraWorklogAPIHandler();

		#endregion Private Fields

		
	}
	
}
