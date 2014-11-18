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
        [Required(ErrorMessage="Името на курса трябва да бъде поне 2 символа")]
        [MinLength(2, ErrorMessage = "Името на курса трябва да бъде поне 2 символа")]
        [MaxLength(100, ErrorMessage = "Името на курса не може да бъде по-дълго от 100 символа")]
        public string Name { get; set; }

        [Display(Name = "Семестър")]
        [Required(ErrorMessage = "Семестър е задължително поле")]
        [Range(0, 15, ErrorMessage="Семестърът не може да бъде отрицателно число или повече от 15")]
        public int Semester { get; set; }

        [Display(Name = "Кредити")]
        [Required(ErrorMessage = "Кредити е задължително поле")]
        [Range(0, 100, ErrorMessage = "Кредитите не могат да бъдат отрицателно число или повече от 100")]
        public int Credits { get; set; }

        [Display(Name = "Часове")]
        [Required(ErrorMessage = "Часове е задължително поле")]
        [Range(0, 200, ErrorMessage = "Часовете не могат да бъдат отрицателно число или повече от 100")]
        public int Hours { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required(ErrorMessage = "Не е избрана специалност, към която да се добави курса")]
        public int ProgrammeId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Course, CourseViewModel>().ReverseMap();
        }
    }
}