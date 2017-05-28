using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionHandling.Controllers
{
    public class BaseController:Controller
    {
        //Third approach - Resusability across diff controllers
        protected override void OnException(ExceptionContext filterContext)
        {
            ViewResult VR = new ViewResult();
            VR.ViewName = "ErrorDisplay";
            filterContext.Result = VR;
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
    }


    public class Exception1Controller : BaseController
    {
        //
        // GET: /Default1/
        //Third approach - Resusability across diff controllers
        public ActionResult ErrorDisplay()
        {
            int i = 0;
            i /= i;
            return View();

        }
	}
}