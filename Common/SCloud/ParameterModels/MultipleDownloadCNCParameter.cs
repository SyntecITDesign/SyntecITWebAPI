using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SyntecITWebAPI.Common
{
	public class MultipleDownloadCNCParameter : IAPIParameter, IInternalAPIParameter
	{
		#region Public Properties

		public string AccessToken
		{
			get; set;
		}

		public string BrandInfo
		{
			get; set;
		}

		public string FileExtension
		{
			get; set;
		}

		public string FileName
		{
			get; set;
		}

		public List<string> FileNames
		{
			get; set;
		}

		public string FileType
		{
			get; set;
		}

		public string SerialNumber
		{
			get; set;
		}

		#endregion Public Properties

		#region Public Constructors + Destructors

		public MultipleDownloadCNCParameter()
		{
			//Default value setting
			FileExtension = "zip";
			FileName = "MultipleDownoadTemp";
		}

		#endregion Public Constructors + Destructors

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
				{ "AccessToken", AccessToken },
			};
		}

		public bool IsDataEnough()
		{
			string[] MustFillAttributes = new string[]{
				"AccessToken",
				"BrandInfo",
				"SerialNumber",
				"FileType",
				"FileName",
				"FileExtension",
			};

			foreach( string szAttributeName in MustFillAttributes )
			{
				string szCheck = GetType().GetProperty( szAttributeName ).GetValue( this, null ).ToString();

				if( string.IsNullOrEmpty( szCheck ) )
				{
					return false;
				}
			}

			if( FileNames.Count <= 0 )
			{
				return false;
			}

			return true;
		}

		#endregion Public Methods

		#region Internal Methods

		internal string GetJsonStringBody()
		{
			JObject JSONBody = new JObject();
			JSONBody[ "fileNames" ] = JArray.FromObject( FileNames.ToArray() );
			return JSONBody.ToString( Formatting.None );
		}

		#endregion Internal Methods
	}
}
