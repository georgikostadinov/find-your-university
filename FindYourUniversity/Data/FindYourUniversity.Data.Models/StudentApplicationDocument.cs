using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class StudentApplicationDocument
    {
        public int Id { get; set; }
        public ApplicationDocumentType DocumentType { get; set; }
        public byte[] Image { get; set; }
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}
