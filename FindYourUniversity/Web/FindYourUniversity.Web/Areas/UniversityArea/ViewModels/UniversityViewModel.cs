using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    public class UniversityViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }
        public UniversityInfo UniversityInfo { get; set; }
        public ICollection<Programme> Programmes { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}