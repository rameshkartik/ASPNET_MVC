using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using ModelBind.Models;
//using ModelBind.DAL;
using MVC_Project_1.Models;
using MVC_Project_1.Dal;

namespace MVC_Project_1.Controllers
{
    public class GazController : Controller
    {
        //
        // GET: /Customer/
        public ActionResult Show()
        {
            GazRequest Req = new GazRequest();
            Req.RequestNo = 1001;
            Req.OldName = "Harshan";
            Req.NewName = "Vinay Aravinth";
            Req.DOB = "06/08/1981";
            Req.City = "Chennai";
            return View("Gaz", Req);
        }

        public ActionResult GetReq()
        {
            GazDal dal = new GazDal();
            List<GazRequest> GalReqColl = dal.Requests.ToList<GazRequest>();
            return Json(GalReqColl, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Submit()
        {
            //return View("Gaz", new GazRequest());

            string strReqnum = Request.Form["RequestNo"];
            string strOldName = Request.Form["OldName"];
            string strNewName = Request.Form["NewName"];
            string strDOB = Request.Form["DOB"];
            string strCity = Request.Form["City"];

            GazRequest req = new GazRequest { RequestNo = int.Parse(strReqnum), OldName = strOldName, NewName = strNewName, DOB = strDOB, City = strCity };
            GazDal dal = new GazDal();
            dal.Requests.Add(req);
            dal.SaveChanges();

            List<GazRequest> GalReqColl = dal.Requests.ToList<GazRequest>();
            return Json(GalReqColl, JsonRequestBehavior.AllowGet);
        }
    }
}