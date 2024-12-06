using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.CourceService;
using CourseProject.BL.TeacherServices;
using Microsoft.AspNetCore.Mvc;
using CourseProject.BL.TeacherServices.DTO;

namespace CourseProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/teacher")]
    public class TeacherController : ControllerBase 
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet, Route("{id}")]
        public TeacherCard Get([FromRoute] int id)
        {
            return teacherService.Get(id);

        }
        [HttpGet, Route("")]
        public IEnumerable<TeacherListItem> GetAll()
        {
            return teacherService.GetAll();

        }

        [HttpGet, Route("{id}/course")]
        public IEnumerable<CourseListItem> GetCourceList([FromRoute]int id)
        {
            return teacherService.GetAllCource(id);

        }
        [HttpDelete, Route("{id}")]
        public void Delete([FromRoute] int id)
        {
            teacherService.Delete(id);
        }

        [HttpPost, Route("")]
        public int Add([FromBody] AddTeacherDTO addTeacherDTO)
        {
            return teacherService.Create(addTeacherDTO);
        }

        [HttpPut, Route("{id}")]
        public void Update([FromRoute] int id, [FromBody] UpdateTeacherDTO updateTeacherDTO)
        {
            teacherService.Update(id,updateTeacherDTO);
        }
    }
}
