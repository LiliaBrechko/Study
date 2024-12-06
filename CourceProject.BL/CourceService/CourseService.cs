using AutoMapper;
using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.StudentServices.DTO;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
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
            var course =  mapper.Map<Course>(addCourceDTO);
            return _courserepository.Create(course);
        }

        public void Delete(int id)
        {
            _courserepository.Delete(id);
        }

        public CourceCard Get(int id)
        {
            var currentCourse = _courserepository.Get(id, t => t.Teacher!, x=>x.Students!);
            return mapper.Map<CourceCard>(currentCourse);
        }

        public IEnumerable<CourseListItem> GetAll()
        {
            return _courserepository.GetAll().Select(mapper.Map<CourseListItem>);
        }

        public IEnumerable<StudentCard> GetAllStudents()
        {
           return _studentrepository.GetAll().Select(mapper.Map<StudentCard>);
        }

        public void Update(int id, UpdateCourceDTO updateCourceDTO)
        {
            var courseToUpdate = _courserepository.Get(id);
            courseToUpdate.Name = updateCourceDTO.Name;
            courseToUpdate.TeacherId = updateCourceDTO.TeacherId;

            _courserepository.Update(id, courseToUpdate);

        }
    }
}
