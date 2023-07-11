using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.LatestNews;
using System.Collections.Generic;
using System.Data;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class LatestNewsDBManager : AbstractDBManager
	{
		#region Internal Methods

		internal bool DeleteNewsByID( int index )
		{
			string sql = m_dbSQL.DELETE_NEWS_BY_INDEX;
			return m_dbproxy.ChangeDataCMD( sql, new object[] { index } );
		}

		internal DataTable GetAllNews( long lastMonthUnixTime )
		{
			string sql = m_dbSQL.GET_ALL_NEWS_IN_LAST_MONTH;
			DataTable result = m_dbproxy.GetDataCMD( sql, new object[] { lastMonthUnixTime } );
			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		internal string InsertNewsAndGetID( NewsParameter newsparameter, string userID )
		{
			string sql = m_dbSQL.INSERT_LATEST_NEWS;
			List<object> parameterList = new List<object>
			{
				newsparameter.title,
				newsparameter.description,
				userID,
				userID,
				newsparameter.updateTime,
				newsparameter.updateTime
			};

			DataTable result = m_dbproxy.GetDataCMD( sql, parameterList.ToArray() );

			if( result == null || result.Rows.Count <= 0 )
			{
				return null;
			}
			else
			{
				return result.Rows[ 0 ][ 0 ].ToString();
			}
		}

		internal bool UpdateNewsByID( NewsParameter newsParameter, string userID )
		{
			string sql = m_dbSQL.UPDATE_NEWS_BY_INDEX;
			List<object> parameterList = new List<object>
			{
				newsParameter.title,
				newsParameter.description,
				userID,
				newsParameter.updateTime,
				newsParameter.index
			};

			return m_dbproxy.ChangeDataCMD( sql, parameterList.ToArray() );
		}

		#endregion Internal Methods
	}
}
