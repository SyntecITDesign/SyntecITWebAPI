using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.ApplyParking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.ApplyParking
{

	internal class PublicApplyParkingHandler
	{
		#region Internal Methods
		internal bool UpdateParkingSpaceStatusMaster( UpdateParkingSpaceStatusMaster UpdateParkingSpaceStatusMasterParameter )
		{

			bool bResult = m_ApplyParkingDBManager.UpdateParkingSpaceStatusMaster( UpdateParkingSpaceStatusMasterParameter );

			return bResult;
		}
		internal JArray GetParkingSpaceStatusMaster( GetParkingSpaceStatusMaster GetParkingSpaceStatusMasterParameter )
		{

			DataTable dtResult = m_ApplyParkingDBManager.GetParkingSpaceStatusMaster( GetParkingSpaceStatusMasterParameter );

			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}
		internal bool UpdateParkingSpaceApplicationsMaster( UpdateParkingSpaceApplicationsMaster UpdateParkingSpaceApplicationsMasterParameter )
		{

			bool bResult = m_ApplyParkingDBManager.UpdateParkingSpaceApplicationsMaster( UpdateParkingSpaceApplicationsMasterParameter );

			return bResult;
		}
		internal JArray GetParkingSpaceApplicationsMaster( GetParkingSpaceApplicationsMaster GetParkingSpaceApplicationsMasterParameter )
		{

			DataTable dtResult = m_ApplyParkingDBManager.GetParkingSpaceApplicationsMaster( GetParkingSpaceApplicationsMasterParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertParkingSpaceApplicationsMaster( InsertParkingSpaceApplicationsMaster InsertParkingSpaceApplicationsMasterParameter )
		{

			bool bResult = m_ApplyParkingDBManager.InsertParkingSpaceApplicationsMaster( InsertParkingSpaceApplicationsMasterParameter );

			return bResult;
		}

		#endregion Internal Methods

		#region Private Fields

		private ApplyParkingDBManager m_ApplyParkingDBManager = new ApplyParkingDBManager();

		#endregion Private Fields
	}
}