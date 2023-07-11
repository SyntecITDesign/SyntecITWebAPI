using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SyntecITWebAPI.Common;
using System.Collections.Generic;
using System.Linq;

namespace SyntecITWebAPI.Filter
{
	public class RequiredValidateModelFilter : ActionFilterAttribute
	{
		#region Public Methods

		public override void OnActionExecuting( ActionExecutingContext context )
		{
			if( !context.ModelState.IsValid )
			{
				var modelState = context.ModelState;
				List<string> errorList = new List<string>();

				foreach( ModelError error in modelState.Values.SelectMany( modelState => modelState.Errors ) )
				{
					errorList.Add( error.ErrorMessage );
				}

				responseHandler.Code = Enums.ErrorCodeList.Param_Error;
				responseHandler.Detail = string.Join( " ", errorList );
				context.Result = new OkObjectResult( responseHandler.GetResult() );
			}
		}

		#endregion Public Methods

		#region Private Fields

		private ResponseHandler responseHandler = new ResponseHandler();

		#endregion Private Fields
	}
}
