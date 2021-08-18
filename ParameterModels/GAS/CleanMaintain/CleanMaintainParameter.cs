using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.CleanMaintain
{
    public class MaintainTypeInfoAllField
	{
        public int MaintainTypeInfoNo { get; set; }
        public string MaintainTypeInfoName { get; set; }
    }
    public class InsertMaintainType : MaintainTypeInfoAllField
	{

    }
    public class DeleteMaintainType : MaintainTypeInfoAllField
	{

    }
    public class UpdateMaintainTypeInfo : MaintainTypeInfoAllField
	{

    }
    public class GetMaintainTypeInfo : MaintainTypeInfoAllField
	{

    }

	public class MaintainQuantityAllField
	{
		public int MaintainTypeNo
		{
			get; set;
		}
		public string MaintainItems
		{
			get; set;
		}
		public int MaintainQuantity
		{
			get; set;
		}
		public int MaintainAlertQuantity
		{
			get; set;
		}
		public String MaintainUnit
		{
			get; set;
		}

	}
	public class UpsertMaintainQuantityInfo : MaintainQuantityAllField
	{

	}
	public class DeleteMaintainQuantity : MaintainQuantityAllField
	{

	}
	public class GetMaintainQuantityInfo : MaintainQuantityAllField
	{

	}
	
	public class MaintainOrderListAllField
	{
		public string MaintainOrderListNo
		{
			get; set;
		}
		public string MaintainOrderDate
		{
			get; set;
		}
		public bool MaintainOk
		{
			get; set;
		}
		public string MaintainUsage
		{
			get; set;
		}
	}
	public class InsertMaintainOrder : MaintainOrderListAllField
	{

	}
	public class DeleteMaintainOrder : MaintainOrderListAllField
	{

	}
	public class UpdateMaintainOrder : MaintainOrderListAllField
	{

	}
	public class GetMaintainOrderList : MaintainOrderListAllField
	{

	}

	public class MaintainOrderListDetailAllField
	{
		public String MaintainOrderListNo
		{
			get; set;
		}
		public int MaintainTypeNo
		{
			get; set;
		}
		public string MaintainItems
		{
			get; set;
		}
		public int MaintainOrderPrice
		{
			get; set;
		}
		public int MaintainQuantity
		{
			get; set;
		}

	}
	public class InsertMaintainOrderListDetail : MaintainOrderListDetailAllField
	{

	}
	public class DeleteMaintainOrderListDetail : MaintainOrderListDetailAllField
	{

	}
	public class UpdateMaintainOrderListDetail : MaintainOrderListDetailAllField
	{

	}
	public class GetMaintainOrderListDetail : MaintainOrderListDetailAllField
	{

	}

	public class CleanFirmInfoAllField
	{
		public int CleanFirmInfoNo
		{
			get; set;
		}
		public string CleanFirmInfoFirm
		{
			get; set;
		}
		public string CleanFirmInfoName
		{
			get; set;
		}
		public string CleanFirmInfoFax
		{
			get; set;
		}
		public string CleanFirmInfoTel
		{
			get; set;
		}
		public string CleanFirmInfoTaxID
		{
			get; set;
		}
		public string CleanFirmInfoAddress
		{
			get; set;
		}
	}
	public class InsertCleanFirm : CleanFirmInfoAllField
	{

	}
	public class DeleteCleanFirm : CleanFirmInfoAllField
	{

	}
	public class UpdateCleanFirmInfo : CleanFirmInfoAllField
	{

	}
	public class GetCleanFirmInfo : CleanFirmInfoAllField
	{

	}

	public class CleanStaffTypeAllField
	{
		public int CleanStaffTypeNo
		{
			get; set;
		}
		public string CleanStaffType
		{
			get; set;
		}		
	}
	public class InsertCleanStaffType : CleanStaffTypeAllField
	{

	}
	public class DeleteCleanStaffType : CleanStaffTypeAllField
	{

	}
	public class UpdateCleanStaffType : CleanStaffTypeAllField
	{

	}
	public class GetCleanStaffType : CleanStaffTypeAllField
	{

	}

}
