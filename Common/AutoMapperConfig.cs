using AutoMapper;
using System.Reflection;

namespace SyntecITWebAPI.Common
{
	internal class AutoMapperConfig
	{
		#region Internal Properties

		internal static MapperConfiguration Instance
		{
			get
			{
				if( m_instance == null )
				{
					m_instance = new MapperConfiguration( cfg =>
					{
						cfg.AddMaps( Assembly.GetExecutingAssembly() );
					} );
				}
				return m_instance;
			}
		}

		#endregion Internal Properties

		#region Private Fields

		private static MapperConfiguration m_instance = null;

		#endregion Private Fields

		#region Private Constructors + Destructors

		private AutoMapperConfig()
		{
		}

		#endregion Private Constructors + Destructors
	}
}
