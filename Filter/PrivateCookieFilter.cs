using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;

namespace SyntecITWebAPI.Filter
{
	public class PrivateCookieFilter : ActionFilterAttribute
	{
		#region Public Methods

		public override void OnActionExecuting( ActionExecutingContext context )
		{
			//Get Cookie
			string accessToken;
			string refreshToken;
			if( !context.HttpContext.Request.Cookies.TryGetValue( nameof( accessToken ), out accessToken ) )
			{
				if( !context.HttpContext.Request.Cookies.TryGetValue( nameof( refreshToken ), out refreshToken ) )
				{
					ReturnAction( context, ErrorCodeList.Cookie_Error, "Cookie not found" );
					return;
				}
				ReturnAction( context, ErrorCodeList.Token_Expired );
				return;
			}

			//3. check Through Token dll
			TokenProxy tokenProxy = new TokenProxy();
			JObject accessTokenPayload = tokenProxy.GetTokenData( accessToken );

			string userID = accessTokenPayload[ "aud" ].ToString();
			string userIP = context.HttpContext.Connection.RemoteIpAddress.ToString();
			ErrorCodeList tokenCheckResult = tokenProxy.IsAccessTokenValid( accessToken, userID, userIP );

			if( tokenCheckResult != ErrorCodeList.Success )
			{
				ReturnAction( context, tokenCheckResult );
				return;
			}
		}

		#endregion Public Methods

		#region Private Methods

		private ActionExecutingContext ReturnAction( ActionExecutingContext context, ErrorCodeList errorCode, string errorContent = null )
		{
			ResponseHandler responseHandler = new ResponseHandler();
			responseHandler.Code = errorCode;
			responseHandler.Detail = errorContent;
			context.Result = new OkObjectResult( responseHandler.GetResult() );
			return context;
		}

		#endregion Private Methods
	}
}
