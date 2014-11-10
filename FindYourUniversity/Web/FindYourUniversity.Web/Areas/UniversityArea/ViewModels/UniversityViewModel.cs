using AutoMapper;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    public class UniversityViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        public string PictureUrl { get; set; }
        public UniversityInfo UniversityInfo { get; set; }
        public ICollection<Programme> Programmes { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
        public ICollection<Application> Applications { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration
                   .CreateMap<University, UniversityViewModel>()
                   .ForMember(uvm => uvm.Applications, opt => opt.MapFrom(u => u.Applications)).ReverseMap();
            configuration
                .CreateMap<University, UniversityViewModel>()
                .ForMember(uvm => uvm.Faculties, opt => opt.MapFrom(u => u.Faculties)).ReverseMap();
            configuration
                .CreateMap<University, UniversityViewModel>()
                .ForMember(uvm => uvm.Programmes, opt => opt.MapFrom(u => u.Programmes)).ReverseMap();
            configuration
                .CreateMap<University, UniversityViewModel>()
                .ForMember(uvm => uvm.UniversityInfo, opt => opt.MapFrom(u => u.UniversityInfo)).ReverseMap();
        }
    }
}