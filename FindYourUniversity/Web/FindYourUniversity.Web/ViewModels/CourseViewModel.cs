namespace FindYourUniversity.Web.ViewModels
{
    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;

    public class CourseViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int Hours { get; set; }
        public int Semester { get; set; }
    }
}