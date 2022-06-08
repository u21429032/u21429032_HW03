using System.Web;
using System.Web.Mvc;

namespace ismail_HomeworkAssignment3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
