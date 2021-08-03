using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.Dorm;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicDormDBManager : AbstractDBManager
	{
		#region Internal Methods


		internal DataTable GetDormInfo( GetDormInfo GetDormInfoParameter )
		{
			string sql = $@"SELECT *
						  FROM [jirareport].[dbo].[GAS_DormStatusMaster]
						  WHERE [RoomTenantID]=@Parameter0 ";

			List<object> SQLParameterList = new List<object>()
			{
				GetDormInfoParameter.EmpID

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



	}
	#endregion Internal Methods
}

