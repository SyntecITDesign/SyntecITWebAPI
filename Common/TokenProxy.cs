using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Enums;
using System;
using System.IO;
using TokenChecker;
using TokenCreator;

namespace SyntecITWebAPI.Common
{
	internal class TokenProxy
	{
		#region Internal Constructors + Destructors

		internal TokenProxy()
		{
			m_dbConfig = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "CustomMSDBSetting.json", optional: false )
			.Build();

			m_dbTableConfig = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "DBTableNameSetting.json", optional: false )
			.Build();

			m_tokenFactory = new TokenFactory( m_dbConfig, m_dbTableConfig );
		}

		#endregion Internal Constructors + Destructors

		#region Internal Methods

		internal string CreateNewAccessToken( string userID, string userIP, string userRights, string weChatID, JObject identityList )
		{
			return m_tokenFactory.CreateNewAccessToken( userID, userIP, userRights, weChatID, identityList );
		}

		internal string CreateNewRefreshToken( string userID, string userIP, string weChatID, JObject identityList )
		{
			return m_tokenFactory.CreateNewRefreshToken( userID, userIP, weChatID, identityList );
		}

		internal JObject GetTokenData( string token )
		{
			TokenCheckerAgent tokenCheckerAgent = new TokenCheckerAgent( token, m_dbConfig, m_dbTableConfig );
			return tokenCheckerAgent.GetTokenData();
		}

		internal ErrorCodeList IsAccessTokenValid( string token, string userID, string userIP )
		{
			TokenCheckerAgent tokenCheckerAgent = new TokenCheckerAgent( token, m_dbConfig, m_dbTableConfig );
			var result = tokenCheckerAgent.IsAccessTokenValid( userID, userIP );

			ErrorCodeList convertCheckResult = (ErrorCodeList)Enum.Parse( typeof( ErrorCodeList ), result.ToString() );

			return convertCheckResult;
		}

		internal ErrorCodeList IsRefreshTokenValid( string token, string userID, string userIP )
		{
			TokenCheckerAgent tokenCheckerAgent = new TokenCheckerAgent( token, m_dbConfig, m_dbTableConfig );
			var result = tokenCheckerAgent.IsRefreshTokenValid( userID, userIP );

			ErrorCodeList convertCheckResult = (ErrorCodeList)Enum.Parse( typeof( ErrorCodeList ), result.ToString() );

			return convertCheckResult;
		}

		#endregion Internal Methods

		#region Private Fields

		private IConfigurationRoot m_dbConfig;
		private IConfigurationRoot m_dbTableConfig;
		private TokenFactory m_tokenFactory;

		#endregion Private Fields
	}
}
