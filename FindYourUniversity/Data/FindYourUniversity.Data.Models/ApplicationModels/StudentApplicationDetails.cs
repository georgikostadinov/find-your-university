namespace FindYourUniversity.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FindYourUniversity.Data.Common.Models;

    public class StudentApplicationDetails : DeletableEntity
    {
        [Key, ForeignKey("Application")]
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string School { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
