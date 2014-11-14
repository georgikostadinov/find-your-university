using AutoMapper;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    public class CourseViewModel : IMapFrom<Course>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public int Credits { get; set; }
        public int Hours { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProgrammeId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Course, CourseViewModel>().ReverseMap();
        }
    }
}