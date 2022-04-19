using SyntecITWebAPI.Abstract;
using System.Collections.Generic;
using System.Data;
using SyntecITWebAPI.ParameterModels.Notify;
using System;

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
			bool bResult = m_DWHdbproxy.ChangeDataCMD(sql, SQLParameterList.ToArray());
			return bResult;
		}

		internal bool SendVerifyCode( SendVerifyCode SendVerifyCodeParameter )
		{
			string sql = "Insert into  [jirareport].[dbo].[VerifyCode] (phone,verifyCode,isUse,application,consDate,modiDate) "
				+ " values (@Parameter0, @Parameter1,@Parameter2,@Parameter3,@Parameter4,@Parameter5)";
			DateTimeOffset now = DateTimeOffset.UtcNow;
			long unixTimeMilliseconds = now.ToUnixTimeMilliseconds();
			List<object> SQLParameterList = new List<object>()
			{
				SendVerifyCodeParameter.phone,
				SendVerifyCodeParameter.verifyCode,
				0,
				SendVerifyCodeParameter.application,
				unixTimeMilliseconds,
				unixTimeMilliseconds
			};
			bool bResult = m_dbproxy.ChangeDataCMD( sql, SQLParameterList.ToArray() );
			return bResult;
		}

		internal bool CheckVerifyCode( CheckVerifyCode CheckVerifyCodeParameter )
		{
			DateTimeOffset now = DateTimeOffset.UtcNow;
			long unixTimeMilliseconds = now.ToUnixTimeMilliseconds()-(10*60*1000);
			long unixTimeMilliseconds10MinBefore = unixTimeMilliseconds - (10 * 60 * 1000);//十分鐘前
			List<object> SQLParameterList = new List<object>()
			{
				CheckVerifyCodeParameter.phone,
				CheckVerifyCodeParameter.verifyCode,
				CheckVerifyCodeParameter.application
			};
			string sql = "SELECT * FROM [jirareport].[dbo].[VerifyCode] where consDate >= "+ unixTimeMilliseconds10MinBefore + " and phone = @Parameter0"
				+ " and verifyCode = @Parameter1 and application = @Parameter2 and isUse = '0'";
			DataTable result = m_dbproxy.GetDataCMD( sql, SQLParameterList.ToArray() );
			if(result == null || result.Rows.Count <= 0)
			{
				return false;
			}
			else
			{
				string UpdateSql = "Update [jirareport].[dbo].[VerifyCode] SET isUse = '1'  where consDate >= " + unixTimeMilliseconds10MinBefore + " and phone = @Parameter0"
				+ " and verifyCode = @Parameter1 and application = @Parameter2 and isUse = '0'";
				bool bResult = m_dbproxy.ChangeDataCMD( UpdateSql, SQLParameterList.ToArray() );
				return bResult;
			}
			
		}
		#endregion Internal Methods
	}
}
