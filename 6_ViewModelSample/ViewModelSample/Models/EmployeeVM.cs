using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModelSample.Models
{
    public class EmployeeVM
    {
        public Employee empObj { get; set; }

        public string GetLowPFBalanceEmp()
        {
            if (int.Parse(empObj.PFObj.PF_Balance) < 100)
            {
                return "red";
            }
            else
                return "Green";
        }

    }
}