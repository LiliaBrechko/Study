using CourseProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.EF_Infrastructure
{
    public class DB_Configuration : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; } = null;
        public DbSet<Student> Students { get; set; } = null;
        public DbSet<Course> Courses { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("F:\\LiliaStudySelf\\CourceProject.Models\\EF_Infrastructure\\ConnectionDetails.json").SetBasePath(Directory.GetCurrentDirectory()).Build();
            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasOne(t => t.Teacher).WithMany(c => c.Courses).HasForeignKey(k => k.TeacherId);
            modelBuilder.Entity<Course>().HasMany(s => s.Students).WithMany(c => c.Courses).UsingEntity(sc => sc.ToTable("Student_Cource"));


        //    modelBuilder.Entity<Teacher>().HasData(
        //    new Teacher { ID = 1, Name = "Alice Johnson", Speciality = "Mathematics" },
        //    new Teacher { ID = 2, Name = "Bob Smith", Speciality = "Physics" },
        //    new Teacher { ID = 3, Name = "Clara James", Speciality = "Chemistry" },
        //    new Teacher { ID = 4, Name = "David Brown", Speciality = "Biology" },
        //    new Teacher { ID = 5, Name = "Emma Wilson", Speciality = "History" },
        //    new Teacher { ID = 6, Name = "Frank Taylor", Speciality = "Literature" },
        //    new Teacher { ID = 7, Name = "Grace Thomas", Speciality = "Programming" },
        //    new Teacher { ID = 8, Name = "Henry Lee", Speciality = "Philosophy" },
        //    new Teacher { ID = 9, Name = "Ivy Adams", Speciality = "Geography" },
        //    new Teacher { ID = 10, Name = "Jack White", Speciality = "Art" });

        //    modelBuilder.Entity<Student>().HasData(
        //    new Student { ID = 1, Name = "John Doe" },
        //    new Student { ID = 2, Name = "Jane Roe" },
        //    new Student { ID = 3, Name = "Mark Twain" },
        //    new Student { ID = 4, Name = "Lucy Hale" },
        //    new Student { ID = 5, Name = "Peter Parker" },
        //    new Student { ID = 6, Name = "Mary Jane" },
        //    new Student { ID = 7, Name = "Bruce Wayne" },
        //    new Student { ID = 8, Name = "Clark Kent" },
        //    new Student { ID = 9, Name = "Diana Prince" },
        //    new Student { ID = 10, Name = "Barry Allen" }
        //);

        //    modelBuilder.Entity<Course>().HasData(
        //    new Course { ID = 1, Name = "Algebra", TeacherId = 1 },
        //    new Course { ID = 2, Name = "Quantum Mechanics", TeacherId = 2 },
        //    new Course { ID = 3, Name = "Organic Chemistry", TeacherId = 3 },
        //    new Course { ID = 4, Name = "Genetics", TeacherId = 4 },
        //    new Course { ID = 5, Name = "World History", TeacherId = 5 },
        //    new Course { ID = 6, Name = "English Literature", TeacherId = 6 },
        //    new Course { ID = 7, Name = "C# Programming", TeacherId = 7 },
        //    new Course { ID = 8, Name = "Logic and Reasoning", TeacherId = 8 },
        //    new Course { ID = 9, Name = "Cartography", TeacherId = 9 },
        //    new Course { ID = 10, Name = "Painting Techniques", TeacherId = 10 }
        //);

        }
    }
}
