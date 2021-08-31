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

		[Route( "GetCleanStaffType" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetCleanStaffType( [FromBody] GetCleanStaffType GetCleanStaffTypeParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetCleanStaffType( GetCleanStaffTypeParameter );

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
		[Route( "InsertCleanStaffType" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertCleanStaffType( [FromBody] InsertCleanStaffType InsertCleanStaffTypeParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.InsertCleanStaffType( InsertCleanStaffTypeParameter );

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
		[Route( "DeleteCleanStaffType" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteCleanStaffType( [FromBody] DeleteCleanStaffType DeleteCleanStaffTypeParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteCleanStaffType( DeleteCleanStaffTypeParameter );

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
		[Route( "UpdateCleanStaffType" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateCleanStaffType( [FromBody] UpdateCleanStaffType UpdateCleanStaffTypeParameter )
		{
			bool bResult = m_publicCleanMaintainHandler.UpdateCleanStaffType( UpdateCleanStaffTypeParameter );

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

		[Route( "GetCleanAreaPlan" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetCleanAreaPlan( [FromBody] GetCleanAreaPlan GetCleanAreaPlanParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetCleanAreaPlan( GetCleanAreaPlanParameter );

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
		[Route( "InsertCleanAreaPlan" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertCleanAreaPlan( [FromBody] InsertCleanAreaPlan InsertCleanAreaPlanParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.InsertCleanAreaPlan( InsertCleanAreaPlanParameter );

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
		[Route( "DeleteCleanAreaPlan" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteCleanAreaPlan([FromBody] DeleteCleanAreaPlan DeleteCleanAreaPlanParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteCleanAreaPlan( DeleteCleanAreaPlanParameter );

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
		[Route( "UpdateCleanAreaPlan" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateCleanAreaPlan( [FromBody] UpdateCleanAreaPlan UpdateCleanAreaPlanParameter )
		{
			bool bResult = m_publicCleanMaintainHandler.UpdateCleanAreaPlan( UpdateCleanAreaPlanParameter );

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

		[Route( "GetCleanStaffInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetCleanStaffInfo( [FromBody] GetCleanStaffInfo GetCleanStaffInfoParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetCleanStaffInfo( GetCleanStaffInfoParameter );

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
		[Route( "InsertCleanStaffInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertCleanStaffInfo( [FromBody] InsertCleanStaffInfo InsertCleanStaffInfoParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.InsertCleanStaffInfo( InsertCleanStaffInfoParameter );

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
		[Route( "DeleteCleanStaffInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteCleanStaffInfo( [FromBody] DeleteCleanStaffInfo DeleteCleanStaffInfoParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteCleanStaffInfo( DeleteCleanStaffInfoParameter );

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
		[Route( "UpdateCleanStaffInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateCleanStaffInfo( [FromBody] UpdateCleanStaffInfo UpdateCleanStaffInfoParameter )
		{
			bool bResult = m_publicCleanMaintainHandler.UpdateCleanStaffInfo( UpdateCleanStaffInfoParameter );

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


		[Route( "GetCleanAreaInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetCleanAreaInfo( [FromBody] GetCleanAreaInfo GetCleanAreaInfoParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetCleanAreaInfo( GetCleanAreaInfoParameter );

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
		[Route( "InsertCleanAreaInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertCleanAreaInfo( [FromBody] InsertCleanAreaInfo InsertCleanAreaInfoParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.InsertCleanAreaInfo( InsertCleanAreaInfoParameter );

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
		[Route( "DeleteCleanAreaInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteCleanAreaInfo( [FromBody] DeleteCleanAreaInfo DeleteCleanAreaInfoParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteCleanAreaInfo( DeleteCleanAreaInfoParameter );

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
		[Route( "UpdateCleanAreaInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateCleanAreaInfo( [FromBody] UpdateCleanAreaInfo UpdateCleanAreaInfoParameter )
		{
			bool bResult = m_publicCleanMaintainHandler.UpdateCleanAreaInfo( UpdateCleanAreaInfoParameter );

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


		[Route( "GetMaintainRecordItemInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMaintainRecordItemInfo( [FromBody] GetMaintainRecordItemInfo GetMaintainRecordItemInfoParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetMaintainRecordItemInfo( GetMaintainRecordItemInfoParameter );

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
		[Route( "InsertMaintainRecordItem" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMaintainRecordItem( [FromBody] InsertMaintainRecordItem InsertMaintainRecordItemParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.InsertMaintainRecordItem( InsertMaintainRecordItemParameter );

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
		[Route( "DeleteMaintainRecordItem" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMaintainRecordItem( [FromBody] DeleteMaintainRecordItem DeleteMaintainRecordItemParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteMaintainRecordItem( DeleteMaintainRecordItemParameter );

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
		[Route( "UpdateMaintainRecordItemInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateMaintainRecordItemInfo( [FromBody] UpdateMaintainRecordItemInfo UpdateMaintainRecordItemInfoParameter )
		{
			bool bResult = m_publicCleanMaintainHandler.UpdateMaintainRecordItemInfo( UpdateMaintainRecordItemInfoParameter );

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

		[Route( "GetMaintainRecordTypeInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMaintainRecordTypeInfo( [FromBody] GetMaintainRecordTypeInfo GetMaintainRecordTypeInfoParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetMaintainRecordTypeInfo( GetMaintainRecordTypeInfoParameter );

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
		[Route( "InsertMaintainRecordType" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMaintainRecordType( [FromBody] InsertMaintainRecordType InsertMaintainRecordTypeParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.InsertMaintainRecordType( InsertMaintainRecordTypeParameter );

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
		[Route( "DeleteMaintainRecordType" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMaintainRecordType( [FromBody] DeleteMaintainRecordType DeleteMaintainRecordTypeParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteMaintainRecordType( DeleteMaintainRecordTypeParameter );

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
		[Route( "UpdateMaintainRecordTypeInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateMaintainRecordTypeInfo( [FromBody] UpdateMaintainRecordTypeInfo UpdateMaintainRecordTypeInfoParameter )
		{
			bool bResult = m_publicCleanMaintainHandler.UpdateMaintainRecordTypeInfo( UpdateMaintainRecordTypeInfoParameter );

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


		[Route( "GetMaintainRecordDetailList" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetMaintainRecordDetailList( [FromBody] GetMaintainRecordDetailList GetMaintainRecordDetailListParameter )
		{

			JArray result = m_publicCleanMaintainHandler.GetMaintainRecordDetailList( GetMaintainRecordDetailListParameter );

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
		[Route( "InsertMaintainRecordDetailList" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertMaintainRecordDetailList( [FromBody] InsertMaintainRecordDetailList InsertMaintainRecordDetailListParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.InsertMaintainRecordDetailList( InsertMaintainRecordDetailListParameter );

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
		[Route( "DeleteMaintainRecordDetailList" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteMaintainRecordDetailList( [FromBody] DeleteMaintainRecordDetailList DeleteMaintainRecordDetailListParameter )
		{

			bool bResult = m_publicCleanMaintainHandler.DeleteMaintainRecordDetailList( DeleteMaintainRecordDetailListParameter );

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
		[Route( "UpdateMaintainRecordDetailList" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateMaintainRecordDetailList( [FromBody] UpdateMaintainRecordDetailList UpdateMaintainRecordDetailListParameter )
		{
			bool bResult = m_publicCleanMaintainHandler.UpdateMaintainRecordDetailList( UpdateMaintainRecordDetailListParameter );

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
		private PublicCleanMaintainHandler m_publicCleanMaintainHandler = new PublicCleanMaintainHandler();

		#endregion Private Fields
	}
}
