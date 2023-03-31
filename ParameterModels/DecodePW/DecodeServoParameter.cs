using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.DecodePW
{
	public class DecodeServoParameter : AbstractDecodePWParameter, IValidatableObject
	{
		#region Public Properties

		[Required]
		public override string customerName
		{
			get; set;
		}

		[Required]
		public override string requestContent
		{
			get; set;
		}

		[Required]
		public override string requestPerson
		{
			get; set;
		}

		[Required]
		public string spcSN
		{
			get; set;
		}

		[Required]
		public override string subCompany
		{
			get; set;
		}

		[Required]
		public int versionSN
		{
			get; set;
		}

		#endregion Public Properties

		#region Public Methods

		public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
		{
			HashSet<string> validRequestContent = new HashSet<string> { "Modify motor parameter", "Modify enoder parameter", "others" };

			if( !validRequestContent.Contains( requestContent.Trim() ) )
				yield return new ValidationResult( $"{nameof( requestContent )} parameter error" );

			if( requestContent == "others".Trim() )
			{
				if( string.IsNullOrEmpty( remark ) )
				{
					yield return new ValidationResult( $"{nameof( remark )} parameter error, can't be empty when requestContent is others" );
				}
			}
		}

		#endregion Public Methods
	}
}
