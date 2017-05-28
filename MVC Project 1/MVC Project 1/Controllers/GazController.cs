using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBind.Models;
using ModelBind.DAL;
using MVC_Project_1.Models;

namespace MVC_Project_1.Controllers
{
    public class GazController : Controller
    {
        //
        // GET: /Customer/
        public ActionResult Show()
        {
            GazRequest Req = new GazRequest();
            Req.RequestNo = 1001;
            Req.OldName = "Harshan";
            Req.NewName = "Vinay Aravinth";
            Req.DOB = "06/08/1981";
            Req.City = "Chennai";
            return View("Gaz",Req);
        }

        public ActionResult New()
        {

            EmployeeVM ViewModel_Obj = new EmployeeVM();
            ViewModel_Obj.EmpObj = new Employee();
            //EmployeeDAL Dal = new EmployeeDAL();
            //List<Employee> EmpColl = Dal.Employees.ToList<Employee>();
            //ViewModel_Obj.Employees = EmpColl;
            return View("New", ViewModel_Obj);
        }
        public ActionResult GetEmployees()
        {
            EmployeeDAL eDal = new EmployeeDAL();
            EmployeeVM Vm = new EmployeeVM();
            Vm.EmpObj = new Employee();
            List<Employee> EmpCol = eDal.Employees.ToList<Employee>();
            //Thread.Sleep(10000);
            return Json(EmpCol, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Submitk()
        {
            Employee emp = new Employee();

            emp.EmployeeCode = Request.Form["EmpObj.EmployeeCode"];
            emp.EmployeeName = Request.Form["EmpObj.EmployeeName"];

            if (ModelState.IsValid)
            {


                EmployeeDAL eDal = new EmployeeDAL();
                eDal.Employees.Add(emp);
                eDal.SaveChanges();
                //return View("Load", e);
            }

            //EmployeeVM ViewModel_Obj = new EmployeeVM();
            //ViewModel_Obj.EmpObj = emp;
            EmployeeDAL Dal = new EmployeeDAL();
            List<Employee> EmpColl = Dal.Employees.ToList<Employee>();
            //ViewModel_Obj.Employees = EmpColl;
            //return View("New",ViewModel_Obj);
            return Json(EmpColl, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Submit()
        {
            //return View("Gaz", new GazRequest());

            return Json(new GazRequest(), JsonRequestBehavior.AllowGet);
        }
	}
}