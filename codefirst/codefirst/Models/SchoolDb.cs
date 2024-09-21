using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace codefirst.Models
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor that uses a connection string from the configuration file
        public ApplicationDbContext() : base("SchoolContext")
        {
        }

        // DbSet for the Product entity representing the Products table in the database
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }

        // Configure models and remove table name pluralization (optional)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Prevent table names from being pluralized (optional)
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        } }

    }
