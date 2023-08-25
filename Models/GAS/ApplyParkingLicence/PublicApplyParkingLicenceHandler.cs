using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.ApplyParking;
using SyntecITWebAPI.ParameterModels.GAS.ApplyParkingLicence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.ApplyParkingLicence
{

	internal class PublicApplyParkingLicenceHandler
	{
		#region Internal Methods
		
		internal bool InsertParkingLicenceApplicationsMaster( InsertParkingLicenceApplicationsMaster InsertParkingLicenceApplicationsMasterParameter )
		{

			bool bResult = m_ApplyParkingLicenceDBManager.InsertParkingLicenceApplicationsMaster( InsertParkingLicenceApplicationsMasterParameter );

			return bResult;
		}
		internal bool UpdateParkingLicenceApplicationsMaster( UpdateParkingLicenceApplicationsMaster UpdateParkingLicenceApplicationsMasterParameter )
		{

			bool bResult = m_ApplyParkingLicenceDBManager.UpdateParkingLicenceApplicationsMaster( UpdateParkingLicenceApplicationsMasterParameter );

			return bResult;
		}
		internal JArray GetParkingLicenceApplicationsMaster( GetParkingLicenceApplicationsMaster GetParkingLicenceApplicationsMasterParameter )
		{

			DataTable dtResult = m_ApplyParkingLicenceDBManager.GetParkingLicenceApplicationsMaster( GetParkingLicenceApplicationsMasterParameter );

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

		private ApplyParkingLicenceDBManager m_ApplyParkingLicenceDBManager = new ApplyParkingLicenceDBManager();

		#endregion Private Fields
	}
}