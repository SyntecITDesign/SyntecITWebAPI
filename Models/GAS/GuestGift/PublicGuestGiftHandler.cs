using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.GuestGift;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.GuestGift
{

	internal class PublicGuestGiftHandler
	{
		#region Internal Methods
		internal bool InsertGuestGiftType( InsertGuestGiftType InsertGuestGiftTypeParameter )
		{

			bool bResult = m_CleanGuestGiftDBManager.InsertGuestGiftType( InsertGuestGiftTypeParameter );

			return bResult;
		}
		internal bool DeleteGuestGiftType( DeleteGuestGiftType DeleteGuestGiftTypeParameter )
		{

			bool bResult = m_CleanGuestGiftDBManager.DeleteGuestGiftType( DeleteGuestGiftTypeParameter );

			return bResult;
		}
		internal bool UpdateGuestGiftTypeInfo( UpdateGuestGiftTypeInfo UpdateGuestGiftTypeInfoParameter )
		{

			bool bResult = m_CleanGuestGiftDBManager.UpdateGuestGiftTypeInfo( UpdateGuestGiftTypeInfoParameter );

			return bResult;
		}
		internal JArray GetGuestGiftTypeInfo( GetGuestGiftTypeInfo GetGuestGiftTypeInfoParameter )
		{

			DataTable dtResult = m_CleanGuestGiftDBManager.GetGuestGiftTypeInfo( GetGuestGiftTypeInfoParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpsertGuestGiftQuantityInfo( UpsertGuestGiftQuantityInfo UpsertGuestGiftQuantityInfoParameter )
		{

			bool bResult = m_CleanGuestGiftDBManager.UpsertGuestGiftQuantityInfo( UpsertGuestGiftQuantityInfoParameter );

			return bResult;
		}
		internal bool DeleteGuestGiftQuantity( DeleteGuestGiftQuantity DeleteGuestGiftQuantityParameter )
		{

			bool bResult = m_CleanGuestGiftDBManager.DeleteGuestGiftQuantity( DeleteGuestGiftQuantityParameter );

			return bResult;
		}
		internal JArray GetGuestGiftQuantityInfo( GetGuestGiftQuantityInfo GetGuestGiftQuantityInfoParameter )
		{

			DataTable dtResult = m_CleanGuestGiftDBManager.GetGuestGiftQuantityInfo( GetGuestGiftQuantityInfoParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool InsertGuestGiftOrder( InsertGuestGiftOrder InsertGuestGiftOrderParameter )
		{

			bool bResult = m_CleanGuestGiftDBManager.InsertGuestGiftOrder( InsertGuestGiftOrderParameter );

			return bResult;
		}
		internal bool InsertGuestGiftOrderListDetail( InsertGuestGiftOrderListDetail InsertGuestGiftOrderListDetailParameter )
		{

			bool bResult = m_CleanGuestGiftDBManager.InsertGuestGiftOrderListDetail( InsertGuestGiftOrderListDetailParameter );

			return bResult;
		}
		internal JArray GetGuestGiftOrderList( GetGuestGiftOrderList GetGuestGiftOrderListParameter )
		{

			DataTable dtResult = m_CleanGuestGiftDBManager.GetGuestGiftOrderList( GetGuestGiftOrderListParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal JArray GetGuestGiftOrderListDetail( GetGuestGiftOrderListDetail GetGuestGiftOrderListDetailParameter )
		{

			DataTable dtResult = m_CleanGuestGiftDBManager.GetGuestGiftOrderListDetail( GetGuestGiftOrderListDetailParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool DeleteGuestGiftOrder( DeleteGuestGiftOrder DeleteGuestGiftOrderParameter )
		{

			bool bResult = m_CleanGuestGiftDBManager.DeleteGuestGiftOrder( DeleteGuestGiftOrderParameter );

			return bResult;
		}
		internal bool UpdateGuestGiftOrder( UpdateGuestGiftOrder UpdateGuestGiftOrderParameter )
		{

			bool bResult = m_CleanGuestGiftDBManager.UpdateGuestGiftOrder( UpdateGuestGiftOrderParameter );

			return bResult;
		}


		#endregion Internal Methods

		#region Private Fields

		private GuestGiftDBManager m_CleanGuestGiftDBManager = new GuestGiftDBManager();

		#endregion Private Fields
	}
}