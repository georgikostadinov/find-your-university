namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    using System.Web.Mvc;

    using AutoMapper;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CourseViewModel : IMapFrom<Course>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name="Име на курса")]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Семестър")]
        [Range(0, 15)]
        public int Semester { get; set; }

        [Display(Name = "Кредити")]
        [Range(0, 100)]
        public int Credits { get; set; }

        [Display(Name = "Часове")]
        [Range(0, 200)]
        public int Hours { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProgrammeId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Course, CourseViewModel>().ReverseMap();
        }
    }
}