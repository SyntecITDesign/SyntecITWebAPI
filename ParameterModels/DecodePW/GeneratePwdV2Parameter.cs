using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.DecodePW
{
	public class GeneratePwdV2Parameter : AbstractGeneratePwdParameter
	{
		#region Public Properties

		public int cloudDecode { get; set; } = 0;

		[Required]
		public string userLang
		{
			get; set;
		}

		//1為線上解密 預設為0

		[Required]
		[StringLength( 7, ErrorMessage = "The length of verfiyCode in GeneratePwdV2 must be between 7 and 4", MinimumLength = 4 )]
		public override string verifyCode
		{
			get; set;
		}

		#endregion Public Properties
	}
}
