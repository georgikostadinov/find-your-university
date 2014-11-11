using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    public class UniversityInfoViewModel: IMapFrom<UniversityInfo>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public string PictureUrl { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<UniversityInfo, UniversityInfoViewModel>().ReverseMap();
        }
    }
}