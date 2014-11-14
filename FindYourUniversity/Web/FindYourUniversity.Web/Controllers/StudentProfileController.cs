using AutoMapper;
using FindYourUniversity.Data;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourUniversity.Web.Controllers
{
    public class StudentProfileController : BaseController
    {
        public StudentProfileController(IFindYourUniversityData data)
            : base(data)
        {
 
        }

        public JsonResult GetCities()
        {
            var cities = this.Data.Cities
                .All()
                .Select(c => new 
            {
                CityId = c.Id,
                CityName = c.Name
            });

            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var student = this.Data.Students.GetById(this.CurrentUser.Id);
            if (student.StudentInfo == null)
            {
                student.StudentInfo = new StudentInfo();
                this.Data.SaveChanges();
            }
            if (student.ContactInfo == null)
            {
                student.ContactInfo = new StudentContactInfo();
                this.Data.SaveChanges();
            }

            var studentModel = Mapper.Map<Student, StudentViewModel>(student);
            return View(studentModel);
        }

        public ActionResult Update(StudentViewModel model)
        {
            var student = this.Data.Students.GetById(this.CurrentUser.Id);
            Mapper.Map<StudentViewModel, Student>(model,student);
            this.Data.Students.Update(student);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}