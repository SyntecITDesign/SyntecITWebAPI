using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplyParking;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplyParkingDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public ApplyParkingDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}

		internal bool UpdateParkingSpaceStatusMaster( UpdateParkingSpaceStatusMaster UpdateParkingSpaceStatusMasterParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[ParkingSpaceStatusMaster]
							set [ParkingSpaceUseage]=@Parameter0, [ParkingSpaceStatus]=@Parameter2, [EmpDept]=@Parameter3, [EmpID]=@Parameter4, [EmpName]=@Parameter5, [CarLicence]=@Parameter6, [ParkingSpaceFee]=@Parameter10, [Remarks]=@Parameter11
							where [ParkingSpaceNum]=@Parameter1 and [SalaryYear] = @Parameter7 and [SalaryMonth] = @Parameter8";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterParkingSpaceUseage,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterParkingSpaceNum,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterParkingSpaceStatus,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterEmpDept,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterEmpID,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterEmpName,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterCarLicence,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterSalaryYear,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterSalaryMonth,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterParameterName,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterParkingSpaceFee,
				UpdateParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterRemarks

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetParkingSpaceStatusMaster( GetParkingSpaceStatusMaster GetParkingSpaceStatusMasterParameter )
		{
			string sql = $@"SELECT DISTINCT *
							FROM (
								SELECT [ParkingSpaceUseage],b.[ParkingSpaceNum],[ParkingSpaceStatus],b.[EmpID],[SalaryYear],[SalaryMonth],[ParameterName],[ParkingSpaceFee],[Remarks],[ApplicationType], [Finished]
								FROM [{m_gas}].[dbo].[ParkingSpaceStatusMaster] as b
								LEFT JOIN (SELECT [ParkingSpaceNum],[ApplicationType], [Finished]
											FROM [{m_gas}].[dbo].[ParkingSpaceApplicationsMaster]
											WHERE [Finished]=0) as c
								ON b.[ParkingSpaceNum]=c.[ParkingSpaceNum]
								WHERE [SalaryYear] = @Parameter7 and [SalaryMonth] = @Parameter8 and b.[ParkingSpaceNum] like @Parameter1 and b.[EmpID] like @Parameter4
							) as ParkingSpaceInfo
							LEFT JOIN(SELECT [GAS_GAInfoMaster].EmpID as MasterEmpID,EmpName,EmpDept,[MotorLicense],[CarLicense]
									FROM [{m_gas}].[dbo].[GAS_GAInfoMaster]	
									WHERE [GAS_GAInfoMaster].[EmpID]<>'') as GAInfoMaster
								ON ParkingSpaceInfo.EmpID=GAInfoMaster.MasterEmpID";
			List<object> SQLParameterList = new List<object>()
			{
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterParkingSpaceUseage,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterParkingSpaceNum,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterParkingSpaceStatus,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterEmpDept,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterEmpID,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterEmpName,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterCarLicence,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterSalaryYear,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterSalaryMonth,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterParameterName,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterParkingSpaceFee,
				GetParkingSpaceStatusMasterParameter.ParkingSpaceStatusMasterRemarks
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

		internal bool UpdateParkingSpaceApplicationsMaster( UpdateParkingSpaceApplicationsMaster UpdateParkingSpaceApplicationsMasterParameter )
		{
			string sql = $@"IF @Parameter8='CheckOut'
							UPDATE [{m_gas}].[dbo].[ParkingSpaceApplicationsMaster]
							set [Finished]=@Parameter9
							where [ParkingSpaceNum] = @Parameter6 and [ApplicationType] = @Parameter8
							ELSE IF @Parameter8='CheckIn'
							UPDATE [{m_gas}].[dbo].[ParkingSpaceApplicationsMaster]
							set [ParkingSpaceNum]=@Parameter6, [Finished]=@Parameter9
							where [ApplicantID] = @Parameter1 and [ApplicationType] = @Parameter8";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterRequisitionID,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicantID,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicantName,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterFillerID,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterFillerName,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicationDate,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterParkingSpaceNum,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterReservationTime,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicationType,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterFinished,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterRemarks
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetParkingSpaceApplicationsMaster( GetParkingSpaceApplicationsMaster GetParkingSpaceApplicationsMasterParameter )
		{
			string sql = $@"SELECT b.[ApplicantID],b.[ApplicantName],b.[ApplicationDate],b.[ParkingSpaceNum],b.[ReservationTime],b.[ApplicationType],b.[Finished],b.[Remarks], a.[SuperDeptName], b.[ApplicationArea]
							FROM [{m_gas}].[dbo].[ParkingSpaceApplicationsMaster] as b
							Inner join (SELECT * FROM [syntecbarcode].[dbo].[TEMP_NAME]) as a
							ON b.[ApplicantID] collate Chinese_Taiwan_Stroke_CI_AS = a.[EmpID]
							WHERE b.[Finished]=0 and b.[ApplicantID] like @Parameter1 and b.[ApplicationArea] = @Parameter11
							Order by b.[ApplicationDate]";
			List<object> SQLParameterList = new List<object>()
			{
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterRequisitionID,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicantID,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicantName,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterFillerID,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterFillerName,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicationDate,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterParkingSpaceNum,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterReservationTime,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicationType,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterFinished,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterRemarks,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicationArea
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
		internal bool InsertParkingSpaceApplicationsMaster( InsertParkingSpaceApplicationsMaster InsertParkingSpaceApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[ParkingSpaceApplicationsMaster] ([ApplicantID],[ApplicantName],[FillerID],[FillerName],[ApplicationDate],[ParkingSpaceNum],[ApplicationType],[Finished],[Remarks],[ApplicationArea])
								VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4,@Parameter5, @Parameter6, @Parameter7,@Parameter8,@Parameter9,@Parameter10)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterRequisitionID,
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicantID,
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicantName,
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterFillerID,
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterFillerName,
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicationDate,
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterParkingSpaceNum,
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicationType,
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterFinished,
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterRemarks,
				InsertParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicationArea
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}


	}
	#endregion Internal Methods
}
