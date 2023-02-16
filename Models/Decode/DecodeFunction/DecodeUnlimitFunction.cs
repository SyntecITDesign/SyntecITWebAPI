using SyntecITWebAPI.Interface;
using SyntecITWebAPI.Models.Decode.SecretDLL;
using SyntecITWebAPI.ParameterModels.DecodePW;

namespace SyntecITWebAPI.Models.Decode.DecodeFunction
{
	internal class DecodeUnlimitFunction : AbstractUseDLL, IDecodePWFunction
	{
		#region Public Methods

		string IDecodePWFunction.Execute( AbstractDecodePWParameter parameter )
		{
			return secretDLL.DLLGenerateDecodeUnlimitPW( (DecodeDatePWParameter)parameter );
		}

		#endregion Public Methods

		#region Internal Constructors + Destructors

		internal DecodeUnlimitFunction( ISecretDLL secretDLL ) : base( secretDLL )
		{
			this.secretDLL = secretDLL;
		}

		#endregion Internal Constructors + Destructors
	}
}
