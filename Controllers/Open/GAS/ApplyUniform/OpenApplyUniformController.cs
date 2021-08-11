using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.ApplyUniform;
using SyntecITWebAPI.Models.GAS.ApplyUniform;
namespace SyntecITWebAPI.Controllers.Open.GAS.ApplyUniform
{
	[EnableCors("AllowAllPolicy")]
	[Route("Open/GAS/ApplyUniform")]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route("InsertUniformStyle")]
		//[CheckTokenFilter]
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

		[Route("DeleteUniformInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteUniformInfo([FromBody] DeleteUniformInfo DeleteUniformInfoParameter)
		{

			bool bResult = m_publicApplyUniformHandler.DeleteUniformInfo(DeleteUniformInfoParameter);

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


		[Route("UpdateUniformInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateFeatures([FromBody] UpdateUniformInfo UpdateUniformInfoParameter)
		{

			bool bResult = m_publicApplyUniformHandler.UpdateUniformInfo(UpdateUniformInfoParameter);

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

		[Route("GetUniformInfo")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetUniformInfo([FromBody] GetUniformInfo GetUniformInfoParameter)
		{

			JArray result = m_publicApplyUniformHandler.GetUniformInfo(GetUniformInfoParameter);

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
		private PublicApplyUniformHandler m_publicApplyUniformHandler = new PublicApplyUniformHandler();

		#endregion Private Fields
	}
}
