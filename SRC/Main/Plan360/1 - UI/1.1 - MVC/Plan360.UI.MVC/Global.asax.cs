using Plan360.UI.MVC.AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Plan360.UI.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();

        }
    }
}
