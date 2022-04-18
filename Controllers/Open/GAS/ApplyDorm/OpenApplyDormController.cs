using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.ApplyDorm;
using SyntecITWebAPI.ParameterModels.GAS.ApplyDorm;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.ApplyDorm
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/ApplyDorm" )]
	[ApiController]
	public class OpenApplyCarBookingController : ControllerBase
	{
		#region Public Methods

		[Route( "GetEmpDormStatusData" )]
		[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetEmpDormStatusData( [FromBody] GetEmpDormStatusData GetEmpDormStatusDataParameter )
		{
			JArray result = m_publicDormHandler.GetEmpDormStatusData( GetEmpDormStatusDataParameter );

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

		[Route( "InsertDormApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertDormApplicationsMaster( [FromBody] InsertDormApplicationsMaster InsertDormApplicationsMasterParameter )
		{

			bool bResult = m_publicDormHandler.InsertDormApplicationsMaster( InsertDormApplicationsMasterParameter );

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
		private PublicApplyDormHandler m_publicDormHandler = new PublicApplyDormHandler();

		#endregion Private Fields
	}
}
