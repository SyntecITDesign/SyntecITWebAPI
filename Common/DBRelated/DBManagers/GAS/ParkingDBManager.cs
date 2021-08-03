using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.Parking;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicParkingDBManager : AbstractDBManager
	{
		#region Internal Methods


		internal DataTable GetParkingInfo( GetParkingInfo GetParkingInfoParameter )
		{
			string sql = $@"SELECT *
						  FROM [jirareport].[dbo].[GAS_ParkingSpaceStatusMaster]
						  WHERE [EmpID]=@Parameter0 ";

			List<object> SQLParameterList = new List<object>()
			{
				GetParkingInfoParameter.EmpID

			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}



	}
	#endregion Internal Methods
}

