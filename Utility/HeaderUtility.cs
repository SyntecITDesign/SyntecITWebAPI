using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common;
using System;

namespace SyntecITWebAPI.Utility
{
	public static class HeaderUtility
	{
		#region Public Methods

		public static JObject GetTokenData( this String token )
		{
			if( string.IsNullOrEmpty( token ) )
				return null;
			else
			{
				return m_tokenProxy.GetTokenData( token );
			}
		}

		public static JObject GetTokenDataFromCookie( this HttpRequest request )
		{
			string accessToken;
			request.Cookies.TryGetValue( nameof( accessToken ), out accessToken );

			if( string.IsNullOrEmpty( accessToken ) )
				return null;
			else
			{
				return m_tokenProxy.GetTokenData( accessToken );
			}
		}

		public static string GetTokenFromBearerHeader( this String header )
		{
			try
			{
				string[] headerAfterSplit = header.Split();
				if( headerAfterSplit.Length != 2 || headerAfterSplit[ 0 ] != "Bearer" )
				{
					return null;
				}
				return headerAfterSplit[ 1 ];
			}
			catch( NullReferenceException )
			{
				return null;
			}
		}

		#endregion Public Methods

		#region Private Fields

		private static TokenProxy m_tokenProxy = new TokenProxy();

		#endregion Private Fields
	}
}
