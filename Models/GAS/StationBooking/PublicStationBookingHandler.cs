using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.GAS.StationBooking;
using System.Data;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Models.GAS.StationBooking
{
	internal class PublicStationBookingHandler
	{
		#region Internal Methods

		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url
		
		internal bool InsertStationApplicationsMaster( InsertStationApplicationsMaster InsertStationApplicationsMasterParameter )
		{

			bool bResult = m_publicStationBookingDBManager.InsertStationApplicationsMaster( InsertStationApplicationsMasterParameter );

			return bResult;
		}
		internal bool DeleteStationApplicationsMaster( DeleteStationApplicationsMaster DeleteStationApplicationsMasterParameter )
		{

			bool bResult = m_publicStationBookingDBManager.DeleteStationApplicationsMaster( DeleteStationApplicationsMasterParameter );

			return bResult;
		}
		internal bool UpdateStationApplicationsMaster( UpdateStationApplicationsMaster UpdateStationApplicationsMasterParameter )
		{

			bool bResult = m_publicStationBookingDBManager.UpdateStationApplicationsMaster( UpdateStationApplicationsMasterParameter );

			return bResult;
		}
		internal JArray GetStationApplicationsMaster( GetStationApplicationsMaster GetStationApplicationsMasterParameter )
		{

			DataTable dtResult = m_publicStationBookingDBManager.GetStationApplicationsMaster( GetStationApplicationsMasterParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}



		internal JArray GetUsingStation( GetUsingStation GetUsingStationParameter )
		{

			DataTable dtResult = m_publicStationBookingDBManager.GetUsingStation( GetUsingStationParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		#endregion Internal Methods

		#region Private Fields

		private PublicStationBookingDBManager m_publicStationBookingDBManager = new PublicStationBookingDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
