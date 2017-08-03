using System.Web;
using System.Web.Optimization;

namespace AngularJs_Inline_Editing_WebApi
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/js").Include(
                      "~/Scripts/jquery-1.10.2.js",
                      "~/Scripts/angular.js",
                      "~/Scripts/app.js"));
        }
    }
}