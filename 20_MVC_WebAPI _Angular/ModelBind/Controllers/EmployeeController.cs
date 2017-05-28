using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelBind.Models;
using ModelBind.DAL;
namespace ModelBind.Controllers
{
    public class EmployeeController : ApiController
    {
        public List<Employee> POST(Employee e)
        {
            if (ModelState.IsValid)
            {
                EmployeeDAL eDal = new EmployeeDAL();
                eDal.Employees.Add(e);
                eDal.SaveChanges();
            }

            EmployeeDAL Dal = new EmployeeDAL();
            List<Employee> EmpColl = Dal.Employees.ToList<Employee>();
            return EmpColl;
        }

        //public List<Employee> GET()
        //{
        //    EmployeeDAL eDal = new EmployeeDAL();
        //    EmployeeVM Vm = new EmployeeVM();
        //    Vm.EmpObj = new Employee();
        //    List<Employee> EmpCol = eDal.Employees.ToList<Employee>();
        //    return EmpCol;
        //}


        public List<Employee> GET()
        {
            var urlKeys = ControllerContext.Request.GetQueryNameValuePairs();

            string EmployeeName = urlKeys.SingleOrDefault(x => x.Key == "EmployeeName").Value;
            string EmployeeCode = urlKeys.SingleOrDefault(x => x.Key == "EmployeeCode").Value;



            EmployeeDAL eDal = new EmployeeDAL();
            List<Employee> EmpCol = new List<Employee>();
            EmployeeVM Vm = new EmployeeVM();

            if(EmployeeName!=null)
            {
                EmpCol = (from t in eDal.Employees
                          where t.EmployeeName == EmployeeName
                          select t).ToList<Employee>();
                Vm.EmpObj = (Employee)EmpCol[0];
            }
            else if (EmployeeCode != null)
            {
                EmpCol = (from t in eDal.Employees
                          where t.EmployeeCode == EmployeeCode
                          select t).ToList<Employee>();
                Vm.EmpObj = (Employee)EmpCol[0];
            }

            else
            {
                EmpCol = eDal.Employees.ToList<Employee>();
                Vm.EmpObj = new Employee();
            }

            
            
            return EmpCol;
        }

        //public List<Employee> GET(Employee e)
        //{
        //    EmployeeDAL eDal = new EmployeeDAL();
        //    List<Employee> eGetColl = (from emp in eDal.Employees
        //                     where emp.EmployeeName == e.EmployeeName
        //                     select emp).ToList<Employee>();
        //    return eGetColl;
        //}

        public List<Employee> Put(Employee e)
        {
            EmployeeDAL eDal = new EmployeeDAL();
            Employee eUpd = (from emp in eDal.Employees
                             where emp.EmployeeCode == e.EmployeeCode
                             select emp).ToList<Employee>()[0];
            eUpd.EmployeeCode = e.EmployeeCode;
            eUpd.EmployeeName = e.EmployeeName;
            eDal.SaveChanges();
            List<Employee> EmpCol = eDal.Employees.ToList<Employee>();
            return EmpCol;
        }

        public List<Employee> Delete(Employee e)
        {
            EmployeeDAL eDal = new EmployeeDAL();
            Employee eDel = (from emp in eDal.Employees
                             where emp.EmployeeCode == e.EmployeeCode
                             select emp).ToList<Employee>()[0];
            eDal.Employees.Remove(eDel);
            eDal.SaveChanges();

            List<Employee> EmpCol = eDal.Employees.ToList<Employee>();
            return EmpCol;
        }
    }
}
