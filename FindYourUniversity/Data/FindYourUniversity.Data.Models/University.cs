namespace FindYourUniversity.Data.Models
{
    using System.Collections.Generic;

    public class University : ApplicationUser
    {
        public University()
        {
            this.Programmes = new HashSet<Programme>();
            this.Faculties = new HashSet<Faculty>();
            this.Applications = new HashSet<Application>();
        }
        public virtual UniversityInfo UniversityInfo { get; set; }
        public virtual UniversityContactInfo ContactInfo { get; set; }
        public virtual ICollection<Programme> Programmes { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
