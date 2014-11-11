using FindYourUniversity.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data.Models
{
    public class Subject : DeletableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
