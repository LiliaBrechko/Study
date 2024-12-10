using AutoMapper;
using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.TeacherServices.DTO;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.TeacherServices
{
    public class TeacherService(IRepository<Teacher> _teacherrepository, IMapper mapper) : ITeacherService
    {
        public int Create(AddTeacherDTO addTeacherDTO)
        {
            var teacher = mapper.Map<Teacher>(addTeacherDTO);
            return _teacherrepository.Create(teacher);
        }

        public void Delete(int id)
        {
            _teacherrepository.Delete(id);
        }

        public TeacherCard Get(int id)
        {
            var currentteacher = _teacherrepository.Get(id, x => x.Include(c => c.Courses));
            return mapper.Map<TeacherCard>(currentteacher);
        }

        public IEnumerable<TeacherListItem> GetAll(IEnumerable<int>? ids = null)
        {
            var teachers = ids != null
               ? _teacherrepository.GetAll(t => ids.Contains(t.ID))
               : _teacherrepository.GetAll();


            return teachers.Select(mapper.Map<TeacherListItem>);
        }

        public IEnumerable<CourseListItem> GetAllCource(int id)
        {
            return _teacherrepository.Get(id, query => query.Include(x => x.Courses)).Courses.Select(mapper.Map<CourseListItem>);
        }

        public void Update(int id, UpdateTeacherDTO updateTeacherDTO)
        {
            var teacherToUpdate = _teacherrepository.Get(id);
            teacherToUpdate.Name = updateTeacherDTO.Name;
            teacherToUpdate.Speciality = updateTeacherDTO.Speciality;

            _teacherrepository.Update(teacherToUpdate);
        }
    }
}
