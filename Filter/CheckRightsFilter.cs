using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Utility;
using System.Collections.Generic;

namespace SyntecITWebAPI.Filter
{
	public class CheckRightsFilter : ActionFilterAttribute
	{
		#region Public Constructors + Destructors

		public CheckRightsFilter( string rights )
		{
			requestRightList = RightsSplitToList( rights );
		}

		#endregion Public Constructors + Destructors

		#region Public Methods

		public override void OnActionExecuting( ActionExecutingContext context )
		{
			JObject accessTokenData = context.HttpContext.Request.GetTokenDataFromCookie();
			string tokenRights = accessTokenData[ "OptionUserRights" ].ToString();

			List<string> userRightList = RightsSplitToList( tokenRights );

			foreach( string requestRight in requestRightList )
			{ //如果功能需要的權限使用者沒有
				if( !userRightList.Contains( requestRight ) )
				{
					ReturnAction( context, ErrorCodeList.No_Right_to_Access, $"No Right Code: {requestRight}" );
					return;
				}
			}
		}

		#endregion Public Methods

		#region Private Fields

		private List<string> requestRightList;

		#endregion Private Fields

		#region Private Methods

		private ActionExecutingContext ReturnAction( ActionExecutingContext context, ErrorCodeList errorCode, string errorContent = null )
		{
			ResponseHandler responseHandler = new ResponseHandler();
			responseHandler.Code = errorCode;
			responseHandler.Detail = errorContent;
			context.Result = new OkObjectResult( responseHandler.GetResult() );
			return context;
		}

		//將Rights String切成 權限List
		private List<string> RightsSplitToList( string rights )
		{
			List<string> result = new List<string>();
			foreach( var right in rights.Split( ',' ) )
			{
				if( !string.IsNullOrEmpty( right ) )
					result.Add( right );
			}
			return result;
		}

		#endregion Private Methods
	}
}
