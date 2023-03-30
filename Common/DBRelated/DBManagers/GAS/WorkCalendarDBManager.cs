using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.WorkCalendar;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicWorkCalendarDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public PublicWorkCalendarDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}

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

