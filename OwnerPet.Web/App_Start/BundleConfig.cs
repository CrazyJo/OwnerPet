using System.Web.Optimization;

namespace OwnerPet.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Infrastructure").Include("~/Scripts/spa/infra/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/vendors/angular.min.js",
                "~/Scripts/vendors/angular-resource.min.js",
                "~/Scripts/vendors/angular-route.min.js",
                "~/Scripts/vendors/angular-touch.min.js",
                "~/Scripts/vendors/angular-animate.min.js",
                "~/Scripts/vendors/angular-sanitize.min.js",
                "~/Scripts/vendors/angular-ui/ui-bootstrap-tpls.min.js",
                "~/Scripts/vendors/ui-grid.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                 "~/Scripts/spa/app.js",
                 "~/Scripts/spa/services/apiService.js",
                 "~/Scripts/spa/services/userService.js",
                 "~/Scripts/spa/controllers/homeCtrl.js"));

            bundles.Add(new StyleBundle("~/Content/css-one").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/Site.css",
                      "~/Scripts/vendors/ui-grid.min.css"));
        }
    }
}
