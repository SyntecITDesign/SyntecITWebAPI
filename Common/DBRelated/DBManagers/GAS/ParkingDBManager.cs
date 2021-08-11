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

		internal bool UpsertParkingInfo( UpsertParkingInfo UpsertParkingInfoParameter )
		{

			string sql = $@"IF EXISTS (SELECT * FROM [jirareport].[dbo].[GAS_ParkingSpaceStatusMaster] WHERE [EmpID]=@Parameter0)
								UPDATE [jirareport].[dbo].[GAS_ParkingSpaceStatusMaster] 
								SET [EmpID]=NULL,[EmpDept]=NULL, [EmpName]=NULL,[CarLicence]=NULL
								WHERE [EmpID]=@Parameter0

							UPDATE [jirareport].[dbo].[GAS_ParkingSpaceStatusMaster] 
							SET EmpID=@Parameter0, EmpName=(SELECT EmpName FROM [jirareport].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0), EmpDept=(SELECT EmpDept FROM [jirareport].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0), CarLicence=(SELECT CarLicense FROM [jirareport].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0)
							WHERE [jirareport].[dbo].[GAS_ParkingSpaceStatusMaster].[ParkingSpaceNum]=@Parameter1";

			List<object> SQLParameterList = new List<object>()
			{
				UpsertParkingInfoParameter.EmpID,
				UpsertParkingInfoParameter.ParkingSpaceNum

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

	}
	#endregion Internal Methods
}

