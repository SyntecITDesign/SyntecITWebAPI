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
		public string AssetManagementDurability
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
		public string AssetManagementIsScrap
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
}
