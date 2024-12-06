using AutoMapper;
using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.StudentServices.DTO;
using CourseProject.BL.TeacherServices.DTO;
using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourceCard>(); 
            CreateMap<AddCourceDTO, Course>();
            CreateMap<UpdateCourceDTO, Course>();
            CreateMap<Course, CourseListItem>();

            CreateMap<Student, StudentCard>();
            CreateMap<AddStudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();

            CreateMap<Teacher, TeacherDTO>();
            CreateMap<AddTeacherDTO, Teacher>();
            CreateMap<UpdateTeacherDTO, Teacher>();


        }

    }
}
