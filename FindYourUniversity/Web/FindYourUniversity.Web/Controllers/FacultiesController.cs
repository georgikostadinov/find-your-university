using FindYourUniversity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using FindYourUniversity.Web.ViewModels;
namespace FindYourUniversity.Web.Controllers
{
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