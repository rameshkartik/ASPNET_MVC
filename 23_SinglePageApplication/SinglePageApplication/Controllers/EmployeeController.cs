using SinglePageApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePageApplication.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            EmployeeVM eVM = new EmployeeVM();
            eVM.Employees = GetEmployees();
            return View(eVM);
        }

        private List<Models.Employee> GetEmployees()
        {
            List<Models.Employee> empColl = new List<Models.Employee>();

            for (int i = 0; i <= 10; i++)
            {
                Models.Employee em = new Models.Employee();
                em.EmployeeCode = "Code" + i;
                em.EmployeeName = "Name" + i;
                em.Age = 25;
                empColl.Add(em);
            }

            return empColl;
        }

        public ActionResult DataEntryScreen()
        {
            return PartialView();
        }

        public ActionResult SaveEmployee(Models.Employee e)
        {
            return Json(e);
        }
	}
}