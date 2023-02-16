using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common;
using SyntecITWebAPI.Enums;
using SyntecITWebAPI.ParameterModels.DeviceManangement;
using SyntecITWebAPI.ParameterModels.DeviceManangement.CRMRepairList.Return;
using SyntecITWebAPI.ParameterModels.DeviceManangement.Overview;
using SyntecITWebAPI.ParameterModels.DeviceManangement.Overview.Return;
using SyntecITWebAPI.ParameterModels.DeviceManangement.RegAnalysis.Return;
using SyntecITWebAPI.ParameterModels.DeviceManangement.RegInfo;
using SyntecITWebAPI.Static;
using SyntecITWebAPI.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TQMLibrary;

namespace SyntecITWebAPI.Models.SN
{
	public class SNHandler
	{
		#region Internal Methods

		internal JObject GetSNInfo( string[] productSNList, string userID )
		{
			DataTable resultDataTable = m_productSN.GetSNInfoEnKey( productSNList, userID, out string message,0 );

			if( resultDataTable == null )
				return null;

			string resultJson = JsonConvert.SerializeObject( resultDataTable, Formatting.Indented );

			JObject resultJObject = new JObject { { "SNInfo", JArray.Parse( resultJson ) } };

			return resultJObject;
		}

		#endregion Internal Methods

		#region Private Fields

		private readonly ProductSN m_productSN = new ProductSN();

		#endregion Private Fields

		#region Private Methods


		#endregion Private Methods
	}
}
