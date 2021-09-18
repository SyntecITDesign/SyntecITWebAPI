using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.MeetingRoom
{


	public class UpsertMeetingRoom
	{
		#region Public Properties

		public int ID
		{
			get; set;
		}

		public string Floor
		{
			get; set;
		}

		public string MeetingRoom
		{
			get; set;
		}


		#endregion Public Properties
	}

	public class DeleteMeetingRoom
	{
		#region Public Properties


		public int ID
		{
			get; set;
		}


		#endregion Public Properties
	}
}
