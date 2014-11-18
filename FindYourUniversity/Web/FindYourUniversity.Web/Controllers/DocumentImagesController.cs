namespace FindYourUniversity.Web.Controllers
{
    using System.Web.Mvc;

    using FindYourUniversity.Data;

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
            return null;
        }
    }
}