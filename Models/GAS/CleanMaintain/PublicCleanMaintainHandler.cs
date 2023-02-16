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

		internal JArray GetCleanStaffType( GetCleanStaffType GetCleanStaffTypeParameter )
		{
			DataTable dtResult = m_CleanMaintainDBManager.GetCleanStaffType( GetCleanStaffTypeParameter );
			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertCleanStaffType( InsertCleanStaffType InsertCleanStaffTypeParameter )
		{
			bool bResult = m_CleanMaintainDBManager.InsertCleanStaffType( InsertCleanStaffTypeParameter );
			return bResult;
		}
		internal bool DeleteCleanStaffType( DeleteCleanStaffType DeleteCleanStaffTypeParameter )
		{
			bool bResult = m_CleanMaintainDBManager.DeleteCleanStaffType( DeleteCleanStaffTypeParameter );
			return bResult;
		}
		internal bool UpdateCleanStaffType( UpdateCleanStaffType UpdateCleanStaffTypeParameter )
		{
			bool bResult = m_CleanMaintainDBManager.UpdateCleanStaffType( UpdateCleanStaffTypeParameter );
			return bResult;
		}

		internal JArray GetCleanAreaPlan( GetCleanAreaPlan GetCleanAreaPlanParameter )
		{
			DataTable dtResult = m_CleanMaintainDBManager.GetCleanAreaPlan( GetCleanAreaPlanParameter );
			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertCleanAreaPlan( InsertCleanAreaPlan InsertCleanAreaPlanParameter )
		{
			bool bResult = m_CleanMaintainDBManager.InsertCleanAreaPlan( InsertCleanAreaPlanParameter );
			return bResult;
		}
		internal bool DeleteCleanAreaPlan( DeleteCleanAreaPlan DeleteCleanAreaPlanParameter )
		{
			bool bResult = m_CleanMaintainDBManager.DeleteCleanAreaPlan( DeleteCleanAreaPlanParameter );
			return bResult;
		}
		internal bool UpdateCleanAreaPlan( UpdateCleanAreaPlan UpdateCleanAreaPlanParameter )
		{
			bool bResult = m_CleanMaintainDBManager.UpdateCleanAreaPlan( UpdateCleanAreaPlanParameter );
			return bResult;
		}

		internal JArray GetCleanStaffInfo( GetCleanStaffInfo GetCleanStaffInfoParameter )
		{
			DataTable dtResult = m_CleanMaintainDBManager.GetCleanStaffInfo( GetCleanStaffInfoParameter );
			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertCleanStaffInfo( InsertCleanStaffInfo InsertCleanStaffInfoParameter )
		{
			bool bResult = m_CleanMaintainDBManager.InsertCleanStaffInfo( InsertCleanStaffInfoParameter );
			return bResult;
		}
		internal bool DeleteCleanStaffInfo( DeleteCleanStaffInfo DeleteCleanStaffInfoParameter )
		{
			bool bResult = m_CleanMaintainDBManager.DeleteCleanStaffInfo( DeleteCleanStaffInfoParameter );
			return bResult;
		}
		internal bool UpdateCleanStaffInfo( UpdateCleanStaffInfo UpdateCleanStaffInfoParameter )
		{
			bool bResult = m_CleanMaintainDBManager.UpdateCleanStaffInfo( UpdateCleanStaffInfoParameter );
			return bResult;
		}

		internal JArray GetCleanAreaInfo( GetCleanAreaInfo GetCleanAreaInfoParameter )
		{
			DataTable dtResult = m_CleanMaintainDBManager.GetCleanAreaInfo( GetCleanAreaInfoParameter );
			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertCleanAreaInfo( InsertCleanAreaInfo InsertCleanAreaInfoParameter )
		{
			bool bResult = m_CleanMaintainDBManager.InsertCleanAreaInfo( InsertCleanAreaInfoParameter );
			return bResult;
		}
		internal bool DeleteCleanAreaInfo( DeleteCleanAreaInfo DeleteCleanAreaInfoParameter )
		{
			bool bResult = m_CleanMaintainDBManager.DeleteCleanAreaInfo( DeleteCleanAreaInfoParameter );
			return bResult;
		}
		internal bool UpdateCleanAreaInfo( UpdateCleanAreaInfo UpdateCleanAreaInfoParameter )
		{
			bool bResult = m_CleanMaintainDBManager.UpdateCleanAreaInfo( UpdateCleanAreaInfoParameter );
			return bResult;
		}

		internal JArray GetMaintainRecordItemInfo( GetMaintainRecordItemInfo GetMaintainRecordItemInfoParameter )
		{
			DataTable dtResult = m_CleanMaintainDBManager.GetMaintainRecordItemInfo( GetMaintainRecordItemInfoParameter );
			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertMaintainRecordItem( InsertMaintainRecordItem InsertMaintainRecordItemParameter )
		{
			bool bResult = m_CleanMaintainDBManager.InsertMaintainRecordItem( InsertMaintainRecordItemParameter );
			return bResult;
		}
		internal bool DeleteMaintainRecordItem( DeleteMaintainRecordItem DeleteMaintainRecordItemParameter )
		{
			bool bResult = m_CleanMaintainDBManager.DeleteMaintainRecordItem( DeleteMaintainRecordItemParameter );
			return bResult;
		}
		internal bool UpdateMaintainRecordItemInfo( UpdateMaintainRecordItemInfo UpdateMaintainRecordItemInfoParameter )
		{
			bool bResult = m_CleanMaintainDBManager.UpdateMaintainRecordItemInfo( UpdateMaintainRecordItemInfoParameter );
			return bResult;
		}

		internal JArray GetMaintainRecordTypeInfo( GetMaintainRecordTypeInfo GetMaintainRecordTypeInfoParameter )
		{
			DataTable dtResult = m_CleanMaintainDBManager.GetMaintainRecordTypeInfo( GetMaintainRecordTypeInfoParameter );
			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertMaintainRecordType( InsertMaintainRecordType InsertMaintainRecordTypeParameter )
		{
			bool bResult = m_CleanMaintainDBManager.InsertMaintainRecordType( InsertMaintainRecordTypeParameter );
			return bResult;
		}
		internal bool DeleteMaintainRecordType( DeleteMaintainRecordType DeleteMaintainRecordTypeParameter )
		{
			bool bResult = m_CleanMaintainDBManager.DeleteMaintainRecordType( DeleteMaintainRecordTypeParameter );
			return bResult;
		}
		internal bool UpdateMaintainRecordTypeInfo( UpdateMaintainRecordTypeInfo UpdateMaintainRecordTypeInfoParameter )
		{
			bool bResult = m_CleanMaintainDBManager.UpdateMaintainRecordTypeInfo( UpdateMaintainRecordTypeInfoParameter );
			return bResult;
		}

		internal JArray GetMaintainRecordDetailList( GetMaintainRecordDetailList GetMaintainRecordDetailListParameter )
		{
			DataTable dtResult = m_CleanMaintainDBManager.GetMaintainRecordDetailList( GetMaintainRecordDetailListParameter );
			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertMaintainRecordDetailList( InsertMaintainRecordDetailList InsertMaintainRecordDetailListParameter )
		{
			bool bResult = m_CleanMaintainDBManager.InsertMaintainRecordDetailList( InsertMaintainRecordDetailListParameter );
			return bResult;
		}
		internal bool DeleteMaintainRecordDetailList( DeleteMaintainRecordDetailList DeleteMaintainRecordDetailListParameter )
		{
			bool bResult = m_CleanMaintainDBManager.DeleteMaintainRecordDetailList( DeleteMaintainRecordDetailListParameter );
			return bResult;
		}
		internal bool UpdateMaintainRecordDetailList( UpdateMaintainRecordDetailList UpdateMaintainRecordDetailListParameter )
		{
			bool bResult = m_CleanMaintainDBManager.UpdateMaintainRecordDetailList( UpdateMaintainRecordDetailListParameter );
			return bResult;
		}

		internal bool InsertCleanCheckTable( InsertCleanCheckTable InsertCleanCheckTableParameter )
		{
			bool bResult = m_CleanMaintainDBManager.InsertCleanCheckTable( InsertCleanCheckTableParameter );
			return bResult;
		}


		#endregion Internal Methods

		#region Private Fields

		private CleanMaintainDBManager m_CleanMaintainDBManager = new CleanMaintainDBManager();

		#endregion Private Fields
	}
}