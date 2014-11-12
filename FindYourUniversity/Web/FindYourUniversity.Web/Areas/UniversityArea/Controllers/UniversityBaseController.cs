using FindYourUniversity.Data;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
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