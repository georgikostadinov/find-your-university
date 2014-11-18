namespace FindYourUniversity.Web.ViewModels
{
    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CourseViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }
        
        [Display(Name="Име на курса")]
        public string Name { get; set; }

        [Display(Name = "Кредити")]
        public int Credits { get; set; }
        
        [Display(Name = "Часове")]
        public int Hours { get; set; }
        
        [Display(Name = "Семестър")]
        public int Semester { get; set; }
    }
}