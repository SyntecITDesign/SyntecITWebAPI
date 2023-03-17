using System.ComponentModel;

namespace SyntecITWebAPI.Enums
{
	public enum SyntecOrganizationList
	{
		//ref : https://confluence.syntecclub.com.tw/x/BIJhIg

		[Description( "0A" )]
		Headquarters = 0,

		[Description( "1A" )]
		Advance_Branch = 1,

		[Description( "2A" )]
		Branch = 2,

		[Description( "3A" )]
		Dealer = 3,

		[Description( "4A" )]
		Cooperation_Manufacturer = 4,

		[Description( "5A" )]
		Machine_Manufacturer = 5,

		[Description( "5B" )]
		Machine_Manufacturer_Branch = 6,

		[Description( "6A" )]
		End_User = 7,
	}
}
