using Newtonsoft.Json.Linq;
using System;

namespace SyntecITWebAPI.Utility
{
	public static class ITServiceUtility
	{
		#region Public Methods

		//從IT回傳的Json取得要的Data columnName有順序性 從最外層json到最內層
		public static JToken ParseITJsonResult( this String itJsonResultString, string[] columnNameArray )
		{
			JObject itJsonResult = JObject.Parse( itJsonResultString );
			JToken source = null;

			if( !itJsonResult.TryGetValue( IT_SUCCESS_KEY, out source ) )  //沒有成功呼叫WS
			{
				return null;
			}
			else
			{
				int nestedNum = columnNameArray.Length;

				for( int index = 0; index < nestedNum; ++index )
				{
					string columnName = columnNameArray[ index ];
					JObject tempSourceJObj = source.ToObject<JObject>();
					source = null;

					if( !tempSourceJObj.TryGetValue( columnName, out source ) ) //沒有成功取到此欄位，成功則取到source裡可能會進到下一迴圈或直接回傳
					{
						return null;
					}
				}

				return source;
			}
		}

		#endregion Public Methods

		#region Private Fields

		private const string IT_SUCCESS_KEY = "0000";

		#endregion Private Fields
	}
}
