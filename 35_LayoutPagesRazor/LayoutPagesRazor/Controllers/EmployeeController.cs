using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayoutPagesRazor.Models;
using LayoutPagesRazor.ViewModel;

namespace LayoutPagesRazor.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            EmployeeVM eVm = new EmployeeVM();
            eVm.EmpObj = new Employee();
            eVm.EmpObj.EmployeeCode = "ABC1234";
            eVm.EmpObj.EmployeeName = "RAMKUMAR";
            eVm.EmpObj.EmployeeSalary = 34000;
            eVm.CompanyName = "XYZ Ltd";
            return View("Employee",eVm);
        }
	}
}