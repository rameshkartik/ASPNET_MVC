using System.Web;
using System.Web.Mvc;

namespace HtmlOption_Multiple_SubmitButton
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
