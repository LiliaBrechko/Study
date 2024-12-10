using CourseProject.DAL.EF_Infrastructure;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using CourseProject.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<DB_Configuration>();
            collection.AddTransient<IRepository<Course>, Repository<Course>>();
            collection.AddTransient<IRepository<Teacher>, Repository<Teacher>>();
            collection.AddTransient<IRepository<Student>, Repository<Student>>();


            return collection;
        }
    }
}
