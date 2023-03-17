using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.Uniform;
using SyntecITWebAPI.ParameterModels.GAS.Uniform;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.Uniform
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/Uniform" )]
	[ApiController]
	public class OpenUniformController : ControllerBase
	{
		#region Public Methods

		[Route( "GetUniformSize" )]
		[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetUniformSize([FromBody] GetUniformSize GetUniformSizeParameter )
		{
			JArray result = m_publicUniformHandler.QueryUniformSize(GetUniformSizeParameter );
			
			if(result == null)
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok( m_responseHandler.GetResult() );
		}

		[Route( "UpsertUniformSize" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertUniformSize( [FromBody] UpsertUniformSize UpsertUniformSizeParameter )
		{

			bool bResult = m_publicUniformHandler.UpsertUniformSize( UpsertUniformSizeParameter );

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
		private PublicUniformHandler m_publicUniformHandler = new PublicUniformHandler();

		#endregion Private Fields
	}
}
