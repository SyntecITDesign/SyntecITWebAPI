using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.Module;
using SyntecITWebAPI.Models.GAS.Module;
using SyntecITWebAPI.Filter;

namespace SyntecITWebAPI.Controllers.Open.GAS.Module
{
	[EnableCors("AllowAllPolicy")]
	[Route("Open/GAS/Module")]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route("InsertFeatures")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertPersonData([FromBody] InsertFeatures InsertFeaturesParameter)
		{

			bool bResult = m_publicModuleHandler.InsertFeatures(InsertFeaturesParameter);

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

		[Route("DeleteFeatures")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteFeatures([FromBody] DeleteFeatures DeleteFeaturesParameter)
		{

			bool bResult = m_publicModuleHandler.DeleteFeatures(DeleteFeaturesParameter);

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


		[Route("UpdateFeatures")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateFeatures([FromBody] UpdateFeatures UpdateFeaturesParameter)
		{

			bool bResult = m_publicModuleHandler.UpdateFeatures(UpdateFeaturesParameter);

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

		[Route("GetFeatures1")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetFeatures1([FromBody] GetFeatures1 GetFeatures1Parameter)
		{

			JArray result = m_publicModuleHandler.GetFeatures1(GetFeatures1Parameter);

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

		[Route("GetFeatures2")]
		[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetFeatures2([FromBody] GetFeatures2 GetFeatures2Parameter)
		{

			JArray result = m_publicModuleHandler.GetFeatures2(GetFeatures2Parameter);

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

		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicJiraAPIHandler m_publicModuleHandler = new PublicJiraAPIHandler();

		#endregion Private Fields
	}
}
