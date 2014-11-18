using FindYourUniversity.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class ImageDocument : DeletableEntity
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int ApplicationDocumentTypeId { get; set; }
        public virtual ApplicationDocumentType ApplicationDocumentType { get; set; }
        public string StudentId { get; set; }
        public virtual  Student Student { get; set; }
    }
}
