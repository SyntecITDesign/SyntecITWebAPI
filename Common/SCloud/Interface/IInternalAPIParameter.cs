using System;
using System.Collections.Generic;

namespace SyntecITWebAPI.Common
{
	internal interface IInternalAPIParameter
	{
		#region Public Methods

		Uri GetDefaultUri( string szURLTemplate );

		Dictionary<string, string> GetHeaders();

		#endregion Public Methods
	}
}
