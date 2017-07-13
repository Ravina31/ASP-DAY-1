using System.Web;
using System.Web.Mvc;

namespace MVC_CRUDUsingEF
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); //makes the error handling global
            filters.Add(new AuthorizeAttribute());
        }
    }
}
