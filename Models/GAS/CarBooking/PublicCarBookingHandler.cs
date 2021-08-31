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

		#endregion Internal Methods

		#region Private Fields

		private PublicCarBookingDBManager m_CarBookingDBManager = new PublicCarBookingDBManager();

		#endregion Private Fields
	}
}