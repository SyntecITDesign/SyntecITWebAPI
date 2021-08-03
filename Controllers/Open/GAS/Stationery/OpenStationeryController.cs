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
	[Route("Open/SyntecGAS")]
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
		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicSyntecGASHandler m_publicSyntecGASHandler = new PublicSyntecGASHandler();

		#endregion Private Fields
	}
}
