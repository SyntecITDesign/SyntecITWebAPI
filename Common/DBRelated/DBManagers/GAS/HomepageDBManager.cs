using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.Homepage;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class HomepageDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public HomepageDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}

		internal DataTable GetHomepageAlertEvents( GetHomepageAlertEvents GetHomepageAlertEventsParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[HomepageAlertEvents]
						ORDER BY [ID]";

			List<object> SQLParameterList = new List<object>()
			{
				GetHomepageAlertEventsParameter.HomepageAlertEventsNo,
				GetHomepageAlertEventsParameter.HomepageAlertEventsTitle,
				GetHomepageAlertEventsParameter.HomepageAlertEventsStartDate,
				GetHomepageAlertEventsParameter.HomepageAlertEventsID,
				GetHomepageAlertEventsParameter.HomepageAlertEventsAlertUrl
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
		internal bool InsertHomepageAlertEvents( InsertHomepageAlertEvents InsertHomepageAlertEventsParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[HomepageAlertEvents] ([Title],[StartDate],[ID],[AlertUrl])
								VALUES (@Parameter1,@Parameter2,@Parameter3,@Parameter4)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertHomepageAlertEventsParameter.HomepageAlertEventsNo,
				InsertHomepageAlertEventsParameter.HomepageAlertEventsTitle,
				InsertHomepageAlertEventsParameter.HomepageAlertEventsStartDate,
				InsertHomepageAlertEventsParameter.HomepageAlertEventsID,
				InsertHomepageAlertEventsParameter.HomepageAlertEventsAlertUrl
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteHomepageAlertEvents( DeleteHomepageAlertEvents DeleteHomepageAlertEventsParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[HomepageAlertEvents]
								where [ID] LIKE @Parameter3";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteHomepageAlertEventsParameter.HomepageAlertEventsNo,
				DeleteHomepageAlertEventsParameter.HomepageAlertEventsTitle,
				DeleteHomepageAlertEventsParameter.HomepageAlertEventsStartDate,
				DeleteHomepageAlertEventsParameter.HomepageAlertEventsID,
				DeleteHomepageAlertEventsParameter.HomepageAlertEventsAlertUrl
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateHomepageAlertEvents( UpdateHomepageAlertEvents UpdateHomepageAlertEventsParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[HomepageAlertEvents]
							set [Title]=@Parameter1,[StartDate]=@Parameter2,[ID]=@Parameter3,[AlertUrl]=@Parameter4
							where [ID]=@Parameter3";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateHomepageAlertEventsParameter.HomepageAlertEventsNo,
				UpdateHomepageAlertEventsParameter.HomepageAlertEventsTitle,
				UpdateHomepageAlertEventsParameter.HomepageAlertEventsStartDate,
				UpdateHomepageAlertEventsParameter.HomepageAlertEventsID,
				UpdateHomepageAlertEventsParameter.HomepageAlertEventsAlertUrl
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal DataTable GetHomepageFinishEvents( GetHomepageFinishEvents GetHomepageFinishEventsParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[HomepageFinishEvents]
						ORDER BY [ID]";

			List<object> SQLParameterList = new List<object>()
			{
				GetHomepageFinishEventsParameter.HomepageFinishEventsID,
				GetHomepageFinishEventsParameter.HomepageFinishEventsTitle,
				GetHomepageFinishEventsParameter.HomepageFinishEventsAlertDate,
				GetHomepageFinishEventsParameter.HomepageFinishEventsFinishDate,
				GetHomepageFinishEventsParameter.HomepageFinishEventsEmpID
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
		internal bool InsertHomepageFinishEvents( InsertHomepageFinishEvents InsertHomepageFinishEventsParameter )
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[HomepageFinishEvents] ([ID],[Title],[AlertDate],[FinishDate],[EmpID])
								VALUES (@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertHomepageFinishEventsParameter.HomepageFinishEventsID,
				InsertHomepageFinishEventsParameter.HomepageFinishEventsTitle,
				InsertHomepageFinishEventsParameter.HomepageFinishEventsAlertDate,
				InsertHomepageFinishEventsParameter.HomepageFinishEventsFinishDate,
				InsertHomepageFinishEventsParameter.HomepageFinishEventsEmpID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool DeleteHomepageFinishEvents( DeleteHomepageFinishEvents DeleteHomepageFinishEventsParameter )
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[HomepageFinishEvents]
								where [ID] LIKE @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteHomepageFinishEventsParameter.HomepageFinishEventsID,
				DeleteHomepageFinishEventsParameter.HomepageFinishEventsTitle,
				DeleteHomepageFinishEventsParameter.HomepageFinishEventsAlertDate,
				DeleteHomepageFinishEventsParameter.HomepageFinishEventsFinishDate,
				DeleteHomepageFinishEventsParameter.HomepageFinishEventsEmpID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
		internal bool UpdateHomepageFinishEvents( UpdateHomepageFinishEvents UpdateHomepageFinishEventsParameter )
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[HomepageFinishEvents]
							set [ID]=@Parameter0,[Title]=@Parameter1,[AlertDate]=@Parameter2,[FinishDate]=@Parameter3,[EmpID]=@Parameter4
							where [ID]=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateHomepageFinishEventsParameter.HomepageFinishEventsID,
				UpdateHomepageFinishEventsParameter.HomepageFinishEventsTitle,
				UpdateHomepageFinishEventsParameter.HomepageFinishEventsAlertDate,
				UpdateHomepageFinishEventsParameter.HomepageFinishEventsFinishDate,
				UpdateHomepageFinishEventsParameter.HomepageFinishEventsEmpID
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}
	}
	#endregion Internal Methods
}
