using System.Web;
using System.Web.Mvc;

namespace panasyukva_apriorit_booksmvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}