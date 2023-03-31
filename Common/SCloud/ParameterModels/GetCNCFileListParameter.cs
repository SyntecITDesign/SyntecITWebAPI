using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SyntecITWebAPI.Common
{
	public enum FileListOrderByItem
	{
		FileTime,
		FileSize
	}

	public enum SearchOrderRule
	{
		DESC,
		ASC
	}

	public class GetCNCFileListParameter : IAPIParameter, IInternalAPIParameter
	{
		#region Public Properties

		// without get & set property, we could not use reflection to find the value
		public string AccessToken
		{
			get; set;
		}

		public string BrandInfo
		{
			get; set;
		}

		public double? EndTime
		{
			get; set;
		}

		public string FileType
		{
			get; set;
		}

		public int? Number
		{
			get; set;
		}

		public FileListOrderByItem OrderBy
		{
			get; set;
		} = FileListOrderByItem.FileTime;

		public SearchOrderRule OrderRule
		{
			get; set;
		} = SearchOrderRule.DESC;

		public string SerialNumber
		{
			get; set;
		}

		public int? StartIndex
		{
			get; set;
		}

		public double? StartTime
		{
			get; set;
		}

		#endregion Public Properties

		#region Public Methods

		Uri IInternalAPIParameter.GetDefaultUri( string szURLTemplate )
		{
			szURLTemplate = szURLTemplate.Replace( "<BrandInfo>", BrandInfo );
			szURLTemplate = szURLTemplate.Replace( "<SerialNumber>", SerialNumber );
			szURLTemplate = szURLTemplate.Replace( "<FileType>", FileType );
			return new Uri( szURLTemplate );
		}

		Dictionary<string, string> IInternalAPIParameter.GetHeaders()
		{
			return new Dictionary<string, string>() {
				{ "AccessToken", AccessToken }
			};
		}

		public bool IsDataEnough()
		{
			string[] MustFillAttributes = new string[]{
				"AccessToken",
				"BrandInfo",
				"SerialNumber",
				"FileType",
			};

			foreach( string szAttributeName in MustFillAttributes )
			{
				string szCheck = GetType().GetProperty( szAttributeName ).GetValue( this, null ).ToString();

				if( string.IsNullOrEmpty( szCheck ) )
				{
					return false;
				}
			}

			return true;
		}

		#endregion Public Methods

		#region Internal Methods

		internal string GetJsonStringBody()
		{
			JObject JSONBody = new JObject();
			JSONBody[ "startTime" ] = StartTime;
			JSONBody[ "endTime" ] = EndTime;
			JSONBody[ "number" ] = Number;
			JSONBody[ "startIndex" ] = StartIndex;
			JSONBody[ "orderRule" ] = OrderRule.ToString();
			JSONBody[ "orderBy" ] = OrderBy.ToString();
			return JSONBody.ToString( Formatting.None );
		}

		#endregion Internal Methods
	}
}
