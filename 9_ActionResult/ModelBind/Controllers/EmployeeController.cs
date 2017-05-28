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
            Employee emp = new Employee { EmployeeCode = 100, 
                EmployeeName = "Rameshkartik" };
            if (Request.QueryString["Type"] == "HTML")
            {
                return View(emp);
            }
            else if (Request.QueryString["Type"] == "Json")
            {
                return Json(emp, JsonRequestBehavior.AllowGet);
            }
            else
                return View(emp);
        }

        public JsonResult LoadJson()
        {
            Employee emp = new Employee { EmployeeCode = 100, EmployeeName = "Rameshkartik" };
            return Json(emp,JsonRequestBehavior.AllowGet);

        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Submit([ModelBinder(typeof(EmpBinder))]Employee e)
        {
            return View("Load", e);
        }
	}
}