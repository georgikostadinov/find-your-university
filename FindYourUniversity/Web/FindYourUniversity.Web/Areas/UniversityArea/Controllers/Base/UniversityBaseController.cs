namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers.Base
{
    using System.Web.Mvc;
    using System.Linq;

    using FindYourUniversity.Data;
    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Controllers;

    [Authorize(Roles = "University")]
    public abstract class UniversityBaseController : BaseController
    {
        protected UniversityBaseController(IFindYourUniversityData data)
            : base(data)
        { }

        protected University CurrentUniversity
        {
            get
            {
                var user = this.CurrentUser;
                return this.CurrentUser as University;
            }
        }

        protected void DeleteCourses(int programmeId)
        {
            var courses = this.Data.Courses.All().Where(c => c.ProgrammeId == programmeId);
            foreach (var course in courses)
            {
                this.Data.Courses.Delete(course);
            }
            this.Data.SaveChanges();
        }

        protected void DeleteProgrammes(int facultyId)
        {
            var programmes = this.Data.Programmes.All().Where(p => p.FacultyId == facultyId).ToList();
            foreach (var programme in programmes)
            {
                this.DeleteCourses(programme.Id);
                this.Data.Programmes.Delete(programme.Id);
            }
            this.Data.SaveChanges();
        }
    }
}