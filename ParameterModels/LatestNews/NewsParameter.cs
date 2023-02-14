using System;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.LatestNews
{
	public class NewsParameter
	{
		#region Public Properties

		[Required]
		public string description
		{
			get; set;
		}

		public int index
		{
			get; set;
		}

		[Required]
		public string title
		{
			get; set;
		}

		public long updateTime { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

		#endregion Public Properties
	}
}
