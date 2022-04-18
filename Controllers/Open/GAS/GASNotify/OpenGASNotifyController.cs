using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.GASNotify;
using System;
using SyntecITWebAPI.Filter;

using Syntec.Notifier;


namespace SyntecITWebAPI.Controllers.Open.GAS.GASNotify
{
	[EnableCors("AllowAllPolicy")]
	[Route( "Open/GAS/GASNotify" )]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods
		[Route( "WeComGASNotify" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult WeComGASNotify( [FromBody] WeComGASNotify WeComGASNotifyParameter )
		{
			try
			{
				string NotifyContent = WeComGASNotifyParameter.WeComGASNotifyContent;

				#region VDS通知機器人
				string WeComKey = WeComGASNotifyParameter.WeComGASNotifyKey;
					//"fd078f6f-e121-41d7-8419-cede6f034f56";
				Syntec.Notifier.WeixinNotifier _WeixinNotifier = new Syntec.Notifier.WeixinNotifier();
				bool checkWeixin = _WeixinNotifier.WeixinTextNotify( WeComKey, NotifyContent, "", "" );
				Console.Write( "" );
				#endregion
			}
			catch( Exception e ) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		

		#endregion Private Fields
	}
}
