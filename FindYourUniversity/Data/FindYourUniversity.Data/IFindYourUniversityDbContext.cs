using FindYourUniversity.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data
{
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
        IDbSet<Interest> Interests { get; set; }
        IDbSet<Mark> Marks { get; set; }
        IDbSet<News> News { get; set; }
        IDbSet<Programme> Programmes { get; set; }
        IDbSet<Subject> Subjects { get; set; }
        IDbSet<Student> Students { get; set; }
        IDbSet<University> Universities { get; set; }
        int SaveChanges();
        void Dispose();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IDbSet<T> Set<T>() where T : class;
    }
}
