using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using ModelBind.Models;
//using ModelBind.DAL;
using MVC_Project_1.Dal;
using MVC_Project_1.Models;

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

        
        public ActionResult Submit()
        {
            GazRequest emp = new GazRequest();

            emp.NewName = Request.Form["EmpObj.EmployeeCode"];
            emp.OldName = Request.Form["EmpObj.EmployeeName"];

            if (ModelState.IsValid)
            {


                GazDal eDal = new GazDal();
                eDal.Requests.Add(emp);
                eDal.SaveChanges();
                //return View("Load", e);
            }

            //EmployeeVM ViewModel_Obj = new EmployeeVM();
            //ViewModel_Obj.EmpObj = emp;
            GazDal Dal = new GazDal();
            List<GazRequest> EmpColl = Dal.Requests.ToList<GazRequest>();
            //ViewModel_Obj.Employees = EmpColl;
            //return View("New",ViewModel_Obj);
            return Json(EmpColl, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Submit1()
        {
            //return View("Gaz", new GazRequest());

            return Json(new GazRequest(), JsonRequestBehavior.AllowGet);
        }
    }
}