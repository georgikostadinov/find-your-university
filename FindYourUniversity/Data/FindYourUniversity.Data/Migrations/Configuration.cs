namespace FindYourUniversity.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FindYourUniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            // TODO: Change in production   
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FindYourUniversityDbContext context)
        {
        }
    }
}
