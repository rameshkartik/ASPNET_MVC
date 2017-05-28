using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBind.DAL;
using ModelBind.Models;
using System.Web.Security;

namespace ModelBind.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Authenticate()
        {
            return View("Login",new Login());
        }

        public ActionResult Submit()
        {
            string username = Request.Form["Username"];
            string password = Request.Form["Password"];

            DataAccessLayer dal = new DataAccessLayer();
            List<Login> CredentialList = (from c in dal.UserCredentials
                                                where (c.Username == username) &&
                                                (c.Password == password)
                                                select c).ToList<Login>();
            if (CredentialList.Count == 1)
            {
                FormsAuthentication.SetAuthCookie("Cookie", true);
                //Login l = new Login();
                //l.Username = username;
                //l.Password = password;
                //return View("Login", l);

                EmployeeVM ViewModel_Obj = new EmployeeVM();
                ViewModel_Obj.EmpObj = new Employee();
                ViewModel_Obj.EmpObj.EmployeeName = username;
                return View("New", ViewModel_Obj);
            }
            else
            {
                return View("Login");
            }


        }

        public ActionResult abc()
        {
            return View("Login");
        }
	}
}