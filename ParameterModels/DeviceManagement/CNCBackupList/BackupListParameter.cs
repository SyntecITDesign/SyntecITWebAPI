using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.DeviceManangement
{
	public class BackupListParameter : IValidatableObject
	{
		#region Public Properties

		[Required]
		public string fileType
		{
			get; set;
		}

		[Required]
		public string productSN
		{
			get; set;
		}

		public string userID
		{
			get; set;
		}

		#endregion Public Properties

		#region Public Methods

		public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
		{
			HashSet<string> validFileType = new HashSet<string> { FILETYPE_SB, FILETYPE_MB, FILETYPE_NC };

			if( !validFileType.Contains( fileType.Trim() ) )
				yield return new ValidationResult( $"{nameof( fileType )} parameter error" );
		}

		#endregion Public Methods

		#region Internal Fields

		internal const string FILETYPE_MB = "MBFile";
		internal const string FILETYPE_NC = "NCFile";
		internal const string FILETYPE_SB = "SBFile";

		#endregion Internal Fields
	}
}
