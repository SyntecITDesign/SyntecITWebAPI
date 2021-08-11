using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.ApplyUniform
{
    public class UniformInfoAllField
    {
        public int UniformInfoNo { get; set; }
        public string UniformInfoStyle { get; set; }
        public int UniformInfoPrice { get; set; }
        public int UniformInfoAvailableQuantity { get; set; }

    }
    public class InsertUniformStyle : UniformInfoAllField
    {

    }
    public class DeleteUniformInfo : UniformInfoAllField
    {

    }
    public class UpdateUniformInfo : UniformInfoAllField
    {

    }
    public class GetUniformInfo : UniformInfoAllField
    {

    }

}
