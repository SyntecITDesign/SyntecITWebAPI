using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers.GAS;
using SyntecITWebAPI.ParameterModels.GAS.ApplyUniform;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Models.GAS.ApplyUniform
{

	internal class PublicApplyUniformHandler
	{
		#region Internal Methods
		internal bool InsertUniformStyle(InsertUniformStyle InsertUniformStyleParameter)
		{

			bool bResult = m_ApplyUniformDBManager.InsertUniformStyle(InsertUniformStyleParameter);

			return bResult;
		}
		internal bool DeleteUniformStyle(DeleteUniformStyle DeleteUniformStyleParameter)
		{

			bool bResult = m_ApplyUniformDBManager.DeleteUniformStyle(DeleteUniformStyleParameter);

			return bResult;
		}
		internal bool UpdateUniformStyleInfo(UpdateUniformStyleInfo UpdateUniformStyleInfoParameter)
		{

			bool bResult = m_ApplyUniformDBManager.UpdateUniformStyleInfo(UpdateUniformStyleInfoParameter);

			return bResult;
		}
		internal JArray GetUniformStyleInfo(GetUniformStyleInfo GetUniformStyleInfoParameter)
		{

			DataTable dtResult = m_ApplyUniformDBManager.GetUniformStyleInfo(GetUniformStyleInfoParameter);

			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}

		internal bool UpsertUniformQuantityInfo( UpsertUniformQuantityInfo UpsertUniformQuantityInfoParameter )
		{

			bool bResult = m_ApplyUniformDBManager.UpsertUniformQuantityInfo( UpsertUniformQuantityInfoParameter );

			return bResult;
		}
		internal bool DeleteUniformQuantity( DeleteUniformQuantity DeleteUniformQuantityParameter )
		{

			bool bResult = m_ApplyUniformDBManager.DeleteUniformQuantity( DeleteUniformQuantityParameter );

			return bResult;
		}
		internal JArray GetUniformQuantityInfo( GetUniformQuantityInfo GetUniformQuantityInfoParameter )
		{

			DataTable dtResult = m_ApplyUniformDBManager.GetUniformQuantityInfo( GetUniformQuantityInfoParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool InsertUniformOrder( InsertUniformOrder InsertUniformOrderParameter )
		{

			bool bResult = m_ApplyUniformDBManager.InsertUniformOrder( InsertUniformOrderParameter );

			return bResult;
		}
		internal bool InsertUniformOrderListDetail( InsertUniformOrderListDetail InsertUniformOrderListDetailParameter )
		{

			bool bResult = m_ApplyUniformDBManager.InsertUniformOrderListDetail( InsertUniformOrderListDetailParameter );

			return bResult;
		}
		internal JArray GetUniformOrderList( GetUniformOrderList GetUniformOrderListParameter )
		{

			DataTable dtResult = m_ApplyUniformDBManager.GetUniformOrderList( GetUniformOrderListParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal JArray GetUniformOrderListDetail( GetUniformOrderListDetail GetUniformOrderListDetailParameter )
		{

			DataTable dtResult = m_ApplyUniformDBManager.GetUniformOrderListDetail( GetUniformOrderListDetailParameter );

			if(dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool DeleteUniformOrder( DeleteUniformOrder DeleteUniformOrderParameter )
		{

			bool bResult = m_ApplyUniformDBManager.DeleteUniformOrder( DeleteUniformOrderParameter );

			return bResult;
		}

		internal bool UpdateUniformOrder( UpdateUniformOrder UpdateUniformOrderParameter )
		{

			bool bResult = m_ApplyUniformDBManager.UpdateUniformOrder( UpdateUniformOrderParameter );

			return bResult;
		}

		internal bool InsertUniformApplicationsMaster( InsertUniformApplicationsMaster InsertUniformApplicationsMasterParameter )
		{

			bool bResult = m_ApplyUniformDBManager.InsertUniformApplicationsMaster( InsertUniformApplicationsMasterParameter );

			return bResult;
		}
		internal bool DeleteUniformApplicationsMaster( DeleteUniformApplicationsMaster DeleteUniformApplicationsMasterParameter )
		{

			bool bResult = m_ApplyUniformDBManager.DeleteUniformApplicationsMaster( DeleteUniformApplicationsMasterParameter );

			return bResult;
		}
		internal bool UpdateUniformApplicationsMaster( UpdateUniformApplicationsMaster UpdateUniformApplicationsMasterParameter )
		{

			bool bResult = m_ApplyUniformDBManager.UpdateUniformApplicationsMaster( UpdateUniformApplicationsMasterParameter );

			return bResult;
		}
		internal JArray GetUniformApplicationsMaster( GetUniformApplicationsMaster GetUniformApplicationsMasterParameter )
		{

			DataTable dtResult = m_ApplyUniformDBManager.GetUniformApplicationsMaster( GetUniformApplicationsMasterParameter );

			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}

		internal bool UpdateCoatApplication( UpdateCoatApplication UpdateCoatApplicationParameter )
		{

			bool bResult = m_ApplyUniformDBManager.UpdateCoatApplication( UpdateCoatApplicationParameter );

			return bResult;
		}

		#endregion Internal Methods

		#region Private Fields

		private ApplyUniformDBManager m_ApplyUniformDBManager = new ApplyUniformDBManager();

		#endregion Private Fields
	}
}