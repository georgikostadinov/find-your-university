using FindYourUniversity.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class Application : DeletableEntity
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string UniversityId { get; set; }
        public virtual University University { get; set; }
        public DateTime DateCreated { get; set; }
        public ApplicationStatus Status { get; set; }
        public string Text { get; set; }
    }
}
