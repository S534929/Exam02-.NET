using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gadge_Exam02.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        

        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}