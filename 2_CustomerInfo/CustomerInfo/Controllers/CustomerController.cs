using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerInfo.Models;
namespace CustomerInfo.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Load()
        {

            Customer custObj = new Customer { CustomerCode = 1001, CustomerName = "Ram" };

            return View("CustomerLoad",custObj);
        }   

        public ActionResult Enter()
        {
            return View("CustomerEnter");
        }

        public ActionResult Submit(Customer C)
        {
            return View("CustomerLoad",C);
        }
	}
}