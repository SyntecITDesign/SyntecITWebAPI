using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.ApplyMail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.ApplyMail
{

	internal class PublicApplyMailHandler
	{
		#region Internal Methods
		internal bool InsertMail( InsertMail InsertMailParameter )
		{

			bool bResult = m_ApplyMailDBManager.InsertMail( InsertMailParameter );

			return bResult;
		}
		//internal JArray GetEmpDormStatusData( GetEmpDormStatusData GetEmpDormStatusDataParameter )
		//{

		//	DataTable dtResult = m_ApplyMailDBManager.GetEmpDormStatusData( GetEmpDormStatusDataParameter );

		//	if(dtResult == null || dtResult.Rows.Count <= 0)
		//		return null;
		//	else
		//	{
		//		JArray ja = JArray.FromObject( dtResult );
		//		return ja;
		//	}
		//}
		//internal bool InsertDormApplicationsMaster( InsertDormApplicationsMaster InsertDormApplicationsMasterParameter )
		//{

		//	bool bResult = m_ApplyMailDBManager.InsertDormApplicationsMaster( InsertDormApplicationsMasterParameter );

		//	return bResult;
		//}

		//internal bool UpdateDormApplicationsMaster( UpdateDormApplicationsMaster UpdateDormApplicationsMasterParameter )
		//{

		//	bool bResult = m_ApplyMailDBManager.UpdateDormApplicationsMaster( UpdateDormApplicationsMasterParameter );

		//	return bResult;
		//}
		//internal JArray GetDormApplicationsMaster_SZ( GetDormApplicationsMaster_SZ GetDormApplicationsMaster_SZ_Parameter )
		//{

		//	DataTable dtResult = m_ApplyMailDBManager.GetDormApplicationsMaster_SZ( GetDormApplicationsMaster_SZ_Parameter );

		//	if(dtResult == null || dtResult.Rows.Count <= 0)
		//		return null;
		//	else
		//	{
		//		JArray ja = JArray.FromObject( dtResult );
		//		return ja;
		//	}
		//}
		//internal JArray GetDormInfo_SZ( GetDormInfo_SZ GetDormInfo_SZParameter )
		//{

		//	DataTable dtResult = m_ApplyMailDBManager.GetDormInfo_SZ( GetDormInfo_SZParameter );

		//	if(dtResult == null || dtResult.Rows.Count <= 0)
		//		return null;
		//	else
		//	{
		//		JArray ja = JArray.FromObject( dtResult );
		//		return ja;
		//	}
		//}

		//internal bool UpsertDormInfo_SZ( UpsertDormInfo_SZ UpsertDormInfo_SZParameter )
		//{

		//	bool bResult = m_ApplyMailDBManager.UpsertDormInfo_SZ( UpsertDormInfo_SZParameter );

		//	return bResult;
		//}

		//internal bool DeleteDormInfo_SZ( DeleteDormInfo_SZ DeleteDormInfo_SZParameter )
		//{

		//	bool bResult = m_ApplyMailDBManager.DeleteDormInfo_SZ( DeleteDormInfo_SZParameter );

		//	return bResult;
		//}

		#endregion Internal Methods

		#region Private Fields

		private ApplyMailDBManager m_ApplyMailDBManager = new ApplyMailDBManager();

		#endregion Private Fields
	}
}