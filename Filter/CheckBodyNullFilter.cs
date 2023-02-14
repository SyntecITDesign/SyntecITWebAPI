using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;

namespace SyntecITWebAPI.Filter
{
	public class CheckBodyNullFilter : ActionFilterAttribute
	{
		#region Public Methods

		public override void OnActionExecuting( ActionExecutingContext context )
		{
			ResponseHandler responseHandler = new ResponseHandler();
			JObject body = (JObject)context.ActionArguments[ "body" ];

			foreach( var attribute in body )
			{
				if( string.IsNullOrEmpty( attribute.Value.ToString() ) )
				{
					responseHandler.Code = ErrorCodeList.Param_Error;
					responseHandler.Detail = "Every value in json can't be empty";
					context.Result = new OkObjectResult( responseHandler.GetResult() );
				}
			}
		}

		#endregion Public Methods
	}
}
