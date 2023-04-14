using SyntecITWebAPI.Interface;
using SyntecITWebAPI.Models.Decode.SecretDLL;
using SyntecITWebAPI.ParameterModels.DecodePW;

namespace SyntecITWebAPI.Models.Decode.DecodeFunction
{
	internal class GeneratePwdV1Function : AbstractUseDLL, IDecodePWFunction
	{
		#region Public Methods

		string IDecodePWFunction.Execute( AbstractDecodePWParameter parameter )
		{
			return secretDLL.DLLGeneratePwdV1( (GeneratePwdV1Parameter)parameter );
		}

		#endregion Public Methods

		#region Internal Constructors + Destructors

		internal GeneratePwdV1Function( ISecretDLL secretDLL ) : base( secretDLL )
		{
			this.secretDLL = secretDLL;
		}

		#endregion Internal Constructors + Destructors
	}
}
