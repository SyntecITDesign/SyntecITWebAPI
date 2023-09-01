using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplyParkingLicence;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplyParkingLicenceDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public ApplyParkingLicenceDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}

		
		internal bool InsertParkingLicenceApplicationsMaster( InsertParkingLicenceApplicationsMaster InsertParkingLicenceApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[ParkingLicenceApplicationsMaster] ([ApplicantID],[ApplicantName],[ApplicationDate],[ApplicationType],[PlateNumber],[Remarks],[Finished],[IsCancel])
								VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicantID,
				InsertParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicantName,
				InsertParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicationDate,
				InsertParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicationType,
				InsertParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterPlateNumber,
				InsertParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterRemarks,
				InsertParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterFinished,
				InsertParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterIsCancel,
				InsertParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterRequisitionID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateParkingLicenceApplicationsMaster( UpdateParkingLicenceApplicationsMaster UpdateParkingLicenceApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[ParkingLicenceApplicationsMaster]
							set [Finished]=@Parameter6,[IsCancel]=@Parameter7
							where [RequisitionID] = @Parameter8 ";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicantID,
				UpdateParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicantName,
				UpdateParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicationDate,
				UpdateParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicationType,
				UpdateParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterPlateNumber,
				UpdateParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterRemarks,
				UpdateParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterFinished,
				UpdateParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterIsCancel,
				UpdateParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterRequisitionID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetParkingLicenceApplicationsMaster( GetParkingLicenceApplicationsMaster GetParkingLicenceApplicationsMasterParameter )
		{
			string sql = $@"SELECT b.[ApplicantID],b.[ApplicantName],b.[ApplicationDate],b.[ApplicationType],b.[PlateNumber],b.[Finished],b.[Remarks],b.[IsCancel],b.[RequisitionID]
							FROM [{m_gas}].[dbo].[ParkingLicenceApplicationsMaster] as b
							Inner join (SELECT * FROM [syntecbarcode].[dbo].[TEMP_NAME]) as a
							ON b.[ApplicantID] collate Chinese_Taiwan_Stroke_CI_AS = a.[EmpID]
							WHERE b.[Finished]=0 and b.[ApplicantID] like @Parameter0
							Order by b.[ApplicationDate]";
			List<object> SQLParameterList = new List<object>()
		{
				GetParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicantID,
				GetParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicantName,
				GetParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicationDate,
				GetParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterApplicationType,
				GetParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterPlateNumber,
				GetParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterRemarks,
				GetParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterFinished,
				GetParkingLicenceApplicationsMasterParameter.ParkingLicenceApplicationsMasterIsCancel
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if( result == null || result.Rows.Count <= 0 )
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
