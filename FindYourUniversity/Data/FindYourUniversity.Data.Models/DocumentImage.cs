using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class DocumentImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public ApplicationDocumentType DocumentType { get; set; }
        public string StudentId { get; set; }
        public virtual  Student Student { get; set; }
    }
}
