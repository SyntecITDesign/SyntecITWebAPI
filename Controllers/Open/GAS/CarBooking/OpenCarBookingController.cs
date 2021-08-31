using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Models.GAS.CarBooking;
using SyntecITWebAPI.ParameterModels.GAS.CarBooking;
using Newtonsoft.Json.Linq;

namespace SyntecITWebAPI.Controllers.Open.GAS.Uniform
{
	[EnableCors( "AllowAllPolicy" )]
	[Route( "Open/GAS/CarBooking" )]
	[ApiController]
	public class OpenCarBookingController : ControllerBase
	{
		#region Public Methods

		[Route( "GetCarInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetCarInfo( )
		{
			JArray result = m_publicCarBookingHandler.GetCarInfo(  );

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

		[Route( "UpsertCarInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertUniformSize( [FromBody] UpsertCarInfo UpsertCarInfoParameter )
		{

			bool bResult = m_publicCarBookingHandler.UpsertCarInfo( UpsertCarInfoParameter );

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

		[Route( "GetCarTakeInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetCarTakeInfo(  )
		{
			JArray result = m_publicCarBookingHandler.GetCarTakeInfo(  );

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

		[Route( "UpdateCarTakeInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateCarTakeInfo( [FromBody] UpdateCarTakeInfo UpdateCarTakeInfoParameter )
		{

			bool bResult = m_publicCarBookingHandler.UpdateCarTakeInfo( UpdateCarTakeInfoParameter );

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

		[Route( "GetCarBackInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetCarBackInfo(  )
		{
			JArray result = m_publicCarBookingHandler.GetCarBackInfo( );

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
		[Route( "UpdateCarBackInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpdateCarBackInfo( [FromBody] UpdateCarBackInfo UpdateCarBackInfoParameter )
		{

			bool bResult = m_publicCarBookingHandler.UpdateCarBackInfo( UpdateCarBackInfoParameter );

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


		[Route( "GetBlackListInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetBlackListInfo()
		{
			JArray result = m_publicCarBookingHandler.GetBlackListInfo(  );

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



		[Route( "InserBlackListInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InserBlackListInfo( [FromBody] InserBlackListInfo InserBlackListInfoParameter )
		{

			bool bResult = m_publicCarBookingHandler.InserBlackListInfo( InserBlackListInfoParameter );

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

		[Route( "BlacktoWhite" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult BlacktoWhite( [FromBody] BlacktoWhite BlacktoWhiteParameter )
		{

			bool bResult = m_publicCarBookingHandler.BlacktoWhite( BlacktoWhiteParameter );

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


		[Route( "GetPreserveCar" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetPreserveCar()
		{
			JArray result = m_publicCarBookingHandler.GetPreserveCar();

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

		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicCarBookingHandler m_publicCarBookingHandler = new PublicCarBookingHandler();

		#endregion Private Fields
	}
}
