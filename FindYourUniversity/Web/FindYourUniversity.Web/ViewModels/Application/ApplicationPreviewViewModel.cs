namespace FindYourUniversity.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class ApplicationPreviewViewModel
    {
        public ApplicationPreviewViewModel()
        {
            this.Documents = new HashSet<ImageDocumentViewModel>();
        }

        public string ProgrammeName { get; set; }
        public string UniversityName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string School { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public virtual ICollection<ImageDocumentViewModel> Documents { get; set; }
    }
}