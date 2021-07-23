using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models;
using SyntecITWebAPI.Filter;
using SyntecITWebAPI.Static;
using SyntecITWebAPI.Utility;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.ParameterModels.GAS.PersonnelInfo;
using SyntecITWebAPI.Models.GAS.PersonnelInfo;

namespace SyntecITWebAPI.Controllers.Open.GAS.PersonnelInfo
{
	[EnableCors("AllowAllPolicy")]
	[Route("Open/GAS/PersonnelInfo")]
	[ApiController]
	public class OpenCRMController : ControllerBase
	{
		#region Public Methods

		[Route("InsertPersonData")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertPersonData([FromBody] InsertPersonData InsertPersonDataParameter)
		{

			bool bResult = m_publicPersonnelInfoHandler.InsertPersonData(InsertPersonDataParameter);

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

		[Route("DeletePersonData")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeletePersonData([FromBody] DeletePersonData DeletePersonDataParameter)
		{

			bool bResult = m_publicPersonnelInfoHandler.DeletePersonData(DeletePersonDataParameter);

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


		[Route("UpdatePersonDept")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdatePersonDept([FromBody] UpdatePersonDept UpdatePersonDeptParameter)
		{

			bool bResult = m_publicPersonnelInfoHandler.UpdatePersonDept(UpdatePersonDeptParameter);

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

		[Route("GetPersonDept")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetPersonDept([FromBody] GetPersonDept GetPersonDeptParameter)
		{

			JArray result = m_publicPersonnelInfoHandler.GetPersonDept(GetPersonDeptParameter);

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

		[Route("GetQuantity")]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult GetQuantity([FromBody] GetQuantity GetQuantityParameter)
		{

			JArray result = m_publicPersonnelInfoHandler.GetQuantity(GetQuantityParameter);

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
		private PublicPersonnelInfoHandler m_publicPersonnelInfoHandler = new PublicPersonnelInfoHandler();

		#endregion Private Fields
	}
}
