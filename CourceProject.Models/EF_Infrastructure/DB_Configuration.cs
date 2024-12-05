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
            var config = new ConfigurationBuilder().AddJsonFile("F:\\Visual Studio\\LiliaStudyGit\\LiliaSolution\\CourceProject.Models\\EF_Infrastructure\\ConnectionDetails.json").SetBasePath(Directory.GetCurrentDirectory()).Build();
            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasOne(t => t.Teacher).WithMany(c => c.Courses).HasForeignKey(k => k.TeacherId);
            modelBuilder.Entity<Course>().HasMany(s => s.Students).WithMany(c => c.Courses).UsingEntity(sc => sc.ToTable("Student_Cource"));

           
        }
    }
}
