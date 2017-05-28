using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBind.Models;
namespace ModelBind.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Load()
        {
            Employee emp = new Employee { EmployeeCode = 100, EmployeeName = "Rameshkartik" };
            return View(emp);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Submit([ModelBinder(typeof(EmpBinder))]Employee e)
        //public ActionResult Submit(Employee e)
        {
            return View("Load", e);
        }
	}
}