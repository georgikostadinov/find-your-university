using FindYourUniversity.Data;
using FindYourUniversity.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourUniversity.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ApplicationUser CurrentUser 
        {
            get 
            {
                return this.UserManager.FindById(User.Identity.GetUserId());
            }
        }
    }
}