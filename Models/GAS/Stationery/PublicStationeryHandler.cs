using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Syntec.CRM;
using Syntec.Flow.Utility;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.GAS.Stationery;
using SyntecITWebAPI.Common.MailRelated;
using SyntecITWebAPI.Common.MailRelated.User;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.ParameterModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;

namespace SyntecITWebAPI.Models.GAS.Stationery
{
	internal class PublicSyntecGASHandler
	{
		#region Internal Methods

		// this function will update user verify code & mail user with
		// QueryString(userID,verifyCode) . urlHelper and scheme are used to generate url
		internal JArray QueryStationeryQuantity()
		{

			DataTable dtResult = m_publicGASDBManager.GetStationeryQuantity();

			if (dtResult == null || dtResult.Rows.Count <= 0)
				return null;
			else
			{
				JArray ja = JArray.FromObject(dtResult);
				return ja;
			}
		}
		internal bool UpsertStationeryQuantity(UpsertStationeryQuantity UpsertStationeryQuantityParameter)
		{

			bool bResult = m_publicGASDBManager.UpsertStationeryQuantity(UpsertStationeryQuantityParameter);

			return bResult;
		}
		internal bool DeleteStationery(DeleteStationery DeleteStationeryParameter)
		{

			bool bResult = m_publicGASDBManager.DeleteStationery(DeleteStationeryParameter);

			return bResult;
		}





		internal JArray GetStationeryApplicationsMaster( GetStationeryApplicationsMaster GetStationeryApplicationsMasterParameter )
		{
			DataTable dtResult = m_publicGASDBManager.GetStationeryApplicationsMaster( GetStationeryApplicationsMasterParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertStationeryApplicationsMaster( InsertStationeryApplicationsMaster InsertStationeryApplicationsMasterParameter )
		{
			bool bResult = m_publicGASDBManager.InsertStationeryApplicationsMaster( InsertStationeryApplicationsMasterParameter );
			return bResult;
		}
		internal bool UpdateStationeryApplicationsMaster( UpdateStationeryApplicationsMaster UpdateStationeryApplicationsMasterParameter )
		{
			bool bResult = m_publicGASDBManager.UpdateStationeryApplicationsMaster( UpdateStationeryApplicationsMasterParameter );
			return bResult;
		}

		internal JArray GetStationeryApplicationsDetail( GetStationeryApplicationsDetail GetStationeryApplicationsDetailParameter )
		{
			DataTable dtResult = m_publicGASDBManager.GetStationeryApplicationsDetail( GetStationeryApplicationsDetailParameter );
			if( dtResult == null || dtResult.Rows.Count <= 0 )
				return null;
			else
			{
				JArray ja = JArray.FromObject( dtResult );
				return ja;
			}
		}
		internal bool InsertStationeryApplicationsDetail( InsertStationeryApplicationsDetail InsertStationeryApplicationsDetailParameter )
		{
			bool bResult = m_publicGASDBManager.InsertStationeryApplicationsDetail( InsertStationeryApplicationsDetailParameter );
			return bResult;
		}
		internal bool UpdateStationeryApplicationsDetail( UpdateStationeryApplicationsDetail UpdateStationeryApplicationsDetailParameter )
		{
			bool bResult = m_publicGASDBManager.UpdateStationeryApplicationsDetail( UpdateStationeryApplicationsDetailParameter );
			return bResult;
		}
		internal bool DeleteStationeryApplicationsDetail( DeleteStationeryApplicationsDetail DeleteStationeryApplicationsDetailParameter )
		{
			bool bResult = m_publicGASDBManager.DeleteStationeryApplicationsDetail( DeleteStationeryApplicationsDetailParameter );
			return bResult;
		}


		

		internal JArray GetStationeryApplicationsDept()
		{

			DataTable dtResult = m_publicGASDBManager.GetStationeryApplicationsDept();

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

		private PublicGASDBManager m_publicGASDBManager = new PublicGASDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
