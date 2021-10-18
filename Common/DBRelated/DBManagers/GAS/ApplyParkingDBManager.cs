using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplyParking;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplyParkingDBManager : AbstractDBManager
	{
		#region Internal Methods
		internal bool UpdateParkingSpaceStatusMaster( UpdateParkingSpaceStatusMaster UpdateParkingSpaceStatusMasterParameter )
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[ParkingSpaceStatusMaster]
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
								FROM [SyntecGAS].[dbo].[ParkingSpaceStatusMaster] as b
								LEFT JOIN (SELECT [ParkingSpaceNum],[ApplicationType], [Finished]
											FROM [SyntecGAS].[dbo].[ParkingSpaceApplicationsMaster]
											WHERE [Finished]=0) as c
								ON b.[ParkingSpaceNum]=c.[ParkingSpaceNum]
								WHERE [SalaryYear] = @Parameter7 and [SalaryMonth] = @Parameter8 and b.[ParkingSpaceNum] like @Parameter1
							) as ParkingSpaceInfo
							LEFT JOIN(SELECT [GAS_GAInfoMaster].EmpID as MasterEmpID,EmpName,EmpDept,[MotorLicense],[CarLicense]
									FROM [SyntecGAS].[dbo].[GAS_GAInfoMaster]	
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
			string sql = $@"IF @Parameter5='CheckOut'
							UPDATE [SyntecGAS].[dbo].[ParkingSpaceApplicationsMaster]
							set [Finished]=@Parameter6
							where [ParkingSpaceNum] = @Parameter3 and [ApplicationType] = @Parameter5
							ELSE IF @Parameter5='CheckIn'
							UPDATE [SyntecGAS].[dbo].[ParkingSpaceApplicationsMaster]
							set [ParkingSpaceNum]=@Parameter3, [Finished]=@Parameter6
							where [EmpID] = @Parameter0 and [ApplicationType] = @Parameter5";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterEmpID,
				UpdateParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterEmpName,
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
			string sql = $@"SELECT b.[EmpID],b.[EmpName],b.[ApplicationDate],b.[ParkingSpaceNum],b.[ReservationTime],b.[ApplicationType],b.[Finished],b.[Remarks], a.[SuperDeptName]
							FROM [SyntecGAS].[dbo].[ParkingSpaceApplicationsMaster] as b
							Inner join (SELECT * FROM [syntecbarcode].[dbo].[TEMP_NAME]) as a
							ON b.[EmpID] collate Chinese_Taiwan_Stroke_CI_AS = a.[EmpID]
							WHERE b.[Finished]=0
							Order by b.[ApplicationDate]";
			List<object> SQLParameterList = new List<object>()
			{
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterEmpID,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterEmpName,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicationDate,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterParkingSpaceNum,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterReservationTime,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterApplicationType,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterFinished,
				GetParkingSpaceApplicationsMasterParameter.ParkingSpaceApplicationsMasterRemarks
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
