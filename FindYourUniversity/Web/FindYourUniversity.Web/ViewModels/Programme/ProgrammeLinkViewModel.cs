namespace FindYourUniversity.Web.ViewModels
{
    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Web.Infrastructure.Mapping;

    public class ProgrammeLinkViewModel : IMapFrom<Programme>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}