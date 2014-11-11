using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class UniversityInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public int ContactInfoId { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
    }
}
