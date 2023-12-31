﻿using Newtonsoft.Json.Linq;
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

		internal bool UpdateITInfo( UpdateITInfo UpdateITInfoParameter )
		{

			bool bResult = m_AssetManagementDBManager.UpdateITInfo( UpdateITInfoParameter );

			return bResult;
		}

		internal bool InsertAssetSpecList( InsertAssetSpecList InsertAssetSpecListParameter )
		{

			bool bResult = m_AssetManagementDBManager.InsertAssetSpecList( InsertAssetSpecListParameter );

			return bResult;
		}
		internal bool DeleteAssetSpecList( DeleteAssetSpecList DeleteAssetSpecListParameter )
		{

			bool bResult = m_AssetManagementDBManager.DeleteAssetSpecList( DeleteAssetSpecListParameter );

			return bResult;
		}
		internal bool UpdateAssetSpecList( UpdateAssetSpecList UpdateAssetSpecListParameter )
		{

			bool bResult = m_AssetManagementDBManager.UpdateAssetSpecList( UpdateAssetSpecListParameter );

			return bResult;
		}
		internal JArray GetAssetSpecList( GetAssetSpecList GetAssetSpecListParameter )
		{

			DataTable dtResult = m_AssetManagementDBManager.GetAssetSpecList( GetAssetSpecListParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool InsertAssetInventory( InsertAssetInventory InsertAssetInventoryParameter )
		{

			bool bResult = m_AssetManagementDBManager.InsertAssetInventory( InsertAssetInventoryParameter );

			return bResult;
		}
		internal bool DeleteAssetInventory( DeleteAssetInventory DeleteAssetInventoryParameter )
		{

			bool bResult = m_AssetManagementDBManager.DeleteAssetInventory( DeleteAssetInventoryParameter );

			return bResult;
		}
		internal bool UpdateAssetInventory( UpdateAssetInventory UpdateAssetInventoryParameter )
		{

			bool bResult = m_AssetManagementDBManager.UpdateAssetInventory( UpdateAssetInventoryParameter );

			return bResult;
		}
		internal JArray GetAssetInventory( GetAssetInventory GetAssetInventoryParameter )
		{

			DataTable dtResult = m_AssetManagementDBManager.GetAssetInventory( GetAssetInventoryParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool InsertAssetLogTable( InsertAssetLogTable InsertAssetLogTableParameter )
		{

			bool bResult = m_AssetManagementDBManager.InsertAssetLogTable( InsertAssetLogTableParameter );

			return bResult;
		}

		internal JArray GetAssetLogTable( GetAssetLogTable GetAssetLogTableParameter )
		{

			DataTable dtResult = m_AssetManagementDBManager.GetAssetLogTable( GetAssetLogTableParameter );

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