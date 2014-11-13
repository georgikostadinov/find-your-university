using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Areas.UniversityArea.ViewModels.Base;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    public class FacultyViewModel : AdministrationViewModel, IMapFrom<Faculty>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UniversityId { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Faculty, FacultyViewModel>().ReverseMap();
        }
    }
}