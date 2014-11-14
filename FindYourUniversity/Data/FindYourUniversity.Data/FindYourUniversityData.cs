using FindYourUniversity.Data.Common.Models;
using FindYourUniversity.Data.Common.Repository;
using FindYourUniversity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourUniversity.Data
{
    public class FindYourUniversityData : IFindYourUniversityData
    {
        private readonly IFindYourUniversityDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public FindYourUniversityData(IFindYourUniversityDbContext context)
        {
            this.context = context;
        }

        public IFindYourUniversityDbContext Context
        {
            get { return this.context; }
        }
        public IDeletableEntityRepository<Application> Applications
        {
            get { return this.GetDeletableEntityRepository<Application>(); }
        }
        public IDeletableEntityRepository<City> Cities
        {
            get
            {
                return this.GetDeletableEntityRepository<City>();
            }
        }

        public IDeletableEntityRepository<Course> Courses
        {
            get
            {
                return this.GetDeletableEntityRepository<Course>();
            }
        }

        public IDeletableEntityRepository<Degree> Degrees
        {
            get
            {
                return this.GetDeletableEntityRepository<Degree>();
            }
        }

        public IDeletableEntityRepository<Faculty> Faculties
        {
            get
            {
                return this.GetDeletableEntityRepository<Faculty>();
            }
        }

        public IDeletableEntityRepository<Feedback> Feedbacks
        {
            get
            {
                return this.GetDeletableEntityRepository<Feedback>();
            }
        }

        public IDeletableEntityRepository<News> News
        {
            get
            {
                return this.GetDeletableEntityRepository<News>();
            }
        }

        public IDeletableEntityRepository<Programme> Programmes
        {
            get
            {
                return this.GetDeletableEntityRepository<Programme>();
            }
        }

        public IDeletableEntityRepository<Student> Students
        {
            get
            {
                return this.GetDeletableEntityRepository<Student>();
            }
        }

        public IDeletableEntityRepository<University> Universities
        {
            get
            {
                return this.GetDeletableEntityRepository<University>();
            }
        }

        public IDeletableEntityRepository<StudentContactInfo> StudentContactInfos
        {
            get { return this.GetDeletableEntityRepository<StudentContactInfo>(); }
        }


        public IDeletableEntityRepository<UniversityContactInfo> UniversityContactInfos
        {
            get { return this.GetDeletableEntityRepository<UniversityContactInfo>(); }
        }

        public IDeletableEntityRepository<UniversityInfo> UniversityInfos
        {
            get { return this.GetDeletableEntityRepository<UniversityInfo>(); }
        }

        public IDeletableEntityRepository<StudentInfo> StudentInfos
        {
            get { return this.GetDeletableEntityRepository<StudentInfo>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
