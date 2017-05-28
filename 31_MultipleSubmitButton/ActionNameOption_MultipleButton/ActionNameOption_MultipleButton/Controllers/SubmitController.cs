using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlOption_Multiple_SubmitButton.Controllers
{
    public class SubmitButton:ActionNameSelectorAttribute
    {
        public string Name { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, System.Reflection.MethodInfo methodInfo)
        {
            var value = controllerContext.
                Controller.ValueProvider.GetValue(Name);

            if (value == null)
            {
                return false;
            }
                return true;
        }
    }


    public class SubmitController : Controller
    {
        public ActionResult Click()
        {
            return View("Submit");
        }
        [SubmitButton(Name="Save")]
        public ActionResult Save()
        {
            return Content("Save Called");
        }

        [SubmitButton(Name = "Delete")]
        public ActionResult Delete()
        {
            return Content("Delete Called");
        }
    }
}