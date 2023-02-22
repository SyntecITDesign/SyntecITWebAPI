using Newtonsoft.Json;
using SyntecITWebAPI.Enums;
using System;

namespace SyntecITWebAPI.Common
{
	public struct ResponseStruct
	{
		#region Public Properties

		[JsonProperty( "code" )]
		public uint Code
		{
			get; set;
		}

		[JsonProperty( "content" )]
		public dynamic Content
		{
			get; set;
		}

		[JsonProperty( "detail" )]
		public string Detail
		{
			get; set;
		}

		[JsonProperty( "message" )]
		public string Message
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class ResponseHandler
	{
		#region Public Properties

		//default
		public ErrorCodeList Code { get; set; } = ErrorCodeList.Success;

		public dynamic Content { get; set; } = null;
		public string Detail { get; set; } = string.Empty;

		#endregion Public Properties

		#region Public Constructors + Destructors

		public ResponseHandler()
		{
		}

		public ResponseHandler( ErrorCodeList code )
		{
			this.Code = code;
		}

		#endregion Public Constructors + Destructors

		#region Public Methods

		public ResponseStruct GetResult()
		{
			return new ResponseStruct
			{
				Code = (uint)this.Code,
				Message = Enum.GetName( typeof( ErrorCodeList ), this.Code ),
				Detail = this.Detail,
				Content = this.Content
			};
		}

		#endregion Public Methods
	}
}
