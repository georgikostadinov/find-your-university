using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class City
    {
        public City()
        {
            this.Students = new HashSet<Student>();
            this.Universities = new HashSet<University>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<University> Universities { get; set; }
    }
}
