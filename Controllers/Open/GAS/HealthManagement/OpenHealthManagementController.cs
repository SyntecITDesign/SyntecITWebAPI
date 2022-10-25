using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.HealthManagement;
using SyntecITWebAPI.Models.GAS.HealthManagement;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.HealthManagement
{
	[EnableCors("AllowAllPolicy")]
	[Route( "Open/GAS/HealthManagement" )]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route("InsertHealthExaminationInfo")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertHealthExaminationInfo([FromBody] InsertHealthExaminationInfo InsertHealthExaminationInfoParameter)
		{

			bool bResult = m_publicHealthManagementHandler.InsertHealthExaminationInfo(InsertHealthExaminationInfoParameter);

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
		[Route("DeleteHealthExaminationInfo")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteHealthExaminationInfo([FromBody] DeleteHealthExaminationInfo DeleteHealthExaminationInfoParameter)
		{

			bool bResult = m_publicHealthManagementHandler.DeleteHealthExaminationInfo(DeleteHealthExaminationInfoParameter);

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
		[Route("UpdateHealthExaminationInfo")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateHealthExaminationInfo([FromBody] UpdateHealthExaminationInfo UpdateHealthExaminationInfoParameter )
		{

			bool bResult = m_publicHealthManagementHandler.UpdateHealthExaminationInfo( UpdateHealthExaminationInfoParameter );

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
		[Route("GetHealthExaminationInfo")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetHealthExaminationInfo([FromBody] GetHealthExaminationInfo GetHealthExaminationInfoParameter)
		{

			JArray result = m_publicHealthManagementHandler.GetHealthExaminationInfo(GetHealthExaminationInfoParameter);

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


		[Route( "InsertHealthExaminationProjects" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertHealthExaminationProjects( [FromBody] InsertHealthExaminationProjects InsertHealthExaminationProjectsParameter )
		{

			bool bResult = m_publicHealthManagementHandler.InsertHealthExaminationProjects( InsertHealthExaminationProjectsParameter );

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
		[Route( "DeleteHealthExaminationProjects" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteHealthExaminationProjects( [FromBody] DeleteHealthExaminationProjects DeleteHealthExaminationProjectsParameter )
		{

			bool bResult = m_publicHealthManagementHandler.DeleteHealthExaminationProjects( DeleteHealthExaminationProjectsParameter );

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
		[Route( "UpdateHealthExaminationProjects" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateHealthExaminationProjects( [FromBody] UpdateHealthExaminationProjects UpdateHealthExaminationProjectsParameter )
		{

			bool bResult = m_publicHealthManagementHandler.UpdateHealthExaminationProjects( UpdateHealthExaminationProjectsParameter );

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
		[Route( "GetHealthExaminationProjects" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetHealthExaminationProjects( [FromBody] GetHealthExaminationProjects GetHealthExaminationProjectsParameter )
		{

			JArray result = m_publicHealthManagementHandler.GetHealthExaminationProjects( GetHealthExaminationProjectsParameter );

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

		[Route( "InsertHealthExaminationItems" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertHealthExaminationItems( [FromBody] InsertHealthExaminationItems InsertHealthExaminationItemsParameter )
		{

			bool bResult = m_publicHealthManagementHandler.InsertHealthExaminationItems( InsertHealthExaminationItemsParameter );

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
		[Route( "DeleteHealthExaminationItems" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteHealthExaminationItems( [FromBody] DeleteHealthExaminationItems DeleteHealthExaminationItemsParameter )
		{

			bool bResult = m_publicHealthManagementHandler.DeleteHealthExaminationItems( DeleteHealthExaminationItemsParameter );

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
		[Route( "UpdateHealthExaminationItems" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateHealthExaminationItems( [FromBody] UpdateHealthExaminationItems UpdateHealthExaminationItemsParameter )
		{

			bool bResult = m_publicHealthManagementHandler.UpdateHealthExaminationItems( UpdateHealthExaminationItemsParameter );

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
		[Route( "GetHealthExaminationItems" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetHealthExaminationItems( [FromBody] GetHealthExaminationItems GetHealthExaminationItemsParameter )
		{

			JArray result = m_publicHealthManagementHandler.GetHealthExaminationItems( GetHealthExaminationItemsParameter );

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


		[Route( "InsertHealthExaminationOptions" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertHealthExaminationOptions( [FromBody] InsertHealthExaminationOptions InsertHealthExaminationOptionsParameter )
		{

			bool bResult = m_publicHealthManagementHandler.InsertHealthExaminationOptions( InsertHealthExaminationOptionsParameter );

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
		[Route( "DeleteHealthExaminationOptions" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteHealthExaminationOptions( [FromBody] DeleteHealthExaminationOptions DeleteHealthExaminationOptionsParameter )
		{

			bool bResult = m_publicHealthManagementHandler.DeleteHealthExaminationOptions( DeleteHealthExaminationOptionsParameter );

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
		[Route( "UpdateHealthExaminationOptions" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateHealthExaminationOptions( [FromBody] UpdateHealthExaminationOptions UpdateHealthExaminationOptionsParameter )
		{

			bool bResult = m_publicHealthManagementHandler.UpdateHealthExaminationOptions( UpdateHealthExaminationOptionsParameter );

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
		[Route( "GetHealthExaminationOptions" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetHealthExaminationOptions( [FromBody] GetHealthExaminationOptions GetHealthExaminationOptionsParameter )
		{

			JArray result = m_publicHealthManagementHandler.GetHealthExaminationOptions( GetHealthExaminationOptionsParameter );

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

		[Route( "GetHealthExaminationEmpInfo" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetHealthExaminationEmpInfo( [FromBody] GetHealthExaminationEmpInfo GetHealthExaminationEmpInfoParameter )
		{

			JArray result = m_publicHealthManagementHandler.GetHealthExaminationEmpInfo( GetHealthExaminationEmpInfoParameter );

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

		[Route( "InsertHealthExaminationApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertHealthExaminationApplicationsMaster( [FromBody] InsertHealthExaminationApplicationsMaster InsertHealthExaminationApplicationsMasterParameter )
		{

			bool bResult = m_publicHealthManagementHandler.InsertHealthExaminationApplicationsMaster( InsertHealthExaminationApplicationsMasterParameter );

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
		[Route( "DeleteHealthExaminationApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteHealthExaminationApplicationsMaster( [FromBody] DeleteHealthExaminationApplicationsMaster DeleteHealthExaminationApplicationsMasterParameter )
		{

			bool bResult = m_publicHealthManagementHandler.DeleteHealthExaminationApplicationsMaster( DeleteHealthExaminationApplicationsMasterParameter );

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
		[Route( "UpdateHealthExaminationApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateHealthExaminationApplicationsMaster( [FromBody] UpdateHealthExaminationApplicationsMaster UpdateHealthExaminationApplicationsMasterParameter )
		{

			bool bResult = m_publicHealthManagementHandler.UpdateHealthExaminationApplicationsMaster( UpdateHealthExaminationApplicationsMasterParameter );

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
		[Route( "GetHealthExaminationApplicationsMaster" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetHealthExaminationApplicationsMaster( [FromBody] GetHealthExaminationApplicationsMaster GetHealthExaminationApplicationsMasterParameter )
		{

			JArray result = m_publicHealthManagementHandler.GetHealthExaminationApplicationsMaster( GetHealthExaminationApplicationsMasterParameter );

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

		[Route( "InsertHealthExaminationApplicationsDetail" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertHealthExaminationApplicationsDetail( [FromBody] InsertHealthExaminationApplicationsDetail InsertHealthExaminationApplicationsDetailParameter )
		{

			bool bResult = m_publicHealthManagementHandler.InsertHealthExaminationApplicationsDetail( InsertHealthExaminationApplicationsDetailParameter );

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
		[Route( "DeleteHealthExaminationApplicationsDetail" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteHealthExaminationApplicationsDetail( [FromBody] DeleteHealthExaminationApplicationsDetail DeleteHealthExaminationApplicationsDetailParameter )
		{

			bool bResult = m_publicHealthManagementHandler.DeleteHealthExaminationApplicationsDetail( DeleteHealthExaminationApplicationsDetailParameter );

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
		[Route( "UpdateHealthExaminationApplicationsDetail" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateHealthExaminationApplicationsDetail( [FromBody] UpdateHealthExaminationApplicationsDetail UpdateHealthExaminationApplicationsDetailParameter )
		{

			bool bResult = m_publicHealthManagementHandler.UpdateHealthExaminationApplicationsDetail( UpdateHealthExaminationApplicationsDetailParameter );

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
		[Route( "GetHealthExaminationApplicationsDetail" )]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetHealthExaminationApplicationsDetail( [FromBody] GetHealthExaminationApplicationsDetail GetHealthExaminationApplicationsDetailParameter )
		{

			JArray result = m_publicHealthManagementHandler.GetHealthExaminationApplicationsDetail( GetHealthExaminationApplicationsDetailParameter );

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
		private PublicHealthManagementHandler m_publicHealthManagementHandler = new PublicHealthManagementHandler();

		#endregion Private Fields
	}
}
