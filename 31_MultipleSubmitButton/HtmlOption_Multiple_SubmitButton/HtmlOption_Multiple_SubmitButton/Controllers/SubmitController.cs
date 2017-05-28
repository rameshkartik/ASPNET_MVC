using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlOption_Multiple_SubmitButton.Controllers
{
    public class SubmitController : Controller
    {
        public ActionResult Click()
        {
            return View("Submit");
        }
        //
        // GET: /Submit/
        public ActionResult Save()
        {
            return Content("Save Called");
        }

        public ActionResult Delete()
        {
            return Content("Delete Called");
        }
	}
}