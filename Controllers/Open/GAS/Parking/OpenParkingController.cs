using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.Parking;
using SyntecITWebAPI.ParameterModels.GAS.Parking;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Controllers.Open.GAS.Parking
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/Parking" )]
	[ApiController]
	public class OpenPeronsalInfoController : ControllerBase
	{
		#region Public Methods

		[Route( "GetParkingInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetParkingInfo( [FromBody] GetParkingInfo GetParkingInfoParameter )
		{
			JArray result = m_publicParkingHandler.QueryParkingInfo( GetParkingInfoParameter );

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

		[Route( "UpsertParkingInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertParkingInfo( [FromBody] UpsertParkingInfo UpsertParkingInfoParameter )
		{

			bool bResult = m_publicParkingHandler.UpsertParkingInfo( UpsertParkingInfoParameter );

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
		private PublicParkingHandler m_publicParkingHandler = new PublicParkingHandler();

		#endregion Private Fields
	}
}
