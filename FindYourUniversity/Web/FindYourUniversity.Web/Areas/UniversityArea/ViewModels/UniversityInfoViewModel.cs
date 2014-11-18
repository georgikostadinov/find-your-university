namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using AutoMapper;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;
    using System.Web.Mvc;


    public class UniversityInfoViewModel : IMapFrom<UniversityInfo>, IHaveCustomMappings
    {
        [Display(Name = "Име на университета")]
        [Required(ErrorMessage = "Името на университета трябва да бъде поне 5 символа")]
        [MinLength(5, ErrorMessage = "Името на университета трябва да бъде поне 5 символа")]
        [MaxLength(100, ErrorMessage = "Името на университета не трябва да бъде по-дълго от 100 символа")]
        public string Name { get; set; }

        [Display(Name = "Информация")]
        [Required(ErrorMessage = "Информацията за университета трябва да бъде поне 50 символа")]
        [MinLength(50, ErrorMessage = "Информацията за университета трябва да бъде поне 50 символа")]
        [MaxLength(5000, ErrorMessage = "Информацията за университета не трябва да бъде повече от 5000 символа")]
        public string Information { get; set; }
        public string PictureUrl { get; set; }
        public HttpPostedFileBase Image { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<UniversityInfo, UniversityInfoViewModel>().ReverseMap();
        }
    }
}