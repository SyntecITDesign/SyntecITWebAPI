using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.ParameterModels.JIRA_Related.WorkLogger;
using System;
using SyntecITWebAPI.Models.JiraAPI_Related.WorkLogger;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Enums;

namespace SyntecITWebAPI.Controllers.Open.JIRA_Related.WorkLogger
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/JIRA_Related/WorkLogger" )]
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
				var content = m_publicJiraWorkLoggerAPIHandler.JiraLogin( JiraWorkLogParameter );
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
				var content = m_publicJiraWorkLoggerAPIHandler.GetJiraIssues( JiraWorkLogParameter );

				m_responseHandler.Content = content;

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "AddWorkLog" )]
		[HttpPost]
		public IActionResult AddWorkLog( [FromBody] JiraWorkLog JiraWorkLogParameter )
		{
			try
			{
				var content = m_publicJiraWorkLoggerAPIHandler.AddWorkLog( JiraWorkLogParameter );

				m_responseHandler.Content = content;

			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "UpsertJiraWorkLogRelatedIssue" )]
		[HttpPost]
		public IActionResult UpsertJiraWorkLogRelatedIssue( [FromBody] UpsertJiraWorkLogRelatedIssue UpsertJiraWorkLogRelatedIssueParameter )
		{
			var bResult = m_publicJiraWorkLoggerAPIHandler.UpsertJiraWorkLogRelatedIssue( UpsertJiraWorkLogRelatedIssueParameter );
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


		
		[ Route( "CheckIssueUpdateTime" ) ]
		[ HttpPost ]
		public IActionResult CheckIssueUpdateTime( [FromBody] UpsertJiraWorkLogRelatedIssue UpsertJiraWorkLogRelatedIssueParameter )
		{

			bool result = m_publicJiraWorkLoggerAPIHandler.CheckIssueUpdateTime( UpsertJiraWorkLogRelatedIssueParameter );
			//m_responseHandler.Detail = result.ToString();

			if( !result )
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "InsertWorkLogs" )]
		[HttpPost]
		public IActionResult InsertWorkLogs( [FromBody] InsertWorkLogs InsertWorkLogsParameter )
		{
			var bResult = m_publicJiraWorkLoggerAPIHandler.InsertWorkLogs( InsertWorkLogsParameter );
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

			JArray result = m_publicJiraWorkLoggerAPIHandler.GetProjectTags( GetProjectTagsParameter );

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

		[Route( "UpsertProjectTag" )]
		[HttpPost]
		public IActionResult UpsertProjectTag( [FromBody] UpsertProjectTag UpsertProjectTagParameter )
		{

			var bResult = m_publicJiraWorkLoggerAPIHandler.UpsertProjectTag( UpsertProjectTagParameter );
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

			var bResult = m_publicJiraWorkLoggerAPIHandler.DeleteProjectTag( DeleteProjectTagParameter );
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


		[Route( "GetEmpInfo" )]
		[HttpPost]
		public IActionResult GetEmpInfo( [FromBody] GetEmpInfo GetEmpInfoParameter )
		{

			JArray result = m_publicJiraWorkLoggerAPIHandler.GetEmpInfo( GetEmpInfoParameter );

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

		[Route( "GetSumSpentSeconds" )]
		[HttpPost]
		public IActionResult GetSumSpentSeconds( [FromBody] GetSumSpentSeconds GetSumSpentSecondsParameter )
		{

			JArray result = m_publicJiraWorkLoggerAPIHandler.GetSumSpentSeconds( GetSumSpentSecondsParameter );

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


		[Route( "UpdateJiraWorkLoggerAccess" )]
		[HttpPost]
		public IActionResult UpdateJiraWorkLoggerAccess( [FromBody] UpdateJiraWorkLoggerAccess UpdateJiraWorkLoggerAccessParameter )
		{
			var bResult = m_publicJiraWorkLoggerAPIHandler.UpdateJiraWorkLoggerAccess( UpdateJiraWorkLoggerAccessParameter );
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

		[Route( "GetJiraWorkLoggerAccess" )]
		[HttpPost]
		public IActionResult GetJiraWorkLoggerAccess( [FromBody] GetJiraWorkLoggerAccess GetJiraWorkLoggerAccessParameter )
		{

			JArray result = m_publicJiraWorkLoggerAPIHandler.GetJiraWorkLoggerAccess( GetJiraWorkLoggerAccessParameter );
			

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
		
		[Route( "GetSuperDeptOfWorkLogs" )]
		[HttpPost]
		public IActionResult GetSuperDeptOfWorkLogs( [FromBody] GetSuperDeptOfWorkLogs GetSuperDeptOfWorkLogsParameter )
		{

			JArray result = m_publicJiraWorkLoggerAPIHandler.GetSuperDeptOfWorkLogs( GetSuperDeptOfWorkLogsParameter );


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


		[Route( "InsertActionLog" )]
		[HttpPost]
		public IActionResult InsertActionLog( [FromBody] InsertActionLog InsertActionLogParameter )
		{
			var bResult = m_publicJiraWorkLoggerAPIHandler.InsertActionLog( InsertActionLogParameter );
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

		#endregion Public Methods

		#region Private Fields

		public ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicJiraWorkLoggerAPIHandler m_publicJiraWorkLoggerAPIHandler = new PublicJiraWorkLoggerAPIHandler();

		#endregion Private Fields

		
	}
	
}
