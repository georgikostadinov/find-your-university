using FindYourUniversity.Data;
using FindYourUniversity.Web.Areas.UniversityArea.Controllers.Base;
using FindYourUniversity.Web.Areas.UniversityArea.ViewModels;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Kendo.Mvc.Extensions;
using AutoMapper;
using FindYourUniversity.Data.Models;

namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
    public class CoursesController : UniversityBaseController
    {
        public CoursesController(IFindYourUniversityData data)
            : base(data)
        { }
        // GET: UniversityArea/Courses
        public ActionResult Index()
        {
            var programmes = this.Data.Programmes.All().Select(p => new 
            {
                Id = p.Id,
                Name = p.Name
            });

            ViewData["programmes"] = programmes;

            return View();
        }

        public JsonResult GetCascadeDegrees()
        {
            var degrees = this.Data.Degrees
                .All()
                .Select(d => new 
                {
                    DegreeId = d.Id,
                    DegreeName = d.Name
                });

            return Json(degrees, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeFaculties(int? degrees)
        {
            if (degrees != null)
            {
                var faculties = this.Data
                    .Faculties
                    .All()
                    .Select(f => new
                    {
                        FacultyId = f.Id,
                        FacultyName = f.Name
                    });

                return Json(faculties, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        public JsonResult GetCascadeProgrammes(int? degrees, int? faculties)
        {
            if (degrees != null && faculties != null)
            {
                var programmes = this.Data
                    .Programmes
                    .All()
                    .Where(p => p.DegreeId == degrees && p.FacultyId == faculties)
                    .Select(p => new
                    {
                        ProgrammeId = p.Id,
                        ProgrammeName = p.Name
                    });

                return Json(programmes, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request, int ProgId)
        {
            var courses = this.Data.Courses.All().Where(c=>c.ProgrammeId == ProgId)
                .Project().To<CourseViewModel>();

            return Json(courses.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, CourseViewModel model, int ProgId)
        {
            if (model != null && ModelState.IsValid)
            {
                model.ProgrammeId = ProgId;
                var dbModel = Mapper.Map<CourseViewModel, Course>(model);
                this.Data.Courses.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CourseViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var course = this.Data.Courses.GetById(model.Id);
                Mapper.Map<CourseViewModel, Course>(model, course);
                this.Data.Courses.Update(course);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, [Bind(Include = "Id")] CourseViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var courseToDelete = this.Data.Courses.GetById(model.Id);
                this.Data.Courses.Delete(courseToDelete);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}