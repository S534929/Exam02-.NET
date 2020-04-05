using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gadge_Exam02.Models
{
        public class EmployeeDepartment
      {
        [Key]
        public int EmployeeDepartmentID { get; set; } 
        public int DepartmentID { get; set; }
        public int EmployeeID { get; set; }

        

        public virtual Employee Employee { get; set; }

        public virtual Department Department { get; set; }
    }
}