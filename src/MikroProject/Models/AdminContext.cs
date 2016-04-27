using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;


namespace MikroProject.Models
{
    public class AdminContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Class>().ToTable("Class");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
