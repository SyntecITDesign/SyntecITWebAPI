﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.VisitorRegistration;
using SyntecITWebAPI.Models.GAS.VisitorRegistration;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.VisitorRegistration
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/VisitorRegistration" )]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods
		
		[Route( "InsertVisitorRegistrationApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertVisitorRegistrationApplicationsMaster( [FromBody] InsertVisitorRegistrationApplicationsMaster InsertVisitorRegistrationApplicationsMasterParameter )
		{

			bool bResult = m_publicVisitorRegistrationHandler.InsertVisitorRegistrationApplicationsMaster( InsertVisitorRegistrationApplicationsMasterParameter );

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

		[Route( "GetVisitorRegistrationApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetVisitorRegistrationApplicationsMaster( [FromBody] GetVisitorRegistrationApplicationsMaster GetVisitorRegistrationApplicationsMasterParameter )
		{

			JArray result = m_publicVisitorRegistrationHandler.GetVisitorRegistrationApplicationsMaster( GetVisitorRegistrationApplicationsMasterParameter );

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

		[Route( "UpdateVisitorRegistrationApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateVisitorRegistrationApplicationsMaster( [FromBody] UpdateVisitorRegistrationApplicationsMaster UpdateVisitorRegistrationApplicationsMasterParameter )
		{

			bool bResult = m_publicVisitorRegistrationHandler.UpdateVisitorRegistrationApplicationsMaster( UpdateVisitorRegistrationApplicationsMasterParameter );

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

		[Route( "VisitorCheckIn" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult VisitorCheckIn( [FromBody] VisitorCheckIn VisitorCheckInParameter )
		{

			bool bResult = m_publicVisitorRegistrationHandler.VisitorCheckIn( VisitorCheckInParameter );

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

		[Route( "VisitorCheckOut" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult VisitorCheckOut( [FromBody] VisitorCheckOut VisitorCheckOutParameter )
		{

			bool bResult = m_publicVisitorRegistrationHandler.VisitorCheckOut( VisitorCheckOutParameter );

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

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicVisitorRegistrationHandler m_publicVisitorRegistrationHandler = new PublicVisitorRegistrationHandler();

		#endregion Private Fields
	}
}
