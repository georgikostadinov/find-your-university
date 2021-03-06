﻿namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    using AutoMapper;

    using FindYourUniversity.Web.Areas.UniversityArea.ViewModels;
    using FindYourUniversity.Common.Extensions;
    using FindYourUniversity.Data;
    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Areas.UniversityArea.Controllers.Base;

    public class CommonInfoController : UniversityBaseController
    {
        public CommonInfoController(IFindYourUniversityData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View(this.GetCommonInfoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Update(UniversityInfoViewModel model)
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
                var info = this.Data.UniversityInfos.GetById(this.CurrentUser.Id);
                Mapper.Map<UniversityInfoViewModel, UniversityInfo>(model, info);
                if (model.PictureUrl != null)
                {
                    this.Data.Universities.All()
                        .Where(u => u.Id == this.CurrentUniversity.Id)
                        .FirstOrDefault()
                        .PictureUrl = model.PictureUrl;
                }

                this.Data.UniversityInfos.Update(info);
                this.Data.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private UniversityInfoViewModel GetCommonInfoViewModel()
        {
            var info = this.CurrentUniversity.UniversityInfo;
            if (info == null)
            {
                var uniId = this.User.Identity.GetUserId();
                var uni = this.Data.Universities.All().Where(u => u.Id == uniId).FirstOrDefault();
                uni.UniversityInfo = new UniversityInfo();
                this.Data.SaveChanges();
                info = uni.UniversityInfo;
            }
            var commonInfoModel = Mapper.Map<UniversityInfo, UniversityInfoViewModel>(info);
            commonInfoModel.PictureUrl = this.CurrentUniversity.PictureUrl;
            return commonInfoModel;
        }
    }
}