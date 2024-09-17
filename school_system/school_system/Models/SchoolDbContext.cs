using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace school_system.Models
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor that uses a connection string from the configuration file
        public ApplicationDbContext() : base("School")
        {
        }

        // DbSet for the Product entity representing the Products table in the database
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Students> Students { get; set; }


        // Configure models and remove table name pluralization (optional)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Prevent table names from being pluralized (optional)
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}