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
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UniversityId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Faculty, FacultyViewModel>().ReverseMap();
        }
    }
}