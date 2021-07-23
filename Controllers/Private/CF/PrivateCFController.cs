using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Filter;
using SyntecITWebAPI.Models;
using SyntecITWebAPI.ParameterModels.CF;

namespace SyntecITWebAPI.Private.CF
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Private/CF" )]
	[ApiController]
	public class PrivateCFController : ControllerBase
	{
		#region Public Methods

		[Route( "CFSendPdfEmail" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult CFSendPdfEmail( [FromBody] CFService_CFSendPdfEmail CFService_CFSendPdfEmailParameter )
		{
			bool bResult = m_privateCFHandler.CFSendPdfEmail( CFService_CFSendPdfEmailParameter );

			if(!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "CheckCFPageIDNotExist" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult CheckCFPageIDNotExist( [FromBody] CFService_CFSendPdfEmail CFService_CFSendPdfEmailParameter )
		{
			JArray result = m_privateCFHandler.CheckCFPageIDNotExist( CFService_CFSendPdfEmailParameter );

			if(result == null)
			{
				m_responseHandler.Code = ErrorCodeList.System_Error;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}

		#endregion Public Methods

		#region Private Fields

		private PrivateCFHandler m_privateCFHandler = new PrivateCFHandler();
		private ResponseHandler m_responseHandler = new ResponseHandler();

		#endregion Private Fields
	}
}
