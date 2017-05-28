using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index(int i)
        {
            if(i == 0)
            {
                return View("View1");
            }
            else
            {
                return View("View2");
            }
        }

        public ActionResult Index2()
        {
            ViewData["MyKey"] = "SomeValue";
            return View("Index2");
        }

        public ActionResult Index3(int i)
        {
            if(i == 0)
            {
                return RedirectToAction("Index4");
            }
            else
            {
                return View("Index4");
            }
        }
	}
}