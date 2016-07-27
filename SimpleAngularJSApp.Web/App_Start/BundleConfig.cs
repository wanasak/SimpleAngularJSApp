using System.Web;
using System.Web.Optimization;

namespace SimpleAngularJSApp.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/Vendors/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/Vendors/jquery.js",
                "~/Scripts/Vendors/angular.js",
                "~/Scripts/Vendors/angular-route.js",
                "~/Scripts/Vendors/angular-validator.js",
                "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/modules/common.ui.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/students/add/studentAddCtrl.js",
                "~/Scripts/spa/students/detail/studentDetailCtrl.js",
                "~/Scripts/spa/students/edit/studentEditCtrl.js",
                "~/Scripts/spa/students/index/studentIndexCtrl.js",
                "~/Scripts/spa/students/index/deleteStudentModalCtrl.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/content/css/bootstrap.css",
                "~/content/css/bootstrap-theme.css"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}