using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.ApplyCarBooking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.ApplyCarBooking
{

	internal class PublicApplyCarBookingHandler
	{
		#region Internal Methods
		internal JArray GetCarBookingApplicationsMaster( GetCarBookingApplicationsMaster GetCarBookingApplicationsMasterParameter )
		{

			DataTable dtResult = m_ApplyCarBookingDBManager.GetCarBookingApplicationsMaster( GetCarBookingApplicationsMasterParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertCarBookingApplicationsMaster( InsertCarBookingApplicationsMaster InsertCarBookingApplicationsMasterParameter )
		{

			bool bResult = m_ApplyCarBookingDBManager.InsertCarBookingApplicationsMaster( InsertCarBookingApplicationsMasterParameter );

			return bResult;
		}
		
		internal bool DeleteCarBookingApplicationsMaster( DeleteCarBookingApplicationsMaster DeleteCarBookingApplicationsMasterParameter )
		{

			bool bResult = m_ApplyCarBookingDBManager.DeleteCarBookingApplicationsMaster( DeleteCarBookingApplicationsMasterParameter );

			return bResult;
		}
		
		#endregion Internal Methods

		#region Private Fields

		private ApplyCarBookingDBManager m_ApplyCarBookingDBManager = new ApplyCarBookingDBManager();

		#endregion Private Fields
	}
}