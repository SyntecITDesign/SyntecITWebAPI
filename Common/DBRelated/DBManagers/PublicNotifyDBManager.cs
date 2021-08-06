using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.Notify;

namespace SyntecITWebAPI.Common.DBRelated.DBManagers
{
	internal class PublicNotifyDBManager : AbstractDBManager
	{
		#region Internal Methods
		internal bool SendWXNotify( WXNotify WXNotifyParameter )
		{
			string sql = m_dbSQL.InsertWXMessage;
			List<object> SQLParameterList = new List<object>()
			{
				WXNotifyParameter.sendOpenid,
				WXNotifyParameter.title,
				WXNotifyParameter.contentBody,
				WXNotifyParameter.keyWords,
				WXNotifyParameter.platform,
				WXNotifyParameter.masterID,
				WXNotifyParameter.masterType,
				WXNotifyParameter.keyword1,
				WXNotifyParameter.keyword2,
				WXNotifyParameter.keyword3,
				WXNotifyParameter.keyword4,
				WXNotifyParameter.keyword5,
				WXNotifyParameter.url,
				WXNotifyParameter.flowStatus
			};
			bool bResult = m_SyntecBBSdbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}
		#endregion Internal Methods
	}
}
