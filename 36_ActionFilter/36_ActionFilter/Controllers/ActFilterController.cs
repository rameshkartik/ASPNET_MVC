using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
namespace _36_ActionFilter.Controllers
{
    [MyActionFilter]
    public class ActFilterController : Controller,IActionFilter
    {
        //
        // GET: /ActFilter/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyIndex()
        {
            return View("Index");
        }
    }

    public class MyActionFilter:ActionFilterAttribute,IActionFilter
    {

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Post processing logic
            Trace.WriteLine(filterContext.ActionDescriptor.ActionName + "was executed at" + DateTime.Now.ToString());
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Pre processing logic
            filterContext.Result = new RedirectResult("http://www.google.com");
            Trace.WriteLine(filterContext.ActionDescriptor.ActionName + "was executing at" + DateTime.Now.ToString());
        }
    }
}