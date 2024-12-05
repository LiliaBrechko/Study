using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.StudentServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.CourceService
{
    public interface ICourseService
    {
        int Create(AddCourceDTO addCourceDTO);
        void Update(int id, UpdateCourceDTO updateCourceDTO);
        CourceDTO Get(int id);
        IEnumerable<CourceDTO> GetAll();
        void Delete(int id);
        IEnumerable<StudentDTO> GetAllStudents();


    }
}
