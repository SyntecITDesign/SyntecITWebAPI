using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.LogTable;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicLogTableDBManager : AbstractDBManager
	{
		#region Internal Methods
		
		internal bool InsertLogTable( InsertLogTable InsertLogTableParameter )
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[LogTable]
								([EmpID],[ExecuteTime],[Module],[ModuleParameter],[Action],[Memo])
							VALUES
								(@Parameter0,@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5)";

			List<object> SQLParameterList = new List<object>()
			{
				InsertLogTableParameter.EmpID,
				InsertLogTableParameter.ExecuteTime,
				InsertLogTableParameter.Module,
				InsertLogTableParameter.ModuleParameter,
				InsertLogTableParameter.Action,
				InsertLogTableParameter.Memo
			

			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}


	}
	#endregion Internal Methods
}

