using SyntecITWebAPI.Common.DBRelated;
using SyntecITWebAPI.Interface;
using SyntecITWebAPI.Static;

namespace SyntecITWebAPI.Abstract
{
	public abstract class AbstractExternalDBManager
	{
		#region Protected Fields

		private protected IDBAccess m_dbproxy = ExternalMSDBProxy.GetInstance();

		private protected DBSQL m_dbSQL = DBSQL.GetInstance();

		#endregion Protected Fields
	}
}
