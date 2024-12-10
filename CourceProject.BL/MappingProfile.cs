using AutoMapper;
using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.Primitives;
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
            CreateMap<Course, IdName>()
                .ForMember(x => x.Id, opts => opts.MapFrom(src => src.ID))
                .ForMember(x => x.Name, opts => opts.MapFrom(src => src.Name)); ;

            CreateMap<Student, StudentCard>();
            CreateMap<Student, IdName>()
                .ForMember(x => x.Id, opts => opts.MapFrom(src => src.ID))
                .ForMember(x => x.Name, opts => opts.MapFrom(src => src.Name));
            CreateMap<AddStudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();
            CreateMap<Student, StudentListItem>();

            CreateMap<Teacher, TeacherCard>();
            CreateMap<AddTeacherDTO, Teacher>();
            CreateMap<UpdateTeacherDTO, Teacher>();
            CreateMap<Teacher, TeacherListItem>();


        }

    }
}
