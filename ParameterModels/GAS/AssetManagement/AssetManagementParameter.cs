using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.AssetManagement
{
	public class AssetManagementAllField
	{
		public string AssetManagementAssetNo
		{
			get; set;
		}
		public string AssetManagementAssetName
		{
			get; set;
		}
		public string AssetManagementSpec
		{
			get; set;
		}
		public string AssetManagementaAsetType
		{
			get; set;
		}
		public string AssetManagementProperty
		{
			get; set;
		}
		public string AssetManagementGetDate
		{
			get; set;
		}
		public string AssetManagementGetCost
		{
			get; set;
		}
		public string AssetManagementQuantity
		{
			get; set;
		}
		public string AssetManagementManagerID
		{
			get; set;
		}
		public string AssetManagementCostCenter
		{
			get; set;
		}
		public string AssetManagementStorage
		{
			get; set;
		}
		public string AssetManagementFirmName
		{
			get; set;
		}
		public string AssetManagementFirmTel
		{
			get; set;
		}
		public string AssetManagementFirmContactWindow
		{
			get; set;
		}
		public string AssetManagementMemo
		{
			get; set;
		}
		public bool AssetManagementIsScrap
		{
			get; set;
		}
		public string AssetManagementSAPNo
		{
			get; set;
		}
		public string AssetManagementPRNo
		{
			get; set;
		}
		public string AssetManagementPONo
		{
			get; set;
		}
		public string AssetManagementLimit
		{
			get; set;
		}
		public string AssetManagementBranch
		{
			get; set;
		}
		public string AssetManagementEquipmentNo
		{
			get; set;
		}
		public string AssetManagementLicenceAccount
		{
			get; set;
		}
		public string AssetManagementState
		{
			get; set;
		}
		public string AssetManagementWarranty
		{
			get; set;
		}
	}
	public class InsertAssetInfo : AssetManagementAllField
	{

	}
	public class DeleteAssetInfo : AssetManagementAllField
	{

	}
	public class UpdateAssetInfo : AssetManagementAllField
	{

	}
	public class GetAssetInfo : AssetManagementAllField
	{

	}
	public class UpdateITInfo : AssetManagementAllField
	{

	}

	public class AssetSpecListAllField
	{
		public string AssetSpecListUsage
		{
			get; set;
		}
		public string AssetSpecListNo
		{
			get; set;
		}
		public string AssetSpecListName
		{
			get; set;
		}

	}
	public class InsertAssetSpecList : AssetSpecListAllField
	{

	}
	public class DeleteAssetSpecList : AssetSpecListAllField
	{

	}
	public class UpdateAssetSpecList : AssetSpecListAllField
	{

	}
	public class GetAssetSpecList : AssetSpecListAllField
	{

	}

	public class AssetInventoryAllField
	{
		public string AssetInventoryAssetNo
		{
			get; set;
		}
		public string AssetInventoryAssetName
		{
			get; set;
		}
		public string AssetInventoryQuantity
		{
			get; set;
		}
		public string AssetInventoryManagerID
		{
			get; set;
		}
		public string AssetInventoryCostCenter
		{
			get; set;
		}
		public string AssetInventoryStorage
		{
			get; set;
		}
		public string AssetInventoryMemo
		{
			get; set;
		}
		public string AssetInventoryCheckID
		{
			get; set;
		}



	}
	public class InsertAssetInventory : AssetInventoryAllField
	{

	}
	public class DeleteAssetInventory : AssetInventoryAllField
	{

	}
	public class UpdateAssetInventory : AssetInventoryAllField
	{

	}
	public class GetAssetInventory : AssetInventoryAllField
	{

	}



	public class AssetLogTableAllField
	{
		public string AssetLogTableLogNo
		{
			get; set;
		}
		public string AssetLogTableAssetNo
		{
			get; set;
		}
		public string AssetLogTableEmpID
		{
			get; set;
		}
		public string AssetLogTableEmpName
		{
			get; set;
		}
		public string AssetLogTableChangeDate
		{
			get; set;
		}
		public string AssetLogTableBefore
		{
			get; set;
		}
		public string AssetLogTableAfter
		{
			get; set;
		}
		public string AssetLogTableMemo
		{
			get; set;
		}
		
	}
	public class InsertAssetLogTable : AssetLogTableAllField
	{

	}
	
	public class GetAssetLogTable : AssetLogTableAllField
	{

	}





}
