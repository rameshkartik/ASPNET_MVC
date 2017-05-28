using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ModelBind.Models
{
    public class Employee
    {
        
        [RegularExpression("^[A-Z]{3,3}[0-9]{4,4}$")]
        [Required]
        [Key]
        public string EmployeeCode { get; set; }
        [Required]
        [StringLength(5)]
        public string EmployeeName { get; set; } 

    }
}