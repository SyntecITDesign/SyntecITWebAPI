using SyntecITWebAPI.Abstract;
using SyntecITWebAPI.ParameterModels.Mail;
using SyntecITWebAPI.ParameterModels.User;
using System.Collections.Generic;

namespace SyntecITWebAPI.Common.MailRelated.User
{
	internal class RegisterUserMailHandler : AbstractMailHandler
	{
		#region Internal Fields

		internal List<MailParameter> mailParameterList;
		internal RegisterParameter registerParameter = new RegisterParameter();

		#endregion Internal Fields

		#region Internal Constructors + Destructors

		internal RegisterUserMailHandler( List<MailParameter> mailParameterList ) : base( mailParameterList )
		{
			this.mailParameterList = mailParameterList;
		}

		#endregion Internal Constructors + Destructors

		#region Protected Methods

		protected override string GetContent( MailParameter mailParameter )
		{
			string mailContent = "我們將有專人和您聯絡並儘快處理權限事宜<br><br>請確認以下註冊資料並至認證網址驗證：<br><br>";
			mailContent += $"帳號 : {mailParameter.mailAttachParameter[ nameof( registerParameter.userID ) ]} <br>";
			mailContent += $"密碼 : {mailParameter.mailAttachParameter[ nameof( registerParameter.userPassword ) ]} <br>";
			mailContent += $"姓名 : {mailParameter.mailAttachParameter[ nameof( registerParameter.userName ) ]} <br>";
			mailContent += $"機械廠代碼 : {mailParameter.mailAttachParameter[ nameof( registerParameter.machineCode ) ]} <br>";
			mailContent += $"公司名稱 : {mailParameter.mailAttachParameter[ nameof( registerParameter.companyName ) ]} <br>";
			mailContent += $"公司地址 : {mailParameter.mailAttachParameter[ nameof( registerParameter.companyAddress ) ]} <br>";
			mailContent += $"Email : {mailParameter.mailAttachParameter[ nameof( registerParameter.userEmail ) ]} <br>";
			mailContent += $"TEL : {mailParameter.mailAttachParameter[ nameof( registerParameter.userPhone ) ]} <br>";
			mailContent += $"認證網址 : <a href={ mailParameter.mailAttachParameter[ "url" ]}>由此進入</a><br> ";
			mailContent += $"如有任何疑問請來電：<br>";
			mailContent += $"台灣: 03-5612031 分機 123 負責人 蔡小姐<br>";
			mailContent += $"大陸:0512-69008860 分機 2603 負責人 鄭小姐<br>";

			return mailContent;
		}

		protected override string GetTitle( MailParameter mailParameter )
		{
			string mailTitle = "新代解密網站感謝您的註冊";
			return mailTitle;
		}

		#endregion Protected Methods
	}
}
