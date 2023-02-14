using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	public class DecodeDBManager : AbstractDBManager
	{
		#region Public Methods

		public string GetOptionIsMother( string userID )
		{
			string sql = m_dbSQL.GET_USER_BY_ID;

			DataTable userResult = m_dbproxy.GetDataCMD( sql, new object[] { userID } );

			if( userResult == null || userResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return userResult.Rows[ 0 ][ "isMother" ].ToString();
			}
		}

		public string GetOptionRoles( string userID )
		{
			string sql = m_dbSQL.GET_USER_BY_ID;

			DataTable userResult = m_dbproxy.GetDataCMD( sql, new object[] { userID } );

			if( userResult == null || userResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return userResult.Rows[ 0 ][ "Roles" ].ToString();
			}
		}

		public bool InsertDecodeHistoryRecord( string sn, string verifyCode, string password, string userID, string code, string decryptionType, string remark )
		{
			string sql = m_dbSQL.INSERT_DECODE_HISTORY_RECORD;
			List<object> parameterList = new List<object>();

			parameterList.AddRange( new List<object>
			{
				sn,
				verifyCode,
				password,
				userID,
				code,
				decryptionType,
				remark,
				System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
			} );

			return m_dbproxy.ChangeDataCMD( sql, parameterList.ToArray() );
		}

		#endregion Public Methods
	}
}
