namespace FindYourUniversity.Web.ViewModels
{
    using System.Collections.Generic;

    public class UniversitiesGroupedByCityViewModel
    {
        public string CityName { get; set; }
        public IEnumerable<UniversityViewModel> Universities { get; set; }
    }
}