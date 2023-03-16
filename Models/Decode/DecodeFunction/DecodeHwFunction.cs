using SyntecITWebAPI.Interface;
using SyntecITWebAPI.Models.Decode.SecretDLL;
using SyntecITWebAPI.ParameterModels.DecodePW;

namespace SyntecITWebAPI.Models.Decode.DecodeFunction
{
	internal class DecodeHwFunction : AbstractUseDLL, IDecodePWFunction
	{
		#region Public Methods

		string IDecodePWFunction.Execute( AbstractDecodePWParameter parameter )
		{
			return secretDLL.DLLGenerateDecodeHardWarePW( (DecodeHWParameter)parameter );
		}

		#endregion Public Methods

		#region Internal Constructors + Destructors

		internal DecodeHwFunction( ISecretDLL secretDLL ) : base( secretDLL )
		{
			this.secretDLL = secretDLL;
		}

		#endregion Internal Constructors + Destructors
	}
}
