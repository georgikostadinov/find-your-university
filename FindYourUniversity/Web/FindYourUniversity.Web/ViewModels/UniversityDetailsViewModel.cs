using AutoMapper;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;

namespace FindYourUniversity.Web.ViewModels
{
    public class UniversityDetailsViewModel : IMapFrom<University>, IHaveCustomMappings
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Information { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public IEnumerable<FacultyLinkViewModel> Faculties { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<University, UniversityDetailsViewModel>()
                .ForMember(model => model.Name, opt => opt.MapFrom(university => university.UniversityInfo.Name))
                .ForMember(model => model.Information, opt => opt.MapFrom(university => university.UniversityInfo.Information))
                .ForMember(model => model.Address, opt => opt.MapFrom(university => university.ContactInfo.Address))
                .ForMember(model => model.PhoneNumber, opt => opt.MapFrom(university => university.ContactInfo.Telephone))
                .ForMember(model => model.Website, opt => opt.MapFrom(university => university.ContactInfo.Website))
                .ForMember(model => model.Email, opt => opt.MapFrom(university => university.ContactInfo.Email))
                .ForMember(model => model.Faculties, opt => opt.MapFrom(university => university.Faculties.AsQueryable().Project().To<FacultyLinkViewModel>()));
        }
    }
}