using AutoMapper;
using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.TeacherServices.DTO;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.TeacherServices
{
    public class TeacherService(IRepository<Course> _courserepository, IRepository<Teacher> _teacherrepository, IMapper mapper) : ITeacherService
    {
        public int Create(AddTeacherDTO addTeacherDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TeacherDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeacherDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourceDTO> GetAllCource()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, UpdateTeacherDTO updateTeacherDTO)
        {
            throw new NotImplementedException();
        }
    }
}
