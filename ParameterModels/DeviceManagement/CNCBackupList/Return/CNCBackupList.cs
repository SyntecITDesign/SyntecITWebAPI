using System.Collections.Generic;

namespace SyntecITWebAPI.ParameterModels.DeviceManangement
{
	public class CNCBackupList
	{
		#region Public Properties

		public List<SingleFileData> dataList
		{
			get; set;
		}

		public int totalCount
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class SingleFileData
	{
		#region Public Properties

		public string fileExtension
		{
			get; set;
		}

		public string fileName
		{
			get; set;
		}

		public double fileSize
		{
			get; set;
		}

		public long fileTime
		{
			get; set;
		}

		#endregion Public Properties
	}
}
