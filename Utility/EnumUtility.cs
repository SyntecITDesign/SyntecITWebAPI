using System;
using System.ComponentModel;
using System.Reflection;

namespace SyntecITWebAPI.Utility
{
	public static class EnumUtility
	{
		#region Public Methods

		// 取得 Enum 列舉 Attribute Description 設定值
		public static string GetDescriptionText( this Enum source )
		{
			FieldInfo fi = source.GetType().GetField( source.ToString() );
			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
			 typeof( DescriptionAttribute ), false );
			if( attributes.Length > 0 )
				return attributes[ 0 ].Description;
			else
				return source.ToString();
		}

		#endregion Public Methods
	}
}
