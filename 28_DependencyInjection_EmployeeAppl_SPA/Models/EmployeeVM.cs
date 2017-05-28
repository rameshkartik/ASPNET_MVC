using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Models
{
    public class EmployeeVM
    {
        public Employee EmpObj { get; set; }

        public List<Employee> Employees { get; set; }

        
    }
}