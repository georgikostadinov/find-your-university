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
    public class ContactInfoViewModel : IMapFrom<UniversityContactInfo>, IHaveCustomMappings
    {
        public int? CityId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<UniversityContactInfo, ContactInfoViewModel>().ReverseMap();
        }
    }
}