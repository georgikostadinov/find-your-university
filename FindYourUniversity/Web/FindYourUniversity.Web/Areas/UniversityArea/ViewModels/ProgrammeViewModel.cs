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
        [MinLength(5)]
        [MaxLength(100)]
        [UIHint("TextBoxField")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [UIHint("Description")]
        public string Description { get; set; }

        [UIHint("GridForeignKey")]
        [Display(Name = "Образователна степен")]
        public int DegreeId { get; set; }

        [UIHint("GridForeignKey")]
        [Display(Name = "Факултет")]
        public int FacultyId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Programme, ProgrammeViewModel>().ReverseMap();
        }
    }
}