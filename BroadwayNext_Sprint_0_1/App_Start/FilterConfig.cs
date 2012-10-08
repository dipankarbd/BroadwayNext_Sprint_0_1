using System.Web;
using System.Web.Mvc;

namespace BroadwayNext_Sprint_0_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}