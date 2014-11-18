using FindYourUniversity.Data;
using FindYourUniversity.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FindYourUniversity.Web.Controllers
{
    public class ApplicationsController : BaseController
    {
        public ApplicationsController(IFindYourUniversityData data) : base(data)
        { }

        // GET: Applications
        public ActionResult PreviewApplication(int programmeId)
        {
            var programme = this.Data.Programmes.GetById(programmeId);
            var userId = this.User.Identity.GetUserId();
            var student = this.Data.Students.GetById(userId);

            var model = new ApplicationPreviewViewModel();

            model.ProgrammeName = programme.Name;
            model.UniversityName = programme.University.UniversityInfo.Name;
            model.FirstName = student.StudentInfo.FirstName;
            model.SecondName = student.StudentInfo.SecondName;
            model.LastName = student.StudentInfo.LastName;
            model.School = student.StudentInfo.School;
            model.Telephone = student.ContactInfo.Telephone;
            model.Address = student.ContactInfo.Address;
            model.BirthDate = student.StudentInfo.BirthDate;
            model.City = student.ContactInfo.City == null ? "" : student.ContactInfo.City.Name;
            model.Email = student.ContactInfo.Email;

            foreach (var document in student.ImageDocuments.ToList())
            {
                var imageData = Convert.ToBase64String(document.Image);
                var imageDocumentModel = new ImageDocumentViewModel() 
                {
                    DocumentType = document.ApplicationDocumentType.Name,
                    ImageData = imageData 
                };

                model.Documents.Add(imageDocumentModel);
            }

            return View(model);
        }
    }
}