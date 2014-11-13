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
    public class ProgrammeViewModel : IMapFrom<Programme>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name="Име")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [UIHint("GridForeignKey")]
        [Display(Name = "Образователна степен")]
        public int DegreeId { get; set; }

        [UIHint("GridForeignKey")]
        [Display(Name = "Факултет")]
        public int FacultyId { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Programme, ProgrammeViewModel>().ReverseMap();
        }
    }
}