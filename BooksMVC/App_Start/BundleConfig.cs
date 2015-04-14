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
        /// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        /// </summary>
        /// <param name="bundles">Collection of bundles to register.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new StyleBundle("~/bundles/Content").Include(
                        "~/Content/Books.css",
                        "~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/jquery.validate.mizxn.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.validate.mizxn.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-{version}.js"));

            Bundle bundleScripts = new ScriptBundle("~/bundles/Scripts").Include(
                "~/Scripts/Model/author.js",
                "~/Scripts/Model/book.js",
                "~/Scripts/ViewModel/bookViewModel.js",
                "~/Scripts/ViewModel/authorViewModel.js",
                "~/Scripts/ViewModel/booksViewModel.js",
                "~/Scripts/ViewModel/masterViewModel.js",
                "~/Scripts/BooksNS/books.js");
            bundleScripts.Transforms.Clear();
            bundles.Add(bundleScripts);
        }
    }
}