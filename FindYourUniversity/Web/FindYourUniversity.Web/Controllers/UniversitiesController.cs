namespace FindYourUniversity.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    
    using FindYourUniversity.Data;
    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.ViewModels;

    public class UniversitiesController : BaseController
    {
        public UniversitiesController(IFindYourUniversityData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GroupedByName()
        {

            var models = this.Data.Universities
                .All()
                .GroupBy(u => u.UniversityInfo.Name.Substring(0, 1))
                .Select(group => new UniversitiesGroupedByLetterViewModel()
                {
                    Letter = group.Key,
                    Universities = group.Select(university => new UniversityViewModel()
                    {
                        Id = university.Id,
                        Name = university.UniversityInfo.Name
                    })
                });

            return PartialView("_GroupedByName", models);
        }
        public ActionResult GroupedByCity()
        {

            var models = this.Data.Universities
                .All()
                .GroupBy(u => u.ContactInfo.City.Name)
                .Select(group => new UniversitiesGroupedByCityViewModel()
                {
                    CityName = group.Key,
                    Universities = group.Select(university => new UniversityViewModel()
                    {
                        Id = university.Id,
                        Name = university.UniversityInfo.Name
                    })
                });

            return PartialView("_GroupedByCity", models);
        }

        public ActionResult GroupedByFaculty()
        {
            var models = this.Data.Faculties
                .All()
                .GroupBy(f=>f.Name)
                .Select(group => new UniversitiesGroupedByFacultyViewModel()
                {
                    FacultyName = group.Key,
                    Universities = group.Select(faculty => new UniversityViewModel()
                    {
                        Id = faculty.UniversityId,
                        Name = faculty.University.UniversityInfo.Name
                    })
                });

            return PartialView("_GroupedByFaculty", models);
        }

        public ActionResult Details(string id)
        {
            var university = this.Data.Universities.GetById(id);
            // TODO: Message if not fount
            var model = Mapper.Map<University, UniversityDetailsViewModel>(university);
            return View(model);
        }
    }
}