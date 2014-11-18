namespace FindYourUniversity.Web.ViewModels
{
    using System.Collections.Generic;

    public class UniversitiesGroupedByLetterViewModel
    {
        public string Letter { get; set; }
        public IEnumerable<UniversityViewModel> Universities { get; set; }
    }
}