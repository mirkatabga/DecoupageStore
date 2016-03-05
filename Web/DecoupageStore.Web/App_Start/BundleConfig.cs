using System.Web;
using System.Web.Optimization;

namespace DecoupageStore.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStylesBundles(bundles);
            RegisterScriptsBundles(bundles);
        }

        private static void RegisterStylesBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/Products.css"));

            bundles.Add(new StyleBundle("~/Styles/css").Include(
                "~/Styles/style-main.css",
                "~/Styles/style-admin.css"));
        }

        private static void RegisterScriptsBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/Scripts/app-scripts/custom").Include(
                "~/Scripts/app-scripts/photo-upload-ui-helper.js",
                "~/Scripts/app-scripts/json-requester.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryunob").Include(
                        "~/Scripts/jquery.unobtrusive-ajax*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
        }
    }
}
