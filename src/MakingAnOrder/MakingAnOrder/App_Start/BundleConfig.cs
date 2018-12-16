using System.Web.Optimization;

namespace MakingAnOrder
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStyleBundles(bundles);

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-plugins").Include(
                "~/Scripts/bootstrap-datepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-3.4.2.js",
                "~/Scripts/knockout.mapping-latest.js"));

            bundles.Add(new ScriptBundle("~/bundles/libraries").Include(
                "~/Scripts/toastr.min.js",
                "~/Scripts/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/polyfills").Include(
                "~/Scripts/polyfills.js"));

            bundles.Add(new ScriptBundle("~/bundles/app-services").Include(
                "~/Scripts/app/services/toastr-service.js",
                "~/Scripts/app/services/ajax-service.js",
                "~/Scripts/app/services/modal-service.js"));

            bundles.Add(new ScriptBundle("~/bundles/app-general").Include(
                "~/Scripts/app/constants.js",
                "~/Scripts/app/app-navbar.js"));

            bundles.Add(new ScriptBundle("~/bundles/app-pages").Include(
                "~/Scripts/app/main-page.js",
                "~/Scripts/app/product-create.js",
                "~/Scripts/app/purchase.js",
                "~/Scripts/app/order-history.js"));
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}
