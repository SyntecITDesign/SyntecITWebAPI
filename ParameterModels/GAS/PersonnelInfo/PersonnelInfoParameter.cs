using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.PersonnelInfo
{
    public class PersonnelInfoAllField
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public string DeptNo { get; set; }

    }
    public class InsertPersonData : PersonnelInfoAllField
    {

    }
    public class DeletePersonData : PersonnelInfoAllField
    {

    }

    public class UpdatePersonDept: PersonnelInfoAllField
    {
       
    }
    public class GetPersonDept : PersonnelInfoAllField
    {

    }

    public class GetQuantity 
    {
        public string ProductName { get; set; }
        public string Specification { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
    }

}
