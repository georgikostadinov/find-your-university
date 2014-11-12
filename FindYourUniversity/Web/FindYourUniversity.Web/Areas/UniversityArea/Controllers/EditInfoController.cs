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
using System.IO;
using FindYourUniversity.Common.Extensions;

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
            var info = this.CurrentUniversity.UniversityInfo;
            var commonInfoModel = Mapper.Map<UniversityInfo, UniversityInfoViewModel>(info);
            commonInfoModel.PictureUrl = this.CurrentUniversity.PictureUrl;
            return View(commonInfoModel);
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
            contactsModel.CitiesList = this.GetCitiesSelectList();
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

            model.CitiesList = this.GetCitiesSelectList();
            return PartialView("_Contacts", model);
        }

        public ActionResult CommonInfo()
        {
            var info = this.CurrentUniversity.UniversityInfo;
            var commonInfoModel = Mapper.Map<UniversityInfo, UniversityInfoViewModel>(info);
            commonInfoModel.PictureUrl = this.CurrentUniversity.PictureUrl;
            return PartialView("_CommonInfo", commonInfoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCommonInfo(UniversityInfoViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        byte[] filedata = null;

                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            filedata = binaryReader.ReadBytes(file.ContentLength);
                        }

                        var dataAsString = Convert.ToBase64String(filedata);
                        if (dataAsString.IsImage())
                        {
                            var fileName = this.CurrentUniversity.Id + file.FileName.Substring(file.FileName.LastIndexOf('.'));
                            var path = Path.Combine(Server.MapPath("~/Areas/UniversityArea/Images"), fileName);
                            System.IO.File.WriteAllBytes(path, filedata);
                            model.PictureUrl = "/Areas/UniversityArea/Images/" + fileName;
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                var info = this.data.UniversityInfos.GetById(model.Id);
                Mapper.Map<UniversityInfoViewModel, UniversityInfo>(model, info);
                if (model.PictureUrl != null)
                {
                    this.data.Universities.All()
                        .Where(u => u.Id == this.CurrentUniversity.Id)
                        .FirstOrDefault()
                        .PictureUrl = model.PictureUrl;
                }
               
                this.data.UniversityInfos.Update(info);
                this.data.SaveChanges();
            }

            return RedirectToAction("Index");
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