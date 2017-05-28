using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayoutPagesRazor.Models;
using LayoutPagesRazor.ViewModel;

namespace LayoutPagesRazor.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            CustomerVM eCust = new CustomerVM();
            eCust.CusObj = new Customer();
            eCust.CusObj.CustomerName = "RAKESH";
            eCust.CusObj.CustomerAddress = "Chennai";
            eCust.CompanyName = "XYZ Ltd";
            return View("Customer", eCust);
        }
	}
}