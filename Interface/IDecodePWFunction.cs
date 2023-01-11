using SyntecITWebAPI.ParameterModels.DecodePW;

namespace SyntecITWebAPI.Interface
{
	internal interface IDecodePWFunction
	{
		#region Public Methods

		string Execute( AbstractDecodePWParameter parameter );

		#endregion Public Methods
	}
}
