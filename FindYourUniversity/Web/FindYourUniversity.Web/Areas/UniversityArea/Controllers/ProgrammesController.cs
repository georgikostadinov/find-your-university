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
                //.Where(p => p.Faculty.University.Id == this.CurrentUniversity.Id)
                .Project().To<ProgrammeViewModel>();

            return Json(programmes.ToDataSourceResult(request));
        }
    }
}