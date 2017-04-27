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

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/plugins/dialog/dialog.js", "~/Scripts/plugins/dialog/dialog.css"));

            bundles.Add(new ScriptBundle("~/bundles/framework").Include(
          "~/Scripts/framework/framework-ui.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/style/framework-font.css",
                      "~/Content/style/framework-theme.css",
                      "~/Content/style/framework-login.css",
                      "~/Content/style/framework-ui.css"
                     ));
        }
    }
}
