namespace FindYourUniversity.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FindYourUniversity.Data.Common.Models;

    public class StudentInfo : DeletableEntity
    {
        [Key, ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string School { get; set; }
    }
}
