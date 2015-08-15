using System.Web;
using System.Web.Optimization;

namespace MealViteController
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string jqueryCdnPath = "https://code.jquery.com/jquery-2.1.3.min.js";
            string angularCdnPath = "https://ajax.googleapis.com/ajax/libs/angularjs/1.3.15/angular.min.js";
            string uiRouterCdnPath = "https://cdnjs.cloudflare.com/ajax/libs/angular-ui-router/0.2.11/angular-ui-router.min.js";
            string bootstrapCdnPath = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js";
            string uiBootstrapCdnPath = "https://cdnjs.cloudflare.com/ajax/libs/angular-ui-bootstrap/0.11.0/ui-bootstrap-tpls.min.js";
            string angularStorageCdnPath = "https://cdnjs.cloudflare.com/ajax/libs/angular-local-storage/0.1.4/angular-local-storage.min.js";
            string bootboxCdnPath = "https://cdnjs.cloudflare.com/ajax/libs/bootbox.js/4.4.0/bootbox.min.js";
            string jqueryUICdnPath = "http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js";
            string angularSanitizeCdnPath = "http://ajax.googleapis.com/ajax/libs/angularjs/1.2.28/angular-sanitize.js";
            bundles.UseCdn = true;


            bundles.Add(new ScriptBundle("~/bundles/jquery",
                jqueryCdnPath).Include("~/app/scripts/jquery/jquery-2.1.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui",
                jqueryUICdnPath).Include("~/app/scripts/jquery/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs",
                angularCdnPath).Include("~/app/scripts/angular/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/uiRouter",
                uiRouterCdnPath).Include("~/app/scripts/angular/angular-ui-router.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap",
                bootstrapCdnPath).Include("~/app/scripts/bootstrap/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/uibootstrap",
                uiBootstrapCdnPath).Include("~/app/scripts/bootstrap/ui-bootstrap-tpls-0.13.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularStorage",
                angularStorageCdnPath).Include("~/app/scripts/angular/angular-local-storage.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootbox",
               bootboxCdnPath).Include("~/app/scripts/bootstrap/bootbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/loadingbar")
             .Include("~/app/scripts/angular/loading-bar.min.js"));

             bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/app/app.js"
                ));

             bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/app/css/bootstrap/bootstrap.min.css"));
             bundles.Add(new StyleBundle("~/Content/fontawesome").Include("~/app/css/fontawesome/css/font-awesome.min.css"));
             bundles.Add(new StyleBundle("~/Content/loadingbar").Include("~/app/css/loading-bar.min.css"));
             bundles.Add(new StyleBundle("~/Content/adminlte").Include("~/app/components/adminlte/css/AdminLTE.min.css",
                 "~/app/components/adminlte/css/skins/skin-yellow-light.min.css"));
        }
    }
}
