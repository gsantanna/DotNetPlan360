using System.Web.Optimization;

namespace Plan360.UI.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery.selectBoxIt.css"));

            //Add plan360UI and Nofity 
            bundles.Add(new ScriptBundle("~/bundles/Plan360UI").Include(
                "~/Scripts/Plan360.UI/plan360*"));



            //JQuery UI
            bundles.Add(new ScriptBundle("~/bundles/JQueryUI").Include(
                "~/Scripts/jquery-ui-1.11.2/jquery-ui.min.js",
                "~/Scripts/jquery.selectBoxIt.min.js"
                ));

            //Bootstrap Table
            bundles.Add( new ScriptBundle("~/bundles/bootstrap-table").Include(
                "~/Scripts/bootstrap-table-min.js",
                "~/Scripts/bootstrap-table-pt-BR.min.js")
                );

            bundles.Add(new StyleBundle("~/Content/bootstrap-table").Include(
                "~/Content/bootstrap-table.min.css"
                )
                );
          




        }
    }
}
