namespace FindYourUniversity.Web.Areas.UniversityArea.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;

    public class ContactInfoViewModel : IMapFrom<UniversityContactInfo>, IHaveCustomMappings
    {
        [Display(Name="Град")]
        public int? CityId { get; set; }

        [Display(Name = "Имейл адрес")]
        [EmailAddress(ErrorMessage="Невалиден имейл адрес")]
        public string Email { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефонен номер")]
        [UIHint("Number")]
        public string Telephone { get; set; }

        [Display(Name = "Уебсайт")]
        public string Website { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<UniversityContactInfo, ContactInfoViewModel>().ReverseMap();
        }
    }
}