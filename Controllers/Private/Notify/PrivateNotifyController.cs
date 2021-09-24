using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models;
using SyntecITWebAPI.Filter;
using SyntecITWebAPI.Static;
using SyntecITWebAPI.Utility;
using SyntecITWebAPI.ParameterModels.Notify;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Private.OpenNotifyController
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Private/Notify" )]
	[ApiController]
	public class PrivateNotifyController : ControllerBase
	{
		#region Public Methods

		[Route( "SendVerifyCode" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult SendVerifyCode( [FromBody] SendVerifyCode SendVerifyCodeParameter )
		{
			bool bResult = m_publicNotifyHandler.SendVerifyCode( SendVerifyCodeParameter );

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

		[Route( "CheckVerifyCode" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult CheckVerifyCode( [FromBody] CheckVerifyCode CheckVerifyCodeParameter )
		{
			bool bResult = m_publicNotifyHandler.CheckVerifyCode( CheckVerifyCodeParameter );

			if(!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Verify_Fail;
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
		private PublicNotifyHandler m_publicNotifyHandler = new PublicNotifyHandler();

		#endregion Private Fields
	}
}
