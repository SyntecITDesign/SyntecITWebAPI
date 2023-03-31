using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.Dorm;
using SyntecITWebAPI.ParameterModels.GAS.Dorm;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.Dorm
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/Dorm" )]
	[ApiController]
	public class OpenPeronsalInfoController : ControllerBase
	{
		#region Public Methods

		[Route( "GetDormInfo" )]
		[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetDormInfo( [FromBody] GetDormInfo GetDormInfoParameter )
		{
			JArray result = m_publicDormHandler.QueryDormInfo( GetDormInfoParameter );

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
		


		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicDormHandler m_publicDormHandler = new PublicDormHandler();

		#endregion Private Fields
	}
}
