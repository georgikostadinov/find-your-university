using AutoMapper;
using FindYourUniversity.Data;
using FindYourUniversity.Data.Models;
using FindYourUniversity.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
            model.ImageDocuments = student.ImageDocuments;
            Mapper.Map<StudentViewModel, Student>(model, student);
            this.Data.Students.Update(student);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult DocumentsUpload()
        {
            var uploaded = this.Data.DocumentImages.All().Where(i => i.StudentId == this.CurrentUser.Id);
            return View();
        }

        public ActionResult GetUploadForm()
        {
            if (Session["requestedDocumentFieldsCount"] != null)
            {
                var counter = int.Parse(Session["requestedDocumentFieldsCount"].ToString()) + 1;
                TempData["count"] = counter;
            }
            else
            {
                Session.Add("requestedDocumentFieldsCount", 0);
                TempData["count"] = 0;
            }

            var types = GetDocumentTypes();

            return PartialView("_DocumentUploadForm", types);
        }

        public IEnumerable<SelectListItem> GetDocumentTypes()
        {
            IEnumerable<SelectListItem> selectList = this.Data.ApplicationDocumentTypes
                              .All()
                              .Select(c => new SelectListItem()
                              {
                                  Text = c.Name,
                                  Value = c.Id.ToString()
                              });

            return selectList;
        }

        public ActionResult Upload(IEnumerable<DocumentImageViewModel> images)
        {
            Session.Remove("requestedDocumentFieldsCount");
            var student = this.Data.Students.GetById(this.CurrentUser.Id);

            foreach (var image in images)
            {
                byte[] imageData = null;
                if (image.Image != null)
                {
                    using (var binaryReader = new BinaryReader(image.Image.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(image.Image.ContentLength);
                    }
                    student.ImageDocuments.Add(new ImageDocument()
                    {
                        ApplicationDocumentTypeId = image.DocumentTypeId,
                        Image = imageData
                    });
                }

            }

            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}