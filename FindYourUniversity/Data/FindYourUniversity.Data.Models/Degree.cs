namespace FindYourUniversity.Data.Models
{
    using FindYourUniversity.Data.Common.Models;

    public class Degree : DeletableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
