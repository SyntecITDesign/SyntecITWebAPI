using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.LogTable
{


	public class InsertLogTable
	{
		#region Public Properties

		public string EmpID
		{
			get; set;
		}
		public string ExecuteTime
		{
			get; set;
		}
		public string Module
		{
			get; set;
		}
		public string ModuleParameter
		{
			get; set;
		}
		public string Action
		{
			get; set;
		}
		public string Memo
		{
			get; set;
		}

		#endregion Public Properties
	}

}
