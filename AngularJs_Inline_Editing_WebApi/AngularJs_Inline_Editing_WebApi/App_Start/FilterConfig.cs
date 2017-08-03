using System.Web;
using System.Web.Mvc;

namespace AngularJs_Inline_Editing_WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}