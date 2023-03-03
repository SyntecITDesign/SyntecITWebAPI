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

namespace SyntecITWebAPI.Open.OpenNotifyController
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/Notify" )]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route( "WXNotify" )]
		[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult WXNotify( [FromBody] WXNotify WXNotifyParameter )
		{
			bool bResult = m_publicNotifyHandler.SendWXNotify( WXNotifyParameter );

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



		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicNotifyHandler m_publicNotifyHandler = new PublicNotifyHandler();

		#endregion Private Fields
	}
}
