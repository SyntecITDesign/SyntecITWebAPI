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
						  FROM [SyntecGAS].[dbo].[ParkingSpaceStatusMaster]
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

			string sql = $@"IF EXISTS (SELECT * FROM [SyntecGAS].[dbo].[ParkingSpaceStatusMaster] WHERE [EmpID]=@Parameter0)
								UPDATE [SyntecGAS].[dbo].[ParkingSpaceStatusMaster] 
								SET [EmpID]=NULL
								WHERE [EmpID]=@Parameter0

							UPDATE [SyntecGAS].[dbo].[ParkingSpaceStatusMaster] 
							SET EmpID=@Parameter0
							WHERE [ParkingSpaceNum]=@Parameter1";

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

