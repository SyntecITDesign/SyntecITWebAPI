using SyntecITWebAPI.Interface;
using SyntecITWebAPI.Models.Decode.SecretDLL;
using SyntecITWebAPI.ParameterModels.DecodePW;

namespace SyntecITWebAPI.Models.Decode.DecodeFunction
{
	internal class DecodeDateFunction : AbstractUseDLL, IDecodePWFunction
	{
		#region Public Methods

		string IDecodePWFunction.Execute( AbstractDecodePWParameter parameter )
		{
			//do SyntecValidity
			return secretDLL.DLLGenerateDecodeDatePW( (DecodeDatePWParameter)parameter );
		}

		#endregion Public Methods

		#region Internal Constructors + Destructors

		internal DecodeDateFunction( ISecretDLL secretDLL ) : base( secretDLL )
		{
			this.secretDLL = secretDLL;
		}

		#endregion Internal Constructors + Destructors
	}
}
