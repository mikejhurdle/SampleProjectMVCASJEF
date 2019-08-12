using System.Web;
using System.Web.Optimization;

namespace SampleProjectMVCAJSEF
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular/angular.min.js",
                "~/Scripts/angular/angular-aria.min.js",
                "~/Scripts/angular/angular-animate.min.js",
                "~/Scripts/angular/angular-material.min.js",
                "~/Scripts/angular/ng-google-chart.min.js",
                "~/Scripts/angular/dirPagination.js",
                "~/AngularApp/app.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/angular-*",
                      "~/Content/site.css"));
        }
    }
}
