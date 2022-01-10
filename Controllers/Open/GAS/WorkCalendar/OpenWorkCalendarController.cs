using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.WorkCalendar;
using SyntecITWebAPI.ParameterModels.GAS.WorkCalendar;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Controllers.Open.GAS.WorkCalendar
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/WorkCalendar" )]
	[ApiController]
	public class OpenUniformController : ControllerBase
	{
		#region Public Methods

		[Route( "GetWorkDayInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetWorkDayInfo( [FromBody] GetWorkDayInfo GetWorkDayInfoParameter )
		{
			JArray result = m_publicWorkCalendarHandler.GetWorkDayInfo( GetWorkDayInfoParameter );

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
		private PublicWorkCalendarHandler m_publicWorkCalendarHandler = new PublicWorkCalendarHandler();

		#endregion Private Fields
	}
}
