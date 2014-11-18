namespace FindYourUniversity.Web.ViewModels
{
    using AutoMapper;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class ProgrammeViewModel : IMapFrom<Programme>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name="Име")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Образователна степен")]
        public string Degree { get; set; }

        [Display(Name = "Факултет")]
        public string Faculty { get; set; }

        [Display(Name = "Университет")]
        public string University { get; set; }

        public bool CanApply { get; set; }
        public bool HasApplied { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Programme, ProgrammeViewModel>()
                .ForMember(m => m.Degree, opt => opt.MapFrom(p => p.Degree.Name))
                .ForMember(m => m.Faculty, opt => opt.MapFrom(p => p.Faculty.Name))
                .ForMember(m => m.University, opt => opt.MapFrom(p => p.University.UniversityInfo.Name));
        }
    }
}