using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.ApplyParkingLicence;
using SyntecITWebAPI.Models.GAS.ApplyParkingLicence;
using SyntecITWebAPI.Filter;
using SyntecITWebAPI.Models.GAS.ApplyParking;
using SyntecITWebAPI.ParameterModels.GAS.ApplyParking;

namespace SyntecITWebAPI.Controllers.Open.GAS.ApplyParkingLicence
{
	[EnableCors("AllowAllPolicy")]
	[Route( "Open/GAS/ApplyParkingLicence" )]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods
		[Route( "InsertParkingLicenceApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertParkingLicenceApplicationsMaster( [FromBody] InsertParkingLicenceApplicationsMaster InsertParkingLicenceApplicationsMasterParameter )
		{
			bool bResult = m_publicApplyParkingLicenceHandler.InsertParkingLicenceApplicationsMaster( InsertParkingLicenceApplicationsMasterParameter );

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
		[Route( "UpdateParkingLicenceApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateParkingLicenceApplicationsMaster( [FromBody] UpdateParkingLicenceApplicationsMaster UpdateParkingLicenceApplicationsMasterParameter )
		{
			bool bResult = m_publicApplyParkingLicenceHandler.UpdateParkingLicenceApplicationsMaster( UpdateParkingLicenceApplicationsMasterParameter );

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

		[Route( "GetParkingLicenceApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetParkingLicenceApplicationsMaster( [FromBody] GetParkingLicenceApplicationsMaster GetParkingLicenceApplicationsMasterParameter )
		{

			JArray result = m_publicApplyParkingLicenceHandler.GetParkingLicenceApplicationsMaster( GetParkingLicenceApplicationsMasterParameter );

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
		private PublicApplyParkingLicenceHandler m_publicApplyParkingLicenceHandler = new PublicApplyParkingLicenceHandler();

		#endregion Private Fields
	}
}
