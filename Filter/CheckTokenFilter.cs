using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Microsoft.Extensions.Primitives;

namespace SyntecITWebAPI.Filter
{
	public class CheckTokenFilter : ActionFilterAttribute
	{
		#region Public Methods

		public override void OnActionExecuting( ActionExecutingContext context )
		{
			//Get Token
			if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorizationToken))
			{
				string accessToken = authorizationToken.ToString().Replace("Bearer","").Trim();
				

				//check Through Token dll
				TokenProxy tokenProxy = new TokenProxy();
				JObject accessTokenPayload = tokenProxy.GetTokenData(accessToken);

				string userID = accessTokenPayload["aud"].ToString();
				string userIP = context.HttpContext.Connection.RemoteIpAddress.ToString();
				ErrorCodeList tokenCheckResult = tokenProxy.IsAccessTokenValid(accessToken, userID, userIP);

				if (tokenCheckResult != ErrorCodeList.Success)
				{
					ReturnAction(context, tokenCheckResult);
					return;
				}
			}
			else 
			{
				ReturnAction(context, ErrorCodeList.Token_Missing);
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
