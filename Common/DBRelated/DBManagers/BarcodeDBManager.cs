using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	public class BarcodeDBManager : AbstractExternalDBManager
	{
		#region Public Methods

		public bool CheckCncTypeMachineModelExist( string cncType, string machineModel )
		{
			string sql = m_dbSQL.CHECK_CNCTYPE_MACHINEMODEL_EXIST;

			List<object> parameterList = new List<object>();

			parameterList.Add( cncType );
			parameterList.Add( machineModel );

			DataTable checkResult = m_dbproxy.GetDataCMD( sql, parameterList.ToArray() );

			if( checkResult == null || checkResult.Rows.Count <= 0 )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool CheckSyntecEmpIDExist( string empID )
		{
			string sql = m_dbSQL.CHECK_SYNTEC_USER_EXIST;

			List<object> parameterList = new List<object>();

			parameterList.Add( empID );

			DataTable checkResult = m_dbproxy.GetDataCMD( sql, parameterList.ToArray() );

			if( checkResult == null || checkResult.Rows.Count <= 0 )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public (List<string>, List<string>) GetManagersNameEmail()
		{
			string sql = m_dbSQL.GET_MANAGE_NAME_EMAIL;
			DataTable result = m_dbproxy.GetDataCMD( sql, new object[] { } );
			if( result == null || result.Rows.Count <= 0 )
			{
				return (null, null);
			}
			else
			{
				List<string> manageNameList = result.AsEnumerable().Select( x => x[ 0 ].ToString() ).ToList();
				List<string> manageEmailList = result.AsEnumerable().Select( x => x[ 1 ].ToString() ).ToList();

				return (manageNameList, manageEmailList);
			}
		}

		public string GetOrgTypeByOrgID( string orgID )
		{
			string sql = m_dbSQL.GET_ORGTYPE_BY_ORGID;

			DataTable result = m_dbproxy.GetDataCMD( sql, new object[] { orgID } );

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result.Rows[ 0 ][ "Type" ].ToString();
			}
		}

		public string GetSyntecEmpNameByID( string userID )
		{
			string sql = m_dbSQL.GET_USERNAME_BY_ID_TEMPNAME;

			DataTable result = m_dbproxy.GetDataCMD( sql, new object[] { userID } );
			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result.Rows[ 0 ][ 0 ].ToString();
			}
		}

		public bool IsSyntecEmpExist( string userID, string userEmail )
		{
			string sql = m_dbSQL.CHECK_SYNTEC_USER_EMAIL_EXIST;

			List<object> parameterList = new List<object>();

			parameterList.Add( userID );
			parameterList.Add( userEmail );

			DataTable checkResult = m_dbproxy.GetDataCMD( sql, parameterList.ToArray() );

			if( checkResult == null || checkResult.Rows.Count <= 0 )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion Public Methods
	}
}
