using SyntecITWebAPI.Abstract;
using System;
using System.Collections.Generic;
using System.Data;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	public class TokenDBManager : AbstractDBManager
	{
		#region Public Methods

		public string GetRightsByRoles( string roles )
		{
			DataTable rightsResult = m_dbproxy.GetDataCMD( m_dbSQL.GET_RIGHTS_BY_ROLES, new object[] { roles } );

			if( rightsResult == null || rightsResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				string rights = rightsResult.Rows[ 0 ][ "Rights" ].ToString();
				return rights;
			}
		}

		public string GetRolesByID( string userID )
		{
			DataTable rolesResult = m_dbproxy.GetDataCMD( m_dbSQL.GET_ROLES_BY_ID, new object[] { userID } );

			if( rolesResult == null || rolesResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				string role = rolesResult.Rows[ 0 ][ "Roles" ].ToString();
				return role;
			}
		}

		public bool UpdateRefreshTokenUsageTimes( string userID, string userIP, string refreshToken )
		{
			string sql = m_dbSQL.UPDATE_REFRESHTOKEN_USAGE_TIMES;
			List<object> parameterList = new List<object>();

			parameterList.Add( DateTimeOffset.UtcNow.ToUnixTimeSeconds() ); //modiDate
			parameterList.Add( userID );
			parameterList.Add( userIP );
			parameterList.Add( refreshToken );

			return m_dbproxy.ChangeDataCMD( sql, parameterList.ToArray() );
		}

		#endregion Public Methods
	}
}
