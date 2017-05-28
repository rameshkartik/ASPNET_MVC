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
            Employee emp = new Employee { EmployeeCode = "100", EmployeeName = "Rameshkartik" };
            return View(emp);
        }

        public ActionResult New()
        {
            return View("New",new Employee());
        }

        public ActionResult Submit(Employee e)
        {
            if (ModelState.IsValid)
            {
                return View("Load", e);
            }
            else
            {
                return View("New",e);
            }
        }
	}
}