//------------------------------------------------------
// <copyright file="BundleConfig.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//------------------------------------------------------
namespace Books
{
    #region
    using System.Web;
    using System.Web.Optimization;

    #endregion

    /// <summary>
    /// Represents configurator for Bundling.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registers Bundling.
        /// </summary>
        /// <param name="bundles">Collection of bundles to register.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new StyleBundle("~/bundles/Content").Include(
                        "~/Content/Books.css",
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap.min.css",
                        "~/Content/jquery-ui.css",
                        "~/Content/jquery.multiselect.css",
                        "~/Content/sumoselect.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/jquery.validate.mizxn.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.multiselect.js",
                        "~/Scripts/jquery.sumoselect.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                "~/Scripts/Model/author.js",
                "~/Scripts/Model/book.js",
                "~/Scripts/ViewModel/bookViewModel.js",
                "~/Scripts/ViewModel/authorViewModel.js",
                "~/Scripts/ViewModel/booksViewModel.js",
                "~/Scripts/ViewModel/masterViewModel.js",
                "~/Scripts/BooksNS/books.js"));
        }
    }
}