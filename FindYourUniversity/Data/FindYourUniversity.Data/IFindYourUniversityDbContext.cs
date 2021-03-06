﻿namespace FindYourUniversity.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using FindYourUniversity.Data.Models;

    public interface IFindYourUniversityDbContext
    {
        IDbSet<Application> Applications { get; set; }
        IDbSet<City> Cities { get; set; }
        IDbSet<Course> Courses { get; set; }
        IDbSet<Degree> Degrees { get; set; }
        IDbSet<StudentContactInfo> StudentContactInfos { get; set; }
        IDbSet<UniversityContactInfo> UniversityContactInfos { get; set; }
        IDbSet<UniversityInfo> UniversityInfos { get; set; }
        IDbSet<StudentInfo> StudentInfos { get; set; }
        IDbSet<Faculty> Faculties { get; set; }
        IDbSet<Feedback> Feedbacks { get; set; }
        IDbSet<News> News { get; set; }
        IDbSet<Programme> Programmes { get; set; }
        IDbSet<Student> Students { get; set; }
        IDbSet<University> Universities { get; set; }
        IDbSet<ApplicationDocumentType> ApplicationDocumentTypes { get; set; }
        IDbSet<ImageDocument> DocumentImages { get; set; }
        int SaveChanges();
        void Dispose();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IDbSet<T> Set<T>() where T : class;
    }
}
