using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.DecodePW
{
	public class DecodeResetParameter : AbstractDecodePWParameter, IValidatableObject
	{
		#region Public Properties

		[Required]
		public string decodeRightType
		{
			get; set;
		}

		public new string productSN { get; set; } = null;

		#endregion Public Properties

		#region Public Methods

		public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
		{
			HashSet<string> validDecodeRightType = new HashSet<string> { RIGHTTYPE_SYNTEC, RIGHTTYPE_MACHINECOMPANY, RIGHTTYPE_ENDCUSTOMER };

			if( !validDecodeRightType.Contains( decodeRightType.Trim() ) )
			{
				yield return new ValidationResult( $"{nameof( decodeRightType )} parameter error" );
			}
		}

		#endregion Public Methods

		#region Internal Fields

		internal const string RIGHTTYPE_ENDCUSTOMER = "endCustomer";
		internal const string RIGHTTYPE_MACHINECOMPANY = "machineCompany";
		internal const string RIGHTTYPE_SYNTEC = "syntec";

		#endregion Internal Fields
	}
}
