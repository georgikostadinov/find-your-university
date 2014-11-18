namespace FindYourUniversity.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using FindYourUniversity.Data;
    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.ViewModels;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    public class ProgrammesController : BaseController
    {

        public ProgrammesController(IFindYourUniversityData data)
            : base(data)
        { }
        // GET: Programmes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var programme = this.Data.Programmes.GetById(id);
            var model = Mapper.Map<Programme, ProgrammeViewModel>(programme);

            if (User.Identity.IsAuthenticated && User.IsInRole("Student"))
            {
                model.CanApply = true;
                var userId = this.User.Identity.GetUserId();
                var applications = this.Data.Students.GetById(userId).Applications;
                foreach (var app in applications)
                {
                    if (app.ProgrammeId == id)
                    {
                        model.HasApplied = true;
                        break;
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult GetCoursesByProgramme([DataSourceRequest]DataSourceRequest request, int programmeId)
        {
            var pr = this.Data.Programmes.GetById(programmeId);

            var courses = this.Data
                .Programmes
                .GetById(programmeId)
                .Courses
                .AsQueryable()
                .Project()
                .To<CourseViewModel>();

            return Json(courses.ToDataSourceResult(request));
        }
    }
}