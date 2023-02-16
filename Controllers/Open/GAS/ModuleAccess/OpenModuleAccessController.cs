using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.ModuleAccess;
using SyntecITWebAPI.ParameterModels.GAS.ModuleAccess;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.ModuleAccess
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/ModuleAccess" )]
	[ApiController]
	public class OpenModuleAccessController : ControllerBase
	{
		#region Public Methods

		[Route( "GetModuleAccess" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetModuleAccess( [FromBody] GetModuleAccess GetModuleAccessParameter)
		{

			JArray result = m_publicModuleAccessHandler.GetModuleAccess( GetModuleAccessParameter );

			if( result == null )
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}

		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicModuleAccessHandler m_publicModuleAccessHandler = new PublicModuleAccessHandler();

		#endregion Private Fields
	}
}
