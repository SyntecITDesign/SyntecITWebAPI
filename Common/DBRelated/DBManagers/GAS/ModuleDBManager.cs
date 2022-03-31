using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.Module;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{


	internal class ModuleDBManager : AbstractDBManager
	{
		#region Internal Methods
		public string m_bpm;
		public string m_gas;
		public ModuleDBManager()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_bpm = configuration[ "bpm" ].Trim();
			m_gas = configuration[ "gas" ].Trim();
		}


		internal bool InsertFeatures(InsertFeatures InsertFeaturesParameter)
		{
			string sql = $@"INSERT INTO [{m_gas}].[dbo].[Table1] ([Table1Field1], [Table1Field2], [Table1Field3], [Table1Field4])
								VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertFeaturesParameter.Table1Field1,
				InsertFeaturesParameter.Table1Field2,
				InsertFeaturesParameter.Table1Field3,
				InsertFeaturesParameter.Table1Field4

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool DeleteFeatures(DeleteFeatures DeleteFeaturesParameter)
		{
			string sql = $@"DELETE [{m_gas}].[dbo].[Table1]
								where Table1Field1=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteFeaturesParameter.Table1Field1,
				DeleteFeaturesParameter.Table1Field2,
				DeleteFeaturesParameter.Table1Field3,
				DeleteFeaturesParameter.Table1Field4

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpdateFeatures(UpdateFeatures UpdateFeaturesParameter)
		{
			string sql = $@"UPDATE [{m_gas}].[dbo].[Table1]
							set [Table1Field3]=@Parameter3
							where Table1Field1=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateFeaturesParameter.Table1Field1,
				UpdateFeaturesParameter.Table1Field2,
				UpdateFeaturesParameter.Table1Field3,
				UpdateFeaturesParameter.Table1Field4

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal DataTable GetFeatures1(GetFeatures1 GetFeatures1Parameter)
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[Table1]
						WHERE [Table1Field1] = @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				GetFeatures1Parameter.Table1Field1,
				GetFeatures1Parameter.Table1Field2,
				GetFeatures1Parameter.Table1Field3,
				GetFeatures1Parameter.Table1Field4
			};
			DataTable result = m_dbproxy.GetDataCMD(sql, SQLParameterList.ToArray());
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if (result == null || result.Rows.Count <= 0)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal DataTable GetFeatures2(GetFeatures2 GetFeatures2Parameter)
		{
			string sql = $@"SELECT *
						FROM [{m_gas}].[dbo].[Table2]
						WHERE [Table2Field1] = @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				GetFeatures2Parameter.Table2Field1,
				GetFeatures2Parameter.Table2Field2,
				GetFeatures2Parameter.Table2Field3,
				GetFeatures2Parameter.Table2Field4
			};
			DataTable result = m_dbproxy.GetDataCMD(sql, SQLParameterList.ToArray());
			//bool bresult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			//return bresult;

			if (result == null || result.Rows.Count <= 0)
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
