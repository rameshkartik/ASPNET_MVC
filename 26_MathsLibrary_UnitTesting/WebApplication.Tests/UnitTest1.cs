using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Controllers;
using System.Web.Mvc;

namespace WebApplication.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForViewName()
        {
            //Arrange
            EmployeeController Ec = new EmployeeController();

            //Act
            ViewResult v =  Ec.Index(0) as ViewResult;

            Assert.AreEqual<string>("View1", v.ViewName);
        }


        [TestMethod]
        public void TestForViewName2()
        {
            //Arrange
            EmployeeController Ec = new EmployeeController();

            //Act
            ViewResult v = Ec.Index(1) as ViewResult;

            Assert.AreEqual<string>("View2", v.ViewName);
        }


        [TestMethod]
        public void TestForViewData()
        {
            //Arrange
            EmployeeController Ec = new EmployeeController();

            ViewResult V = Ec.Index2() as ViewResult;

            Assert.AreEqual<string>("SomeValue", V.ViewData["MyKey"].ToString());

        }

        [TestMethod]
        public void TestForRedirect()
        {
            EmployeeController e = new EmployeeController();
            RedirectToRouteResult r = e.Index3(0) as RedirectToRouteResult;
            Assert.AreEqual<string>("Index4", r.RouteValues["action"].ToString());
        }
    }
}
