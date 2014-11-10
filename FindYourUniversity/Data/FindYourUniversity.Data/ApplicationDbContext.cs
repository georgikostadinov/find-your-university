namespace FindYourUniversity.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using FindYourUniversity.Data.Models;
    using FindYourUniversity.Data.Migrations;
    using FindYourUniversity.Data.Common.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<Application> Applications { get; set; }
        public IDbSet<City> Cities { get; set; }
        public IDbSet<Course> Courses { get; set; }
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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();

            return base.SaveChanges();
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

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
