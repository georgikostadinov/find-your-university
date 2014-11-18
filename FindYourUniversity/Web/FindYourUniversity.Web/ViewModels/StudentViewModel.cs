namespace FindYourUniversity.Web.ViewModels
{
    using System.Collections.Generic;

    using AutoMapper;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;

    public class StudentViewModel : IMapFrom<Student>, IHaveCustomMappings
    {
        public StudentViewModel()
        {
            this.ImageDocuments = new HashSet<ImageDocument>();
            this.Applications = new HashSet<Application>();
        }
        public virtual StudentInfo StudentInfo { get; set; }
        public virtual StudentContactInfo ContactInfo { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<ImageDocument> ImageDocuments { get; set; }

        public string PictureUrl { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Student, StudentViewModel>().ReverseMap();
        }
    }
}