using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_Project_1.Models;
using MVC_Project_1.Dal;


namespace MVC_Angular_Work_Project.Controllers
{
    public class LoginController : ApiController
    {
        public List<LoginCredential> GET(LoginCredential c)
        {
            GazDal dal = new GazDal();
            List<LoginCredential> CredColl = new List<LoginCredential>();
            if(c.UserName == "Ramesh" && c.Passwrd == "Kartik")
            {
                CredColl.Add(c);
            }
            return CredColl;
        }
    }
}
