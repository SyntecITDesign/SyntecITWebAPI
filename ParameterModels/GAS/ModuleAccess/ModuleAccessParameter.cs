using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.ModuleAccess
{


	public class GetModuleAccess
	{
		#region Public Properties

		public string ModuleAccessModule
		{
			get; set;
		}
		public string ModuleAccessPageName
		{
			get; set;
		}
		public string ModuleAccessPageLink
		{
			get; set;
		}
		public string ModuleAccessAccessRightDeptNo
		{
			get; set;
		}
		public string ModuleAccessAccessRightEmpID
		{
			get; set;
		}
		public string ModuleAccessMemo
		{
			get; set;
		}
		#endregion Public Properties
	}

	
}
