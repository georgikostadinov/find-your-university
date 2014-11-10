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

namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
    public class EditInfoController : BaseController
    {
        // GET: UniversityArea/EditInfo
        public ActionResult Index()
        {
            var uni = this.CurrentUser as University;
            var uniViewModel = new UniversityViewModel()
            {
                Applications = uni.Applications,
                Faculties = uni.Faculties,
                Programmes = uni.Programmes,
                UniversityInfo = uni.UniversityInfo
            };
            return View();
        }
    }
}