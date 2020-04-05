using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gadge_Exam02.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
         
        public string  DepartmentName{ get; set; }
        public int  CompanyCode{ get; set; }

        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}