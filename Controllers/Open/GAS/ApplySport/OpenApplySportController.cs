using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.ApplySport;
using SyntecITWebAPI.Models.GAS.ApplySport;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.ApplySport
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/ApplySport" )]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route( "GetAllCourt" )]
		[CheckTokenFilter]
		[HttpGet]
		public IActionResult GetAllCourt()
		{
			JArray result = m_publicApplySportHandler.GetAllCourt();

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

		[Route( "InsertCourtReserve" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertCourtReserve( [FromBody] InsertCourtReserve InsertCourtReserveParameter )
		{
			bool bResult = m_publicApplySportHandler.InsertCourtReserve( InsertCourtReserveParameter );

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

		[Route( "GetUsingCourt" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUsingCourt( [FromBody] GetUsingCourt GetUsingCourtParameter )
		{
			JArray result = m_publicApplySportHandler.GetUsingCourt( GetUsingCourtParameter );

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

		[Route( "DuplicateReserve" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DuplicateReserve( [FromBody] DuplicateReserve DuplicateReserveParameter )
		{
			JArray result = m_publicApplySportHandler.DuplicateReserve( DuplicateReserveParameter );

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
		//在個人專區的處理中事項分頁抓取該工號目前有預約那些運動場
		[Route( "GetSportCourtReserve" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetSportCourtReserve( [FromBody] GetSportCourtReserve GetSportCourtReserveParameter )
		{
			JArray result = m_publicApplySportHandler.GetSportCourtReserve( GetSportCourtReserveParameter );

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
		//在個人專區的處理中事項分頁刪除預約後更新
		[Route( "UpdateSportCourtReserve" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateSportCourtReserve( [FromBody] UpdateSportCourtReserve UpdateSportCourtReserveParameter )
		{
			bool bResult = m_publicApplySportHandler.UpdateSportCourtReserve( UpdateSportCourtReserveParameter );

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
		//[Route( "UpdateParkingSpaceStatusMaster" )]
		//[CheckTokenFilter]
		//[HttpPost]
		//public IActionResult UpdateParkingSpaceStatusMaster( [FromBody] UpdateParkingSpaceStatusMaster UpdateParkingSpaceStatusMasterParameter )
		//{

		//	bool bResult = m_publicApplySportHandler.UpdateParkingSpaceStatusMaster( UpdateParkingSpaceStatusMasterParameter );

		//	if(!bResult)
		//	{
		//		m_responseHandler.Code = ErrorCodeList.Param_Error;
		//	}
		//	else
		//	{
		//		m_responseHandler.Content = "true";
		//	}

		//	return Ok( m_responseHandler.GetResult() );
		//}
		//[Route( "GetParkingSpaceStatusMaster" )]
		//[CheckTokenFilter]
		//[HttpPost]
		//public IActionResult GetParkingSpaceStatusMaster( [FromBody] GetParkingSpaceStatusMaster GetParkingSpaceStatusMasterParameter )
		//{

		//	JArray result = m_publicApplySportHandler.GetParkingSpaceStatusMaster( GetParkingSpaceStatusMasterParameter );

		//	if(result == null)
		//	{
		//		m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
		//	}
		//	else
		//	{
		//		m_responseHandler.Content = result;
		//	}

		//	return Ok( m_responseHandler.GetResult() );
		//}

		//[Route( "UpdateParkingSpaceApplicationsMaster" )]
		//[CheckTokenFilter]
		//[HttpPost]
		//public IActionResult UpdateParkingSpaceApplicationsMaster( [FromBody] UpdateParkingSpaceApplicationsMaster UpdateParkingSpaceApplicationsMasterParameter )
		//{
		//	bool bResult = m_publicApplySportHandler.UpdateParkingSpaceApplicationsMaster( UpdateParkingSpaceApplicationsMasterParameter );

		//	if(!bResult)
		//	{
		//		m_responseHandler.Code = ErrorCodeList.Param_Error;
		//	}
		//	else
		//	{
		//		m_responseHandler.Content = "true";
		//	}

		//	return Ok( m_responseHandler.GetResult() );
		//}

		//[Route( "GetParkingSpaceApplicationsMaster" )]
		//[CheckTokenFilter]
		//[HttpPost]
		//public IActionResult GetParkingSpaceApplicationsMaster( [FromBody] GetParkingSpaceApplicationsMaster GetParkingSpaceApplicationsMasterParameter )
		//{

		//	JArray result = m_publicApplySportHandler.GetParkingSpaceApplicationsMaster( GetParkingSpaceApplicationsMasterParameter );

		//	if(result == null)
		//	{
		//		m_responseHandler.Code = ErrorCodeList.Select_Problem_No_Data;
		//	}
		//	else
		//	{
		//		m_responseHandler.Content = result;
		//	}

		//	return Ok( m_responseHandler.GetResult() );
		//}


		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicApplySportHandler m_publicApplySportHandler = new PublicApplySportHandler();

		#endregion Private Fields
	}
}
