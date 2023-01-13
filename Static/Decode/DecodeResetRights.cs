using SyntecITWebAPI.Enums;
using SyntecITWebAPI.ParameterModels.DecodePW;
using System.Collections.Generic;

namespace SyntecITWebAPI.Static
{
	internal class DecodeResetRights
	{
		#region Internal Fields

		internal static HashSet<string> MACHINECOMPANY_VALID_RESET_RIGHTS = new HashSet<string> { DecodeResetParameter.RIGHTTYPE_MACHINECOMPANY };

		// 新代體系 => 可以重置 1.新代 2.機械廠 3.終端 權限 機械廠體系 => 只能重置 機械廠 終端用戶體系 => 只能重置 終端用戶
		internal static HashSet<string> SYNTEC_VALID_RESET_RIGHTS = new HashSet<string> { DecodeResetParameter.RIGHTTYPE_SYNTEC, DecodeResetParameter.RIGHTTYPE_MACHINECOMPANY, DecodeResetParameter.RIGHTTYPE_ENDCUSTOMER };

		internal static HashSet<string> USER_VALID_RESET_RIGHTS = new HashSet<string> { DecodeResetParameter.RIGHTTYPE_ENDCUSTOMER };

		#endregion Internal Fields

		#region Internal Methods

		// 組織代碼0~3 => 新代體系 組織代碼5 => 機械廠體系 組織代碼6 => 終端用戶體系
		internal static HashSet<string> ORG_CODE_TO_RESET_RIGHTS( SyntecOrganizationList orgCode )
		{
			switch( orgCode )
			{
				case SyntecOrganizationList.Headquarters:
					return SYNTEC_VALID_RESET_RIGHTS;

				case SyntecOrganizationList.Advance_Branch:
					return SYNTEC_VALID_RESET_RIGHTS;

				case SyntecOrganizationList.Branch:
					return SYNTEC_VALID_RESET_RIGHTS;

				case SyntecOrganizationList.Dealer:
					return SYNTEC_VALID_RESET_RIGHTS;

				case SyntecOrganizationList.Machine_Manufacturer:
					return MACHINECOMPANY_VALID_RESET_RIGHTS;

				case SyntecOrganizationList.Machine_Manufacturer_Branch:
					return MACHINECOMPANY_VALID_RESET_RIGHTS;

				case SyntecOrganizationList.End_User:
					return USER_VALID_RESET_RIGHTS;

				default:
					return null;
			}
		}

		#endregion Internal Methods
	}
}
