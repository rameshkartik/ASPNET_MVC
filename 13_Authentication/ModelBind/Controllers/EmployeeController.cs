using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBind.Models;
using ModelBind.DAL;
using System.Threading;
using System.Web.Security;
using System.Management;
namespace ModelBind.Controllers
{
    //[Authorize(Users = @"Kiruthika-PC\Kiruthika")]
    [Authorize]
    public class EmployeeController : Controller
    {
        [Authorize]
        public ActionResult Load()
        {
            Employee emp = new Employee { EmployeeCode = "100", EmployeeName = "Rameshkartik" };
            
            return View(emp);
        }

        //[Authorize(Users = @"Kiruthika-PC\Kiruthika")]
        [Authorize]
        public ActionResult New()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            string username = (string)collection.Cast<ManagementBaseObject>().First()["UserName"];

            //string s = User.Identity.Name;

            //bool u = User.Identity.IsAuthenticated;

            //string s = Membership.GetUser().ProviderUserKey.ToString();

            //Guid C_User = (Guid)Membership.GetUser().ProviderUserKey;
            
            EmployeeVM ViewModel_Obj = new EmployeeVM();
            ViewModel_Obj.EmpObj = new Employee();
            //EmployeeDAL Dal = new EmployeeDAL();
            //List<Employee> EmpColl = Dal.Employees.ToList<Employee>();
            //ViewModel_Obj.Employees = EmpColl;
            ViewModel_Obj.EmpObj.EmployeeName = username;
            return View("New", ViewModel_Obj);
        }
        [Authorize]
        //[Authorize(Users = @"Kiruthika-PC\Kiruthika")]
        public ActionResult SearchEnter()
        {
            EmployeeVM Emp_Vm = new EmployeeVM();
            Emp_Vm.EmpObj = new Employee();
            DataAccessLayer eDal = new DataAccessLayer();
            List<Employee> EmpColl = eDal.Employees.ToList<Employee>();
            Emp_Vm.Employees = EmpColl;

//            Guid C_User =  (Guid)Membership.GetUser().ProviderUserKey;
            //return Json(EmpColl, JsonRequestBehavior.AllowGet);
            return View("Search",Emp_Vm);
        }


        public ActionResult GetSearchResult()
        {
            DataAccessLayer eDal = new DataAccessLayer();
            List<Employee> EmpColl = eDal.Employees.ToList<Employee>();
            return Json(EmpColl, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployees()
        {
            try
            {
                DataAccessLayer eDal = new DataAccessLayer();
                EmployeeVM Vm = new EmployeeVM();
                Vm.EmpObj = new Employee();
                
                List<Employee> EmpCol = eDal.Employees.ToList<Employee>();
                //Thread.Sleep(10000);

                return Json(EmpCol, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ActionResult SearchEmployee()
        {
            //EmployeeVM VM = new EmployeeVM();
            DataAccessLayer eDal = new DataAccessLayer();
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
                

                DataAccessLayer eDal = new DataAccessLayer();
                eDal.Employees.Add(emp);
                eDal.SaveChanges();
                //return View("Load", e);
            }

            //EmployeeVM ViewModel_Obj = new EmployeeVM();
            //ViewModel_Obj.EmpObj = emp;
            DataAccessLayer Dal = new DataAccessLayer();
            List<Employee> EmpColl = Dal.Employees.ToList<Employee>();
            //ViewModel_Obj.Employees = EmpColl;
            //return View("New",ViewModel_Obj);
            return Json(EmpColl, JsonRequestBehavior.AllowGet);
            
        }
	}
}