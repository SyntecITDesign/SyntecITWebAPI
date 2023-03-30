using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SyntecITWebAPI.ParameterModels.GAS.Module
{
    public class Table1AllField
    {
        public string Table1Field1 { get; set; }
        public string Table1Field2 { get; set; }
        public string Table1Field3 { get; set; }
        public string Table1Field4 { get; set; }

    }
    public class InsertFeatures : Table1AllField
    {

    }
    public class DeleteFeatures : Table1AllField
    {

    }

    public class UpdateFeatures : Table1AllField
    {

    }
    public class GetFeatures1 : Table1AllField
    {

    }

    public class Table2AllField
    {
        public string Table2Field1 { get; set; }
        public string Table2Field2 { get; set; }
        public string Table2Field3 { get; set; }
        public string Table2Field4 { get; set; }
    }
    public class GetFeatures2 : Table2AllField
    {

    }
}
