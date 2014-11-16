using AutoMapper;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.ViewModels
{
    public class FacultyLinkViewModel : IMapFrom<Faculty>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Faculty, FacultyLinkViewModel>();
        }
    }
}