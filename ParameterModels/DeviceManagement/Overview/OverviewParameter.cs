using System;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.DeviceManangement.Overview
{
	public enum OverviewQueryType
	{
		registDate,
		WarrantyDate
	}

	public class OverviewParameter
	{
		#region Public Properties

		public string customerName
		{
			get; set;
		} = null;

		public long? queryEndTime
		{
			get; set;
		} = null;

		[Range( 1, 200 )]
		public int queryMaxNumber
		{
			get; set;
		} = 10;

		public int queryStartIndex
		{
			get; set;
		} = 0;

		public long? queryStartTime
		{
			get; set;
		} = null;

		[Required]
		public OverviewQueryType queryType
		{
			get; set;
		}

		public string userID
		{
			get; set;
		}

		#endregion Public Properties
	}
}
