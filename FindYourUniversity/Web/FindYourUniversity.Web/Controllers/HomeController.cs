using FindYourUniversity.Data.Common.Repository;
using FindYourUniversity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using FindYourUniversity.Web.ViewModels;

namespace FindYourUniversity.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<ApplicationUser> users;
        public HomeController(IRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
           // var userViewModels = this.users.All().Where(u => u.IsDeleted == false).Project().To<UserViewModel>().ToList();
            return View();
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