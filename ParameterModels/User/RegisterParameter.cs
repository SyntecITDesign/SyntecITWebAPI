using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.User
{
	public class RegisterParameter
	{
		#region Public Properties

		[Required]
		public string companyAddress
		{
			get; set;
		}

		[Required]
		public string companyName
		{
			get; set;
		}

		public string CreateDate
		{
			get; set;
		}

		// 尚未被新代管理者認證
		public int inUse { get; set; } = 0;

		// 機械廠母帳號
		public int isMother { get; set; } = 1;

		public int isNotifyMother { get; set; } = 1;

		[Required]
		public string machineCode
		{
			get; set;
		}

		//統一為5表示 機械廠
		public int orgType { get; set; } = 5;

		public int pwchanged { get; set; } = -1;

		// 尚未信箱驗證
		public int status { get; set; } = 0;

		//為首頁申請 不進DB
		public int type { get; set; } = 1;

		[Required]
		public string userEmail
		{
			get; set;
		}

		[Required]
		public string userID
		{
			get; set;
		}

		public string userLine { get; set; } = null;

		[Required]
		public string userName
		{
			get; set;
		}

		[Required]
		public string userPassword
		{
			get; set;
		}

		[Required]
		public string userPhone
		{
			get; set;
		}

		public string userQQ { get; set; } = null;
		public string userSkype { get; set; } = null;
		public string userWeChat { get; set; } = null;
		public string verifyCode { get; set; } = null;

		#endregion Public Properties

		//機械廠
	}
}
