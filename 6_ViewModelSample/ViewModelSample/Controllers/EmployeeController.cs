using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModelSample.Models;
namespace ViewModelSample.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Show()
        {
            EmployeeVM vm = new EmployeeVM();
            vm.empObj = new Employee();
            vm.empObj.PFObj = new EmployeePFDetails();
            vm.empObj.Age = "24";
            vm.empObj.EmployeeCode = "123";
            vm.empObj.EmployeeName = "Ram";
            vm.empObj.Location = "Chennai";
            vm.empObj.PFObj.PF_Balance = "2000";
            vm.empObj.PFObj.PF_Number = "1234";
            return View(vm);
        }
	}
}