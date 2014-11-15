using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.ViewModels
{
    public class UniversitiesGroupedByLetterViewModel
    {
        public string Letter { get; set; }
        public IEnumerable<UniversityViewModel> Universities { get; set; }
    }
}