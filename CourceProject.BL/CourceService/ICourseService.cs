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
        CourceCard Get(int id);
        IEnumerable<CourseListItem> GetAll(IEnumerable<int>? ids = null );
        void Delete(int id);
        IEnumerable<StudentListItem> GetAllStudents(int id);


    }
}
