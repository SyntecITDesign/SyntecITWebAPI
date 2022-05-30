using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplyDorm;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplyDormDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public ApplyDormDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}
		internal DataTable GetEmpDormStatusData( GetEmpDormStatusData GetEmpDormStatusDataParameter )
		{
			string sql = $@"SELECT * 
							FROM [{m_gas}].[dbo].[DormStatusMaster] 
							WHERE RoomTenantID =@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				GetEmpDormStatusDataParameter.EmpID

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

		internal bool InsertDormApplicationsMaster( InsertDormApplicationsMaster InsertDormApplicationsMasterParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[DormApplicationsMaster] 
							([EmpID],[ApplicationDate],[Dorm],[RoomNum],[ReservationTime],[Finished],[ApplicationType],[LeaveDate],[EmpRemarks])
							VAlUES(@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter7,@Parameter6,@Parameter8)";

			List<object> SQLParameterList = new List<object>()
			{
				InsertDormApplicationsMasterParameter.EmpID,
				InsertDormApplicationsMasterParameter.ApplicationDate,
				InsertDormApplicationsMasterParameter.Dorm,
				InsertDormApplicationsMasterParameter.RoomNum,
				InsertDormApplicationsMasterParameter.ReservationTime,
				InsertDormApplicationsMasterParameter.Finished,
				InsertDormApplicationsMasterParameter.LeaveDate,
				InsertDormApplicationsMasterParameter.ApplicationType,
				InsertDormApplicationsMasterParameter.EmpRemarks
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		/*
		internal DataTable GetDormApplicationsMaster( GetDormApplicationsMaster GetDormApplicationsMasterParameter )
		{
			string sql = $@"SELECT * 
							FROM [{m_gas}].[dbo].[DormApplicationsMaster] 
							WHERE RoomTenantID =@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				GetDormApplicationsMasterParameter.EmpID

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
		*/

	}
	#endregion Internal Methods
}
