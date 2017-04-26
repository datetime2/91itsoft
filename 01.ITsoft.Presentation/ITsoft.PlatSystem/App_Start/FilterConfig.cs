using System.Web.Mvc;
namespace ITsoft.PlatSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AjaxExceptionAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}