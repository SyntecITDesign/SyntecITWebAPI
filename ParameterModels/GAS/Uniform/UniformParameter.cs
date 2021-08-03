using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.Uniform
{


	public class GetUniformSize
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class UpsertUniformSize
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}
		public string UniformSSSize
		{
			get; set;
		}
		public string UniformSSDate
		{
			get; set;
		}
		public string UniformFWSize
		{
			get; set;
		}
		public string UniformFWDate
		{
			get; set;
		}
		public string JacketSize
		{
			get; set;
		}
		public string JacketDate
		{
			get; set;
		}
		public string SweatShirtSize
		{
			get; set;
		}
		public string SweatShirtDate
		{
			get; set;
		}
		#endregion Public Properties
	}
}
