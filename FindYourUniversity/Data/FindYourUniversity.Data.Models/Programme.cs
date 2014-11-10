using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class Programme
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
        public ICollection<Course> Courses { get; set; }
    }
}
