using System.Web;
using System.Web.Optimization;

namespace TesteAxado
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.mask.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/Site.js",
                        "~/Scripts/raty/jquery.raty.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
                "~/Scripts/raty/jquery.raty.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap/css/bootstrap.css", 
                "~/Content/bootstrap/css/bootstrap-theme.css"));
        }
    }
}