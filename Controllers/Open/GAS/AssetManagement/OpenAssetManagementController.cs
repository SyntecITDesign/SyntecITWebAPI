using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.AssetManagement;
using SyntecITWebAPI.Models.GAS.AssetManagement;
namespace SyntecITWebAPI.Controllers.Open.GAS.AssetManagement
{
	[EnableCors("AllowAllPolicy")]
	[Route("Open/GAS/AssetManagement")]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route("InsertAssetInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertAssetInfo([FromBody] InsertAssetInfo InsertAssetInfoParameter)
		{

			bool bResult = m_publicAssetManagementHandler.InsertAssetInfo(InsertAssetInfoParameter);

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
		[Route("DeleteAssetInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteAssetInfo([FromBody] DeleteAssetInfo DeleteAssetInfoParameter)
		{

			bool bResult = m_publicAssetManagementHandler.DeleteAssetInfo(DeleteAssetInfoParameter);

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
		[Route("UpdateAssetInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateAssetInfo( [FromBody] UpdateAssetInfo UpdateAssetInfoParameter)
		{

			bool bResult = m_publicAssetManagementHandler.UpdateAssetInfo(UpdateAssetInfoParameter);

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
		[Route("GetAssetInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetAssetInfo([FromBody] GetAssetInfo GetAssetInfoParameter)
		{

			JArray result = m_publicAssetManagementHandler.GetAssetInfo(GetAssetInfoParameter);

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


		[Route( "InsertAssetSpecList" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertAssetSpecList( [FromBody] InsertAssetSpecList InsertAssetSpecListParameter )
		{

			bool bResult = m_publicAssetManagementHandler.InsertAssetSpecList( InsertAssetSpecListParameter );

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
		[Route( "DeleteAssetSpecList" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteAssetSpecList( [FromBody] DeleteAssetSpecList DeleteAssetSpecListParameter )
		{

			bool bResult = m_publicAssetManagementHandler.DeleteAssetSpecList( DeleteAssetSpecListParameter );

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
		[Route( "UpdateAssetSpecList" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateAssetSpecList( [FromBody] UpdateAssetSpecList UpdateAssetSpecListParameter )
		{

			bool bResult = m_publicAssetManagementHandler.UpdateAssetSpecList( UpdateAssetSpecListParameter );

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
		[Route( "GetAssetSpecList" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetAssetSpecList( [FromBody] GetAssetSpecList GetAssetSpecListParameter )
		{

			JArray result = m_publicAssetManagementHandler.GetAssetSpecList( GetAssetSpecListParameter );

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

		[Route( "InsertAssetInventory" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertAssetInventory( [FromBody] InsertAssetInventory InsertAssetInventoryParameter )
		{

			bool bResult = m_publicAssetManagementHandler.InsertAssetInventory( InsertAssetInventoryParameter );

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
		[Route( "DeleteAssetInventory" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteAssetInventory( [FromBody] DeleteAssetInventory DeleteAssetInventoryParameter )
		{

			bool bResult = m_publicAssetManagementHandler.DeleteAssetInventory( DeleteAssetInventoryParameter );

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
		[Route( "UpdateAssetInventory" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateAssetInventory( [FromBody] UpdateAssetInventory UpdateAssetInventoryParameter )
		{

			bool bResult = m_publicAssetManagementHandler.UpdateAssetInventory( UpdateAssetInventoryParameter );

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
		[Route( "GetAssetInventory" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetAssetInventory( [FromBody] GetAssetInventory GetAssetInventoryParameter )
		{

			JArray result = m_publicAssetManagementHandler.GetAssetInventory( GetAssetInventoryParameter );

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
		private PublicAssetManagementHandler m_publicAssetManagementHandler = new PublicAssetManagementHandler();

		#endregion Private Fields
	}
}
