namespace FindYourUniversity.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationPreviewViewModel
    {
        public ApplicationPreviewViewModel()
        {
            this.Documents = new HashSet<ImageDocumentViewModel>();
        }
        [Display(Name="Специалност")]
        public string ProgrammeName { get; set; }

        [Display(Name = "Университет")]
        public string UniversityName { get; set; }

        [Display(Name = "Първо име")]
        public string FirstName { get; set; }

        [Display(Name = "Бащино име")]
        public string SecondName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Дата на раждане")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Училище")]
        public string School { get; set; }

        [Display(Name = "Град")]
        public string City { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string Telephone { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Уебсайт")]
        public string Website { get; set; }

        public virtual ICollection<ImageDocumentViewModel> Documents { get; set; }
    }
}