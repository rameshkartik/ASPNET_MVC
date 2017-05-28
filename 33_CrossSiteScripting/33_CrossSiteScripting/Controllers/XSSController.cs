using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _33_CrossSiteScripting.Controllers
{
    public class XSSController : Controller
    {
        //
        // GET: /XSS/
        public ActionResult Index()
        {
            return View("XSS");
        }
	}
}