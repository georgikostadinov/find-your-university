namespace FindYourUniversity.Data.Models
{
    using FindYourUniversity.Data.Common.Models;
    using System.Collections.Generic;

    public class Faculty : DeletableEntity
    {
        public Faculty()
        {
            this.Programmes = new HashSet<Programme>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniversityId { get; set; }
        public virtual University University { get; set; }
        public virtual ICollection<Programme> Programmes { get; set; }
    }
}
