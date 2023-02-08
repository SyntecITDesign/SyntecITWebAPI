using Microsoft.AspNetCore.Mvc;
using System;

namespace SyntecITWebAPI.Filter
{
	[AttributeUsage( AttributeTargets.Class | AttributeTargets.Method )]
	public sealed class NoCacheAttribute : ResponseCacheAttribute
	{
		#region Public Constructors + Destructors

		public NoCacheAttribute()
		{
			Duration = 0;
			NoStore = true;
			Location = ResponseCacheLocation.None;
		}

		#endregion Public Constructors + Destructors
	}
}
