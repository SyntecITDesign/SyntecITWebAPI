using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.Utility;
using System.Collections.Generic;
using System.Linq;
using TQMLibrary;

namespace SyntecITWebAPI.Models
{
	public class TokenHandler
	{
		#region Public Methods

		//登入Create兩個Token
		public JObject CreateAllToken( string userID, string userIP, string weChatID = null, JObject identityList = null )
		{
			string userRights = GetUserRightsByID( userID );
			string accessToken = m_tokenProxy.CreateNewAccessToken( userID, userIP, userRights, weChatID, identityList );
			string refreshToken = m_tokenProxy.CreateNewRefreshToken( userID, userIP, weChatID, identityList );

			if( string.IsNullOrEmpty( accessToken ) || string.IsNullOrEmpty( refreshToken ) )
			{
				return null;
			}

			JObject allTokenObject = new JObject();
			allTokenObject[ nameof( accessToken ) ] = accessToken;
			allTokenObject[ nameof( refreshToken ) ] = refreshToken;

			return allTokenObject;
		}

		// Refresh 取 acceessToken if success return (true,<accessToken>) else return (false, ErrorCode.ToString)
		public (bool success, string result) GetNewAccessToken( string userID, string userIP, string refreshToken )
		{
			ErrorCodeList checkRefresh = m_tokenProxy.IsRefreshTokenValid( refreshToken, userID, userIP );

			if( checkRefresh.Equals( ErrorCodeList.Success ) )
			{
				bool updateRefreshUsageResult = m_dBManager.UpdateRefreshTokenUsageTimes( userID, userIP, refreshToken ); //更新這個Token的使用次數

				if( updateRefreshUsageResult == false ) // 若不成功回傳Update Error
				{
					return (success: false, result: ErrorCodeList.Update_Error.ToString());
				}

				// 取refreshToken之weChatID,orgCode,characterCode及參數轉換
				JObject refreshTokenData = refreshToken.GetTokenData();

				List<string> weChatIDList = refreshTokenData.GetValue( "WeChatID" ).ToObject<List<string>>();
				string weChatID = null;
				if( weChatIDList != null )
					weChatID = string.Join( ",", weChatIDList );

				JObject identityList = new JObject
				{
					{ "orgCode", refreshTokenData.GetValue("orgCode").ToString()},
					{ "characterCode" , refreshTokenData.GetValue("characterCode").ToString() }
				};

				// 更新成功，取新Access Token
				string userRights = GetUserRightsByID( userID );
				string newAceessToken = m_tokenProxy.CreateNewAccessToken( userID, userIP, userRights, weChatID, identityList );
				return (success: true, result: newAceessToken);
			}
			else
			{
				// verify 失敗 return error code
				return (success: false, result: checkRefresh.ToString());
			}
		}

		#endregion Public Methods

		#region Private Fields

		private TokenDBManager m_dBManager = new TokenDBManager();

		private TokenProxy m_tokenProxy = new TokenProxy();

		private UserInfo m_userInfo = new UserInfo();

		#endregion Private Fields

		#region Private Methods

		private string GetOptionUserRightsByID( string userID )
		{
			//Get User role code by userID (new Token)
			string userRole = m_dBManager.GetRolesByID( userID );

			if( userRole == null )
			{
				return null;
			}

			return RolesToRight( userRole );
		}

		private string GetSyntecEmpOptionRightsByID( string userID )
		{
			string userRole = m_userInfo.GetUserRole( userID, (int)Syntec.Meta.ICTPlatform.Option );
			if( userRole == null )
			{
				return null;
			}

			return RolesToRight( userRole );
		}

		private string GetUserRightsByID( string userID )
		{
			string rightsResult = null;

			string getRightsForSyntecEmp = GetSyntecEmpOptionRightsByID( userID );
			if( !string.IsNullOrEmpty( getRightsForSyntecEmp ) )
			{
				rightsResult = getRightsForSyntecEmp;
			}
			else
			{
				string getRightsForOptionUser = GetOptionUserRightsByID( userID );
				if( !string.IsNullOrEmpty( getRightsForOptionUser ) )
					rightsResult = getRightsForOptionUser;
			}

			return rightsResult;
		}

		private string RolesToRight( string userRole )
		{
			string userRights = null;
			if( userRole != null && userRole.Length > 1 )
			{
				//子帳號處理
				if( userRole.Length >= 4 )
				{
					string firstTwowords = userRole.Substring( 0, 4 );
					if( firstTwowords == "N,O," )
					{
						return "N,O,";
					}
				}

				//母帳號處理
				List<string> filterUserRole = new List<string>();
				filterUserRole = userRole.Split( ',' ).ToList();

				if( filterUserRole.Count > 0 )
				{
					HashSet<string> totalRightsSet = new HashSet<string>();
					foreach( string role in filterUserRole )
					{
						if( role.Length > 0 ) // split like {7,17,} will be {'7','17',''} so check length avoid null
						{
							string tempRights = m_dBManager.GetRightsByRoles( role );

							if( tempRights == null )
								return null;

							foreach( string rightCode in tempRights.Split( ',' ).ToList() )
							{
								if( !string.IsNullOrEmpty( rightCode ) )
								{
									totalRightsSet.Add( rightCode );
								}
							}
						}
					}
					totalRightsSet.ToList().ForEach( x => userRights += ( x + "," ) );
				}
			}
			return userRights;
		}

		#endregion Private Methods
	}
}
