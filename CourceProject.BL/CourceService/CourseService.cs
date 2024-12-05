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

        public CourceDTO Get(int id)
        {
            var currentCourse = _courserepository.Get(id);
            return mapper.Map<CourceDTO>(currentCourse);
        }

        public IEnumerable<CourceDTO> GetAll()
        {
            return _courserepository.GetAll().Select(mapper.Map<CourceDTO>);
        }

        public IEnumerable<StudentDTO> GetAllStudents()
        {
           return _studentrepository.GetAll().Select(mapper.Map<StudentDTO>);
        }

        public void Update(int id, UpdateCourceDTO updateCourceDTO)
        {
            var courseToUpdate = _courserepository.Get(id);
            courseToUpdate.Name = updateCourceDTO.Name;
            courseToUpdate.Teacher = updateCourceDTO.Teacher;

            _courserepository.Update(id, courseToUpdate);

        }
    }
}
