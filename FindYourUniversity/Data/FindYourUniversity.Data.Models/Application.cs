using FindYourUniversity.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class Application : DeletableEntity
    {
        public Application()
        {
            this.Documents = new HashSet<StudentApplicationDocument>();
        }

        [Key]
        public int Id { get; set; }
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string UniversityId { get; set; }
        public virtual University University { get; set; }
        public int ProgrammeId { get; set; }
        public virtual Programme Programme{ get; set; }
        public virtual StudentApplicationDetails Details { get; set; }
        public virtual ICollection<StudentApplicationDocument> Documents { get; set; }
    }
}
