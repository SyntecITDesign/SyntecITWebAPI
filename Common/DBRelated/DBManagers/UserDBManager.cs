using Syntec.CRM;
using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	public class UserDBManager : AbstractDBManager
	{
		#region Public Methods

		public string GetOptionMachineCode( string userID )
		{
			string sql = m_dbSQL.GET_USER_BY_ID;

			DataTable userResult = m_dbproxy.GetDataCMD( sql, new object[] { userID } );

			if( userResult == null || userResult.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return userResult.Rows[ 0 ][ "OptionMachineCode" ].ToString();
			}
		}

		public string GetOptionUserNameByID( string userID )
		{
			string sql = m_dbSQL.GET_USERNAME_BY_ID_OPTION;

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

		public string GetStatusByID( string userID )
		{
			string sql = m_dbSQL.GET_STATUS_BY_ID;

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

		public string GetWeChatByID( string userID )
		{
			string sql = m_dbSQL.GET_USER_BY_ID;

			DataTable result = m_dbproxy.GetDataCMD( sql, new object[] { userID } );
			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result.Rows[ 0 ][ "WeChat" ].ToString();
			}
		}

		public bool InsertUserAllData( RegisterParameter registerParameter )
		{
			string sql = m_dbSQL.INSERT_USER_ALL_DATA;
			List<object> parameterList = new List<object>();

			parameterList.AddRange( new List<object>
			{
				registerParameter.userID,
				registerParameter.userName,
				registerParameter.userPassword,
				registerParameter.machineCode,
				registerParameter.companyName,
				registerParameter.companyAddress,
				registerParameter.userEmail,
				registerParameter.userPhone,
				registerParameter.userSkype,
				registerParameter.userLine,
				registerParameter.userQQ,
				registerParameter.userWeChat,
				registerParameter.orgType,
				registerParameter.verifyCode,
				registerParameter.pwchanged,
				registerParameter.isMother,
				registerParameter.inUse,
				registerParameter.status,
				registerParameter.isNotifyMother,
				registerParameter.CreateDate
			} );

			return m_dbproxy.ChangeDataCMD( sql, parameterList.ToArray() );
		}

		public bool IsEmailExist( string userEmail )
		{
			string sql = m_dbSQL.CHECK_EMAIL_EXIST;
			DataTable checkResult = m_dbproxy.GetDataCMD( sql, new object[] { userEmail } );
			if( checkResult == null || checkResult.Rows.Count <= 0 )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool IsMachineCodeExist( string machineCode )
		{
			string sql = m_dbSQL.CHECK_MACHINECODE_EXIST;
			DataTable checkResult = m_dbproxy.GetDataCMD( sql, new object[] { machineCode } );
			if( checkResult == null || checkResult.Rows.Count <= 0 )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool IsOptionUserExist( string userID )
		{
			string sql = m_dbSQL.GET_USER_BY_ID;

			DataTable userResult = m_dbproxy.GetDataCMD( sql, new object[] { userID } );

			if( userResult == null || userResult.Rows.Count <= 0 )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool IsOptionUserMother( string userID )
		{
			string sql = m_dbSQL.GET_USER_BY_ID;

			DataTable userResult = m_dbproxy.GetDataCMD( sql, new object[] { userID } );

			if( userResult.Rows[ 0 ][ "isMother" ].ToString().Equals( "1" ) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool IsUserEmailExist( string userID, string userEmail )
		{
			string sql = m_dbSQL.CHECK_USER_EMAIL_EXIST_BY_ID;
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

		public bool IsUserVerifyCodeExist( string userID, string verifyCode )
		{
			string sql = m_dbSQL.CHECK_USER_VERIFYCODE_EXIST;
			List<object> parameterList = new List<object>();

			parameterList.Add( userID );
			parameterList.Add( verifyCode );

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

		public bool UpdateOptionUserPassword( string userNewPassword, string userID )
		{
			string sql = m_dbSQL.UPDATE_USERPASSWORD_BY_ID;
			List<object> parameterList = new List<object>();

			parameterList.Add( userNewPassword );
			parameterList.Add( userID );

			return m_dbproxy.ChangeDataCMD( sql, parameterList.ToArray() );
		}

		public bool UpdateUserPWChanged( string userID, int pwChanged )
		{
			string sql = m_dbSQL.UPDATE_USER_PWCHANGED;
			List<object> parameterList = new List<object>();

			parameterList.Add( pwChanged );
			parameterList.Add( userID );

			return m_dbproxy.ChangeDataCMD( sql, parameterList.ToArray() );
		}

		public bool UpdateUserStatus( string userID, string status )
		{
			string sql = m_dbSQL.UPDATE_USER_STATUS;

			List<object> parameterList = new List<object>();
			parameterList.Add( status );
			parameterList.Add( userID );

			return m_dbproxy.ChangeDataCMD( sql, parameterList.ToArray() );
		}

		public bool UpdateUserVerifyCode( string userID, string verifyCode )
		{
			string sql = m_dbSQL.UPDATE_USER_VERIFYCODE;

			List<object> parameterList = new List<object>();
			parameterList.Add( verifyCode );
			parameterList.Add( userID );

			return m_dbproxy.ChangeDataCMD( sql, parameterList.ToArray() );
		}

		#endregion Public Methods
	}
}
