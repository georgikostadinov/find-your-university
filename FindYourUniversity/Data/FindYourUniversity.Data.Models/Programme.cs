namespace FindYourUniversity.Data.Models
{
    using FindYourUniversity.Data.Common.Models;
    using System.Collections.Generic;

    public class Programme : DeletableEntity
    {
        public Programme()
        {
            this.Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DegreeId { get; set; }
        public virtual Degree Degree { get; set; }
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public string UniversityId { get; set; }
        public virtual University University { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
