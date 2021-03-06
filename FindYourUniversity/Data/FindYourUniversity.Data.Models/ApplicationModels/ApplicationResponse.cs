﻿namespace FindYourUniversity.Data.Models
{
    public class ApplicationResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ApplicationStatus Status { get; set; }
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}
