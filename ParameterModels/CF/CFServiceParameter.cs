using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace SyntecITWebAPI.ParameterModels.CF
{
	public class CFService_CFSendPdfEmail
	{
		#region Public Properties

		public List<string> pageIDList
		{
			get; set;
		}

		public string content
		{
			get; set;
		}

		public string title
		{
			get; set;
		}

		public string userEmail
		{
			get; set;
		}

		public string Includpage
		{
			get; set;
		}

		#endregion Public Properties

	}

	
	public class Links
	{
		public string webui
		{
			get; set;
		}
		public string self
		{
			get; set;
		}
		public string edit
		{
			get; set;
		}
		public string tinyui
		{
			get; set;
		}
		public string collection
		{
			get; set;
		}
		public string @base
		{
			get; set;
		}
		public string context
		{
			get; set;
		}
	}

	public class Expandable
	{
		public string metadata
		{
			get; set;
		}
		public string icon
		{
			get; set;
		}
		public string description
		{
			get; set;
		}
		public string homepage
		{
			get; set;
		}
		public string status
		{
			get; set;
		}
		public string lastUpdated
		{
			get; set;
		}
		public string previousVersion
		{
			get; set;
		}
		public string contributors
		{
			get; set;
		}
		public string nextVersion
		{
			get; set;
		}
		public string content
		{
			get; set;
		}
		public string container
		{
			get; set;
		}
		public string operations
		{
			get; set;
		}
		public string children
		{
			get; set;
		}
		public string restrictions
		{
			get; set;
		}
		public string ancestors
		{
			get; set;
		}
		public string body
		{
			get; set;
		}
		public string descendants
		{
			get; set;
		}
	}

	public class Space
	{
		public int id
		{
			get; set;
		}
		public string key
		{
			get; set;
		}
		public string name
		{
			get; set;
		}
		public string type
		{
			get; set;
		}
		public Links _links
		{
			get; set;
		}
		public Expandable _expandable
		{
			get; set;
		}
	}

	public class ProfilePicture
	{
		public string path
		{
			get; set;
		}
		public int width
		{
			get; set;
		}
		public int height
		{
			get; set;
		}
		public bool isDefault
		{
			get; set;
		}
	}

	public class CreatedBy
	{
		public string type
		{
			get; set;
		}
		public string username
		{
			get; set;
		}
		public string userKey
		{
			get; set;
		}
		public ProfilePicture profilePicture
		{
			get; set;
		}
		public string displayName
		{
			get; set;
		}
		public Links _links
		{
			get; set;
		}
		public Expandable _expandable
		{
			get; set;
		}
	}

	public class History
	{
		public bool latest
		{
			get; set;
		}
		public CreatedBy createdBy
		{
			get; set;
		}
		public DateTime createdDate
		{
			get; set;
		}
		public Links _links
		{
			get; set;
		}
		public Expandable _expandable
		{
			get; set;
		}
	}

	public class By
	{
		public string type
		{
			get; set;
		}
		public string username
		{
			get; set;
		}
		public string userKey
		{
			get; set;
		}
		public ProfilePicture profilePicture
		{
			get; set;
		}
		public string displayName
		{
			get; set;
		}
		public Links _links
		{
			get; set;
		}
		public Expandable _expandable
		{
			get; set;
		}
	}

	public class Version
	{
		public By by
		{
			get; set;
		}
		public DateTime when
		{
			get; set;
		}
		public string message
		{
			get; set;
		}
		public int number
		{
			get; set;
		}
		public bool minorEdit
		{
			get; set;
		}
		public bool hidden
		{
			get; set;
		}
		public Links _links
		{
			get; set;
		}
		public Expandable _expandable
		{
			get; set;
		}
	}

	public class Extensions
	{
		public string position
		{
			get; set;
		}
	}

	public class CFContent
	{
		public string id
		{
			get; set;
		}
		public string type
		{
			get; set;
		}
		public string status
		{
			get; set;
		}
		public string title
		{
			get; set;
		}
		public Space space
		{
			get; set;
		}
		public History history
		{
			get; set;
		}
		public Version version
		{
			get; set;
		}
		public Extensions extensions
		{
			get; set;
		}
		public Links _links
		{
			get; set;
		}
		public Expandable _expandable
		{
			get; set;
		}
	}



}
