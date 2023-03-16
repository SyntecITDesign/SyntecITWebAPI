using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.DecodePW
{
	public class GeneratePwdV1Parameter : AbstractGeneratePwdParameter
	{
		#region Public Properties

		[Required]
		[StringLength( 4, ErrorMessage = "The length of verfiyCode in GeneratePwdV1 must be 4", MinimumLength = 4 )]
		public override string verifyCode
		{
			get; set;
		}

		#endregion Public Properties

		//error
	}
}
