namespace FindYourUniversity.Web.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using FindYourUniversity.Data;
    using FindYourUniversity.Data.Models;

    public abstract class BaseController : Controller
    {
        private IFindYourUniversityData data;
        public BaseController(IFindYourUniversityData data)
        {
            this.ApplicationDbContext = new FindYourUniversityDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            this.data = data;
        }

        protected IFindYourUniversityData Data
        {
            get { return this.data; }
        }

        protected FindYourUniversityDbContext ApplicationDbContext { get; set; }

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