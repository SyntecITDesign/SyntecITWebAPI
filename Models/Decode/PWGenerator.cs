using SyntecITWebAPI.Interface;
using SyntecITWebAPI.ParameterModels.DecodePW;

namespace SyntecITWebAPI.Models.Decode
{
	internal class PWGenerator
	{
		#region Internal Constructors + Destructors

		internal PWGenerator( IDecodePWFunction decodePWFunction )
		{
			this.decodePWFunction = decodePWFunction;
		}

		#endregion Internal Constructors + Destructors

		#region Internal Methods

		internal string Generate( AbstractDecodePWParameter abstractDecodePWParameter )
		{
			return decodePWFunction.Execute( abstractDecodePWParameter );
		}

		#endregion Internal Methods

		#region Private Fields

		private IDecodePWFunction decodePWFunction;

		#endregion Private Fields
	}
}
