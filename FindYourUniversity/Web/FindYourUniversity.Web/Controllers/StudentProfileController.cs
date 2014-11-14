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

        public ActionResult Index()
        {
            var student = this.Data.Students.GetById(this.CurrentUser.Id);
            var studentModel = Mapper.Map<Student, StudentViewModel>(student);
            return View(studentModel);
        }

        public ActionResult Update(StudentViewModel model)
        {
            var student = this.Data.Students.GetById(this.CurrentUser.Id);
            if (student.StudentInfo == null)
            {
                student.StudentInfo = new StudentInfo();
                this.Data.SaveChanges();
            }
            Mapper.Map<StudentViewModel, Student>(model,student);
            this.Data.Students.Update(student);
            this.Data.SaveChanges();

            return null;
        }
    }
}