﻿using System.Web;
using System.Web.Optimization;
namespace _91itsoft.PlatSystem
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.7.2.min.js",
                        "~/Scripts/jquery.ui.custom.js",
                        "~/Scripts/jquery.gritter.min.js",
                        "~/Scripts/plugins/jquery.unobtrusive/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap-colorpicker.js",
                      "~/Scripts/jquery.bootstrap-duallistbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/unicorn").Include(
                      "~/Scripts/unicorn.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                      "~/Scripts/common.js"));

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
