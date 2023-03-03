using SyntecITWebAPI.Abstract;
using System;
using System.Collections.Generic;
using System.Data;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	public class FrDBManager : AbstractDBManager
	{
		#region Internal Methods

		internal string GetFRTokenByID( string userID )
		{
			string sql = m_dbSQL.GET_FR_TOKEN_BY_ID;
			DataTable result = m_dbproxy.GetDataCMD( sql, new object[] { userID } );

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result.Rows[ 0 ][ "fr_token" ].ToString();
			}
		}

		internal bool InsertFRToken( string userID, string userIP, string token, long expireDate )
		{
			string sql = m_dbSQL.INSERT_FR_TOKEN;
			List<object> parameterList = new List<object>
			{
				userID, //customer_id
				userIP, //customer_ip
				token, //fr_token
				DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), // cons_date
				expireDate, //expire_date
				DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() // modi_date
			};

			return m_dbproxy.ChangeDataCMD( sql, parameterList.ToArray() );
		}

		internal bool IsFRTokenExist( string token )
		{
			string sql = m_dbSQL.CHECK_FRTOKEN_EXIST;

			DataTable result = m_dbproxy.GetDataCMD( sql, new object[] { token } );

			if( result == null || result.Rows.Count <= 0 )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion Internal Methods
	}
}
