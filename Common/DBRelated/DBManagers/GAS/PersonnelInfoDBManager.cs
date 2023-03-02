using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.GAS.PersonnelInfo;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers.GAS
{

	internal class PersonnelInfoDBManager : AbstractDBManager
	{
		#region Internal Methods

		internal bool InsertPersonData(InsertPersonData InsertPersonDataParameter)
		{
			string sql = $@"INSERT INTO [SyntecGAS].[dbo].[PersonnelInfo] ([EmpID], [EmpName], [DeptName], [DeptNo])
								VALUES (@Parameter0, @Parameter1, @Parameter2, @Parameter3)";
			List<object> SQLParameterList = new List<object>()
			{
				InsertPersonDataParameter.EmpID,
				InsertPersonDataParameter.EmpName,
				InsertPersonDataParameter.DeptName,
				InsertPersonDataParameter.DeptNo

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		internal bool DeletePersonData(DeletePersonData DeletePersonDataParameter)
		{
			string sql = $@"DELETE [SyntecGAS].[dbo].[PersonnelInfo]
								where EmpID=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				DeletePersonDataParameter.EmpID,
				DeletePersonDataParameter.EmpName,
				DeletePersonDataParameter.DeptName,
				DeletePersonDataParameter.DeptNo

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool UpdatePersonDept(UpdatePersonDept UpdatePersonDeptParameter)
		{
			string sql = $@"UPDATE [SyntecGAS].[dbo].[PersonnelInfo]
							set [DeptNo]=@Parameter3
							where EmpID=@Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				UpdatePersonDeptParameter.EmpID,
				UpdatePersonDeptParameter.EmpName,
				UpdatePersonDeptParameter.DeptName,
				UpdatePersonDeptParameter.DeptNo

			};
			bool bResult = m_dbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal DataTable GetPersonDept(GetPersonDept GetPersonDeptParameter)
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[PersonnelInfo]
						WHERE [EmpID] = @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				GetPersonDeptParameter.EmpID,
				GetPersonDeptParameter.EmpName,
				GetPersonDeptParameter.DeptName,
				GetPersonDeptParameter.DeptNo
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

		internal DataTable GetQuantity(GetQuantity GetQuantityParameter)
		{
			string sql = $@"SELECT *
						FROM [SyntecGAS].[dbo].[API_TEST]
						WHERE [ProductName] = @Parameter0";
			List<object> SQLParameterList = new List<object>()
			{
				GetQuantityParameter.ProductName,
				GetQuantityParameter.Specification,
				GetQuantityParameter.Unit,
				GetQuantityParameter.Quantity
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
