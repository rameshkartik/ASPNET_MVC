using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBind.Models;
using ModelBind.DAL;
using System.Threading;
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

            EmployeeVM ViewModel_Obj = new EmployeeVM();
            ViewModel_Obj.EmpObj = new Employee();
            //EmployeeDAL Dal = new EmployeeDAL();
            //List<Employee> EmpColl = Dal.Employees.ToList<Employee>();
            //ViewModel_Obj.Employees = EmpColl;
            return View("New", ViewModel_Obj);
        }

        public ActionResult SearchEnter()
        {
            EmployeeVM Emp_Vm = new EmployeeVM();
            Emp_Vm.EmpObj = new Employee();
            EmployeeDAL eDal = new EmployeeDAL();
            List<Employee> EmpColl = eDal.Employees.ToList<Employee>();
            Emp_Vm.Employees = EmpColl;


            //return Json(EmpColl, JsonRequestBehavior.AllowGet);
            return View("Search",Emp_Vm);
        }


        public ActionResult GetSearchResult()
        {
            EmployeeDAL eDal = new EmployeeDAL();
            List<Employee> EmpColl = eDal.Employees.ToList<Employee>();
            return Json(EmpColl, JsonRequestBehavior.AllowGet);
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

        public ActionResult SearchEmployee()
        {
            //EmployeeVM VM = new EmployeeVM();
            EmployeeDAL eDal = new EmployeeDAL();
            string input = Request.Form["EmpObj.EmployeeName"];

            List<Employee> EmpResult = (from x in eDal.Employees
                                        where x.EmployeeName == input
                                        select x).ToList<Employee>();
            //VM.Employees = EmpResult;
            //return View("Search", VM);

            return Json(EmpResult, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Submit()
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
	}
}