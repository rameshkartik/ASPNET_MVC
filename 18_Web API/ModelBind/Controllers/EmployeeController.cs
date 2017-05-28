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

        public List<Employee> GET()
        {
            EmployeeDAL eDal = new EmployeeDAL();
            EmployeeVM Vm = new EmployeeVM();
            Vm.EmpObj = new Employee();
            List<Employee> EmpCol = eDal.Employees.ToList<Employee>();
            return EmpCol;
        }
    }
}
