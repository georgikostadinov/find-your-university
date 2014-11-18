namespace FindYourUniversity.Data.Models
{
    using FindYourUniversity.Data.Common.Models;
    using System;

    public class Feedback : DeletableEntity
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
