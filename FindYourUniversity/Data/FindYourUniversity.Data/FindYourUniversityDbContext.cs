namespace FindYourUniversity.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Data.Migrations;
    using FindYourUniversity.Data.Common.Models;

    public class FindYourUniversityDbContext : IdentityDbContext<ApplicationUser>, IFindYourUniversityDbContext
    {
        public FindYourUniversityDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FindYourUniversityDbContext, Configuration>());
        }

        public IDbSet<Application> Applications { get; set; }
        public IDbSet<City> Cities { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<StudentContactInfo> StudentContactInfos { get; set; }
        public IDbSet<UniversityContactInfo> UniversityContactInfos { get; set; }
        public IDbSet<UniversityInfo> UniversityInfos { get; set; }
        public IDbSet<StudentInfo> StudentInfos { get; set; }
        public IDbSet<Degree> Degrees { get; set; }
        public IDbSet<Faculty> Faculties { get; set; }
        public IDbSet<Feedback> Feedbacks { get; set; }
        public IDbSet<Interest> Interests { get; set; }
        public IDbSet<Mark> Marks { get; set; }
        public IDbSet<News> News { get; set; }
        public IDbSet<Programme> Programmes { get; set; }
        public IDbSet<Subject> Subjects { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<University> Universities { get; set; }

        public static FindYourUniversityDbContext Create()
        {
            return new FindYourUniversityDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();

            return base.SaveChanges();
        }
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
