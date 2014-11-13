using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using FindYourUniversity.Data;
using AutoMapper;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Areas.UniversityArea.ViewModels;
using FindYourUniversity.Web.Areas.UniversityArea.Controllers.Base;
using System.Collections;
using AutoMapper.QueryableExtensions;

namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
    public class FacultiesController : UniversityBaseController
    {
        public FacultiesController(IFindYourUniversityData data)
            : base(data)
        {
        }
        // GET: UniversityArea/Faculties
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var faculties = this.Data.Faculties.All()
                .Where(f => f.UniversityId == this.CurrentUniversity.Id)
                .Project().To<FacultyViewModel>();

            return Json(faculties.ToDataSourceResult(request));
        }

        public ActionResult Update([DataSourceRequest]DataSourceRequest request, [Bind(Include = "Id, Name")] FacultyViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var faculty = this.Data.Faculties.GetById(model.Id);
                faculty.Name = model.Name;
                this.Data.Faculties.Update(faculty);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Create([DataSourceRequest]DataSourceRequest request, FacultyViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.UniversityId = this.CurrentUniversity.Id;
                var dbModel = Mapper.Map<FacultyViewModel, Faculty>(model);
                this.Data.Faculties.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, [Bind(Include = "Id")] FacultyViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var facultyToDelete = this.Data.Faculties.GetById(model.Id);
                this.Data.Faculties.Delete(facultyToDelete);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}