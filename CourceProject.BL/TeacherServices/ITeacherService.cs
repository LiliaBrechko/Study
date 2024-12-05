using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.StudentServices.DTO;
using CourseProject.BL.TeacherServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.TeacherServices
{
    public interface ITeacherService
    {
        int Create(AddTeacherDTO addTeacherDTO);
        void Update(int id, UpdateTeacherDTO updateTeacherDTO);
        TeacherDTO Get(int id);
        IEnumerable<TeacherDTO> GetAll();
        void Delete(int id);
        IEnumerable<CourceDTO> GetAllCource();
    }
}
