using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.ViewModels
{
    public class ProgrammeLinkViewModel : IMapFrom<Programme>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}