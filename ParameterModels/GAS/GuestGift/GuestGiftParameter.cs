using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.GuestGift
{
	public class GuestGiftTypeInfoAllField
	{
		public int GuestGiftTypeInfoNo
		{
			get; set;
		}
		public string GuestGiftTypeInfoName
		{
			get; set;
		}
	}
	public class InsertGuestGiftType : GuestGiftTypeInfoAllField
	{

	}
	public class DeleteGuestGiftType : GuestGiftTypeInfoAllField
	{

	}
	public class UpdateGuestGiftTypeInfo : GuestGiftTypeInfoAllField
	{

	}
	public class GetGuestGiftTypeInfo : GuestGiftTypeInfoAllField
	{

	}

	public class GuestGiftQuantityAllField
	{
		public string GuestGiftTypeNo
		{
			get; set;
		}
		public string GuestGiftItems
		{
			get; set;
		}
		public int GuestGiftQuantity
		{
			get; set;
		}
		public int GuestGiftAlertQuantity
		{
			get; set;
		}
		public String GuestGiftUnit
		{
			get; set;
		}

	}
	public class UpsertGuestGiftQuantityInfo : GuestGiftQuantityAllField
	{

	}
	public class DeleteGuestGiftQuantity : GuestGiftQuantityAllField
	{

	}
	public class GetGuestGiftQuantityInfo : GuestGiftQuantityAllField
	{

	}

	public class GuestGiftOrderListAllField
	{
		public string GuestGiftOrderListNo
		{
			get; set;
		}
		public string GuestGiftOrderDate
		{
			get; set;
		}
		public bool GuestGiftOk
		{
			get; set;
		}
		public string GuestGiftUsage
		{
			get; set;
		}
		public string GuestGiftMemo
		{
			get; set;
		}
	}
	public class InsertGuestGiftOrder : GuestGiftOrderListAllField
	{

	}
	public class DeleteGuestGiftOrder : GuestGiftOrderListAllField
	{

	}
	public class UpdateGuestGiftOrder : GuestGiftOrderListAllField
	{

	}
	public class GetGuestGiftOrderList : GuestGiftOrderListAllField
	{

	}

	public class GuestGiftOrderListDetailAllField
	{
		public String GuestGiftOrderListNo
		{
			get; set;
		}
		public int GuestGiftTypeNo
		{
			get; set;
		}
		public string GuestGiftItems
		{
			get; set;
		}
		public int GuestGiftOrderPrice
		{
			get; set;
		}
		public int GuestGiftQuantity
		{
			get; set;
		}
		public string GuestGiftUnit
		{
			get; set;
		}
	}
	public class InsertGuestGiftOrderListDetail : GuestGiftOrderListDetailAllField
	{

	}
	public class DeleteGuestGiftOrderListDetail : GuestGiftOrderListDetailAllField
	{

	}
	public class UpdateGuestGiftOrderListDetail : GuestGiftOrderListDetailAllField
	{

	}
	public class GetGuestGiftOrderListDetail : GuestGiftOrderListDetailAllField
	{

	}

	public class GuestReceptionApplicationsMasterAllField
	{
		public int GuestReceptionApplicationsMasterRequisitionID
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterFillerID
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterFillerName
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterApplicationDate
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterApplicantID
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterApplicantName
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterApplicantDept
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterApplicantExt
		{
			get; set;
		}
		public bool GuestReceptionApplicationsMasterIsCancel
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterIntervieweeID
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterIntervieweeDeptName
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterVisitors
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterVisitorsCompany
		{
			get; set;
		}
		public int GuestReceptionApplicationsMasterVisitorsNum
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterVisitStartDateTime
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterVisitEndDateTime
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterMeetingRoom
		{
			get; set;
		}
		public bool GuestReceptionApplicationsMasterNeedElectronicPoster
		{
			get; set;
		}
		public bool GuestReceptionApplicationsMasterNeedWater
		{
			get; set;
		}
		public bool GuestReceptionApplicationsMasterNeedCoffee
		{
			get; set;
		}
		public bool GuestReceptionApplicationsMasterNeedTea
		{
			get; set;
		}
		public bool GuestReceptionApplicationsMasterNeedFruit
		{
			get; set;
		}
		public int GuestReceptionApplicationsMasterVeggieLunch
		{
			get; set;
		}
		public int GuestReceptionApplicationsMasterMeatLunch
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterParkingCarName
		{
			get; set;
		}
		public int GuestReceptionApplicationsMasterParkingCarCounting
		{
			get; set;
		}
		public bool GuestReceptionApplicationsMasterNeedVideoPPT
		{
			get; set;
		}
		public bool GuestReceptionApplicationsMasterNeedCatalog
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterSouvenirType
		{
			get; set;
		}
		public int GuestReceptionApplicationsMasterSouvenirNum
		{
			get; set;
		}
		public string GuestReceptionApplicationsMasterMemo
		{
			get; set;
		}
		public bool GuestReceptionApplicationsMasterFinished
		{
			get; set;
		}		
	}
	public class InsertGuestReceptionApplicationsMaster : GuestReceptionApplicationsMasterAllField
	{

	}
	public class DeleteGuestReceptionApplicationsMaster : GuestReceptionApplicationsMasterAllField
	{

	}
	public class UpdateGuestReceptionApplicationsMaster : GuestReceptionApplicationsMasterAllField
	{

	}
	public class GetGuestReceptionApplicationsMaster : GuestReceptionApplicationsMasterAllField
	{

	}






}
