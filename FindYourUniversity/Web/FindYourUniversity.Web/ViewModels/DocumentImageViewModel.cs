using FindYourUniversity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourUniversity.Web.ViewModels
{
    public class DocumentImageViewModel
    {
        public HttpPostedFileBase Image { get; set; }
        public int DocumentTypeId { get; set; }
    }
}