using FindYourUniversity.Data;
using FindYourUniversity.Web.Areas.UniversityArea.Controllers.Base;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using FindYourUniversity.Web.Areas.UniversityArea.ViewModels;
using Kendo.Mvc.Extensions;
using FindYourUniversity.Data.Models;
using AutoMapper;
using System.Globalization;

namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
    public class ProgrammesController : UniversityBaseController
    {
        public ProgrammesController(IFindYourUniversityData data)
            : base(data)
        { 
            
        }
        
        // GET: UniversityArea/Programmes
        public ActionResult Index()
        {           
            ViewData["degrees"] = this.Data.Degrees.All().ToArray();
            var faculties = this.Data.Faculties.All().Select(f => new 
            {
                Id = f.Id,
                Name = f.Name
            });
            ViewData["faculties"] = faculties.ToArray();

            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var programmes = this.Data.Programmes.All()
                .Where(p => p.Faculty.University.Id == this.CurrentUniversity.Id)
                .Project().To<ProgrammeViewModel>();

            return Json(programmes.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ProgrammeViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<ProgrammeViewModel, Programme>(model);
                dbModel.UniversityId = this.CurrentUniversity.Id;
                this.Data.Programmes.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ProgrammeViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var programme = this.Data.Programmes.GetById(model.Id);
                Mapper.Map<ProgrammeViewModel, Programme>(model,programme);
                this.Data.Programmes.Update(programme);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }


        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, [Bind(Include = "Id")] ProgrammeViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var programmeToDelete = this.Data.Programmes.GetById(model.Id);
                this.Data.Programmes.Delete(programmeToDelete);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}