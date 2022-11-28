using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplySport;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplySportDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public ApplySportDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration["bpm"].Trim();
			m_gas = configuration["gas"].Trim();
		}
		internal DataTable GetAllCourt() //取得所有球場的資訊
		{
			string sql = $@"SELECT *
							FROM [{m_gas}].[dbo].[CourtInfo]
							";
			DataTable result = m_dbproxy.GetDataWithNoParaCMD( sql);

			if(result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}
		internal bool InsertCourtReserve( InsertCourtReserve InsertCourtReserveParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[CourtRecord] 
							([EmpID]
							  ,[Name]
							  ,[ApplyDate]
							  ,[ReserveDate]
							  ,[ReserveStartTime]
							  ,[ReserveEndTime]
							  ,[Court])
							VALUES(@Parameter0,  @Parameter1,  @Parameter2,  @Parameter3,  @Parameter4, @Parameter5,  @Parameter6)
							";

			List<object> SQLParameterList = new List<object>()
			{
				InsertCourtReserveParameter.EmpID,
				InsertCourtReserveParameter.Name,
				InsertCourtReserveParameter.ApplyDate,
				InsertCourtReserveParameter.ReserveDate,
				InsertCourtReserveParameter.ReserveStartTime,
				InsertCourtReserveParameter.ReserveEndTime,
				InsertCourtReserveParameter.Court
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal DataTable GetUsingCourt( GetUsingCourt GetUsingCourtParameter )
		{
			string sql = $@"SELECT [ReserveStartTime],[ReserveEndTime],[Court] FROM [{m_gas}].[dbo].[CourtRecord] 
							WHERE [ReserveDate]=@Parameter0
							";

			List<object> SQLParameterList = new List<object>()
			{
				GetUsingCourtParameter.ReserveDate
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
		internal DataTable DuplicateReserve( DuplicateReserve DuplicateReserveParameter ) 
		{
			string sql = $@"SELECT [EmpID]
							FROM [{m_gas}].[dbo].[CourtRecord]
							WHERE [ApplyDate]=@Parameter0
							";
			List<object> SQLParameterList = new List<object>()
			{
				DuplicateReserveParameter.ApplyDate
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
		//internal bool DeleteCarBookingApplicationsMaster( DeleteCarBookingApplicationsMaster DeleteCarBookingApplicationsMasterParameter )
		//{
		//	string sql = $@"DELETE FROM [{m_gas}].[dbo].[CarBookingApplicationsMaster]
		//					WHERE  ReuisitionID=@Parameter0";

		//	List<object> SQLParameterList = new List<object>()
		//	{
		//		DeleteCarBookingApplicationsMasterParameter.ReuisitionID
		//	};
		//	bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
		//	return bResult;
		//}

	}
	#endregion Internal Methods
}
