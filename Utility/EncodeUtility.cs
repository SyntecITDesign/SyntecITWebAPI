using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;

namespace SyntecITWebAPI.Utility
{
	public static class EncodeUtility
	{
		#region Public Methods

		public static string ITKeyEncode( this String userID )
		{
			var keyConfig = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "WebServiceKey.json", optional: false )
			.Build();

			string key = keyConfig[ "ITKey" ].ToString();
			return Syntec.Crypto.DES.EncryptString( userID, key, Encoding.UTF8 );
		}

		#endregion Public Methods
	}
}
