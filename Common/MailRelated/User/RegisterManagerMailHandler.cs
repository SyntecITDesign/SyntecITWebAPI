using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.Mail;
using SyntecITWebAPI.ParameterModels.User;
using System.Collections.Generic;

namespace SyntecITWebAPI.Common.MailRelated.User
{
	internal class RegisterManagerMailHandler : AbstractMailHandler
	{
		#region Internal Fields

		internal List<MailParameter> mailParameterList;
		internal RegisterParameter registerParameter = new RegisterParameter();

		#endregion Internal Fields

		#region Internal Constructors + Destructors

		internal RegisterManagerMailHandler( List<MailParameter> mailParameterList ) : base( mailParameterList )
		{
			this.mailParameterList = mailParameterList;
		}

		#endregion Internal Constructors + Destructors

		#region Protected Methods

		protected override string GetContent( MailParameter mailParameter )
		{
			string mailContent = $"親愛的 {mailParameter.userName} 您好<br><br>";
			mailContent += "有一位新使用者申請加入新代解密網站機械廠管理員,請儘快確認相關事宜並開通權限:管理功能->人員角色管理 <br>";
			mailContent += $" 帳號： {mailParameter.mailAttachParameter[ nameof( registerParameter.userID ) ]} <br>";
			mailContent += $" 姓名： {mailParameter.mailAttachParameter[ nameof( registerParameter.userName ) ]} <br>";
			mailContent += $" 機械廠代碼：{mailParameter.mailAttachParameter[ nameof( registerParameter.machineCode ) ]} <br>";
			mailContent += $"公司名稱： {mailParameter.mailAttachParameter[ nameof( registerParameter.companyName ) ]} <br>";
			mailContent += $"公司地址： {mailParameter.mailAttachParameter[ nameof( registerParameter.companyAddress ) ]} <br>";
			mailContent += $"Email： {mailParameter.mailAttachParameter[ nameof( registerParameter.userEmail ) ]} <br>";
			mailContent += $"TEL： {mailParameter.mailAttachParameter[ nameof( registerParameter.userPhone ) ]} <br>";
			mailContent += "<br>謝謝<br>";

			return mailContent;
		}

		protected override string GetTitle( MailParameter mailParameter )
		{
			string mailTitle = "新代科技解密網站 新註冊用戶通知";
			return mailTitle;
		}

		#endregion Protected Methods
	}
}
