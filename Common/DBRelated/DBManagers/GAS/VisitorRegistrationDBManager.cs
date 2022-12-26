using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.VisitorRegistration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class VisitorRegistrationDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public VisitorRegistrationDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration["bpm"].Trim();
			m_gas = configuration["gas"].Trim();
		}

		//in use--
		internal bool InsertVisitorApplication( InsertVisitorApplication InsertVisitorApplicationParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[VisitorRegistration] ([ApplyTime]
						  ,[VisitorName]
						  ,[VisitorTel]
						  ,[IntervieweeName]
						  ,[VisitorCompany]
						  ,[ParkingCar]
						  ,[BringComputer])
						VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertVisitorApplicationParameter.VisitorRegistrationApplicationsApplyTime,
				InsertVisitorApplicationParameter.VisitorRegistrationApplicationsVisitorName,
				InsertVisitorApplicationParameter.VisitorRegistrationApplicationsVisitorTel,
				InsertVisitorApplicationParameter.VisitorRegistrationApplicationsIntervieweeName,
				InsertVisitorApplicationParameter.VisitorRegistrationApplicationsVisitorCompany,
				InsertVisitorApplicationParameter.VisitorRegistrationApplicationsParkingCar,
				InsertVisitorApplicationParameter.VisitorRegistrationApplicationsBringComputer
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetVisitorRecord()
		{
			string sql = $@"SELECT [ApplyTime], [VisitorName], [VisitorTel], [VisitorRFIDCardNum],[VisitorCardNum]  FROM [{m_gas}].[dbo].[VisitorRegistration]
							WHERE [ReturnTime] IS NULL OR [ReturnTime]=''";
			
			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql );

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal bool DeleteRecord( DeleteRecord DeleteRecordParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[VisitorRegistration]
							set [ReturnTime]=@Parameter2,[Affirmant]=@Parameter3
							where [VisitorName]=@Parameter1 and [ApplyTime]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteRecordParameter.VisitorRegistrationApplicationsApplyTime,
				DeleteRecordParameter.VisitorRegistrationApplicationsVisitorName,
				DeleteRecordParameter.VisitorRegistrationApplicationsReturnTime,
				DeleteRecordParameter.VisitorRegistrationApplicationsAffirmant
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateRecord( UpdateRecord UpdateRecordParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[VisitorRegistration]
							set [VisitorRFIDCardNum]=@Parameter2,[VisitorCardNum]=@Parameter3
							where [VisitorName]=@Parameter1 and [ApplyTime]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateRecordParameter.VisitorRegistrationApplicationsApplyTime,
				UpdateRecordParameter.VisitorRegistrationApplicationsVisitorName,
				UpdateRecordParameter.VisitorRegistrationApplicationsVisitorRFIDCardNum,
				UpdateRecordParameter.VisitorRegistrationApplicationsVisitorCardNum
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		//--
		internal bool InsertVisitorRegistrationApplicationsMaster( InsertVisitorRegistrationApplicationsMaster InsertVisitorRegistrationApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[VisitorRegistrationApplicationsMaster] ([FillDate],[PreserveVisitDateTime],[VisitorCompany],[Visitor],[VisitorNum],[VisitorType],[VisitorTel],[IntervieweeName],[ParkingCarsName],[ParkingCarsNum],[HealthDeclaration],[Disseminate],[CarryOn])
						VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter7, @Parameter9, @Parameter10, @Parameter11, @Parameter12)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterRequisitionID,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterFillDate,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterPreserveVisitDateTime,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterVisitorCompany,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterVisitor,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterVisitorNum,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterVisitorType,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterVisitorTel,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterIntervieweeName,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterParkingCarsName,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterParkingCarsNum,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterHealthDeclaration,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterDisseminate,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterCarryOn,

				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterActualVisitDateTime,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterBadgeType,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterBadgeNo,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterIntervieweeID,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterCheckCarryOn,

				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterActualLeaveDateTime,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterIsReturnBadge,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterIsCheckCarryOn,

				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterFinished,
				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterIsCancel,

				InsertVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetVisitorRegistrationApplicationsMaster( GetVisitorRegistrationApplicationsMaster GetVisitorRegistrationApplicationsMasterParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[VisitorRegistrationApplicationsMaster]
						Where [IsCancel]=@Parameter20 and [Finished]=@Parameter19
						ORDER BY [PreserveVisitDateTime] desc";
			List<object> SQLParameterList = new List<object>()
			{
				GetVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterRequisitionID,
				GetVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterPreserveVisitDateTime,
				GetVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterFinished,
				GetVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterIsCancel,
				GetVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterMemo
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal bool UpdateVisitorRegistrationApplicationsMaster( UpdateVisitorRegistrationApplicationsMaster UpdateVisitorRegistrationApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[VisitorRegistrationApplicationsMaster]
							set [Finished]=@Parameter19,[IsCancel]=@Parameter20
							where RequisitionID=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterRequisitionID,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterPreserveVisitDateTime,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterVisitorCompany,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterVisitor,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterVisitorNum,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterVisitorType,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterVisitorTel,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterIntervieweeName,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterParkingCarsName,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterParkingCarsNum,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterHealthDeclaration,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterDisseminate,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterCarryOn,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterActualVisitDateTime,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterBadgeType,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterBadgeNo,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterIntervieweeID,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterCheckCarryOn,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterActualLeaveDateTime,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterIsReturnBadge,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterFinished,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterIsCancel,
				UpdateVisitorRegistrationApplicationsMasterParameter.VisitorRegistrationApplicationsMasterMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool VisitorCheckIn( VisitorCheckIn VisitorCheckInParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[VisitorRegistrationApplicationsMaster]
							set [ActualVisitDateTime]=@Parameter,[BadgeType]=@Parameter,[BadgeNo]=@Parameter,[IntervieweeID]=@Parameter,[CheckCarryOn]=
							where RequisitionID=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				VisitorCheckInParameter.VisitorRegistrationApplicationsMasterRequisitionID,
				VisitorCheckInParameter.VisitorRegistrationApplicationsMasterActualVisitDateTime,
				VisitorCheckInParameter.VisitorRegistrationApplicationsMasterBadgeType,
				VisitorCheckInParameter.VisitorRegistrationApplicationsMasterBadgeNo,
				VisitorCheckInParameter.VisitorRegistrationApplicationsMasterIntervieweeID,
				VisitorCheckInParameter.VisitorRegistrationApplicationsMasterCheckCarryOn
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool VisitorCheckOut( VisitorCheckOut VisitorCheckOutParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[VisitorRegistrationApplicationsMaster]
							set [Finished]=@Parameter19,[IsCancel]=@Parameter20
							where RequisitionID=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				VisitorCheckOutParameter.VisitorRegistrationApplicationsMasterRequisitionID,
				VisitorCheckOutParameter.VisitorRegistrationApplicationsMasterActualLeaveDateTime,
				VisitorCheckOutParameter.VisitorRegistrationApplicationsMasterIsReturnBadge,
				VisitorCheckOutParameter.VisitorRegistrationApplicationsMasterIsCheckCarryOn,
				VisitorCheckOutParameter.VisitorRegistrationApplicationsMasterFinished,
				VisitorCheckOutParameter.VisitorRegistrationApplicationsMasterIsCancel,
				VisitorCheckOutParameter.VisitorRegistrationApplicationsMasterMemo
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
	}
	#endregion Internal Methods
}
