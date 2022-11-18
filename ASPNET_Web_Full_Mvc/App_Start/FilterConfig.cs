using System.Web;
using System.Web.Mvc;

namespace ASPNET_Web_Full_Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
