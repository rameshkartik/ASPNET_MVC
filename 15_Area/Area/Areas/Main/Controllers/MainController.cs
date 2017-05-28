using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Area.Areas.Main.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/Main/
        public ActionResult Display()
        {
            return View("Main");
        }
	}
}