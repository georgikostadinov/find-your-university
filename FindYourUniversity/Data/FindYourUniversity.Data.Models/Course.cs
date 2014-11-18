namespace FindYourUniversity.Data.Models
{
    using FindYourUniversity.Data.Common.Models;

    public class Course : DeletableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int Hours { get; set; }
        public int Semester { get; set; }
        public int ProgrammeId { get; set; }
        public virtual Programme Programme { get; set; }
    }
}
