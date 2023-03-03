using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.Common.DBRelated.DBManagers;
using SyntecITWebAPI.ParameterModels.Mail;
using System.Collections.Generic;

namespace SyntecITWebAPI.Common.MailRelated
{
	internal class ForgotPasswordMailHandler : AbstractMailHandler
	{
		#region Internal Fields

		internal List<MailParameter> mailParameterList;

		#endregion Internal Fields

		#region Internal Constructors + Destructors

		internal ForgotPasswordMailHandler( List<MailParameter> mailParameterList ) : base( mailParameterList )
		{
			this.mailParameterList = mailParameterList;
		}

		#endregion Internal Constructors + Destructors

		#region Protected Methods

		protected override string GetContent( MailParameter mailParameter )
		{
			mailParameter.userName = m_dbManager.GetOptionUserNameByID( mailParameter.userID );
			string mailContent = "";
			switch( mailParameter.userLang )
			{
				case "en-US":
					mailContent = $"Dear {mailParameter.userName}：<br><br>";
					mailContent += "Your password is already reseted. Please enter the link to comfirm it.<br>";
					mailContent += "<br>";
					mailContent += $"Please go to follow page to modify password <a href=\"{mailParameter.mailAttachParameter[ "url" ] }\"> Modify link </a> <br><br>";
					mailContent += "Cheers,<br>Syntec<br>";
					mailContent += "This is SystemMail. Do not reply directly.<br>";
					mailContent += "-------------------------------------------------------------<br><br>";
					mailContent += "<br>";
					mailContent += "SYNTEC TECHNOLOGY CO., LTD.<br><br>";

					mailContent += "<br>";
					mailContent += "No. 21 Industry E. Rd. 4, Hsinchu Science Park, Hsinchu City 30077, Taiwan, ROC<br><br>";

					mailContent += "http://www.syntecclub.com.tw<br>";
					mailContent += "TEL: +886-3-666-3553<br>";
					mailContent += "FAX: +886-3-666-3505<br>";

					break;

				case "zh-TW":

					mailContent = $"親愛的{mailParameter.userName}您好：<br><br>";
					mailContent += "您的密碼已經重新設定好囉，請立即點擊以下連結並重新輸入您的新密碼<br>";
					mailContent += "建議您妥善保存密碼以免權益受損<br><br>";
					mailContent += $"請點擊連結修改密碼 <a href=\"{mailParameter.mailAttachParameter[ "url" ]}\"> 修改密碼 </a> <br><br>";
					mailContent += "祝順心<br>新代科技<br>";
					mailContent += "此為系統自動寄發，請勿直接回信，請見諒<br>";
					mailContent += "-------------------------------------------------------------<br><br>";
					mailContent += "新代科技股份有限公司<br>";
					mailContent += "最值得信任的電控夥伴<br><br>";

					mailContent += "新竹科學園區研發二路25號<br>";

					mailContent += "http://www.syntecclub.com<br>";
					mailContent += "TEL: +886-3-666-3553<br>";
					mailContent += "FAX: +886-3-666-3505<br>";

					break;

				case "zh-CN":
					mailContent = $"亲爱的{mailParameter.userName}您好：<br><br>";
					mailContent += "您的密码已经重新设定好啰，请立即点击以下连结并重新输入您的新密码<br>";
					mailContent += "建议您妥善保存密码以免权益受损<br><br>";
					mailContent += $"请点击连结修改密码 <a href=\"{mailParameter.mailAttachParameter[ "url" ]}\"> 修改密码 </a><br><br>";
					mailContent += "祝顺心<br>新代科技<br>";
					mailContent += "此为系统自动寄发，请勿直接回信，请见谅<br>";
					mailContent += "---------------------------------------------- ---------------<br><br>";
					mailContent += "新代科技股份有限公司<br>";
					mailContent += "值得信任的电控夥伴<br><br>";

					mailContent += "蘇州市工業園區春輝路9號一號廠房2樓<br>";

					mailContent += "http://www.syntecclub.com<br>";
					mailContent += "TEL: +86-13962170079<br>";

					break;

				default:
					mailContent = $"親愛的{mailParameter.userName}您好：<br><br>";
					mailContent += "您的密碼已經重新設定好囉，請立即點擊以下連結並重新輸入您的新密碼<br>";
					mailContent += "建議您妥善保存密碼以免權益受損<br><br>";
					mailContent += $"請點擊連結修改密碼 <a href=\"{mailParameter.mailAttachParameter[ "url" ]}\"> 修改密碼 </a> <br><br>";
					mailContent += "祝順心<br>新代科技<br>";
					mailContent += "此為系統自動寄發，請勿直接回信，請見諒<br>";
					mailContent += "-------------------------------------------------------------<br><br>";
					mailContent += "新代科技股份有限公司<br>";
					mailContent += "最值得信任的電控夥伴<br><br>";

					mailContent += "新竹科學園區研發二路25號<br>";

					mailContent += "http://www.syntecclub.com<br>";
					mailContent += "TEL: +886-3-666-3553<br>";
					mailContent += "FAX: +886-3-666-3505<br>";
					break;
			}
			return mailContent;
		}

		protected override string GetTitle( MailParameter mailParameter )
		{
			string mailTitle = "";
			switch( mailParameter.userLang )
			{
				case "en-US":
					mailTitle = "Syntec PasswordSite reset Password notice";
					break;

				case "zh-TW":
					mailTitle = "新代科技解密網站 密碼重設通知";
					break;

				case "zh-CN":
					mailTitle = "新代科技解密网站 密码重设通知";
					break;

				default:
					mailTitle = "新代科技解密網站 密碼重設通知";
					break;
			}
			return mailTitle;
		}

		#endregion Protected Methods

		#region Private Fields

		private UserDBManager m_dbManager = new UserDBManager();

		#endregion Private Fields
	}
}
