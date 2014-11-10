﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class Faculty
    {
        public Faculty()
        {
            this.Programmes = new HashSet<Programme>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniversityId { get; set; }
        public virtual University University { get; set; }
        public ICollection<Programme> Programmes { get; set; }
    }
}
