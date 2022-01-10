using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.WorkCalendar;
using System.Linq;


namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicWorkCalendarDBManager : AbstractDBManager
	{
		#region Internal Methods
	
		internal DataTable GetWorkDayInfo( GetWorkDayInfo GetWorkDayInfoParameter )
		{
			string sql = $@"SELECT *
							FROM [dwh].[dbo].[Calendar]
							WHERE [Date]=@Parameter0";

			List<object> SQLParameterList = new List<object>()
			{
				GetWorkDayInfoParameter.Date
				

			};
			DataTable result = m_DWHdbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );


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

