using System.Web;
using System.Web.Optimization;

namespace TaskManager.PL.WebAPI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libraries").Include(
                        "~/bower_components/angular/angular.js",
                        "~/bower_components/angular-ui-router/release/angular-ui-router.js",
                        "~/bower_components/lodash/dist/lodash.js"));

            bundles.Add(new ScriptBundle("~/bundles/mainScripts").Include(
                        "~/Scripts/templates.js",/*Порядок важен*/
                        "~/Scripts/app/app.js",
                        "~/Scripts/app/config.js",
                        "~/Scripts/app/controllers/*.js",
                        "~/Scripts/app/values/*.js",
                        "~/Scripts/app/services/*.js",
                        "~/Scripts/app/run/*.js"));

            bundles.Add(new StyleBundle("~/content/libraries").Include("~/Styles/css/allStyles.css"));

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/Content/themes/base/jquery.ui.core.css",
            //            "~/Content/themes/base/jquery.ui.resizable.css",
            //            "~/Content/themes/base/jquery.ui.selectable.css",
            //            "~/Content/themes/base/jquery.ui.accordion.css",
            //            "~/Content/themes/base/jquery.ui.autocomplete.css",
            //            "~/Content/themes/base/jquery.ui.button.css",
            //            "~/Content/themes/base/jquery.ui.dialog.css",
            //            "~/Content/themes/base/jquery.ui.slider.css",
            //            "~/Content/themes/base/jquery.ui.tabs.css",
            //            "~/Content/themes/base/jquery.ui.datepicker.css",
            //            "~/Content/themes/base/jquery.ui.progressbar.css",
            //            "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}