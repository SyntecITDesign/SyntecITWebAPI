using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.CleanMaintain;
using SyntecITWebAPI.Models.GAS.CleanMaintain;
namespace SyntecITWebAPI.Controllers.Open.GAS.CleanMaintain
{
	[EnableCors("AllowAllPolicy")]
	[Route("Open/GAS/CleanMaintain")]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route("InsertMaintainType")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMaintainType([FromBody] InsertMaintainType InsertMaintainTypeParameter)
		{

			bool bResult = m_publicCleanMaintainHandler.InsertMaintainType(InsertMaintainTypeParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("DeleteMaintainType")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMaintainType([FromBody] DeleteMaintainType DeleteMaintainTypeParameter)
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteMaintainType(DeleteMaintainTypeParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("UpdateMaintainTypeInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateMaintainTypeInfo( [FromBody] UpdateMaintainTypeInfo UpdateMaintainTypeInfoParameter)
		{

			bool bResult = m_publicCleanMaintainHandler.UpdateMaintainTypeInfo(UpdateMaintainTypeInfoParameter);

			if (!bResult)
			{
				m_responseHandler.Code = ErrorCodeList.Param_Error;
			}
			else
			{
				m_responseHandler.Content = "true";
			}

			return Ok(m_responseHandler.GetResult());
		}
		[Route("GetMaintainTypeInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMaintainTypeInfo([FromBody] GetMaintainTypeInfo GetMaintainTypeInfoParameter)
		{

			JArray result = m_publicCleanMaintainHandler.GetMaintainTypeInfo(GetMaintainTypeInfoParameter);

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

		[Route( "UpsertMaintainQuantityInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertMaintainQuantityInfo( [FromBody] UpsertMaintainQuantityInfo UpsertMaintainQuantityInfoParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.UpsertMaintainQuantityInfo( UpsertMaintainQuantityInfoParameter );

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
		[Route( "DeleteMaintainQuantity" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMaintainQuantity( [FromBody] DeleteMaintainQuantity DeleteMaintainQuantityParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteMaintainQuantity( DeleteMaintainQuantityParameter );

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
		[Route( "GetMaintainQuantityInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMaintainQuantityInfo( [FromBody] GetMaintainQuantityInfo GetMaintainQuantityInfoParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetMaintainQuantityInfo( GetMaintainQuantityInfoParameter );

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

		[Route( "InsertMaintainOrder" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMaintainOrder( [FromBody] InsertMaintainOrder InsertMaintainOrderParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.InsertMaintainOrder( InsertMaintainOrderParameter );

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
		[Route( "GetMaintainOrderList")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMaintainOrderList( [FromBody] GetMaintainOrderList GetMaintainOrderListParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetMaintainOrderList( GetMaintainOrderListParameter );

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
		[Route( "DeleteMaintainOrder" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMaintainOrder( [FromBody] DeleteMaintainOrder DeleteMaintainOrderParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteMaintainOrder( DeleteMaintainOrderParameter );

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
		[Route( "UpdateMaintainOrder" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateMaintainOrder( [FromBody] UpdateMaintainOrder UpdateMaintainOrderParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.UpdateMaintainOrder( UpdateMaintainOrderParameter );

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

		[Route( "InsertMaintainOrderDetail" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMaintainOrderListDetail( [FromBody] InsertMaintainOrderListDetail InsertMaintainOrderListDetailParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.InsertMaintainOrderListDetail( InsertMaintainOrderListDetailParameter );

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
		[Route( "GetMaintainOrderListDetail" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMaintainOrderListDetail( [FromBody] GetMaintainOrderListDetail GetMaintainOrderListDetailParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetMaintainOrderListDetail( GetMaintainOrderListDetailParameter );

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

		[Route( "InsertCleanFirm" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertCleanFirm( [FromBody] InsertCleanFirm InsertCleanFirmParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.InsertCleanFirm( InsertCleanFirmParameter );

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
		[Route( "DeleteCleanFirm" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteCleanFirm( [FromBody] DeleteCleanFirm DeleteCleanFirmParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteCleanFirm( DeleteCleanFirmParameter );

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
		[Route( "UpdateCleanFirmInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateCleanFirmInfo( [FromBody] UpdateCleanFirmInfo UpdateCleanFirmInfoParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.UpdateCleanFirmInfo( UpdateCleanFirmInfoParameter );

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
		[Route( "GetCleanFirmInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetCleanFirmInfo( [FromBody] GetCleanFirmInfo GetCleanFirmInfoParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetCleanFirmInfo( GetCleanFirmInfoParameter );

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
		private PublicCleanMaintainHandler m_publicCleanMaintainHandler = new PublicCleanMaintainHandler();

		#endregion Private Fields
	}
}
