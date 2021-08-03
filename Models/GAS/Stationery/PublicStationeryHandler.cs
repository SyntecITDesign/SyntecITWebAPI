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
		#endregion Internal Methods

		#region Private Fields

		private PublicGASDBManager m_publicGASDBManager = new PublicGASDBManager();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
