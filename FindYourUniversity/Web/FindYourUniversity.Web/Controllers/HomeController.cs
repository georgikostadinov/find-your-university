using FindYourUniversity.Data.Common.Repository;
using FindYourUniversity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using FindYourUniversity.Data;
using FindYourUniversity.Web.ViewModels;

namespace FindYourUniversity.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IFindYourUniversityData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult UniversitiesSlider()
        {
            var universities = this.Data.Universities.All().Take(3).Select(u => new UniversitySliderViewModel()
            {
                Id = u.Id,
                Name = u.UniversityInfo.Name,
                Description = u.UniversityInfo.Information.Substring(0, 100),
                PictureUrl = u.PictureUrl
            });

            return PartialView("_UniversitiesSlider", universities);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}