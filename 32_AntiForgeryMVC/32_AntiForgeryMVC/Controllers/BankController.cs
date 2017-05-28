using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _32_AntiForgeryMVC.Controllers
{
    public class BankController : Controller
    {
        //
        // GET: /Bank/
        public ActionResult Screen()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult Transfer()
        {
            return Content(Request.Form["amount"] +
                "has been transferred to account"
                + Request.Form["account"]);
        }
	}
}