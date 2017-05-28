using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SinglePageApplication.Models;

namespace SinglePageApplication.ViewModel
{
    public class EmployeeVM
    {
        public List<Employee> Employees { get; set; }

        public Employee Emp { get; set; }


    }
}