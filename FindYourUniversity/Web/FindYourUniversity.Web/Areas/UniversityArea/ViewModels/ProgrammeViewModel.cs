namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;

    public class ProgrammeViewModel : IMapFrom<Programme>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Име на специалността")]
        [Required(ErrorMessage = "Името на специалността е задължително поле")]
        [MinLength(5, ErrorMessage = "Името на специалността не може бъде по-малко от 5 символа")]
        [MaxLength(100, ErrorMessage = "Името на специалността не може бъде повече от 100 символа")]
        [UIHint("TextBoxField")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [UIHint("Description")]
        public string Description { get; set; }

        [UIHint("GridForeignKey")]
        [Required(ErrorMessage = "Образователната степен е задължително поле")]
        [Display(Name = "Образователна степен")]
        public int DegreeId { get; set; }

        [UIHint("GridForeignKey")]
        [Required(ErrorMessage = "Факултета е задължително поле")]
        [Display(Name = "Факултет")]
        public int FacultyId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Programme, ProgrammeViewModel>().ReverseMap();
        }
    }
}