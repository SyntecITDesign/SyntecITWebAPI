using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.ApplyUniform;
using SyntecITWebAPI.Models.GAS.ApplyUniform;
using SyntecITWebAPI.Filter;



namespace SyntecITWebAPI.Controllers.Open.GAS.ApplyUniform
{
	[EnableCors("AllowAllPolicy")]
	[Route("Open/GAS/ApplyUniform")]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route("InsertUniformStyle")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertUniformStyle([FromBody] InsertUniformStyle InsertUniformStyleParameter)
		{

			bool bResult = m_publicApplyUniformHandler.InsertUniformStyle(InsertUniformStyleParameter);

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
		
		
		[Route("DeleteUniformStyle")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteUniformStyle([FromBody] DeleteUniformStyle DeleteUniformStyleParameter)
		{

			bool bResult = m_publicApplyUniformHandler.DeleteUniformStyle(DeleteUniformStyleParameter);

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
		[Route("UpdateUniformStyleInfo")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateUniformStyleInfo( [FromBody] UpdateUniformStyleInfo UpdateUniformStyleInfoParameter)
		{

			bool bResult = m_publicApplyUniformHandler.UpdateUniformStyleInfo(UpdateUniformStyleInfoParameter);

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
		[Route("GetUniformStyleInfo")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUniformStyleInfo([FromBody] GetUniformStyleInfo GetUniformStyleInfoParameter)
		{

			JArray result = m_publicApplyUniformHandler.GetUniformStyleInfo(GetUniformStyleInfoParameter);

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
		[Route( "GetUniformStyleInfoSZ" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUniformStyleInfoSZ( [FromBody] GetUniformStyleInfoSZ GetUniformStyleInfoSZParameter )
		{

			JArray result = m_publicApplyUniformHandler.GetUniformStyleInfoSZ( GetUniformStyleInfoSZParameter );

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


		[Route( "UpsertUniformQuantityInfo" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertUniformQuantityInfo( [FromBody] UpsertUniformQuantityInfo UpsertUniformQuantityInfoParameter )
		{

			bool bResult = m_publicApplyUniformHandler.UpsertUniformQuantityInfo( UpsertUniformQuantityInfoParameter );

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
		[Route( "DeleteUniformQuantity" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteUniformQuantity( [FromBody] DeleteUniformQuantity DeleteUniformQuantityParameter )
		{

			bool bResult = m_publicApplyUniformHandler.DeleteUniformQuantity( DeleteUniformQuantityParameter );

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
		[Route( "GetUniformQuantityInfo" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUniformQuantityInfo( [FromBody] GetUniformQuantityInfo GetUniformQuantityInfoParameter )
		{

			JArray result = m_publicApplyUniformHandler.GetUniformQuantityInfo( GetUniformQuantityInfoParameter );

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
		[Route( "GetUniformQuantityInfoSZ" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUniformQuantityInfoSZ( [FromBody] GetUniformQuantityInfoSZ GetUniformQuantityInfoSZParameter )
		{

			JArray result = m_publicApplyUniformHandler.GetUniformQuantityInfoSZ( GetUniformQuantityInfoSZParameter );

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
		[Route( "InsertUniformOrder" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertUniformOrder( [FromBody] InsertUniformOrder InsertUniformOrderParameter )
		{

			bool bResult = m_publicApplyUniformHandler.InsertUniformOrder( InsertUniformOrderParameter );

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
		[Route( "InsertUniformOrderDetail" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertUniformOrderListDetail( [FromBody] InsertUniformOrderListDetail InsertUniformOrderListDetailParameter )
		{

			bool bResult = m_publicApplyUniformHandler.InsertUniformOrderListDetail( InsertUniformOrderListDetailParameter );

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

		[Route( "GetUniformOrderList")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUniformOrderList( [FromBody] GetUniformOrderList GetUniformOrderListParameter )
		{

			JArray result = m_publicApplyUniformHandler.GetUniformOrderList( GetUniformOrderListParameter );

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

		[Route( "GetUniformOrderListDetail" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUniformOrderListDetail( [FromBody] GetUniformOrderListDetail GetUniformOrderListDetailParameter )
		{

			JArray result = m_publicApplyUniformHandler.GetUniformOrderListDetail( GetUniformOrderListDetailParameter );

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

		[Route( "DeleteUniformOrder" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteUniformOrder( [FromBody] DeleteUniformOrder DeleteUniformOrderParameter )
		{

			bool bResult = m_publicApplyUniformHandler.DeleteUniformOrder( DeleteUniformOrderParameter );

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

		[Route( "UpdateUniformOrder" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateUniformOrder( [FromBody] UpdateUniformOrder UpdateUniformOrderParameter )
		{

			bool bResult = m_publicApplyUniformHandler.UpdateUniformOrder( UpdateUniformOrderParameter );

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

		[Route( "InsertUniformApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertUniformApplicationsMaster( [FromBody] InsertUniformApplicationsMaster InsertUniformApplicationsMasterParameter )
		{

			bool bResult = m_publicApplyUniformHandler.InsertUniformApplicationsMaster( InsertUniformApplicationsMasterParameter );

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
		[Route( "DeleteUniformApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteUniformApplicationsMaster( [FromBody] DeleteUniformApplicationsMaster DeleteUniformApplicationsMasterParameter )
		{

			bool bResult = m_publicApplyUniformHandler.DeleteUniformApplicationsMaster( DeleteUniformApplicationsMasterParameter );

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
		[Route( "UpdateUniformApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateUniformApplicationsMaster( [FromBody] UpdateUniformApplicationsMaster UpdateUniformApplicationsMasterParameter )
		{

			bool bResult = m_publicApplyUniformHandler.UpdateUniformApplicationsMaster( UpdateUniformApplicationsMasterParameter );

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
		[Route( "GetUniformApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUniformApplicationsMaster( [FromBody] GetUniformApplicationsMaster GetUniformApplicationsMasterParameter )
		{

			JArray result = m_publicApplyUniformHandler.GetUniformApplicationsMaster( GetUniformApplicationsMasterParameter );

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

		[Route( "UpdateCoatApplication" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateCoatApplication( [FromBody] UpdateCoatApplication UpdateCoatApplicationParameter )
		{

			bool bResult = m_publicApplyUniformHandler.UpdateCoatApplication( UpdateCoatApplicationParameter );

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


		[Route( "UpdateGAS_GAInfoMasterSize" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateGAS_GAInfoMasterSize( [FromBody] UpdateGAS_GAInfoMasterSize UpdateGAS_GAInfoMasterSizeParameter )
		{

			bool bResult = m_publicApplyUniformHandler.UpdateGAS_GAInfoMasterSize( UpdateGAS_GAInfoMasterSizeParameter );

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
		private PublicApplyUniformHandler m_publicApplyUniformHandler = new PublicApplyUniformHandler();

		#endregion Private Fields
	}
}
