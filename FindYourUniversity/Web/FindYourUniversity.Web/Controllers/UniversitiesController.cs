﻿using FindYourUniversity.Data;
using FindYourUniversity.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourUniversity.Web.Controllers
{
    public class UniversitiesController : BaseController
    {
        public UniversitiesController(IFindYourUniversityData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GroupedByName()
        {

            var models = this.Data.Universities
                .All()
                .GroupBy(u => u.UniversityInfo.Name.Substring(0, 1))
                .Select(group => new UniversitiesGroupedByLetterViewModel()
                {
                    Letter = group.Key,
                    Universities = group.Select(university => new UniversityViewModel()
                    {
                        Id = university.Id,
                        Name = university.UniversityInfo.Name
                    })
                });

            return PartialView("_GroupedByName", models);
        }
        public ActionResult GroupedByCity()
        {

            var models = this.Data.Universities
                .All()
                .GroupBy(u => u.ContactInfo.City.Name)
                .Select(group => new UniversitiesGroupedByCityViewModel()
                {
                    CityName = group.Key,
                    Universities = group.Select(university => new UniversityViewModel()
                    {
                        Id = university.Id,
                        Name = university.UniversityInfo.Name
                    })
                });

            return PartialView("_GroupedByCity", models);
        }
    }
}