using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using FindYourUniversity.Web.Areas.UniversityArea.ViewModels;
using FindYourUniversity.Data.Common.Repository;
using FindYourUniversity.Data;

namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
    public class EditInfoController : BaseController
    {
        private ApplicationDbContext db;
        public EditInfoController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: UniversityArea/EditInfo
        public ActionResult Index()
        {
            var uni = this.CurrentUser as University;
            var uniViewModel = Mapper.Map<University, UniversityViewModel>(uni);
            return View(uniViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UniversityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uni = this.db.Users.Find(model.Id);
                var result = Mapper.Map<UniversityViewModel, University>(model);

                uni.PictureUrl = "asd";
                this.db.SaveChanges();
            }

            return null;
        }
    }
}