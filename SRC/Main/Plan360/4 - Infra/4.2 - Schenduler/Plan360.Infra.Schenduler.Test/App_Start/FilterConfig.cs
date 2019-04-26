using System.Web.Mvc;

namespace Plan360.Infra.Schenduler.Test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
