using AutoMapper;
using FindYourUniversity.Data;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Areas.UniversityArea.Controllers.Base;
using FindYourUniversity.Web.Areas.UniversityArea.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
    public class ContactInfoController : UniversityBaseController
    {
        public ContactInfoController(IFindYourUniversityData data) 
            : base(data) 
        {
        }

        public ActionResult Index()
        {
            var info = this.Data.UniversityContactInfos.GetById(this.CurrentUniversity.Id);
            if (info == null)
            {
                var uniId = this.User.Identity.GetUserId();
                var uni = this.Data.Universities.All().Where(u => u.Id == uniId).FirstOrDefault();
                uni.ContactInfo = new UniversityContactInfo();
                //uni.UniversityInfo.ContactInfo = new ContactInfo();
                this.Data.SaveChanges();
                info = uni.ContactInfo;
            }
            var model = Mapper.Map<UniversityContactInfo, ContactInfoViewModel>(info);
            return View(model);
        }

        public JsonResult GetCities()
        {
            var cities = this.Data.Cities
                .All()
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .OrderBy(c=>c.Name);

            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ContactInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = this.Data.UniversityContactInfos.GetById(User.Identity.GetUserId());
                Mapper.Map<ContactInfoViewModel, UniversityContactInfo>(model, contact);
                this.Data.UniversityContactInfos.Update(contact);
                this.Data.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}