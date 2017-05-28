using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Project_1.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index()
        {
            return View();
        }
	}

    public class ErrorAttr:HandleErrorAttribute
    {

        public override void OnException(ExceptionContext filterContext)
        {
            ViewResult V = new ViewResult();
            V.ViewName = "Error";
            filterContext.Result = V;
            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }

    }
}