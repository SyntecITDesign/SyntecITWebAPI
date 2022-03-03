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
		public string MaintainTypeNo
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
		public string MaintainMemo
		{
			get; set;
		}
		public string MaintainFloor
		{
			get; set;
		}
		public string MaintainApplicantName
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
		public string MaintainUnit
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
		public string CleanStaffColor
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

	public class CleanAreaPlanAllField
	{
		public int CleanAreaPlanXaxis
		{
			get; set;
		}
		public int CleanAreaPlanYaxis
		{
			get; set;
		}
		public string CleanAreaPlanAreaPlan
		{
			get; set;
		}
		public string CleanAreaPlanFloor
		{
			get; set;
		}
	}
	public class InsertCleanAreaPlan : CleanAreaPlanAllField
	{

	}
	public class DeleteCleanAreaPlan : CleanAreaPlanAllField
	{

	}
	public class UpdateCleanAreaPlan : CleanAreaPlanAllField
	{

	}
	public class GetCleanAreaPlan : CleanAreaPlanAllField
	{

	}

	public class CleanStaffInfoAllField
	{
		public string CleanStaffInfoID
		{
			get; set;
		}
		public string CleanStaffInfoName
		{
			get; set;
		}
		public string CleanStaffInfoTel
		{
			get; set;
		}
		public string CleanStaffInfoCell
		{
			get; set;
		}
		public string CleanStaffInfoAddress
		{
			get; set;
		}
		public int CleanStaffInfoFirm
		{
			get; set;
		}
		public int CleanStaffInfoType
		{
			get; set;
		}
		public string CleanStaffInfoBirthDate
		{
			get; set;
		}
	}
	public class InsertCleanStaffInfo : CleanStaffInfoAllField
	{

	}
	public class DeleteCleanStaffInfo : CleanStaffInfoAllField
	{

	}
	public class UpdateCleanStaffInfo : CleanStaffInfoAllField
	{

	}
	public class GetCleanStaffInfo : CleanStaffInfoAllField
	{

	}

	public class CleanAreaInfoAllField
	{
		public int CleanAreaInfoAreaNo
		{
			get; set;
		}
		public string CleanAreaInfoAreaName
		{
			get; set;
		}
		public string CleanAreaInfoCleanStaff
		{
			get; set;
		}
		public string CleanAreaInfoColor
		{
			get; set;
		}
	}
	public class InsertCleanAreaInfo : CleanAreaInfoAllField
	{

	}
	public class DeleteCleanAreaInfo : CleanAreaInfoAllField
	{

	}
	public class UpdateCleanAreaInfo : CleanAreaInfoAllField
	{

	}
	public class GetCleanAreaInfo : CleanAreaInfoAllField
	{

	}

	public class MaintainRecordItemInfoAllField
	{
		public int MaintainRecordItemInfoNo
		{
			get; set;
		}
		public string MaintainRecordItemInfoItems
		{
			get; set;
		}
	}
	public class InsertMaintainRecordItem : MaintainRecordItemInfoAllField
	{

	}
	public class DeleteMaintainRecordItem : MaintainRecordItemInfoAllField
	{

	}
	public class UpdateMaintainRecordItemInfo : MaintainRecordItemInfoAllField
	{

	}
	public class GetMaintainRecordItemInfo : MaintainRecordItemInfoAllField
	{

	}

	public class MaintainRecordTypeInfoAllField
	{
		public int MaintainRecordTypeInfoNo
		{
			get; set;
		}
		public int MaintainRecordTypeInfoItems
		{
			get; set;
		}
		public string MaintainRecordTypeInfoType
		{
			get; set;
		}
		public int MaintainRecordTypeInfoPeriod
		{
			get; set;
		}
		public string MaintainRecordTypeInfoStartDate
		{
			get; set;
		}
		public string MaintainRecordTypeInfoEndDate
		{
			get; set;
		}
	}
	public class InsertMaintainRecordType : MaintainRecordTypeInfoAllField
	{

	}
	public class DeleteMaintainRecordType : MaintainRecordTypeInfoAllField
	{

	}
	public class UpdateMaintainRecordTypeInfo : MaintainRecordTypeInfoAllField
	{

	}
	public class GetMaintainRecordTypeInfo : MaintainRecordTypeInfoAllField
	{

	}

	public class MaintainRecordDetailListAllField
	{
		public int MaintainRecordDetailListNo
		{
			get; set;
		}
		public string MaintainRecordDetailListItems
		{
			get; set;
		}
		public string MaintainRecordDetailListType
		{
			get; set;
		}
		public string MaintainRecordDetailListMemo
		{
			get; set;
		}
		public string MaintainRecordDetailListDate
		{
			get; set;
		}
	}
	public class InsertMaintainRecordDetailList : MaintainRecordDetailListAllField
	{

	}
	public class DeleteMaintainRecordDetailList : MaintainRecordDetailListAllField
	{

	}
	public class UpdateMaintainRecordDetailList : MaintainRecordDetailListAllField
	{

	}
	public class GetMaintainRecordDetailList : MaintainRecordDetailListAllField
	{

	}


	public class CleanCheckTableAllField
	{
		public int CleanCheckTableNo
		{
			get; set;
		}
		public string CleanCheckTableCleanStaff
		{
			get; set;
		}
		public string CleanCheckTableCleanArea
		{
			get; set;
		}
		public string CleanCheckTableDescription
		{
			get; set;
		}
		public string CleanCheckTableDate
		{
			get; set;
		}
		public string CleanCheckTableFillerName
		{
			get; set;
		}
	}
	public class InsertCleanCheckTable : CleanCheckTableAllField
	{

	}



}
