using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplyDorm;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplyDormDBManager : AbstractDBManager
	{
		#region Internal Methods
		internal DataTable GetEmpDormStatusData( GetEmpDormStatusData GetEmpDormStatusDataParameter )
		{
			string sql = $@"SELECT * 
							FROM [SyntecGAS].[dbo].[DormStatusMaster] 
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
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[DormApplicationsMaster] 
							([EmpID],[ApplicationDate],[Dorm],[RoomNum],[ReservationTime],[Finished],[ApplicationType],[LeaveDate])
							VAlUES(@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,'CheckOut',@Parameter6)";

			List<object> SQLParameterList = new List<object>()
			{
				InsertDormApplicationsMasterParameter.EmpID,
				InsertDormApplicationsMasterParameter.ApplicationDate,
				InsertDormApplicationsMasterParameter.Dorm,
				InsertDormApplicationsMasterParameter.RoomNum,
				InsertDormApplicationsMasterParameter.ReservationTime,
				InsertDormApplicationsMasterParameter.Finished,
				InsertDormApplicationsMasterParameter.LeaveDate
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

	}
	#endregion Internal Methods
}
