using FindYourUniversity.Data.Common.Repository;
using FindYourUniversity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data
{
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
        IDeletableEntityRepository<Interest> Interests { get; }
        IDeletableEntityRepository<Mark> Marks { get; }
        IDeletableEntityRepository<News> News { get; }
        IDeletableEntityRepository<Programme> Programmes { get; }
        IDeletableEntityRepository<Subject> Subjects { get; }
        IDeletableEntityRepository<Student> Students { get; }
        IDeletableEntityRepository<University> Universities { get; }

        int SaveChanges();
    }
}
