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
        StudentCard Get(int id);
        IEnumerable<StudentListItem> GetAll(IEnumerable<int>? ids = null);
        void Delete(int id);
        void EnrollToTheCource(int studentId, int courseId);
        void UnEnrollToTheCource(int studentId, int courseId);
        IEnumerable<CourseListItem> GetAllCource(int studentid);

    }
}
