using System.Data;

namespace SyntecITWebAPI.Interface
{
	public interface IDBAccess
	{
		#region Public Methods

		bool ChangeDataCMD( string sql, object[] sqlParameterArray );

		DataTable GetDataCMD( string sql, object[] sqlParameterArray );
		DataTable GetDataWithNoParaCMD( string sql );

	
		#endregion Public Methods
	}
}
