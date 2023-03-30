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
							([EmpID],[ApplicationDate],[Dorm],[RoomNum],[ReservationTime],[Finished],[ApplicationType],[LeaveDate],[EmpRemarks],[EmpName],[RoomCompany],[Remarks])
							VAlUES(@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter7,@Parameter6,@Parameter8,@Parameter9,@Parameter10,@Parameter11)";

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
				InsertDormApplicationsMasterParameter.EmpRemarks,
				InsertDormApplicationsMasterParameter.EmpName,
				InsertDormApplicationsMasterParameter.RoomCompany,
				InsertDormApplicationsMasterParameter.Remarks
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool UpdateDormApplicationsMaster( UpdateDormApplicationsMaster UpdateDormApplicationsMasterParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[DormApplicationsMaster]
							set [Finished]=@Parameter1, [Remarks]=@Parameter3
							where [EmpID]=@Parameter0 and [ApplicationType]=@Parameter2";

			List<object> SQLParameterList = new List<object>()
			{
				UpdateDormApplicationsMasterParameter.EmpID,
				UpdateDormApplicationsMasterParameter.Finished,
				UpdateDormApplicationsMasterParameter.ApplicationType,
				UpdateDormApplicationsMasterParameter.Remarks
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetDormApplicationsMaster_SZ( GetDormApplicationsMaster_SZ GetDormApplicationsMaster_SZ_Parameter )
		{
			string sql = $@"SELECT * 
							FROM [{m_gas}].[dbo].[DormApplicationsMaster] 
							WHERE [EmpID] like @Parameter0 and [Finished]=@Parameter1 and [ApplicationType] like @Parameter2";

			List<object> SQLParameterList = new List<object>()
			{
				GetDormApplicationsMaster_SZ_Parameter.EmpID,
				GetDormApplicationsMaster_SZ_Parameter.Finished,
				GetDormApplicationsMaster_SZ_Parameter.ApplicationType

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

		internal DataTable GetDormInfo_SZ( GetDormInfo_SZ GetDormInfo_SZParameter )
		{
			string sql = $@"SELECT * 
							FROM [{m_gas}].[dbo].[DormInfo_SZ]
							where [EmpID] like @Parameter3
							order by [ID] desc";

			List<object> SQLParameterList = new List<object>()
			{
				GetDormInfo_SZParameter.DormInfo_SZID,
				GetDormInfo_SZParameter.DormInfo_SZDorm,
				GetDormInfo_SZParameter.DormInfo_SZRoomNum,
				GetDormInfo_SZParameter.DormInfo_SZEmpID,
				GetDormInfo_SZParameter.DormInfo_SZEmpName

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

		internal bool UpsertDormInfo_SZ( UpsertDormInfo_SZ UpsertDormInfo_SZParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [{m_gas}].[dbo].[DormInfo_SZ] WHERE [ID]=@Parameter0 )
							UPDATE [{m_gas}].[dbo].[DormInfo_SZ] SET [Dorm]=@Parameter1, [RoomNum]=@Parameter2, [EmpID]=@Parameter3, [EmpName]=@Parameter4
							WHERE [ID]=@Parameter0 
						ELSE
						INSERT INTO [{m_gas}].[dbo].[DormInfo_SZ] ([Dorm],[RoomNum]) 
						VALUES (@Parameter1,@Parameter2)";
			List<object> SQLParameterList = new List<object>()
			{
				UpsertDormInfo_SZParameter.DormInfo_SZID,
				UpsertDormInfo_SZParameter.DormInfo_SZDorm,
				UpsertDormInfo_SZParameter.DormInfo_SZRoomNum,
				UpsertDormInfo_SZParameter.DormInfo_SZEmpID,
				UpsertDormInfo_SZParameter.DormInfo_SZEmpName


			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool DeleteDormInfo_SZ( DeleteDormInfo_SZ DeleteDormInfo_SZParameter )
		{
			string sql = $@"DELETE FROM [{m_gas}].[dbo].[DormInfo_SZ]
						WHERE [ID] = @Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				DeleteDormInfo_SZParameter.DormInfo_SZID,
				DeleteDormInfo_SZParameter.DormInfo_SZDorm,
				DeleteDormInfo_SZParameter.DormInfo_SZRoomNum,
				DeleteDormInfo_SZParameter.DormInfo_SZEmpID,
				DeleteDormInfo_SZParameter.DormInfo_SZEmpName


			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		
	}
	#endregion Internal Methods
}
