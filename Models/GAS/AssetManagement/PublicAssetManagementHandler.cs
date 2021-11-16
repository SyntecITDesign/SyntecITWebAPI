using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.AssetManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.AssetManagement
{

	internal class PublicAssetManagementHandler
	{
		#region Internal Methods
		internal bool InsertAssetInfo( InsertAssetInfo InsertAssetInfoParameter )
		{

			bool bResult = m_AssetManagementDBManager.InsertAssetInfo( InsertAssetInfoParameter );

			return bResult;
		}
		internal bool DeleteAssetInfo( DeleteAssetInfo DeleteAssetInfoParameter )
		{

			bool bResult = m_AssetManagementDBManager.DeleteAssetInfo( DeleteAssetInfoParameter );

			return bResult;
		}
		internal bool UpdateAssetInfo( UpdateAssetInfo UpdateAssetInfoParameter )
		{

			bool bResult = m_AssetManagementDBManager.UpdateAssetInfo( UpdateAssetInfoParameter );

			return bResult;
		}
		internal JArray GetAssetInfo( GetAssetInfo GetAssetInfoParameter )
		{

			DataTable dtResult = m_AssetManagementDBManager.GetAssetInfo( GetAssetInfoParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		#endregion Internal Methods

		#region Private Fields

		private AssetManagementDBManager m_AssetManagementDBManager = new AssetManagementDBManager();

		#endregion Private Fields
	}
}