using System.Web.Mvc;

namespace Community_Medicine_Automation_App
{
    public class FilterConfig
    {
  
            public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
                filters.Add(new HandleErrorAttribute());
            }
        
    
     }
}