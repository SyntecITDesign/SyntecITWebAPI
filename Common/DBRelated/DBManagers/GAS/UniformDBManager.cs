using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.Uniform;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicUniformDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public PublicUniformDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}


		internal DataTable GetUniformSize( GetUniformSize GetUniformSizeParameter )
		{
			string sql = $@"SELECT *
						  FROM [{m_gas}].[dbo].[GAS_UniformMaster]
						  WHERE [EmpID]=@Parameter0 ";

			List<object> SQLParameterList = new List<object>()
			{
				GetUniformSizeParameter.EmpID
				
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

		internal bool UpsertUniformSize( UpsertUniformSize UpsertUniformSizeParameter )
		{
			string sql = $@"IF EXISTS (SELECT * FROM [{m_gas}].[dbo].[GAS_UniformMaster] WHERE [EmpID]=@Parameter0 )
												UPDATE [{m_gas}].[dbo].[GAS_UniformMaster] 
												SET [UniformSSSize]=@Parameter1, [UniformSSDate]=@Parameter2, [UniformFWSize]=@Parameter3,[UniformFWDate]=@Parameter4,
													[JacketSize]=@Parameter5, [JacketDate]=@Parameter6, [SweatShirtSize]=@Parameter7, [SweatShirtDate]=@Parameter8,[EmpDept]= (SELECT EmpDept From [{m_gas}].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0), [EmpName]= (SELECT EmpName From [{m_gas}].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0)
												WHERE [EmpID]=@Parameter0 
							ELSE
							INSERT INTO [{m_gas}].[dbo].[GAS_UniformMaster] ([EmpID],[EmpDept],[EmpName],[UniformSSSize],[UniformSSDate],[UniformFWSize],[UniformFWDate],[JacketSize],[JacketDate],[SweatShirtSize],[SweatShirtDate]) 
							VALUES (@Parameter0, (SELECT EmpDept From [{m_gas}].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0), (SELECT EmpName From [{m_gas}].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0),@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8)";
			
			List<object> SQLParameterList = new List<object>()
			{
				UpsertUniformSizeParameter.EmpID,
				UpsertUniformSizeParameter.UniformSSSize,
				UpsertUniformSizeParameter.UniformSSDate,
				UpsertUniformSizeParameter.UniformFWSize,
				UpsertUniformSizeParameter.UniformFWDate,
				UpsertUniformSizeParameter.JacketSize,
				UpsertUniformSizeParameter.JacketDate,
				UpsertUniformSizeParameter.SweatShirtSize,
				UpsertUniformSizeParameter.SweatShirtDate

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}


	}
	#endregion Internal Methods
}

