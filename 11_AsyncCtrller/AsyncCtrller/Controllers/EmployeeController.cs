using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsyncCtrller.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncCtrller.Controllers
{
    public class EmployeeController : AsyncController
    {
        //
        // GET: /Employee/
        public async Task<ActionResult> Main()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            DashboardVM VM = new DashboardVM();
            DashboardBL BL = new DashboardBL();

            int ThreadId1 = Thread.CurrentThread.ManagedThreadId;

            Task<string> T1 = Task.Factory.StartNew<string>(BL.GetEmpCode);
            Task<string> T2 = Task.Factory.StartNew<string>(BL.GetEmpName);
            Task<string> T3 = Task.Factory.StartNew<string>(BL.GetLocation);
            Task<string> T4 = Task.Factory.StartNew<string>(BL.GetSalary);

            await Task.WhenAll(T1, T2, T3, T4);

            int ThreadId2 = Thread.CurrentThread.ManagedThreadId;

            ViewData["ThreadId1"] = ThreadId1;
            ViewData["ThreadId2"] = ThreadId2;

            VM.EmployeeCode = T1.Result;
            VM.EmloyeeName = T2.Result;
            VM.Location = T3.Result;
            VM.Salary = T4.Result;


            //VM.EmployeeCode = BL.GetEmpCode();
            //VM.EmloyeeName = BL.GetEmpName();
            //VM.Location = BL.GetLocation();
            //VM.Salary = BL.GetSalary();
            watch.Stop();
            ViewData["Time"] = watch.Elapsed.Seconds;
            return View("Dashboard",VM);
        }
	}
}