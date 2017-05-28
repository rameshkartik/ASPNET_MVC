using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModelSample.Models
{
    public class Employee
    {
        public string EmployeeCode { get; set; }

        public string EmployeeName { get; set; }

        public string Age { get; set; }

        public string Location { get; set; }

        public EmployeePFDetails PFObj { get; set; }

    }
}