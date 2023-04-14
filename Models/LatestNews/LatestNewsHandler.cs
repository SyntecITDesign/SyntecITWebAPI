using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.LatestNews;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SyntecITWebAPI.Models.LatestNews
{
	internal class LatestNewsHandler
	{
		#region Internal Methods

		internal JObject CreateNews( NewsParameter newsParameter, string userID )
		{
			if( string.IsNullOrEmpty( userID ) )
				return null;

			string insertResult = m_newsDbManager.InsertNewsAndGetID( newsParameter, userID );

			if( string.IsNullOrEmpty( insertResult ) )
				return null;
			else
			{
				newsParameter.index = Convert.ToInt32( insertResult );
				JObject resultJson = JObject.FromObject( newsParameter );
				return resultJson;
			}
		}

		internal bool DeleteNewsByIndex( int news_id )
		{
			return m_newsDbManager.DeleteNewsByID( news_id );
		}

		//取得一個月內的所有公告
		internal JObject GetNews()
		{
			long lastMonthUnixTime = DateTimeOffset.UtcNow.AddMonths( -1 ).ToUnixTimeMilliseconds();
			DataTable getNewsResult = m_newsDbManager.GetAllNews( lastMonthUnixTime );
			if( getNewsResult == null )
				return null;

			//Convert DataTable(from DB) to list<NewsPararmter>
			List<NewsParameter> newsList = ( from row in getNewsResult.AsEnumerable()
											 select new NewsParameter()
											 {
												 index = Convert.ToInt32( row[ "news_id" ] ),
												 title = Convert.ToString( row[ "title" ] ),
												 description = Convert.ToString( row[ "content" ] ),
												 updateTime = Convert.ToInt64( row[ "modi_date" ] )
											 } ).ToList();

			JObject jsonResult = new JObject();
			jsonResult[ "latestNews" ] = JToken.FromObject( newsList );
			return jsonResult;
		}

		internal bool UpdateNewsByIndex( NewsParameter newsParameter, string userID )
		{
			if( string.IsNullOrEmpty( userID ) )
				return false;

			bool updateResult = m_newsDbManager.UpdateNewsByID( newsParameter, userID );

			return updateResult;
		}

		#endregion Internal Methods

		#region Private Fields

		private LatestNewsDBManager m_newsDbManager = new LatestNewsDBManager();

		#endregion Private Fields
	}
}
