using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
namespace AsyncCtrller.Models
{
    public class DashboardVM
    {
            
        public string EmployeeCode { get; set; }

        public string EmloyeeName { get; set; }

        public string Location { get; set; }

        public string Salary { get; set; }
    }


    public class DashboardBL
    {
        public string GetEmpCode()
        {
            Task.Delay(3000).Wait();
            return "90021";
        }

        public string GetEmpName()
        {
            Task.Delay(3000).Wait();
            return "Rameshkartik";
        }

        public string GetLocation()
        {
            Task.Delay(3000).Wait();
            return "Chennai";
        }

        public string GetSalary()
        {
            Task.Delay(3000).Wait();
            return "10000";
        }

        

    }
}