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
		public IActionResult UpsertCarInfo( [FromBody] UpsertCarInfo UpsertCarInfoParameter )
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

		[Route( "DelCarInfo" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DelCarInfo( [FromBody] DelCarInfo DelCarInfoParameter )
		{

			bool bResult = m_publicCarBookingHandler.DelCarInfo( DelCarInfoParameter );

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
		[Route( "GetCarLastBackInfo" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetCarLastBackInfo( [FromBody] GetCarLastBackInfo GetCarLastBackInfoParameter )
		{
			JArray result = m_publicCarBookingHandler.GetCarLastBackInfo( GetCarLastBackInfoParameter );

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

		[Route( "GetCarRepairFrequency" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetCarRepairFrequency()
		{
			JArray result = m_publicCarBookingHandler.GetCarRepairFrequency();

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

		[Route( "UpsertCarRepairFrequency" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertCarRepairFrequency( [FromBody] UpsertCarRepairFrequency UpsertCarRepairFrequencyParameter )
		{

			bool bResult = m_publicCarBookingHandler.UpsertCarRepairFrequency( UpsertCarRepairFrequencyParameter );

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

		[Route( "DeleteCarRepairFrequency" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteCarRepairFrequency( [FromBody] DeleteCarRepairFrequency DeleteCarRepairFrequencyParameter )
		{

			bool bResult = m_publicCarBookingHandler.DeleteCarRepairFrequency( DeleteCarRepairFrequencyParameter );

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

		[Route( "GetCarRepairRecord" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetCarRepairRecord()
		{
			JArray result = m_publicCarBookingHandler.GetCarRepairRecord();

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

		[Route( "GetCarRepairCost" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetCarRepairCost()
		{
			JArray result = m_publicCarBookingHandler.GetCarRepairCost();

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

		[Route( "UpsertCarRepairRecord" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertCarRepairRecord( [FromBody] UpsertCarRepairRecord UpsertCarRepairRecordParameter )
		{

			bool bResult = m_publicCarBookingHandler.UpsertCarRepairRecord( UpsertCarRepairRecordParameter );

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

		[Route( "GetCarFavoriteLink" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetCarFavoriteLink()
		{
			JArray result = m_publicCarBookingHandler.GetCarFavoriteLink();

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

		[Route( "UpsertCarFavoriteLink" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertCarFavoriteLink( [FromBody] UpsertCarFavoriteLink UpsertCarFavoriteLinkParameter )
		{

			bool bResult = m_publicCarBookingHandler.UpsertCarFavoriteLink( UpsertCarFavoriteLinkParameter );

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

		[Route( "DelCarFavoriteLink" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DelCarFavoriteLink( [FromBody] DelCarFavoriteLink DelCarFavoriteLinkParameter )
		{

			bool bResult = m_publicCarBookingHandler.DelCarFavoriteLink( DelCarFavoriteLinkParameter );

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

		[Route( "GetCarInsurance" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetCarInsurance( [FromBody] GetCarInsurance GetCarInsuranceParameter )
		{
			JArray result = m_publicCarBookingHandler.GetCarInsurance( GetCarInsuranceParameter );

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


		[Route( "GetCarInsuranceNameLast" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetCarInsuranceNameLast( )
		{
			JArray result = m_publicCarBookingHandler.GetCarInsuranceNameLast( );

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
		[Route( "GetCarInsuranceSpecificTime" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetCarInsuranceSpecificTime( [FromBody] GetCarInsuranceSpecificTime GetCarInsuranceSpecificTimeParameter )
		{
			JArray result = m_publicCarBookingHandler.GetCarInsuranceSpecificTime( GetCarInsuranceSpecificTimeParameter );

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
		[Route( "UpsertCarInsurance" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertCarInsurance( [FromBody] UpsertCarInsurance UpsertCarInsuranceParameter )
		{

			bool bResult = m_publicCarBookingHandler.UpsertCarInsurance( UpsertCarInsuranceParameter );

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

		[Route( "DelCarInsurance" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DelCarInsurance( [FromBody] DelCarInsurance DelCarInsuranceParameter )
		{

			bool bResult = m_publicCarBookingHandler.DelCarInsurance( DelCarInsuranceParameter );

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

		[Route( "GetCarInsuranceName" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetCarInsuranceName( [FromBody] GetCarInsuranceName GetCarInsuranceNameParameter )
		{
			JArray result = m_publicCarBookingHandler.GetCarInsuranceName( GetCarInsuranceNameParameter );

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

		[Route( "UpsertCarInsuranceName" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertCarInsuranceName( [FromBody] UpsertCarInsuranceName UpsertCarInsuranceNameParameter )
		{

			bool bResult = m_publicCarBookingHandler.UpsertCarInsuranceName( UpsertCarInsuranceNameParameter );

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

		[Route( "DelCarInsuranceName" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DelCarInsuranceName( [FromBody] DelCarInsuranceName DelCarInsuranceNameParameter )
		{

			bool bResult = m_publicCarBookingHandler.DelCarInsuranceName( DelCarInsuranceNameParameter );

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
		[Route( "GetCarInsuranceType" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpGet]
		public IActionResult GetCarInsuranceType()
		{
			JArray result = m_publicCarBookingHandler.GetCarInsuranceType();

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

		[Route( "UpsertCarInsuranceType" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult UpsertCarInsuranceType( [FromBody] UpsertCarInsuranceType UpsertCarInsuranceTypeParameter )
		{

			bool bResult = m_publicCarBookingHandler.UpsertCarInsuranceType( UpsertCarInsuranceTypeParameter );

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

		[Route( "DelCarInsuranceType" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DelCarInsuranceType( [FromBody] DelCarInsuranceType DelCarInsuranceTypeParameter )
		{

			bool bResult = m_publicCarBookingHandler.DelCarInsuranceType( DelCarInsuranceTypeParameter );

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

		[Route( "GetBeenRentCarSpecTime" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetBeenRentCarSpecTime( [FromBody] GetBeenRentCarSpecTime GetBeenRentCarSpecTimeParameter )
		{
			JArray result = m_publicCarBookingHandler.GetBeenRentCarSpecTime( GetBeenRentCarSpecTimeParameter );

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

		[Route( "GetPersonalCarBookingRecord" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetPersonalCarBookingRecord( [FromBody] GetPersonalCarBookingRecord GetPersonalCarBookingRecordParameter )
		{
			JArray result = m_publicCarBookingHandler.GetPersonalCarBookingRecord( GetPersonalCarBookingRecordParameter );

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

		[Route( "GetPrivatePriorityNumber" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult GetPrivatePriorityNumber( [FromBody] GetPrivatePriorityNumber GetPrivatePriorityNumberParameter )
		{
			JArray result = m_publicCarBookingHandler.GetPrivatePriorityNumber( GetPrivatePriorityNumberParameter );

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
		[Route( "CheckInner14DaysHasPrivatDate" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult CheckInner14DaysHasPrivatDate( [FromBody] CheckInner14DaysHasPrivatDate CheckInner14DaysHasPrivatDateParameter )
		{
			JArray result = m_publicCarBookingHandler.CheckInner14DaysHasPrivatDate( CheckInner14DaysHasPrivatDateParameter );

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
		[Route( "CheckPersonalBlockStatus" )]
		//[CheckTokenFilter]
		//[PrivateCookieFilter]
		[HttpPost]
		public IActionResult CheckPersonalBlockStatus( [FromBody] CheckPersonalBlockStatus CheckPersonalBlockStatusParameter )
		{
			JArray result = m_publicCarBookingHandler.CheckPersonalBlockStatus( CheckPersonalBlockStatusParameter );

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

		[Route( "InsertReserveToCarBookingRecord" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult InsertReserveToCarBookingRecord( [FromBody] InsertReserveToCarBookingRecord InsertReserveToCarBookingRecordParameter )
		{

			bool bResult = m_publicCarBookingHandler.InsertReserveToCarBookingRecord( InsertReserveToCarBookingRecordParameter );

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
		[Route( "DeleteCarBookingRecord" )]
		//[CheckTokenFilter]
		[HttpPost]
		public IActionResult DeleteCarBookingRecord( [FromBody] DeleteCarBookingRecord DeleteCarBookingRecordParameter )
		{

			bool bResult = m_publicCarBookingHandler.DeleteCarBookingRecord( DeleteCarBookingRecordParameter );
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
		#endregion Public Methods

		#region Private Fields

		private ResponseHandler m_responseHandler = new ResponseHandler();
		private PublicCarBookingHandler m_publicCarBookingHandler = new PublicCarBookingHandler();

		#endregion Private Fields
	}
}
