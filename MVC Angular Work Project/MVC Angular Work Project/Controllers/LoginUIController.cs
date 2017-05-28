using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_Project_1.Models;
namespace MVC_Project_1.Controllers
{
    public class LoginUIController : Controller
    {
        public ActionResult Show()
        {
            LoginCredential crd = new LoginCredential();
            
            return View("AuthenticationScreen",crd);
        }

        //[AllowAnonymous]
        public ActionResult ShowGaz()
        {
            GazRequestVM VM = new GazRequestVM();
            GazRequest Req = new GazRequest();
            Req.RequestNo = 1001;
            Req.OldName = "Harshan";
            Req.NewName = "Vinay Aravinth";
            Req.DOB = "06/08/1981";
            Req.City = "Chennai";
            VM.GazObj = Req;
            return View("Gaz", VM);
        }

        public ActionResult Submit()
        {
            GazRequestVM VM = new GazRequestVM();
            GazRequest Req = new GazRequest();
            Req.RequestNo = 1001;
            Req.OldName = "Harshan";
            Req.NewName = "Vinay Aravinth";
            Req.DOB = "06/08/1981";
            Req.City = "Chennai";
            VM.GazObj = Req;
            //return RedirectToAction("ShowGaz", "LoginUI");
            return View("Gaz", VM);
        }

        public ActionResult SubmitCredentials(LoginCredential c)
        {
            
            if (c.UserName == "Rameshkartik" && c.Passwrd == "Ram")
            {
                FormsAuthentication.SetAuthCookie("Cookies", true);
                GazRequestVM VM = new GazRequestVM();
                GazRequest Req = new GazRequest();
                Req.RequestNo = 1001;
                Req.OldName = "Harshan";
                Req.NewName = "Vinay Aravinth";
                Req.DOB = "06/08/1981";
                Req.City = "Chennai";
                VM.GazObj = Req;
                return View("Gaz",VM);
            }
            else
            {
                return View("AuthenticationScreen", c);
            }
        }
	}
}