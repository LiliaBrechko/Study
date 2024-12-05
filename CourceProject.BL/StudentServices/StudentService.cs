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

namespace CourseProject.BL.StudentServices
{
    public class StudentService(IRepository<Course> _courserepository, IRepository<Student> _studentrepository, IMapper mapper) : IStudentService
    {
        public int Create(AddStudentDTO addStudentDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void EnrollToTheCource(CourceDTO courceDTO)
        {
            throw new NotImplementedException();
        }

        public StudentDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourceDTO> GetAllCource()
        {
            throw new NotImplementedException();
        }

        public void UnEnrollToTheCource(CourceDTO courceDTO)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, UpdateStudentDTO updateStudentDTO)
        {
            throw new NotImplementedException();
        }
    }
}
