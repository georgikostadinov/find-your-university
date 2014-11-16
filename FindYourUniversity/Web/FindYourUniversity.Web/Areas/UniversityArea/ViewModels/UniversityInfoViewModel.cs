namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using AutoMapper;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;
    public class UniversityInfoViewModel: IMapFrom<UniversityInfo>, IHaveCustomMappings
    {
        [Display(Name = "Име на университета")]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Информация")]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Information { get; set; }
        public string PictureUrl { get; set; }
        public HttpPostedFileBase Image { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<UniversityInfo, UniversityInfoViewModel>().ReverseMap();
        }
    }
}