﻿using Microsoft.AspNetCore.Cors;
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

		
		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicAssetManagementHandler m_publicAssetManagementHandler = new PublicAssetManagementHandler();

		#endregion Private Fields
	}
}