using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.StudentServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.StudentServices
{
    public interface IStudentService
    {
        int Create(AddStudentDTO addStudentDTO);
        void Update(int id, UpdateStudentDTO updateStudentDTO);
        StudentDTO Get(int id);
        IEnumerable<StudentDTO> GetAll();
        void Delete(int id);
        void EnrollToTheCource(CourceDTO courceDTO);
        void UnEnrollToTheCource(CourceDTO courceDTO);
        IEnumerable<CourceDTO> GetAllCource();

    }
}
