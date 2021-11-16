using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.LogTable;
using SyntecITWebAPI.ParameterModels.GAS.LogTable;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Controllers.Open.GAS.LogTable
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/LogTable" )]
	[ApiController]
	public class OpenPeronsalInfoController : ControllerBase
	{
		#region Public Methods

		[Route( "InsertLogTable" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult InsertLogTable( [FromBody] InsertLogTable InsertLogTableParameter )
		{

			bool bResult = m_publicLogTableHandler.InsertLogTable( InsertLogTableParameter );

			if( !bResult )
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
		private PublicLogTableHandler m_publicLogTableHandler = new PublicLogTableHandler();

		#endregion Private Fields
	}
}
