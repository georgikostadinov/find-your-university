﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class University : ApplicationUser
    {
        public University()
        {
            this.Programmes = new HashSet<Programme>();
            this.Faculties = new HashSet<Faculty>();
            this.Applications = new HashSet<Application>();
        }
        public int? UniversityInfoId { get; set; }
        public virtual UniversityInfo UniversityInfo { get; set; }
        public virtual ICollection<Programme> Programmes { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}