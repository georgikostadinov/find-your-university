using FindYourUniversity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourUniversity.Web.Controllers
{
    public class DocumentImagesController : BaseController
    {
        public DocumentImagesController(IFindYourUniversityData data)
            : base(data)
        { }

        public ActionResult DeleteById(int id)
        {
            var document = this.Data.DocumentImages.GetById(id);
            this.Data.DocumentImages.Delete(document);
            this.Data.SaveChanges();
            return Content("da");
        }

    }
}