using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.Stationery;
using SyntecITWebAPI.ParameterModels.GAS.Stationery;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Controllers.Open.GAS.Stationery
{
	[EnableCors("AllowAllPolicy")]
	[Route("Open/GAS/Stationery")]
	[ApiController]
	public class OpenStationeryController : ControllerBase
	{
		#region Public Methods

		[Route("GetStationeryQuantity")]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetStationeryQuantity()
		{
			JArray result = m_publicSyntecGASHandler.QueryStationeryQuantity();

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
		[Route("UpsertStationeryQuantity")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertStationeryQuantity([FromBody] UpsertStationeryQuantity UpsertStationeryQuantityParameter)
		{

			bool bResult = m_publicSyntecGASHandler.UpsertStationeryQuantity(UpsertStationeryQuantityParameter);

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
		[Route("DeleteStationery")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteStationery([FromBody] DeleteStationery DeleteStationeryParameter)
		{

			bool bResult = m_publicSyntecGASHandler.DeleteStationery(DeleteStationeryParameter);

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




		[Route( "GetStationeryApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetStationeryApplicationsMaster( [FromBody] GetStationeryApplicationsMaster GetStationeryApplicationsMasterParameter )
		{

			JArray result =m_publicSyntecGASHandler.GetStationeryApplicationsMaster( GetStationeryApplicationsMasterParameter );

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
		[Route( "InsertStationeryApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertStationeryApplicationsMaster( [FromBody] InsertStationeryApplicationsMaster InsertStationeryApplicationsMasterParameter )
		{

			bool bResult =m_publicSyntecGASHandler.InsertStationeryApplicationsMaster( InsertStationeryApplicationsMasterParameter );

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
		[Route( "UpdateStationeryApplicationsMaster" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateStationeryApplicationsMaster( [FromBody] UpdateStationeryApplicationsMaster UpdateStationeryApplicationsMasterParameter )
		{
			bool bResult =m_publicSyntecGASHandler.UpdateStationeryApplicationsMaster( UpdateStationeryApplicationsMasterParameter );

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

		[Route( "GetStationeryApplicationsDetail" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetStationeryApplicationsDetail( [FromBody] GetStationeryApplicationsDetail GetStationeryApplicationsDetailParameter )
		{

			JArray result =m_publicSyntecGASHandler.GetStationeryApplicationsDetail( GetStationeryApplicationsDetailParameter );

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
		
		[Route( "InsertStationeryApplicationsDetail" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertStationeryApplicationsDetail( [FromBody] InsertStationeryApplicationsDetail InsertStationeryApplicationsDetailParameter )
		{

			bool bResult =m_publicSyntecGASHandler.InsertStationeryApplicationsDetail( InsertStationeryApplicationsDetailParameter );

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
		[Route( "UpdateStationeryApplicationsDetail" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateStationeryApplicationsDetail( [FromBody] UpdateStationeryApplicationsDetail UpdateStationeryApplicationsDetailParameter )
		{
			bool bResult =m_publicSyntecGASHandler.UpdateStationeryApplicationsDetail( UpdateStationeryApplicationsDetailParameter );

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
		[Route( "DeleteStationeryApplicationsDetail" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteStationeryApplicationsDetail( [FromBody] DeleteStationeryApplicationsDetail DeleteStationeryApplicationsDetailParameter )
		{

			bool bResult =m_publicSyntecGASHandler.DeleteStationeryApplicationsDetail( DeleteStationeryApplicationsDetailParameter );

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


		[Route( "GetStationeryApplicationsDept" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetStationeryApplicationsDept()
		{
			JArray result = m_publicSyntecGASHandler.GetStationeryApplicationsDept();

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
		private PublicSyntecGASHandler m_publicSyntecGASHandler = new PublicSyntecGASHandler();

		#endregion Private Fields
	}
}
