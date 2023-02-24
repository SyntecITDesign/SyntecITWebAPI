using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.DecodePW
{
	public class DecodeDatePWParameter : AbstractDecodePWParameter, IValidatableObject
	{
		#region Public Properties

		[Required]
		public string decryptionType
		{
			get; set;
		}

		[Required]
		public int dueDateDetail
		{
			get; set;
		}

		[Required]
		public string timeType
		{
			get; set;
		}

		[Required]
		[StringLength( 4, ErrorMessage = "The length of verfiyCode must be 4", MinimumLength = 4 )]
		public override string verifyCode
		{
			get; set;
		}

		#endregion Public Properties

		#region Public Methods

		public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
		{
			HashSet<string> validTimeType = new HashSet<string> { "Date", "Month", "Unlimit" };
			HashSet<string> validDecrytionType = new HashSet<string> { "Before", "After" };

			//Check timeType & decrytionType properties is valid

			if( !validTimeType.Contains( timeType ) )
				yield return new ValidationResult( $"{nameof( timeType )} parameter error" );

			if( !validDecrytionType.Contains( decryptionType ) )
				yield return new ValidationResult( $"{nameof( validDecrytionType )} parameter error" );

			if( timeType == "Date" && ( dueDateDetail < 1 || dueDateDetail > 155 ) ) //天數需介於1-155
			{
				yield return new ValidationResult( $"{nameof( dueDateDetail )} parameter error, must be between 1 and 155 when timeType is Date" );
			}

			if( timeType == "Month" && ( dueDateDetail < 1 || dueDateDetail > 100 ) )
			{
				yield return new ValidationResult( $"{nameof( dueDateDetail )} parameter error, must be between 1 and 100 when timeType is Month" );
			}
		}

		#endregion Public Methods
	}
}
