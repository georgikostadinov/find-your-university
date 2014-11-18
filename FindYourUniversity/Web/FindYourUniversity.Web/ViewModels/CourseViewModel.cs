using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.ViewModels
{
    public class CourseViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int Hours { get; set; }
        public int Semester { get; set; }
    }
}