using AutoMapper;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.ViewModels
{
    public class UniversityViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration
                .CreateMap<ApplicationUser, UniversityViewModel>()
                .ForMember(uvm => uvm.RegistrationDate, opt => opt.MapFrom(u => u.CreatedOn));
            configuration
                .CreateMap<ApplicationUser, UniversityViewModel>()
                .ForMember(uvm => uvm.Email, opt => opt.MapFrom(u => u.UserName));
        }
    }
}