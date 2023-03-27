using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.ApplyParking;
using SyntecITWebAPI.Models.GAS.ApplyParking;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.ApplyParking
{
	[EnableCors("AllowAllPolicy")]
	[Route( "Open/GAS/ApplyParking" )]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route( "UpdateParkingSpaceStatusMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateParkingSpaceStatusMaster( [FromBody] UpdateParkingSpaceStatusMaster UpdateParkingSpaceStatusMasterParameter )
		{

			bool bResult = m_publicApplyParkingHandler.UpdateParkingSpaceStatusMaster( UpdateParkingSpaceStatusMasterParameter );

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
		[Route( "GetParkingSpaceStatusMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetParkingSpaceStatusMaster( [FromBody] GetParkingSpaceStatusMaster GetParkingSpaceStatusMasterParameter )
		{

			JArray result = m_publicApplyParkingHandler.GetParkingSpaceStatusMaster( GetParkingSpaceStatusMasterParameter );

			if (result == null)
			{
				m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
			}
			else
			{
				m_responseHandler.Content = result;
			}

			return Ok(m_responseHandler.GetResult());
		}

		[Route( "UpdateParkingSpaceApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateParkingSpaceApplicationsMaster( [FromBody] UpdateParkingSpaceApplicationsMaster UpdateParkingSpaceApplicationsMasterParameter )
		{
			bool bResult = m_publicApplyParkingHandler.UpdateParkingSpaceApplicationsMaster( UpdateParkingSpaceApplicationsMasterParameter );

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

		[Route( "GetParkingSpaceApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetParkingSpaceApplicationsMaster( [FromBody] GetParkingSpaceApplicationsMaster GetParkingSpaceApplicationsMasterParameter )
		{

			JArray result = m_publicApplyParkingHandler.GetParkingSpaceApplicationsMaster( GetParkingSpaceApplicationsMasterParameter );

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
		[Route( "InsertParkingSpaceApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertParkingSpaceApplicationsMaster( [FromBody] InsertParkingSpaceApplicationsMaster InsertParkingSpaceApplicationsMasterParameter )
		{
			bool bResult = m_publicApplyParkingHandler.InsertParkingSpaceApplicationsMaster( InsertParkingSpaceApplicationsMasterParameter );

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
		private PublicApplyParkingHandler m_publicApplyParkingHandler = new PublicApplyParkingHandler();

		#endregion Private Fields
	}
}
