﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntecITWebAPI.ParameterModels.GAS.CarBooking
{

	

	public class UpsertCarInfo
	{
		#region Public Properties
		public string CarID
		{
			get; set;
		}
		public string CarNumber
		{
			get; set;
		}
		public string Model
		{
			get; set;
		}
		public string Seats
		{
			get; set;
		}
		public string BuyYear
		{
			get; set;
		}
		public string Type
		{
			get; set;
		}
		public string Gas
		{
			get; set;
		}
		public string Engine
		{
			get; set;
		}
		public string InsuranceStart
		{
			get; set;
		}
		public string InsuranceEnd
		{
			get; set;
		}
		public string Belongs
		{
			get; set;
		}
		public string CanRent
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class DelCarInfo
	{
		#region Public Properties
		public string CarID
		{
			get; set;
		}
		

		#endregion Public Properties
	}

	public class UpdateCarTakeInfo
	{
		#region Public Properties
		public string EmpID
		{
			get; set;
		}
		public string CarNumber
		{
			get; set;
		}
		public string AcutalStartTime
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class GetCarLastBackInfo
	{
		#region Public Properties
		
		public string CarNumber
		{
			get; set;
		}
		
		#endregion Public Properties
	}

	public class UpdateCarBackInfo
	{
		#region Public Properties
		public string EmpID
		{
			get; set;
		}
		public string CarNumber
		{
			get; set;
		}
		public string StartMile
		{
			get; set;
		}

		public string EndMile
		{
			get; set;
		}

		public string ErrorMemo
		{
			get; set;
		}
		public string AcutalEndTime
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class InserBlackListInfo
	{
		#region Public Properties
		public string EmpID
			{ get;set;
			}
		public string Reason
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class BlacktoWhite
	{
		#region Public Properties
		public string EmpID
		{
			get; set;
		}
	
		#endregion Public Properties
	}

	public class UpsertCarRepairFrequency
	{
		#region Public Properties
		public string id
		{
			get; set;
		}
		public string CarNumber
		{
			get; set;
		}

		public string Frequency
		{
			get; set;
		}
		public string Memo
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class DeleteCarRepairFrequency
	{
		#region Public Properties
		public string id
		{
			get; set;
		}
		
		#endregion Public Properties
	}

	public class UpsertCarRepairRecord
	{
		#region Public Properties
		public string id
		{
			get; set;
		}
		public string CarNumber
		{
			get; set;
		}

		public string RecordMonth
		{
			get; set;
		}
		public string Memo
		{
			get; set;
		}
		public string FileName
		{
			get; set;
		}
		public string ReordID
		{
			get; set;
		}
		public string Cost
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class UpsertCarFavoriteLink
	{
		#region Public Properties
		
		public string WebName
		{
			get; set;
		}

		public string WebLink
		{
			get; set;
		}
	
		#endregion Public Properties
	}

	public class DelCarFavoriteLink
	{
		#region Public Properties
		public string id
		{
			get; set;
		}
	
		#endregion Public Properties
	}

	public class UpsertCarInsurance
	{
		#region Public Properties

		public string CarID
		{
			get; set;
		}
		public string CarNumber
		{
			get; set;
		}
		public string InsuranceStart
		{
			get; set;
		}
		public string InsuranceEnd
		{
			get;set;
		}
		public string InsuranceType
		{
			get; set;
		}
		public string InsuranceMoney
		{
			get; set;
		}
		public string SelfPay
		{
			get; set;
		}
		public string InsuranceCost
		{
			get; set;
		}
		public string InsuranceFileName
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class DelCarInsurance
	{
		#region Public Properties
		public string CarID
		{
			get; set;
		}

		#endregion Public Properties
	}

}
