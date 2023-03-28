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
using SyntecITWebAPI.Enums;

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

		[Route( "UpsertJiraWorkLogRelatedIssue" )]
		[HttpPost]
		public IActionResult UpsertJiraWorkLogRelatedIssue( [FromBody] UpsertJiraWorkLogRelatedIssue UpsertJiraWorkLogRelatedIssueParameter )
		{

			var bResult = m_publicJiraWorklogAPIHandler.UpsertJiraWorkLogRelatedIssue( UpsertJiraWorkLogRelatedIssueParameter );
			//m_responseHandler.Content = bResult;

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "InsertWorkLogs" )]
		[HttpPost]
		public IActionResult InsertWorkLogs( [FromBody] InsertWorkLogs InsertWorkLogsParameter )
		{

			var bResult = m_publicJiraWorklogAPIHandler.InsertWorkLogs( InsertWorkLogsParameter );
			//m_responseHandler.Content = bResult;

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}


		[Route( "GetProjectTags" )]
		[HttpPost]
		public IActionResult GetProjectTags( [FromBody] GetProjectTags GetProjectTagsParameter )
		{

			JArray result = m_publicJiraWorklogAPIHandler.GetProjectTags( GetProjectTagsParameter );

			if( result == null )
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}




		[Route( "InsertProjectTag" )]
		[HttpPost]
		public IActionResult InsertProjectTag( [FromBody] InsertProjectTag InsertProjectTagParameter )
		{

			var bResult = m_publicJiraWorklogAPIHandler.InsertProjectTag( InsertProjectTagParameter );
			//m_responseHandler.Content = JObject.Parse( bResult.Replace("[","").Replace( "]", "" ).Split("},{")[0]+"}" );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}


		[Route( "DeleteProjectTag" )]
		[HttpPost]
		public IActionResult DeleteProjectTag( [FromBody] DeleteProjectTag DeleteProjectTagParameter )
		{

			var bResult = m_publicJiraWorklogAPIHandler.DeleteProjectTag( DeleteProjectTagParameter );
			//m_responseHandler.Content = JObject.Parse( bResult.Replace("[","").Replace( "]", "" ).Split("},{")[0]+"}" );

			if( !bResult )
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}

		#endregion Public Methods

		#region Private Fields

		public ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicJiraWorklogAPIHandler m_publicJiraWorklogAPIHandler = new PublicJiraWorklogAPIHandler();

		#endregion Private Fields

		
	}
	
}
