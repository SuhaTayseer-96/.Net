using System.Web;
using System.Web.Mvc;

namespace Passing_V_to_C___vice_versa
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
