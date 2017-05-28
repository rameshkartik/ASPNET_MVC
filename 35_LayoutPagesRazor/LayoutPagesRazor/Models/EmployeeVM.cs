using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LayoutPagesRazor.Models;

namespace LayoutPagesRazor.ViewModel
{
    public class EmployeeVM:LayoutVM
    {
        public Employee EmpObj { get; set; }

        public List<Employee> Employees { get; set; }


    }
}