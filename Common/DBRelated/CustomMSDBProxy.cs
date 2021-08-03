using Microsoft.Extensions.Configuration;
using SyntecITWebAPI.Interface;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SyntecITWebAPI.Common.DBRelated
{
	public class CustomMSDBProxy : IDBAccess
	{
		#region Public Methods

		public static IDBAccess GetInstance()
		{
			if( Instance == null )
			{
				lock( LockObject )
				{ //確保單一
					if( Instance == null )
					{
						Instance = new CustomMSDBProxy();
					}
				}
			}
			return Instance;
		}

		public bool ChangeDataCMD( string sql, object[] sqlParameterArray )
		{
			SqlConnection sqlConn = null;
			try
			{
				using( sqlConn = new SqlConnection( m_connectionString ) )
				{
					SqlCommand sqlCmd = new SqlCommand( sql, sqlConn );
					string parameter = "";
					for( int counter = 0; counter < sqlParameterArray.Length; counter++ )
					{
						parameter = "@Parameter" + counter.ToString();
						// ?為允許Parameter為空
						sqlCmd.Parameters.AddWithValue( parameter, sqlParameterArray[ counter ] ?? DBNull.Value.ToString() );
					}

					sqlConn.Open();
					if( sqlCmd.ExecuteNonQuery() != 0 )
					{
						sqlConn.Close();
						return true;
					}
				}
				sqlConn.Close();
				return false;
			}
			catch( Exception ex )
			{
				return false;
			}
		}

		public DataTable GetDataCMD( string sql, object[] sqlParameterArray )
		{
			DataSet theDataSet = new DataSet();
			try
			{
				using( SqlDataAdapter adapter = new SqlDataAdapter( sql, m_connectionString ) )
				{
					string parameter = "";
					for( int counter = 0; counter < sqlParameterArray.Length; counter++ )
					{
						parameter = "@Parameter" + counter.ToString();
						adapter.SelectCommand.Parameters.AddWithValue( parameter, sqlParameterArray[ counter ] ?? DBNull.Value.ToString() );
					}
					adapter.SelectCommand.CommandTimeout = int.MaxValue;
					adapter.Fill( theDataSet );
				}
				return theDataSet.Tables[ 0 ];
			}
			catch( Exception ex )
			{
				return null;
			}
		}

		public DataTable GetDataWithNoParaCMD( string sql )
		{
			throw new NotImplementedException();
		}

		#endregion Public Methods

		#region Private Fields

		private static readonly object LockObject = new object();

		private static IDBAccess Instance = null;

		private string m_connectionString;

		#endregion Private Fields

		#region Private Constructors + Destructors

		private CustomMSDBProxy()
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath( $"{Directory.GetCurrentDirectory()}\\Config\\" )
			.AddJsonFile( path: "CustomMSDBSetting.json", optional: false )
			.Build();

			string dataSource = configuration[ "dataSource" ].Trim();
			string initialCatalog = configuration[ "initialCatalog" ].Trim();
			string userID = configuration[ "userID" ].Trim();
			string userPassword = configuration[ "userPassword" ].Trim();

			//get connection string from config
			m_connectionString =
			$"Data Source={dataSource};" +
			$"Initial Catalog={initialCatalog};" +
			$"User id={userID};" +
			$"Password={userPassword};";
		}

		#endregion Private Constructors + Destructors
	}
}
