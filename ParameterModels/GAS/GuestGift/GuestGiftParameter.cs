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

}
