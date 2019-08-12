using System.Web;
using System.Web.Mvc;

namespace SampleProjectMVCAJSEF
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
