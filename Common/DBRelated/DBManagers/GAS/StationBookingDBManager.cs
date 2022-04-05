using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.StationBooking;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicStationBookingDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public PublicStationBookingDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}


		internal bool InsertStationApplicationsMaster( InsertStationApplicationsMaster InsertStationApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[StationApplicationsMaster] ([FillerID],[FillerName],[ApplicationDate],[ApplicantID],[ApplicantName],[ApplicantDept],[ApplyType],[StartDate],[EndDate],[Memo],[Station])
						VALUES (@Parameter1, @Parameter2, @Parameter3, @Parameter4, @Parameter5, @Parameter6, @Parameter8, @Parameter9, @Parameter10, @Parameter11, @Parameter13)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertStationApplicationsMasterParameter.StationApplicationsMasterRequisitionID,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterFillerID,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterFillerName,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterApplicationDate,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterApplicantID,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterApplicantName,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterApplicantDept,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterIsCancel,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterApplyType,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterStartDate,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterEndDate,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterMemo,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterFinished,
				InsertStationApplicationsMasterParameter.StationApplicationsMasterStation
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteStationApplicationsMaster( DeleteStationApplicationsMaster DeleteStationApplicationsMasterParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[StationApplicationsMaster]
								where [RequisitionID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterRequisitionID,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterFillerID,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterFillerName,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterApplicationDate,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterApplicantID,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterApplicantName,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterApplicantDept,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterIsCancel,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterApplyType,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterStartDate,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterEndDate,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterMemo,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterFinished,
				DeleteStationApplicationsMasterParameter.StationApplicationsMasterStation

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateStationApplicationsMaster( UpdateStationApplicationsMaster UpdateStationApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[StationApplicationsMaster]
							set [Finished]=@Parameter12,[IsCancel]=@Parameter7
							where [RequisitionID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterRequisitionID,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterFillerID,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterFillerName,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterApplicationDate,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterApplicantID,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterApplicantName,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterApplicantDept,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterIsCancel,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterApplyType,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterStartDate,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterEndDate,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterMemo,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterFinished,
				UpdateStationApplicationsMasterParameter.StationApplicationsMasterStation

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetStationApplicationsMaster( GetStationApplicationsMaster GetStationApplicationsMasterParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[StationApplicationsMaster]
						WHERE [ApplicantID] like @Parameter4 and [Finished]=@Parameter11
						ORDER BY [RequisitionID] desc";
			List<object> SQLParameterList = new List<object>()
			{

				GetStationApplicationsMasterParameter.StationApplicationsMasterRequisitionID,
				GetStationApplicationsMasterParameter.StationApplicationsMasterFillerID,
				GetStationApplicationsMasterParameter.StationApplicationsMasterFillerName,
				GetStationApplicationsMasterParameter.StationApplicationsMasterApplicationDate,
				GetStationApplicationsMasterParameter.StationApplicationsMasterApplicantID,
				GetStationApplicationsMasterParameter.StationApplicationsMasterApplicantName,
				GetStationApplicationsMasterParameter.StationApplicationsMasterApplicantDept,
				GetStationApplicationsMasterParameter.StationApplicationsMasterApplyType,
				GetStationApplicationsMasterParameter.StationApplicationsMasterStartDate,
				GetStationApplicationsMasterParameter.StationApplicationsMasterEndDate,
				GetStationApplicationsMasterParameter.StationApplicationsMasterMemo,
				GetStationApplicationsMasterParameter.StationApplicationsMasterFinished,
				GetStationApplicationsMasterParameter.StationApplicationsMasterStation
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetUsingStation( GetUsingStation GetUsingStationParameter )
		{
			string sql = $@"select * from [{m_gas}].[dbo].StationApplicationsMaster 
where (([StartDate] BETWEEN CONVERT(datetime,@Parameter0,120) and CONVERT(datetime,@Parameter1,120)) AND ([StartDate]<>CONVERT(datetime,@Parameter1,120))) or (([EndDate] BETWEEN CONVERT(datetime,@Parameter0,120) and CONVERT(datetime,@Parameter1,120)) AND ([EndDate]<>CONVERT(datetime,@Parameter0,120)))";
			List<object> SQLParameterList = new List<object>()
			{
				GetUsingStationParameter.TimeStart,
				GetUsingStationParameter.TimeEnd
			};
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			

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

