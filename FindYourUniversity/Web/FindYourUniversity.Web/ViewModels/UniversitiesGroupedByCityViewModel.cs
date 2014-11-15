using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.ViewModels
{
    public class UniversitiesGroupedByCityViewModel
    {
        public string CityName { get; set; }
        public IEnumerable<UniversityViewModel> Universities { get; set; }
    }
}