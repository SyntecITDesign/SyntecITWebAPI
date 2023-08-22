using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.ModuleAccess;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicModuleAccessDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public PublicModuleAccessDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}
				
		internal DataTable GetModuleAccess( GetModuleAccess GetModuleAccessParameter )
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[ModuleAccess] ORDER BY [secondGroup] ASC";
			List<object> SQLParameterList = new List<object>()
			{
				GetModuleAccessParameter.ModuleAccessModule,
				GetModuleAccessParameter.ModuleAccessPageName,
				GetModuleAccessParameter.ModuleAccessPageLink,
				GetModuleAccessParameter.ModuleAccessAccessRightDeptNo,
				GetModuleAccessParameter.ModuleAccessAccessRightEmpID,
				GetModuleAccessParameter.ModuleAccessMemo
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

