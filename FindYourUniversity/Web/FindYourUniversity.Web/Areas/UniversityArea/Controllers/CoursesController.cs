using FindYourUniversity.Data;
using FindYourUniversity.Web.Areas.UniversityArea.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        public JsonResult GetCascadeDegrees()
        {
            var degrees = this.Data.Degrees.All().Select(d => new { Id = d.Id, Name = d.Name });
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
                        Id = f.Id,
                        Name = f.Name
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
                        Id = p.Id,
                        Name = p.Name
                    });

                return Json(programmes, JsonRequestBehavior.AllowGet);
            }

            return null;
        }
    }
}