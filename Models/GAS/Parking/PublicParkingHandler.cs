using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.GAS.Parking;
using System.Data;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Models.GAS.Parking
{
	internal class PublicParkingHandler
	{
		#region Internal Methods

		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url
		internal JArray QueryParkingInfo( GetParkingInfo GetParkingInfoParameter )
		{

			DataTable dtResult = m_publicParkingDBManager.GetParkingInfo( GetParkingInfoParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertParkingInfo( UpsertParkingInfo UpsertParkingInfoParameter )
		{

			bool bResult = m_publicParkingDBManager.UpsertParkingInfo( UpsertParkingInfoParameter );

			return bResult;
		}
		#endregion Internal Methods

		#region Private Fields

		private PublicParkingDBManager m_publicParkingDBManager = new PublicParkingDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
