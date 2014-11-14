using FindYourUniversity.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            this.ImageDocuments = new HashSet<DocumentImage>();
            this.Applications = new HashSet<Application>();            
        }
        public virtual StudentInfo StudentInfo { get; set; }
        public virtual StudentContactInfo ContactInfo { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<DocumentImage> ImageDocuments { get; set; }
    }
}
