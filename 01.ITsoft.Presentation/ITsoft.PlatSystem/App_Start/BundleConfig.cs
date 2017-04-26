using System.Web;
using System.Web.Optimization;
namespace ITsoft.PlatSystem
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-2.1.1.min.js",
                        "~/Scripts/jquery/jquery.ui.custom.js",
                        "~/Scripts/jquery/jquery.cookie.js",
                        "~/Scripts/jquery/jquery.gritter.min.js",
                        "~/Scripts/jquery/jquery.md5.js",
                        "~/Scripts/jquery/jquery.bootstrap-duallistbox.min.js",
                        "~/Scripts/jquery/plugins/jquery.unobtrusive/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/bootstrap.min.js",
                      "~/Scripts/bootstrap/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap/bootstrap-colorpicker.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/unicorn").Include(
                      "~/Scripts/unicorn.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-responsive.min.css",
                      "~/Content/datepicker.css",
                      "~/Content/colorpicker.css",
                      "~/Content/bootstrap-duallistbox.min.css",
                      "~/Content/prettify.css",
                      "~/Content/common.css",
                      "~/Content/unicorn.css",
                      "~/Content/unicorn.main.css",
                      "~/Content/unicorn.grey.css",
                      "~/Content/jquery.gritter.css"));
        }
    }
}
