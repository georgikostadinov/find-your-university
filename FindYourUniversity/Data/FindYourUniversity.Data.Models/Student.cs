using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class Student : ApplicationUser
    {
        public Student()
        {
            this.Interests = new HashSet<Interest>();
            this.Marks = new HashSet<Mark>();
            this.Applications = new HashSet<Application>();            
        }
        public int? StudentInfoId { get; set; }
        public virtual StudentInfo StudentInfo { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<Application> Applications { get; set; }        
    }
}
