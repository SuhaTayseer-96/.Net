namespace codefirst.Migrations
{
    using codefirst.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<codefirst.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(codefirst.Models.ApplicationDbContext context)
        {
            if (!context.Subjects.Any())
            {
                context.Subjects.AddRange(new List<Subject>
        {
            new Subject { SubjectName = "Math" },
            new Subject { SubjectName = "Science" },
            new Subject { SubjectName = "History" }
        });

                context.SaveChanges();
            }
            base.Seed(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
