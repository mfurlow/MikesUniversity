﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MikesUniversity.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/*.css"));

            bundles.Add(new ScriptBundle("~/bundles/client-featuresscripts").Include("~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new StyleBundle("~/Scripts/jquery").Include("~/Content/.css"));
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include("~/Scripts/jquery-(version).js", "~/Scripts/jquery.unobtrusive-ajax.js"));
        }
    }
}