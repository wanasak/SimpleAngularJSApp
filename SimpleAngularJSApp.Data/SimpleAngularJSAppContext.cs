using SimpleAngularJSApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAngularJSApp.Data
{
    public class SimpleAngularJSAppContext : DbContext
    {
        public SimpleAngularJSAppContext()
            : base("SimpleAngularJSApp")
        {
            Database.SetInitializer<SimpleAngularJSAppContext>(null);
        }

        public IDbSet<Student> StudentSet { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Student>()
                .Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Student>()
                .Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Student>()
                .Property(s => s.BirthDate);
        }
    }
}
