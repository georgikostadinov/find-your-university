﻿namespace FindYourUniversity.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FindYourUniversity.Data.Common.Models;

    public class UniversityContactInfo : DeletableEntity
    {
        [Key, ForeignKey("University")]
        public string Id { get; set; }
        public virtual University University { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }
    }
}
