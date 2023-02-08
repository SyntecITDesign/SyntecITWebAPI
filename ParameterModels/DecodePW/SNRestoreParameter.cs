using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.DecodePW
{
	public class SNRestoreParameter : AbstractDecodePWParameter
	{
		#region Public Properties

		[Required]
		public int axis
		{
			get; set;
		}

		[Required]
		public string cncType
		{
			get; set;
		}

		[Required]
		public string machineModel
		{
			get; set;
		}

		[Required]
		public decimal optionNum
		{
			get; set;
		}

		#endregion Public Properties
	}
}
