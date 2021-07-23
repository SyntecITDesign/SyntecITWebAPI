using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.DecodePW
{
	public class AbstractDecodePWParameter
	{
		#region Public Properties

		public virtual string customerName
		{
			get; set;
		}

		[Required]
		public virtual string productSN
		{
			get; set;
		}

		public virtual string remark
		{
			get; set;
		}

		public virtual string requestContent
		{
			get; set;
		}

		public virtual string requestPerson
		{
			get; set;
		}

		public virtual string subCompany
		{
			get; set;
		}

		public virtual string userID
		{
			get; set;
		}

		[Required]
		public virtual string verifyCode
		{
			get; set;
		}

		#endregion Public Properties
	}
}
