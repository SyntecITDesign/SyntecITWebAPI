using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.ApplyUniform;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{
	internal class ApplyUniformDBManager : AbstractDBManager
	{
		#region Internal Methods

		internal bool InsertUniformStyle(InsertUniformStyle InsertUniformStyleParameter)
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[UniformInfo] ([Style], [Price])
								VALUES (@Parameter1, @Parameter2)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertUniformStyleParameter.UniformInfoNo,
				InsertUniformStyleParameter.UniformInfoStyle,
				InsertUniformStyleParameter.UniformInfoPrice,
				InsertUniformStyleParameter.UniformInfoAvailableQuantity
			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool DeleteUniformInfo(DeleteUniformInfo DeleteUniformInfoParameter)
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[UniformInfo]
								where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeleteUniformInfoParameter.UniformInfoNo,
				DeleteUniformInfoParameter.UniformInfoStyle,
				DeleteUniformInfoParameter.UniformInfoPrice,
				DeleteUniformInfoParameter.UniformInfoAvailableQuantity

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpdateUniformInfo(UpdateUniformInfo UpdateUniformInfoParameter)
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[UniformInfo]
							set [Style]=@Parameter1, [Price]=@Parameter2, [AvailableQuantity]=@Parameter3
							where No=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdateUniformInfoParameter.UniformInfoNo,
				UpdateUniformInfoParameter.UniformInfoStyle,
				UpdateUniformInfoParameter.UniformInfoPrice,
				UpdateUniformInfoParameter.UniformInfoAvailableQuantity

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal DataTable GetUniformInfo(GetUniformInfo GetUniformInfoParameter)
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[UniformInfo]
						ORDER BY [No]";
			List<object> SQLParameterList = new List<object>()
			{
				GetUniformInfoParameter.UniformInfoNo,
				GetUniformInfoParameter.UniformInfoStyle,
				GetUniformInfoParameter.UniformInfoPrice,
				GetUniformInfoParameter.UniformInfoAvailableQuantity
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
