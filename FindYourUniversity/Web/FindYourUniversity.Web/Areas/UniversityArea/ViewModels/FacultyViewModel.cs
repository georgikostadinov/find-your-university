namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Areas.UniversityArea.ViewModels.Base;
    using FindYourUniversity.Web.Infrastructure.Mapping;

    public class FacultyViewModel : AdministrationViewModel, IMapFrom<Faculty>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Име на факултета")]
        [Required(ErrorMessage = "Името на факултета е задължително поле")]
        [MinLength(5, ErrorMessage = "Името на факултета не може бъде по-малко от 5 символа")]
        [MaxLength(100, ErrorMessage = "Името на факултета не може бъде повече от 100 символа")]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UniversityId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Faculty, FacultyViewModel>().ReverseMap();
        }
    }
}