﻿using SyntecITWebAPI.Common.DBRelated;
using SyntecITWebAPI.Interface;
using SyntecITWebAPI.Static;

namespace SyntecITWebAPI.Abstract
{
	public abstract class AbstractDBManager
	{
		#region Protected Fields

		private protected IDBAccess m_dbproxy = CustomMSDBProxy.GetInstance();

		private protected DBSQL m_dbSQL = DBSQL.GetInstance();

		#endregion Protected Fields
	}
}
