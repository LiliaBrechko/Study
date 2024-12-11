using AutoMapper;
using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.StudentServices.DTO;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.CourceService
{
    public class CourseService(IRepository<Course> _courserepository, IRepository<Student> _studentrepository, IMapper mapper) : ICourseService
    {

        public int Create(AddCourceDTO addCourceDTO)
        {
            var course = mapper.Map<Course>(addCourceDTO);
            return _courserepository.Create(course);
        }

        public void Delete(int id)
        {
            _courserepository.Delete(id);
        }

        public CourceCard Get(int id)
        {
            var currentCourse = _courserepository.Get(id, query => query.Include(x => x.Teacher).Include(x => x.Students));
            return mapper.Map<CourceCard>(currentCourse);
        }

        public IEnumerable<CourseListItem> GetAll(IEnumerable<int>? ids = null)
        {
            if (ids == null)
            return _courserepository.GetAll(includeFunc: query => query.Include(c => c.Teacher)).Select(mapper.Map<CourseListItem>);
            return _courserepository.GetAll(x => ids.Contains(x.ID), query => query.Include(c => c.Teacher)).Select(mapper.Map<CourseListItem>);

        }

        public IEnumerable<StudentListItem> GetAllStudents(int id)
        {
            return _courserepository.Get(id, x => x.Include(s => s.Students)).Students.Select(mapper.Map<StudentListItem>);
        }

        public void Update(int id, UpdateCourceDTO updateCourceDTO)
        {
            var courseToUpdate = _courserepository.Get(id);
            courseToUpdate.Name = updateCourceDTO.Name;
            courseToUpdate.TeacherId = updateCourceDTO.TeacherId;

            _courserepository.Update(courseToUpdate);

        }
    }
}
