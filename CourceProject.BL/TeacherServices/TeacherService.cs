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

        public TeacherDTO Get(int id)
        {
            var currentteacher =  _teacherrepository.Get(id);
            return mapper.Map<TeacherDTO>(currentteacher);
        }

        public IEnumerable<TeacherDTO> GetAll()
        {
            return _teacherrepository.GetAll().Select(mapper.Map<TeacherDTO>);
        }

        public IEnumerable<CourceCard> GetAllCource()
        {
            return _teacherrepository.GetAll().Select(mapper.Map<CourceCard>);
        }

        public void Update(int id, UpdateTeacherDTO updateTeacherDTO)
        {
            var teacherToUpdate = _teacherrepository.Get(id);
            teacherToUpdate.Name = updateTeacherDTO.Name;
            teacherToUpdate.Speciality = updateTeacherDTO.Speciality;

            _teacherrepository.Update(id, teacherToUpdate);
        }
    }
}
