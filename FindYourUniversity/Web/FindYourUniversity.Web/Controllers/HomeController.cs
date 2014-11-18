namespace FindYourUniversity.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using FindYourUniversity.Data;
    using FindYourUniversity.Web.ViewModels;

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