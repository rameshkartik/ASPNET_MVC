using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            Session["SessData"] = "SessionData";
            TempData["TempDataa"] = "TempData";
            return RedirectToAction("GotoHome", "Home");
        }

        public ActionResult GotoHome()
        {
            ViewBag.DateTimeViwBag = DateTime.Now.ToString();
            ViewData["DateTime"] = DateTime.Now.ToString();
            return View("HomeView");
        }

        [ActionName("GotoHomeWithInput")]
        public ActionResult GotoHome(string input)
        {
            ViewBag.DateTimeViwBag = DateTime.Now.ToString();
            ViewData["DateTime"] = DateTime.Now.ToString();
            return View("HomeView");
        }
	}
}