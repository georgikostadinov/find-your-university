namespace FindYourUniversity.Data.Models
{
    using FindYourUniversity.Data.Common.Models;
    using System;

    public class News : DeletableEntity
    {
        public int Id { get; set; }
        public DateTime DatePosted { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int ViewsCount { get; set; }
        public string PictureUrl { get; set; }
    }
}
