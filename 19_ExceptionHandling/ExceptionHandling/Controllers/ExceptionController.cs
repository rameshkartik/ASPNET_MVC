using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionHandling.Controllers
{
    public class ExceptionController : Controller
    {

        //second approach - Override void on exception
        protected override void OnException(ExceptionContext filterContext)
        {
            ViewResult VR = new ViewResult();
            VR.ViewName = "ErrorDisplay";
            filterContext.Result = VR;
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
        //
        //Simple approach - Try catch
        public ActionResult ErrorDisplay()
        {
            try
            {
                int i = 0;
                i /= i;
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
            
        }


        //second approach - override on exception
        public ActionResult ErrorDisplay1()
        {
           int i = 0;
           i /= i;
           return View();

        }

	}
}