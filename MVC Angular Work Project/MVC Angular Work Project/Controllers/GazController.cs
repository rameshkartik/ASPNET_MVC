using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_Project_1.Models;
using MVC_Project_1.Dal;

namespace MVC_Project_1.Controllers
{
    public class GazController : ApiController
    {
        public List<GazRequest> POST(GazRequest G)
        {
            string strReqnum = G.RequestNo.ToString();
            string strOldName = G.OldName;
            string strNewName = G.NewName;
            string strDOB = G.DOB;
            string strCity = G.City;

            GazRequest req = new GazRequest { RequestNo = int.Parse(strReqnum), OldName = strOldName, NewName = strNewName, DOB = strDOB, City = strCity };
            GazDal dal = new GazDal();
            dal.Requests.Add(req);
            dal.SaveChanges();

            List<GazRequest> GalReqColl = dal.Requests.ToList<GazRequest>();
            return GalReqColl;
            //return Json(GalReqColl, JsonRequestBehavior.AllowGet);
        }

        public List<GazRequest> GET()
        {
            GazDal dal = new GazDal();
            List<GazRequest> GalReqColl = dal.Requests.ToList<GazRequest>();
            return GalReqColl;

        }

        
    }
}
