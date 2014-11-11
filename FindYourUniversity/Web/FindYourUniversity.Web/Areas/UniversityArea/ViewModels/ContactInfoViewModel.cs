using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    public class ContactInfoViewModel : IMapFrom<ContactInfo>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<ContactInfo, ContactInfoViewModel>().ReverseMap();
        }
    }
}