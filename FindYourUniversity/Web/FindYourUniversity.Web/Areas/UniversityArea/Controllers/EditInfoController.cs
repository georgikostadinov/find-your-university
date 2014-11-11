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
        private IFindYourUniversityData data;

        public EditInfoController(IFindYourUniversityData data)
        {
            this.data = data;
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
                var uni = this.data.Universities.All().Where(u => u.Id == model.Id).FirstOrDefault();
                Mapper.Map(model, uni, typeof(UniversityViewModel), typeof(University));
                
                this.data.Universities.Update(uni);
                this.data.SaveChanges();
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
                var contact = this.data.ContactInfos.GetById(model.Id);
                Mapper.Map<ContactInfoViewModel, ContactInfo>(model, contact);
                this.data.ContactInfos.Update(contact);
                this.data.SaveChanges();
            }

            model.Cities = this.GetCitiesSelectList();
            return PartialView("_Contacts", model);
        }

        public ActionResult CommonInfo()
        {
            var info = this.CurrentUniversity.UniversityInfo;
            var commonInfoModel = Mapper.Map<UniversityInfo, UniversityInfoViewModel>(info);
            commonInfoModel.PictureUrl = this.CurrentUniversity.PictureUrl;
            return PartialView("_CommonInfo", commonInfoModel);
        }

        public ActionResult UpdateCommonInfo(UniversityInfoViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                
            }
            return null;
        }

        private IEnumerable<SelectListItem> GetCitiesSelectList()
        {
            IEnumerable<SelectListItem> selectList = this.data.Cities
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