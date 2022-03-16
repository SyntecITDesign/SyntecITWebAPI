using System;
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
		public string RecordType
		{
			get; set;
		}
		public string NewRecordRoad
		{
			get; set;
		}
		#endregion Public Properties
	}
	public class DelCarRepairRecord
	{
		#region Public Properties
		public string CarNumber
		{
			get; set;
		}
		public string FileName
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

	public class GetCarInsurance
	{
		#region Public Properties
		public string CarID
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class GetCarInsuranceSpecificTime
	{
		#region Public Properties
		public string CarID
		{
			get; set;
		}
		public string InsuranceYear
		{
			get; set;
		}
		public string InsuranceNextYear
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class UpsertCarInsurance
	{
		#region Public Properties
		public string No
		{
			get; set;
		}
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
		public string Memo
		{
			get; set;
		}
		#endregion Public Properties
	}

	public class DelCarInsurance
	{
		#region Public Properties
		public string No
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class GetCarInsuranceName
	{
		public string Type
		{
			get; set;
		}

	}

	public class UpsertCarInsuranceName
	{
		#region Public Properties

		public string No
		{
			get; set;
		}
		public string Items
		{
			get; set;
		}
		public string Type
		{
			get; set;
		}

		#endregion Public Properties
	}
	public class DelCarInsuranceName
	{
		#region Public Properties


		public string Items
		{
			get; set;
		}

		#endregion Public Properties
	}

	public class UpsertCarInsuranceType
	{
		#region Public Properties
		public string No
		{
			get; set;
		}
		public string InsuranceType
		{
			get; set;
		}
		#endregion Public Properties

	}
	public class DelCarInsuranceType
	{
		#region Public Properties

		public string No
		{
			get; set;
		}
		#endregion Public Properties

	}

	public class GetBeenRentCarSpecTime
	{
		public string StartTime
		{
			get;set;
		}
		public string EndTime
		{
			get;set;
		}
	}

	public class GetPersonalCarBookingRecord
	{
		public string EmpID
		{get;set;
		}
	}

	public class GetPrivatePriorityNumber
	{
		public string PreserveStartTime
		{
			get;set;
		}
		public string PreserveEndTime
		{
			get; set;
		}
	}

	public class CheckInner14DaysHasPrivatDate
	{
		public string EmpID
		{get;set;
		}
	}

	public class CheckPersonalBlockStatus
	{public string EmpID
		{get;set;
		}
	}
	public class InsertReserveToCarBookingRecord
	{
		public string EmpID
		{get;set;
		}
		public string Type
		{get;set;
		}
		public string Title
		{get;set;
		}
		public string StartLocation
		{get;set;
		}
		public string EndLocation
		{get;set;
		}
		public string CarNumber
		{get;set;
		}
		public string PreserveStartTime
		{get;set;
		}
		public string PreserveEndTime
		{get;set;
		}
	


	}

	public class DeleteCarBookingRecord
	{
		public string ID
		{
			get; set;
		}
	
	
	}

	public class GetCarBookingRecordID
	{
		public string EmpID
		{
			get; set;
		}
		public string TypePersonalBusiness
		{
			get; set;
		}
		public string Remark
		{
			get; set;
		}
		public string PreserveStartTime
		{
			get; set;
		}
		public string PreserveEndTime
		{
			get; set;
		}
		public string CarNumber
		{
			get; set;
		}

	}

	public class CarCheckFormAllField
	{
		public string CarCheckFormID
		{
			get; set;
		}
		public string FillerID
		{
			get; set;
		}
		public string FillerName
		{
			get; set;
		}
		public string FillerDate
		{
			get; set;
		}
		public string OilNormal
		{
			get; set;
		}
		public string DashboardNormal
		{
			get; set;
		}
		public string FanBeltNormal
		{
			get; set;
		}
		public string PluginNormal
		{
			get; set;
		}
		public string AcceleratorNormal
		{
			get; set;
		}
		public string WaterNormal
		{
			get; set;
		}
		public string BrakeNormal
		{
			get; set;
		}
		public string LightNormal
		{
			get; set;
		}
		public string GrassNormal
		{
			get; set;
		}
		public string DoorNormal
		{
			get; set;
		}
		public string TireNormal
		{
			get; set;
		}
		public string CarNumber
		{
			get; set;
		}
	}

	public class GetCarCheckFormByFormID : CarCheckFormAllField
	{
	}
	public class GetCarCheckFormByCarNumber : CarCheckFormAllField
	{
	}
	public class InsertCheckForm : CarCheckFormAllField
	{
	}
	public class DeleteCheckForm : CarCheckFormAllField
	{
	}

}
