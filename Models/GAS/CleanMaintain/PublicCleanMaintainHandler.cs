using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.CleanMaintain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.CleanMaintain
{

	internal class PublicCleanMaintainHandler
	{
		#region Internal Methods
		internal bool InsertMaintainType(InsertMaintainType InsertMaintainTypeParameter)
		{

			bool bResult = m_CleanMaintainDBManager.InsertMaintainType(InsertMaintainTypeParameter);

			return bResult;
		}
		internal bool DeleteMaintainType(DeleteMaintainType DeleteMaintainTypeParameter)
		{

			bool bResult = m_CleanMaintainDBManager.DeleteMaintainType(DeleteMaintainTypeParameter);

			return bResult;
		}
		internal bool UpdateMaintainTypeInfo(UpdateMaintainTypeInfo UpdateMaintainTypeInfoParameter)
		{

			bool bResult = m_CleanMaintainDBManager.UpdateMaintainTypeInfo(UpdateMaintainTypeInfoParameter);

			return bResult;
		}
		internal JArray GetMaintainTypeInfo(GetMaintainTypeInfo GetMaintainTypeInfoParameter)
		{

			DataTable dtResult = m_CleanMaintainDBManager.GetMaintainTypeInfo(GetMaintainTypeInfoParameter);

			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}

		internal bool UpsertMaintainQuantityInfo( UpsertMaintainQuantityInfo UpsertMaintainQuantityInfoParameter )
		{

			bool bResult = m_CleanMaintainDBManager.UpsertMaintainQuantityInfo( UpsertMaintainQuantityInfoParameter );

			return bResult;
		}
		internal bool DeleteMaintainQuantity( DeleteMaintainQuantity DeleteMaintainQuantityParameter )
		{

			bool bResult = m_CleanMaintainDBManager.DeleteMaintainQuantity( DeleteMaintainQuantityParameter );

			return bResult;
		}
		internal JArray GetMaintainQuantityInfo( GetMaintainQuantityInfo GetMaintainQuantityInfoParameter )
		{

			DataTable dtResult = m_CleanMaintainDBManager.GetMaintainQuantityInfo( GetMaintainQuantityInfoParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		
		internal bool InsertMaintainOrder( InsertMaintainOrder InsertMaintainOrderParameter )
		{

			bool bResult = m_CleanMaintainDBManager.InsertMaintainOrder( InsertMaintainOrderParameter );

			return bResult;
		}
		internal bool InsertMaintainOrderListDetail( InsertMaintainOrderListDetail InsertMaintainOrderListDetailParameter )
		{

			bool bResult = m_CleanMaintainDBManager.InsertMaintainOrderListDetail( InsertMaintainOrderListDetailParameter );

			return bResult;
		}
		internal JArray GetMaintainOrderList( GetMaintainOrderList GetMaintainOrderListParameter )
		{

			DataTable dtResult = m_CleanMaintainDBManager.GetMaintainOrderList( GetMaintainOrderListParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray GetMaintainOrderListDetail( GetMaintainOrderListDetail GetMaintainOrderListDetailParameter )
		{

			DataTable dtResult = m_CleanMaintainDBManager.GetMaintainOrderListDetail( GetMaintainOrderListDetailParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool DeleteMaintainOrder( DeleteMaintainOrder DeleteMaintainOrderParameter )
		{

			bool bResult = m_CleanMaintainDBManager.DeleteMaintainOrder( DeleteMaintainOrderParameter );

			return bResult;
		}
		internal bool UpdateMaintainOrder( UpdateMaintainOrder UpdateMaintainOrderParameter )
		{

			bool bResult = m_CleanMaintainDBManager.UpdateMaintainOrder( UpdateMaintainOrderParameter );

			return bResult;
		}

		internal bool InsertCleanFirm( InsertCleanFirm InsertCleanFirmParameter )
		{

			bool bResult = m_CleanMaintainDBManager.InsertCleanFirm( InsertCleanFirmParameter );

			return bResult;
		}
		internal bool DeleteCleanFirm( DeleteCleanFirm DeleteCleanFirmParameter )
		{

			bool bResult = m_CleanMaintainDBManager.DeleteCleanFirm( DeleteCleanFirmParameter );

			return bResult;
		}
		internal bool UpdateCleanFirmInfo( UpdateCleanFirmInfo UpdateCleanFirmInfoParameter )
		{

			bool bResult = m_CleanMaintainDBManager.UpdateCleanFirmInfo( UpdateCleanFirmInfoParameter );

			return bResult;
		}
		internal JArray GetCleanFirmInfo( GetCleanFirmInfo GetCleanFirmInfoParameter )
		{

			DataTable dtResult = m_CleanMaintainDBManager.GetCleanFirmInfo( GetCleanFirmInfoParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		#endregion Internal Methods

		#region Private Fields

		private CleanMaintainDBManager m_CleanMaintainDBManager = new CleanMaintainDBManager();

		#endregion Private Fields
	}
}