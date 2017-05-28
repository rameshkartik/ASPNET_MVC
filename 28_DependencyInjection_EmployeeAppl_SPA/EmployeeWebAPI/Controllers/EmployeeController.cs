using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Dal;
using System.Web.Http.Filters;
using System.Web.Http.Dispatcher;
using Microsoft.Practices.Unity;
using System.Web.Http.Controllers;
using System.Web.Script.Serialization;
using AutoMapper;
using System.Web.Http.Cors;
namespace Models.Controllers
{
    public class Errors
    {
        public List<string> ErrorList { get; set; }
    }

    public class ClientData
    {
        public bool IsValid { get; set; }
        public object Data { get; set; }
    }

    [AllowCrossSite]
    [EnableCors("*","*","*")]
    public class EmployeeController : ApiController
    {
        private Employee empGlobal;
        public EmployeeController(Employee e)
        {
            empGlobal = e;
        }

        //public EmployeeController()
        //{

        //}
        public Object POST()
        {
            ClientData cData = new ClientData();
            if (ModelState.IsValid)
            {
                EmployeeDAL eDal = new EmployeeDAL();
                eDal.Employees.Add(empGlobal);
                eDal.SaveChanges();
            }
            else
            {
                var error = new Errors();
                error.ErrorList = new List<string>();

                foreach (var mState in ModelState)
                {
                    foreach (var err in mState.Value.Errors)
                    {
                        error.ErrorList.Add(err.ErrorMessage);
                    }
                }
                cData.IsValid = false;
                cData.Data = error;

                return cData;
            }


            EmployeeDAL Dal = new EmployeeDAL();
            List<Employee> EmpColl = Dal.Employees.ToList<Employee>();
            cData.IsValid = true;
            cData.Data = EmpColl;
            //return EmpColl;
            return cData;
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

            if (EmployeeName != null)
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

        public List<Employee> Put()
        {
            EmployeeDAL eDal = new EmployeeDAL();
            Employee eUpd = (from emp in eDal.Employees
                             where emp.EmployeeCode == empGlobal.EmployeeCode
                             select emp).ToList<Employee>()[0];
            eUpd.EmployeeCode = empGlobal.EmployeeCode;
            eUpd.EmployeeName = empGlobal.EmployeeName;
            eDal.SaveChanges();
            List<Employee> EmpCol = eDal.Employees.ToList<Employee>();
            return EmpCol;
        }

        public List<Employee> Delete()
        {
            EmployeeDAL eDal = new EmployeeDAL();
            Employee eDel = (from emp in eDal.Employees
                             where emp.EmployeeCode == empGlobal.EmployeeCode
                             select emp).ToList<Employee>()[0];
            eDal.Employees.Remove(eDel);
            eDal.SaveChanges();

            List<Employee> EmpCol = eDal.Employees.ToList<Employee>();
            return EmpCol;
        }
    }

    public class AllowCrossSite:ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }

    public class EmployeeControllerFactory:IHttpControllerActivator
    {
        IUnityContainer unity;
        public EmployeeControllerFactory()
        {
            unity = new UnityContainer();
            unity.RegisterType<Employee, EmpDiscountbyAge>("A");
            unity.RegisterType<Employee, EmpDiscountbySalary>("S");
            unity.RegisterType<Employee, EmpDiscountbyDOJ>("J");
            Mapper.CreateMap<Employee, EmpDiscountbyAge>()
                .ForMember(x => x.EmployeeName, opt => opt.MapFrom(y => y.EmployeeName))
                .ForMember(x => x.EmployeeCode, opt => opt.MapFrom(y => y.EmployeeCode))
                .ForMember(x => x.EmployeeAge, opt => opt.MapFrom(y => y.EmployeeAge))
                .ForMember(x => x.EmployeeDOJ, opt => opt.MapFrom(y => y.EmployeeDOJ))
                .ForMember(x => x.EmployeeSalary, opt => opt.MapFrom(y => y.EmployeeSalary));

            Mapper.CreateMap<Employee, EmpDiscountbyDOJ>()
                .ForMember(x => x.EmployeeName, opt => opt.MapFrom(y => y.EmployeeName))
                .ForMember(x => x.EmployeeCode, opt => opt.MapFrom(y => y.EmployeeCode))
                .ForMember(x => x.EmployeeAge, opt => opt.MapFrom(y => y.EmployeeAge))
                .ForMember(x => x.EmployeeDOJ, opt => opt.MapFrom(y => y.EmployeeDOJ))
                .ForMember(x => x.EmployeeSalary, opt => opt.MapFrom(y => y.EmployeeSalary));


            Mapper.CreateMap<Employee, EmpDiscountbySalary>()
                .ForMember(x => x.EmployeeName, opt => opt.MapFrom(y => y.EmployeeName))
                .ForMember(x => x.EmployeeCode, opt => opt.MapFrom(y => y.EmployeeCode))
                .ForMember(x => x.EmployeeAge, opt => opt.MapFrom(y => y.EmployeeAge))
                .ForMember(x => x.EmployeeDOJ, opt => opt.MapFrom(y => y.EmployeeDOJ))
                .ForMember(x => x.EmployeeSalary, opt => opt.MapFrom(y => y.EmployeeSalary));
        }

        public IHttpController Create(HttpRequestMessage request,
            HttpControllerDescriptor cDescriptor,Type cType )
        {
            //First extracting the data from the request object
            var jsonStr = request.Content.ReadAsStringAsync().Result;
            JavaScriptSerializer JS_Serializer = new JavaScriptSerializer();

            //Json string is converted into the Employee object
            Employee empObj =  (Employee)JS_Serializer.Deserialize(jsonStr, typeof(Employee));
            Employee empInjected = new Employee();
            if (empObj != null)
            {
                DateTime eDateLimit = new DateTime(2010, 08, 06);
                if (empObj.EmployeeAge > 60)
                {
                    empInjected = unity.Resolve<Employee>("A");
                    empInjected = Mapper.Map<EmpDiscountbyAge>(empObj);
                }
                else if(empObj.EmployeeDOJ.Date > eDateLimit.Date)
                {
                    empInjected = unity.Resolve<Employee>("J");
                    empInjected = Mapper.Map<EmpDiscountbyDOJ>(empObj);
                }
                else if(empObj.EmployeeSalary < 2000)
                {
                    empInjected = unity.Resolve<Employee>("S");
                    empInjected = Mapper.Map<EmpDiscountbySalary>(empObj);
                }
                else
                {
                    empInjected = new Employee();
                }

                

            }
            var controller = new EmployeeController(empInjected);
            return controller;
        }
    }   
}
