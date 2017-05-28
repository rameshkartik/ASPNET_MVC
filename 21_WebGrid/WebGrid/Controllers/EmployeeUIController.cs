using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGridSample.ViewModel;

namespace WebGridSample.Controllers
{
    public class EmployeeUIController : Controller
    {
        //
        // GET: /EmployeeUI/
        public ActionResult Index()
        {
            GridVM vm = new GridVM();
            vm.Employees = this.GetEmployees();
            return View(vm);
        }


        private List<Models.Employee> GetEmployees()
        {
            List<Models.Employee> empColl = new List<Models.Employee>();

            for (int i = 0; i <= 100; i++)
            {
                Models.Employee em = new Models.Employee();
                em.EmployeeCode = "Code" + i;
                em.EmployeeName = "Name" + i;
                em.Age = 25;
                empColl.Add(em);
            }

            return empColl;
        }

        public ActionResult EditEmployee(string EmployeeName)
        {
            return Content("Recieved:" + EmployeeName);
        }
	}
}