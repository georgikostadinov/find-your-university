namespace FindYourUniversity.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using FindYourUniversity.Data.Models;

    public class DocumentImageViewModel
    {
        public HttpPostedFileBase Image { get; set; }
        public int DocumentTypeId { get; set; }
    }
}