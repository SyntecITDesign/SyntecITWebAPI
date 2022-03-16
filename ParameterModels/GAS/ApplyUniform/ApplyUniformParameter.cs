using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.ApplyUniform
{
	public class UniformStyleInfoAllField
	{
		public int UniformStyleNo
		{
			get; set;
		}
		public string UniformStyleName
		{
			get; set;
		}
		public int UniformStylePrice
		{
			get; set;
		}
		public int UniformStyleApplyQuantity
		{
			get; set;
		}

	}
	public class InsertUniformStyle : UniformStyleInfoAllField
	{

	}
	public class DeleteUniformStyle : UniformStyleInfoAllField
	{

	}
	public class UpdateUniformStyleInfo : UniformStyleInfoAllField
	{

	}
	public class GetUniformStyleInfo : UniformStyleInfoAllField
	{

	}

	public class UniformQuantityAllField
	{
		public string UniformStyleNo
		{
			get; set;
		}
		public string UniformStyleSize
		{
			get; set;
		}
		public int UniformQuantity
		{
			get; set;
		}
		public int UniformAlertQuantity
		{
			get; set;
		}

	}
	public class UpsertUniformQuantityInfo : UniformQuantityAllField
	{

	}
	public class DeleteUniformQuantity : UniformQuantityAllField
	{

	}
	public class GetUniformQuantityInfo : UniformQuantityAllField
	{

	}

	public class UniformOrderListAllField
	{
		public string UniformOrderListNo
		{
			get; set;
		}
		public string UniformOrderDate
		{
			get; set;
		}

		public bool UniformOk
		{
			get; set;
		}

	}
	public class InsertUniformOrder : UniformOrderListAllField
	{

	}
	public class DeleteUniformOrder : UniformOrderListAllField
	{

	}
	public class UpdateUniformOrder : UniformOrderListAllField
	{

	}
	public class GetUniformOrderList : UniformOrderListAllField
	{

	}

	public class UniformOrderListDetailAllField
	{
		public string UniformOrderListNo
		{
			get; set;
		}
		public int UniformStyleNo
		{
			get; set;
		}
		public string UniformStyleSize
		{
			get; set;
		}
		public int UniformOrderPrice
		{
			get; set;
		}
		public int UniformQuantity
		{
			get; set;
		}

	}
	public class InsertUniformOrderListDetail : UniformOrderListDetailAllField
	{

	}
	public class DeleteUniformOrderListDetail : UniformOrderListDetailAllField
	{

	}
	public class UpdateUniformOrderListDetail : UniformOrderListDetailAllField
	{

	}
	public class GetUniformOrderListDetail : UniformOrderListDetailAllField
	{

	}


	public class UniformApplicationsMasterAllField
	{
		public int UniformApplicationsMasterRequisitionID
		{
			get; set;
		}
		public string UniformApplicationsMasterFillerID
		{
			get; set;
		}
		public string UniformApplicationsMasterFillerName
		{
			get; set;
		}
		public string UniformApplicationsMasterApplicationDate
		{
			get; set;
		}
		public string UniformApplicationsMasterApplicantID
		{
			get; set;
		}
		public string UniformApplicationsMasterApplicantName
		{
			get; set;
		}
		public string UniformApplicationsMasterApplicantDept
		{
			get; set;
		}
		public bool UniformApplicationsMasterIsCancel
		{
			get; set;
		}
		public string UniformApplicationsMasterClothesType
		{
			get; set;
		}
		public string UniformApplicationsMasterApplyType
		{
			get; set;
		}
		public string UniformApplicationsMasterApplyQuantity
		{
			get; set;
		}
		public string UniformApplicationsMasterSize
		{
			get; set;
		}

		public int UniformApplicationsMasterPrice
		{
			get; set;
		}
		public string UniformApplicationsMasterMemo
		{
			get; set;
		}
		public bool UniformApplicationsMasterFinished
		{
			get; set;
		}
	}
	public class InsertUniformApplicationsMaster : UniformApplicationsMasterAllField
	{

	}
	public class DeleteUniformApplicationsMaster : UniformApplicationsMasterAllField
	{

	}
	public class UpdateUniformApplicationsMaster : UniformApplicationsMasterAllField
	{

	}
	public class GetUniformApplicationsMaster : UniformApplicationsMasterAllField
	{

	}


	public class CoatApplicationAllField
	{
		public string CoatApplicationEmpID
		{
			get; set;
		}
		public string CoatApplicationSize
		{
			get; set;
		}
		public string CoatApplicationYear
		{
			get; set;
		}
		
	}
	public class UpdateCoatApplication : CoatApplicationAllField
	{

	}


	public class GAS_GAInfoMasterAllField
	{
		public string GAS_GAInfoMasterEmpID
		{
			get; set;
		}
		public string GAS_GAInfoMasterUniformSize
		{
			get; set;
		}
		
		public string GAS_GAInfoMasterSizeType
		{
			get; set;
		}
	}
	public class UpdateGAS_GAInfoMasterSize : GAS_GAInfoMasterAllField
	{

	}



}
