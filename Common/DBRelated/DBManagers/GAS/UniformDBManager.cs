using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.GAS.Uniform;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicUniformDBManager : AbstractDBManager
	{
		#region Internal Methods


		internal DataTable GetUniformSize( GetUniformSize GetUniformSizeParameter )
		{
			string sql = $@"SELECT *
						  FROM [jirareport].[dbo].[GAS_UniformMaster]
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
			string sql = $@"IF EXISTS (SELECT * FROM [jirareport].[dbo].[GAS_UniformMaster] WHERE [EmpID]=@Parameter0 )
												UPDATE [jirareport].[dbo].[GAS_UniformMaster] 
												SET [UniformSSSize]=@Parameter1, [UniformSSDate]=@Parameter2, [UniformFWSize]=@Parameter3,[UniformFWDate]=@Parameter4,
													[JacketSize]=@Parameter5, [JacketDate]=@Parameter6, [SweatShirtSize]=@Parameter7, [SweatShirtDate]=@Parameter8,[EmpDept]= (SELECT EmpDept From [jirareport].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0), [EmpName]= (SELECT EmpName From [jirareport].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0)
												WHERE [EmpID]=@Parameter0 
							ELSE
							INSERT INTO [jirareport].[dbo].[GAS_UniformMaster] ([EmpID],[EmpDept],[EmpName],[UniformSSSize],[UniformSSDate],[UniformFWSize],[UniformFWDate],[JacketSize],[JacketDate],[SweatShirtSize],[SweatShirtDate]) 
							VALUES (@Parameter0, (SELECT EmpDept From [jirareport].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0), (SELECT EmpName From [jirareport].[dbo].[GAS_GAInfoMaster] WHERE [EmpID]=@Parameter0),@Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5,@Parameter6,@Parameter7,@Parameter8)";
			
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

