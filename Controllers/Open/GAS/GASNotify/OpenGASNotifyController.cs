using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;

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

		[Route( "WeComGASNotifyWithoutToken" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult WeComGASNotifyWithoutToken( [FromBody] WeComGASNotify WeComGASNotifyParameter )
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
			catch(Exception e) { Console.Write( e.ToString() ); }
			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "EmailGASNotify" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult EmailGASNotify( [FromBody] EmailGASNotify EmailGASNotifyParameter )
		{
			try
			{
				INotifier mailNotifier = new MailNotifier();

				mailNotifier.Title = EmailGASNotifyParameter.EmailGASNotifyTitle;
				mailNotifier.UserName = EmailGASNotifyParameter.EmailGASNotifyUserEmail;
				int attachmentCount = 0;
				mailNotifier.Content = EmailGASNotifyParameter.EmailGASNotifyContent;
				mailNotifier.SetParam( "AttachmentCount", attachmentCount );
				mailNotifier.Notify();

				#region VDS通知機器人

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
