using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.CarBooking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.CarBooking
{

	internal class PublicCarBookingHandler
	{
		#region Internal Methods


		internal JArray GetCarInfo( )
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarInfo();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertCarInfo( UpsertCarInfo UpsertCarInfoParameter )
		{

			bool bResult = m_CarBookingDBManager.UpsertCarInfo( UpsertCarInfoParameter );

			return bResult;
		}

		internal bool DelCarInfo( DelCarInfo DelCarInfoParameter )
		{

			bool bResult = m_CarBookingDBManager.DelCarInfo( DelCarInfoParameter );

			return bResult;
		}

		internal JArray GetCarTakeInfo( )
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarTakeInfo(  );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpdateCarTakeInfo( UpdateCarTakeInfo UpdateCarTakeInfoParameter )
		{

			bool bResult = m_CarBookingDBManager.UpdateCarTakeInfo( UpdateCarTakeInfoParameter );

			return bResult;
		}

		internal JArray GetCarBackInfo( )
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarBackInfo(  );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetCarLastBackInfo( GetCarLastBackInfo GetCarLastBackInfoParameter )
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarLastBackInfo( GetCarLastBackInfoParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpdateCarBackInfo( UpdateCarBackInfo UpdateCarBackInfoParameter )
		{

			bool bResult = m_CarBookingDBManager.UpdateCarBackInfo( UpdateCarBackInfoParameter );

			return bResult;
		}

		internal JArray GetBlackListInfo( )
		{

			DataTable dtResult = m_CarBookingDBManager.GetBlackListInfo(  );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool InserBlackListInfo( InserBlackListInfo InserBlackListInfoParameter )
		{

			bool bResult = m_CarBookingDBManager.InserBlackListInfo( InserBlackListInfoParameter );

			return bResult;
		}

		internal bool BlacktoWhite( BlacktoWhite BlacktoWhiteParameter )
		{

			bool bResult = m_CarBookingDBManager.BlacktoWhite( BlacktoWhiteParameter );

			return bResult;
		}

		internal JArray GetPreserveCar()
		{

			DataTable dtResult = m_CarBookingDBManager.GetPreserveCar();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetCarRepairFrequency()
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarRepairFrequency();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertCarRepairFrequency( UpsertCarRepairFrequency UpsertCarRepairFrequencyParameter )
		{

			bool bResult = m_CarBookingDBManager.UpsertCarRepairFrequency( UpsertCarRepairFrequencyParameter );

			return bResult;
		}

		internal bool DeleteCarRepairFrequency( DeleteCarRepairFrequency DeleteCarRepairFrequencyParameter )
		{

			bool bResult = m_CarBookingDBManager.DeleteCarRepairFrequency( DeleteCarRepairFrequencyParameter );

			return bResult;
		}

		internal JArray GetCarRepairRecord()
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarRepairRecord();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetCarRepairCost()
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarRepairCost();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool UpsertCarRepairRecord( UpsertCarRepairRecord UpsertCarRepairRecordParameter )
		{

			bool bResult = m_CarBookingDBManager.UpsertCarRepairRecord( UpsertCarRepairRecordParameter );

			return bResult;
		}

		internal JArray GetCarFavoriteLink()
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarFavoriteLink();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertCarFavoriteLink( UpsertCarFavoriteLink UpsertCarFavoriteLinkParameter )
		{

			bool bResult = m_CarBookingDBManager.UpsertCarFavoriteLink( UpsertCarFavoriteLinkParameter );

			return bResult;
		}

		internal bool DelCarFavoriteLink( DelCarFavoriteLink DelCarFavoriteLinkParameter )
		{

			bool bResult = m_CarBookingDBManager.DelCarFavoriteLink( DelCarFavoriteLinkParameter );

			return bResult;
		}

		internal JArray GetCarInsurance( GetCarInsurance GetCarInsuranceParameter )
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarInsurance( GetCarInsuranceParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetCarInsuranceNameLast( )
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarInsuranceNameLast(  );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray GetCarInsuranceSpecificTime( GetCarInsuranceSpecificTime GetCarInsuranceSpecificTimeParameter )
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarInsuranceSpecificTime( GetCarInsuranceSpecificTimeParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool UpsertCarInsurance( UpsertCarInsurance UpsertCarInsuranceParameter )
		{

			bool bResult = m_CarBookingDBManager.UpsertCarInsurance( UpsertCarInsuranceParameter );

			return bResult;
		}

		internal bool DelCarInsurance( DelCarInsurance DelCarInsuranceParameter )
		{

			bool bResult = m_CarBookingDBManager.DelCarInsurance( DelCarInsuranceParameter );

			return bResult;
		}

		internal JArray GetCarInsuranceName( GetCarInsuranceName GetCarInsuranceNameParameter )
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarInsuranceName( GetCarInsuranceNameParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertCarInsuranceName( UpsertCarInsuranceName UpsertCarInsuranceNameParameter )
		{

			bool bResult = m_CarBookingDBManager.UpsertCarInsuranceName( UpsertCarInsuranceNameParameter );

			return bResult;
		}

		internal bool DelCarInsuranceName( DelCarInsuranceName DelCarInsuranceNameParameter )
		{

			bool bResult = m_CarBookingDBManager.DelCarInsuranceName( DelCarInsuranceNameParameter );

			return bResult;
		}
		internal JArray GetCarInsuranceType()
		{

			DataTable dtResult = m_CarBookingDBManager.GetCarInsuranceType();

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertCarInsuranceType( UpsertCarInsuranceType UpsertCarInsuranceTypeParameter )
		{

			bool bResult = m_CarBookingDBManager.UpsertCarInsuranceType( UpsertCarInsuranceTypeParameter );

			return bResult;
		}

		internal bool DelCarInsuranceType( DelCarInsuranceType DelCarInsuranceTypeParameter )
		{

			bool bResult = m_CarBookingDBManager.DelCarInsuranceType( DelCarInsuranceTypeParameter );

			return bResult;
		}
		#endregion Internal Methods

		#region Private Fields

		private PublicCarBookingDBManager m_CarBookingDBManager = new PublicCarBookingDBManager();

		#endregion Private Fields
	}
}