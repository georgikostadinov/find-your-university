using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using FindYourUniversity.Data;
using AutoMapper;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.Areas.UniversityArea.ViewModels;
using FindYourUniversity.Web.Areas.UniversityArea.Controllers.Base;
using System.Collections;

namespace FindYourUniversity.Web.Areas.UniversityArea.Controllers
{
    public class FacultiesController : KendoGridAdministrationController
    {
        public FacultiesController(IFindYourUniversityData data)
            : base(data)
        { 
        }
        // GET: UniversityArea/Faculties
        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            var faculties = this.Data.Faculties.All();
            var models = faculties.Select(f => new
            {
                Id = f.Id,
                Name = f.Name
            });

            return models;
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Faculties.GetById(id) as T;
        }        
    }
}