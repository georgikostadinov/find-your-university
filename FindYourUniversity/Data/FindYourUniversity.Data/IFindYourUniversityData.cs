namespace FindYourUniversity.Data
{
    using FindYourUniversity.Data.Common.Repository;
    using FindYourUniversity.Data.Models;

    public interface IFindYourUniversityData
    {
        IFindYourUniversityDbContext Context { get; }

        IDeletableEntityRepository<Application> Applications { get; }
        IDeletableEntityRepository<City> Cities { get; }
        IDeletableEntityRepository<Course> Courses { get; }
        IDeletableEntityRepository<StudentContactInfo> StudentContactInfos { get; }
        IDeletableEntityRepository<UniversityContactInfo> UniversityContactInfos { get; }
        IDeletableEntityRepository<UniversityInfo> UniversityInfos { get; }
        IDeletableEntityRepository<StudentInfo> StudentInfos { get; }
        IDeletableEntityRepository<Degree> Degrees { get; }
        IDeletableEntityRepository<Faculty> Faculties { get; }
        IDeletableEntityRepository<Feedback> Feedbacks { get; }
        IDeletableEntityRepository<News> News { get; }
        IDeletableEntityRepository<Programme> Programmes { get; }
        IDeletableEntityRepository<Student> Students { get; }
        IDeletableEntityRepository<University> Universities { get; }
        IDeletableEntityRepository<ApplicationDocumentType> ApplicationDocumentTypes { get; }
        IDeletableEntityRepository<ImageDocument> DocumentImages { get; }

        int SaveChanges();
    }
}
