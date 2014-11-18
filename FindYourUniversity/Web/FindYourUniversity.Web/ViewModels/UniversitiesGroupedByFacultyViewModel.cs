namespace FindYourUniversity.Web.ViewModels
{
    using System.Collections.Generic;

    public class UniversitiesGroupedByFacultyViewModel
    {
        public string FacultyName { get; set; }
        public IEnumerable<UniversityViewModel> Universities { get; set; }
    }
}