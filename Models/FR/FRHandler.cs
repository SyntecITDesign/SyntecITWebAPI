using SyntecITWebAPI.Common.DBRelated.DBManagers;
using System;
using System.Linq;

namespace SyntecITWebAPI.Models.FR
{
	public class FRHandler
	{
		#region Internal Methods

		internal string GetFrToken( string userID, string userIP )
		{
			string getTokenFromDBResult = GetFrTokenFromDB( userID );

			//資料表此userID已有token
			if( !string.IsNullOrEmpty( getTokenFromDBResult ) )
				return getTokenFromDBResult;
			else
			{
				//產生token 並檢查DB有無存在此token，若有則重新產生，若超過三次跳error
				string token = null;
				int restartThreshold = 3;
				for( int index = 0; index < restartThreshold; ++index )
				{
					// 生成Token through CSPRNG
					token = GetNewFrToken();

					//DB沒有此 Token => 可以用拉~
					if( !m_dbManager.IsFRTokenExist( token ) )
						break;
					else
						token = null;
				}

				if( string.IsNullOrEmpty( token ) ) // 超過三次都沒找到"DB沒有的token"
					return null;
				else
				{
					//insert to DB
					long expireDate = DateTimeOffset.UtcNow.AddYears( 999 ).ToUnixTimeMilliseconds();
					bool insertResult = m_dbManager.InsertFRToken( userID, userIP, token, expireDate );

					if( insertResult == true )
						return token;
					else
						return null;
				}
			}
		}

		#endregion Internal Methods

		#region Private Fields

		private static Random random = new Random();
		private FrDBManager m_dbManager = new FrDBManager();

		#endregion Private Fields

		#region Private Methods

		private string GetFrTokenFromDB( string userID )
		{
			return m_dbManager.GetFRTokenByID( userID );
		}

		private string GetNewFrToken()
		{
			const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

			string result = new string( Enumerable.Range( 1, 64 ).Select(
				_ => chars[ random.Next( chars.Length ) ] ).ToArray() );

			return result;
		}

		#endregion Private Methods
	}
}
