using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionHandling.Controllers
{


    public class CustomAttr : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {

            ViewResult VR = new ViewResult();
            VR.ViewName = "ErrorDisplay";
            filterContext.Result = VR;
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
    }

    [HandleError(ExceptionType=typeof(DivideByZeroException),View="ErrorDisplayNew")]
    [HandleError(ExceptionType = typeof(NullReferenceException), View = "ErrorDisplayNew1")]
    public class Exception4Controller : Controller
    {

        
        public ActionResult ErrorDisplay()
        {
          
            string s = null;
            s = s.ToString();
            int i = 0;
            i /= i;
            return View();
            
        }

        //4th Approach,using filters
        
        public ActionResult ErrorDisplay1()
        {
           int i = 0;
           i /= i;
           return View();

        }

	}
}