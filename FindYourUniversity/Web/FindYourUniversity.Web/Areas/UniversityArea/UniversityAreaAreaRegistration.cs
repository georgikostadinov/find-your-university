using System.Web.Mvc;

namespace FindYourUniversity.Web.Areas.UniversityArea
{
    public class UniversityAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UniversityArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UniversityArea_default",
                "UniversityArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}