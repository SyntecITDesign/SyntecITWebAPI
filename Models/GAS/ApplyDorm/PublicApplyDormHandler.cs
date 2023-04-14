using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.ApplyDorm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.ApplyDorm
{

	internal class PublicApplyDormHandler
	{
		#region Internal Methods
		internal JArray GetEmpDormStatusData( GetEmpDormStatusData GetEmpDormStatusDataParameter )
		{

			DataTable dtResult = m_ApplyDormDBManager.GetEmpDormStatusData( GetEmpDormStatusDataParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertDormApplicationsMaster( InsertDormApplicationsMaster InsertDormApplicationsMasterParameter )
		{

			bool bResult = m_ApplyDormDBManager.InsertDormApplicationsMaster( InsertDormApplicationsMasterParameter );

			return bResult;
		}

		internal bool UpdateDormApplicationsMaster( UpdateDormApplicationsMaster UpdateDormApplicationsMasterParameter )
		{

			bool bResult = m_ApplyDormDBManager.UpdateDormApplicationsMaster( UpdateDormApplicationsMasterParameter );

			return bResult;
		}
		internal JArray GetDormApplicationsMaster_SZ( GetDormApplicationsMaster_SZ GetDormApplicationsMaster_SZ_Parameter )
		{

			DataTable dtResult = m_ApplyDormDBManager.GetDormApplicationsMaster_SZ( GetDormApplicationsMaster_SZ_Parameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray GetDormInfo_SZ( GetDormInfo_SZ GetDormInfo_SZParameter )
		{

			DataTable dtResult = m_ApplyDormDBManager.GetDormInfo_SZ( GetDormInfo_SZParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertDormInfo_SZ( UpsertDormInfo_SZ UpsertDormInfo_SZParameter )
		{

			bool bResult = m_ApplyDormDBManager.UpsertDormInfo_SZ( UpsertDormInfo_SZParameter );

			return bResult;
		}

		internal bool DeleteDormInfo_SZ( DeleteDormInfo_SZ DeleteDormInfo_SZParameter )
		{

			bool bResult = m_ApplyDormDBManager.DeleteDormInfo_SZ( DeleteDormInfo_SZParameter );

			return bResult;
		}

		#endregion Internal Methods

		#region Private Fields

		private ApplyDormDBManager m_ApplyDormDBManager = new ApplyDormDBManager();

		#endregion Private Fields
	}
}