using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.ViewModels
{
    public class UniversitiesGroupedByFacultyViewModel
    {
        public string FacultyName { get; set; }
        public IEnumerable<UniversityViewModel> Universities { get; set; }
    }
}