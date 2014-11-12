﻿using System.Web.Mvc;

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
                "UniversityArea",
                "UniversityArea/{controller}/{action}/{id}",
                new { controller = "CommonInfo", action = "Index", id = UrlParameter.Optional }                
            );
        }
    }
}