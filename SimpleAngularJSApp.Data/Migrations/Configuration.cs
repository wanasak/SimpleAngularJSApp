namespace SimpleAngularJSApp.Data.Migrations
{
    using SimpleAngularJSApp.Entities;
    using System;
    //using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleAngularJSApp.Data.SimpleAngularJSAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimpleAngularJSApp.Data.SimpleAngularJSAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var students = new Student[]
            {
                new Student { FirstName = "Dan", LastName = "Robert", BirthDate = DateTime.Parse("2005-09-01") },
                new Student { FirstName = "Cory", LastName = "Rupert", BirthDate = DateTime.Parse("2006-03-21") },
                new Student { FirstName = "John", LastName = "King", BirthDate = DateTime.Parse("2005-11-14") }
            };
            context.StudentSet.AddOrUpdate(s => s.FirstName, students);
            context.SaveChanges();
        }
    }
}
