using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.Parking;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicParkingDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public PublicParkingDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}


		internal DataTable GetParkingInfo( GetParkingInfo GetParkingInfoParameter )
		{
			string sql = $@"SELECT *
						  FROM [{m_gas}].[dbo].[ParkingSpaceStatusMaster]
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

			string sql = $@"IF EXISTS (SELECT * FROM [{m_gas}].[dbo].[ParkingSpaceStatusMaster] WHERE [EmpID]=@Parameter0)
								UPDATE [{m_gas}].[dbo].[ParkingSpaceStatusMaster] 
								SET [EmpID]=NULL
								WHERE [EmpID]=@Parameter0

							UPDATE [{m_gas}].[dbo].[ParkingSpaceStatusMaster] 
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

		internal bool InsertCarNumBatch( InsertCarNumBatch InsertCarNumBatchParameter )
		{

			string sql = $@"IF EXISTS (SELECT * FROM [{m_gas}].[dbo].[ParkingNumber] WHERE [CarNum]=@Parameter1)
							UPDATE [{m_gas}].[dbo].[ParkingNumber]
							SET [ParkingNum]=@Parameter2
							WHERE [CarNum]=@Parameter1
							ELSE
						    INSERT INTO [{m_gas}].[dbo].[ParkingNumber]([EmpID],[CarNum],[ParkingNum])  
							VALUES (@Parameter0, @Parameter1, @Parameter2) ";
			
			List<object> SQLParameterList = new List<object>()
			{
				InsertCarNumBatchParameter.EmpID, //0
				InsertCarNumBatchParameter.CarNum, //1
				InsertCarNumBatchParameter.ParkingNum //2
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

	}
	#endregion Internal Methods
}

