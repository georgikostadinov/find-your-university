namespace FindYourUniversity.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FindYourUniversity.Data.Common.Models;

    public class StudentContactInfo : DeletableEntity
    {
        [Key, ForeignKey("Student")]
        public string Id { get; set; }
        public virtual Student Student { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}
