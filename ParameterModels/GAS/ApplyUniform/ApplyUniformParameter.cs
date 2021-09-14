using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.ApplyUniform
{
    public class UniformStyleInfoAllField
    {
        public int UniformStyleNo { get; set; }
        public string UniformStyleName { get; set; }
        public int UniformStylePrice { get; set; }
        public int UniformStyleApplyQuantity { get; set; }

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
		public String UniformOrderListNo
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
		public String UniformOrderListNo
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

}
