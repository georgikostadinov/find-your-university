using AutoMapper;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.ViewModels
{
    public class StudentViewModel : IMapFrom<Student>, IHaveCustomMappings
    {
        public StudentViewModel()
        {
            this.Interests = new HashSet<Interest>();
            this.Marks = new HashSet<Mark>();
            this.Applications = new HashSet<Application>();
        }
        public int? StudentInfoId { get; set; }
        public virtual StudentInfo StudentInfo { get; set; }
        public string PictureUrl { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<Application> Applications { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Student, StudentViewModel>().ReverseMap();
        }
    }
}