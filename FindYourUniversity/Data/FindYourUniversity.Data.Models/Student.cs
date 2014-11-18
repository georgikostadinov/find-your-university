namespace FindYourUniversity.Data.Models
{
    using System.Collections.Generic;

    public class Student : ApplicationUser
    {
        public Student()
        {
            this.ImageDocuments = new HashSet<ImageDocument>();
            this.Applications = new HashSet<Application>();            
        }
        public virtual StudentInfo StudentInfo { get; set; }
        public virtual StudentContactInfo ContactInfo { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<ImageDocument> ImageDocuments { get; set; }
    }
}
