namespace FindYourUniversity.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using FindYourUniversity.Data;
    using FindYourUniversity.Web.ViewModels;

    public class FacultiesController : BaseController
    {
        public FacultiesController(IFindYourUniversityData data)
            : base(data)
        {
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProgrammesPartial(int facultyId)
        {
            var faculty = this.Data.Faculties.GetById(facultyId);
            // TODO: Show message if not found;

            var programmesModels = faculty.Programmes.AsQueryable().Project().To<ProgrammeLinkViewModel>();
            return PartialView("_FacultyProgrammesPartial", programmesModels);
        }
    }
}