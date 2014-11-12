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
            var info = this.CurrentUniversity.UniversityInfo;
            if (info == null)
            {
                return View();
            }
            var contacts = this.CurrentUniversity.UniversityInfo.ContactInfo;
            var contactsModel = Mapper.Map<ContactInfo, ContactInfoViewModel>(contacts);
            contactsModel.CitiesList = this.GetCitiesSelectList();
            return View(contactsModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ContactInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = this.Data.ContactInfos.GetById(model.Id);
                Mapper.Map<ContactInfoViewModel, ContactInfo>(model, contact);
                this.Data.ContactInfos.Update(contact);
                this.Data.SaveChanges();
            }

            model.CitiesList = this.GetCitiesSelectList();
            return RedirectToAction("Index");
        }

        private IEnumerable<SelectListItem> GetCitiesSelectList()
        {
            IEnumerable<SelectListItem> selectList = this.Data.Cities
                           .All()
                           .Select(c => new SelectListItem()
                           {
                               Text = c.Name,
                               Value = c.Id.ToString()
                           });

            return selectList;
        }
    }
}