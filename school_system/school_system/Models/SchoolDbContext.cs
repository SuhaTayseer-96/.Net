using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace school_system.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("School")
        {
        }

        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Students> Students { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }

        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // One-to-One relationship between Student and StudentDetails
            modelBuilder.Entity<Students>()
                .HasOptional(s => s.StudentDetails)
                .WithRequired(sd => sd.Student);

            // One-to-Many relationship between Teacher and Course
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithRequired(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);

            base.OnModelCreating(modelBuilder);
        }





        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}