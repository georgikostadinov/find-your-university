using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindYourUniversity.Data.Models
{
    public class Interest
    {
        public Interest()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
