using System.Web;
using System.Web.Optimization;

namespace FindYourUniversity.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            RegisterScripts(bundles);
            RegisterStyles(bundles);

            BundleTable.EnableOptimizations = false;
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                "~/Content/kendo/kendo.common.min.css",
                "~/Content/kendo/kendo.common-bootstrap.min.css",
                "~/Content/kendo/kendo.silver.min.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/css/animate.min.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/main.css",
                "~/Content/css/prettyPhoto.css",
                "~/Content/css/responsive.css"
                ));
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/kendo/kendo.all.min.js",
                "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                          "~/Scripts/kendo/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
                 "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                    "~/Content/js/jquery.prettyPhoto.js",
                    "~/Content/js/jquery.isotope.min.js",
                    "~/Content/js/main.js",
                    "~/Content/js/wow.min.js"
                ));

        }
    }
}
