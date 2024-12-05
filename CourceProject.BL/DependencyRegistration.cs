using AutoMapper;
using CourseProject.BL.CourceService;
using CourseProject.BL.StudentServices;
using CourseProject.BL.TeacherServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CourseProject.BL
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection collection)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            IMapper mapper = config.CreateMapper();

            collection.AddTransient<ICourseService, CourseService>();
            collection.AddTransient<ITeacherService, TeacherService>();
            collection.AddTransient<IStudentService, StudentService>();
            
            collection.AddSingleton<IMapper>(mapper);

            return collection;
        }
    }
}
