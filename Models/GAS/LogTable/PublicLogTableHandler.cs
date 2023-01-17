using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.GAS.LogTable;
using System.Data;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Models.GAS.LogTable
{
	internal class PublicLogTableHandler
	{
		#region Internal Methods

		internal bool InsertLogTable( InsertLogTable InsertLogTableParameter )
		{

			bool bResult = m_publicLogTableDBManager.InsertLogTable( InsertLogTableParameter );

			return bResult;
		}

		#endregion Internal Methods

		#region Private Fields

		private PublicLogTableDBManager m_publicLogTableDBManager = new PublicLogTableDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
