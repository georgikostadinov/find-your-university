namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using FindYourUniversity.Data;
    using FindYourUniversity.Web.Areas.UniversityArea.Controllers.Base;
    using FindYourUniversity.Web.Areas.UniversityArea.ViewModels;
    using FindYourUniversity.Data.Models;

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
            var faculties = this.Data.Faculties.All()
                .Where(faculty=>faculty.UniversityId == this.CurrentUniversity.Id)
                .Select(f => new 
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
                .Where(p => p.University.Id == this.CurrentUniversity.Id)
                .Project().To<ProgrammeViewModel>();

            return Json(programmes.ToDataSourceResult(request));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
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
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
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
        [ValidateAntiForgeryToken]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, [Bind(Include = "Id")] ProgrammeViewModel model)
        {
            if (model != null)
            {
                var programmeToDelete = this.Data.Programmes.GetById(model.Id);
                base.DeleteCourses(model.Id);
                this.Data.Programmes.Delete(programmeToDelete);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}