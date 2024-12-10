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
        TeacherCard Get(int id);
        IEnumerable<TeacherListItem> GetAll(IEnumerable<int>? ids = null);
        void Delete(int id);
        IEnumerable<CourseListItem> GetAllCource(int id);
    }
}
