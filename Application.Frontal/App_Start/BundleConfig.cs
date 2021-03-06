﻿using System.Web;
using System.Web.Optimization;

namespace Application.Frontal
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region Css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/theme.css",
                     "~/Content/site.css",
                     "~/Content/spin.css"));

            //Datatable Css
            bundles.Add(new StyleBundle("~/Content/datatables")
                                .Include("~/Scripts/datatables.min.css"));
            #endregion

            #region JS
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                       "~/Scripts/moment.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //Datatable
            bundles.Add(new ScriptBundle("~/bundles/datatables")
                            .Include("~/Scripts/datatables.min.js"));
            #endregion


            #region App Files
            bundles.Add(new ScriptBundle("~/bundles/App")
                            .Include("~/Scripts/App/App.js"));
            #endregion




        }
    }
}
