using FindYourUniversity.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class UniversityInfo : DeletableEntity
    {
        [Key, ForeignKey("University")]
        public string Id { get; set; }
        public virtual University University { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public int ContactInfoId { get; set; }
    }
}
