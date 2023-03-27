using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TQMLibrary;

namespace SyntecITWebAPI.Models.User
{
	public class RegistedUserHandler
	{
		internal JObject GetCustomerNameList( string userID )
		{
			JObject result = new JObject();
			DataTable tqmResult = m_productSN.GetCustomerList( userID );

			if( tqmResult.Rows.Count <= 0 )
				return null;
			else
			{
				//將dataTable 轉為 array
				string[] resultArray = tqmResult.AsEnumerable().Select( r => r.Field<string>( "CustomerCompanyName" ) ).ToArray();
				result.Add( "CustomerCompanyName", JArray.FromObject( resultArray ) );
				return result;
			}
		}

		private readonly ProductSN m_productSN = new ProductSN();
	}
}
