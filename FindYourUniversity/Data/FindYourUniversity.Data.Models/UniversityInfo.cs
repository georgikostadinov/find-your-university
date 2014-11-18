namespace FindYourUniversity.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FindYourUniversity.Data.Common.Models;

    public class UniversityInfo : DeletableEntity
    {
        [Key, ForeignKey("University")]
        public string Id { get; set; }
        public virtual University University { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
    }
}
