namespace FindYourUniversity.Data.Models
{
    using FindYourUniversity.Data.Common.Models;

    public class ApplicationDocumentType : DeletableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
