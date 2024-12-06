using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.TeacherServices.DTO;
using CourseProject.BL.TeacherServices;
using Microsoft.AspNetCore.Mvc;
using CourseProject.BL.StudentServices;
using CourseProject.BL.StudentServices.DTO;

namespace CourseProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {

            private readonly IStudentService studentService;

            public StudentController(IStudentService studentService)
            {
                this.studentService = studentService;
            }

            [HttpGet, Route("{id}")]
            public StudentCard Get([FromRoute] int id)
            {
                return studentService.Get(id);

            }
            [HttpGet, Route("")]
            public IEnumerable<StudentListItem> GetAll()
            {
                return studentService.GetAll();

            }

            [HttpGet, Route("{id}/course")]
            public IEnumerable<CourseListItem> GetCourceList([FromRoute] int id)
            {
                return studentService.GetAllCource(id);

            }
            [HttpDelete, Route("{id}")]
            public void Delete([FromRoute] int id)
            {
                studentService.Delete(id);
            }

            [HttpPost, Route("")]
            public int Add([FromBody] AddStudentDTO addStudentDTO)
            {
                return studentService.Create(addStudentDTO);
            }

            [HttpPut, Route("{id}")]
            public void Update([FromRoute] int id, [FromBody] UpdateStudentDTO updateStudentDTO)
            {
                studentService.Update(id, updateStudentDTO);
            }

        [HttpPut, Route("{studentId}/enroll/{courseId}")]
        public void EnrollToTheCource([FromRoute] int studentId,[FromRoute] int courseId)
        {
            studentService.EnrollToTheCource(studentId, courseId);

        }

        [HttpPut, Route("{studentId}/unEnroll/{courseId}")]
        public void UnEnrollToTheCource([FromRoute] int studentId, [FromRoute] int courseId)
        {
            studentService.UnEnrollToTheCource(studentId, courseId);
        }





    }
}
