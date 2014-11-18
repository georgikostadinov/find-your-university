namespace FindYourUniversity.Web.ViewModels
{
    using AutoMapper;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;

    public class FacultyLinkViewModel : IMapFrom<Faculty>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Faculty, FacultyLinkViewModel>();
        }
    }
}