namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers.Base
{
    using System.Web.Mvc;

    using FindYourUniversity.Data;
    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Controllers;

    [Authorize(Roles = "University")]
    public abstract class UniversityBaseController : BaseController
    {
        protected UniversityBaseController(IFindYourUniversityData data)
            : base(data)
        { }

        protected University CurrentUniversity
        {
            get
            {
                var user = this.CurrentUser;
                return this.CurrentUser as University;
            }
        }
    }
}