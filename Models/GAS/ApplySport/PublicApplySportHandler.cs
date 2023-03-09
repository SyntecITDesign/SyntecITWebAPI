using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.ApplySport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.ApplySport
{
	internal class PublicApplySportHandler
	{
		#region Internal Methods
		internal JArray GetAllCourt()
		{
			DataTable dtResult = m_ApplySportDBManager.GetAllCourt();

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertCourtReserve( InsertCourtReserve InsertCourtReserveParameter )
		{
			bool bResult = m_ApplySportDBManager.InsertCourtReserve( InsertCourtReserveParameter );

			return bResult;
		}
		internal JArray GetUsingCourt( GetUsingCourt GetUsingCourtParameter )
		{

			DataTable dtResult = m_ApplySportDBManager.GetUsingCourt( GetUsingCourtParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray DuplicateReserve( DuplicateReserve DuplicateReserveParameter )
		{
			DataTable dtResult = m_ApplySportDBManager.DuplicateReserve( DuplicateReserveParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray GetSportCourtReserve( GetSportCourtReserve GetSportCourtReserveParameter )
		{
			DataTable dtResult = m_ApplySportDBManager.GetSportCourtReserve( GetSportCourtReserveParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool UpdateSportCourtReserve( UpdateSportCourtReserve UpdateSportCourtReserveParameter )
		{
			bool bResult = m_ApplySportDBManager.UpdateSportCourtReserve( UpdateSportCourtReserveParameter );

			return bResult;
		}
		//internal bool UpdateParkingSpaceStatusMaster( UpdateParkingSpaceStatusMaster UpdateParkingSpaceStatusMasterParameter )
		//{

		//	bool bResult = m_ApplyParkingDBManager.UpdateParkingSpaceStatusMaster( UpdateParkingSpaceStatusMasterParameter );

		//	return bResult;
		//}
		//internal bool UpdateParkingSpaceApplicationsMaster( UpdateParkingSpaceApplicationsMaster UpdateParkingSpaceApplicationsMasterParameter )
		//{

		//	bool bResult = m_ApplyParkingDBManager.UpdateParkingSpaceApplicationsMaster( UpdateParkingSpaceApplicationsMasterParameter );

		//	return bResult;
		//}
		//internal JArray GetParkingSpaceApplicationsMaster( GetParkingSpaceApplicationsMaster GetParkingSpaceApplicationsMasterParameter )
		//{

		//	DataTable dtResult = m_ApplyParkingDBManager.GetParkingSpaceApplicationsMaster( GetParkingSpaceApplicationsMasterParameter );

		//	if(dtResult == null || dtResult.Rows.Count <= 0)
		//		return null;
		//	else
		//	{
		//		JArray ja = JArray.FromObject( dtResult );
		//		return ja;
		//	}
		//}

		#endregion Internal Methods

		#region Private Fields

		private ApplySportDBManager m_ApplySportDBManager = new ApplySportDBManager();

		#endregion Private Fields
	}
}
