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
using Microsoft.AspNet.Identity;

namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
    public class EditInfoController : BaseController
    {
        private IRepository<University> universities;
        private IRepository<ContactInfo> contacts;
        private IRepository<City> allCities;

        public EditInfoController(
            IRepository<University> universities,
            IRepository<ContactInfo> contacts,
            IRepository<City> allCities)
        {
            this.universities = universities;
            this.contacts = contacts;
            this.allCities = allCities;
        }

        protected University CurrentUniversity 
        {
            get 
            {
                var us = this.CurrentUser as University;
                return this.CurrentUser as University;
            }
        }

        // GET: UniversityArea/EditInfo
        public ActionResult Index()
        {
            var uniViewModel = Mapper.Map<University, UniversityViewModel>(this.CurrentUniversity);
            return View(uniViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UniversityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uni = this.universities.All().Where(u => u.Id == model.Id).FirstOrDefault();
                Mapper.Map(model, uni, typeof(UniversityViewModel), typeof(University));
                
                this.universities.Update(uni);
                this.universities.SaveChanges();
            }

            return null;
        }

        public ActionResult Contacts()
        {
            var contacts = this.CurrentUniversity.UniversityInfo.ContactInfo;
            var contactsModel = Mapper.Map<ContactInfo, ContactInfoViewModel>(contacts);
            contactsModel.Cities = this.GetCitiesSelectList();
            return PartialView("_Contacts", contactsModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateContacts(ContactInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = this.contacts.GetById(model.Id);
                Mapper.Map<ContactInfoViewModel, ContactInfo>(model, contact);
                this.contacts.Update(contact);
                this.contacts.SaveChanges();
            }

            model.Cities = this.GetCitiesSelectList();
            return PartialView("_Contacts", model);
        }

        private IEnumerable<SelectListItem> GetCitiesSelectList()
        {
            IEnumerable<SelectListItem> selectList = this.allCities
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