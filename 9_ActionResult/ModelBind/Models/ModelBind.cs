using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBind.Models
{
    public class EmpBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase httpContxtObj = controllerContext.HttpContext;
            string custCode = httpContxtObj.Request.Form["txtEmployeeCode"];
            string custName = httpContxtObj.Request.Form["txtEmployeeName"];
            Employee emp = new Employee { EmployeeCode = int.Parse(custCode), EmployeeName = custName };
            return emp;
        }
    }
}