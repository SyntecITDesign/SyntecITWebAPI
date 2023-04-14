using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.DecodePW
{
	public class DecodeHWParameter : AbstractDecodePWParameter
	{
		#region Public Properties

		[Required]
		[StringLength( 4, ErrorMessage = "The length of verfiyCode must be 4", MinimumLength = 4 )]
		public override string verifyCode
		{
			get; set;
		}

		#endregion Public Properties
	}
}
