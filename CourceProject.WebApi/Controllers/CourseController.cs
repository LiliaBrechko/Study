using CourseProject.BL.CourceService;
using CourseProject.BL.CourceService.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CourceProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : ControllerBase
    {
        
        private readonly ICourseService courseService;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService)
        {
            _logger = logger;
            this.courseService = courseService;
        }

        [HttpGet, Route("{id}")]
        public CourceCard GetCourceCard([FromRoute]int id)
        {
            return courseService.Get(id);

        }
        [HttpGet, Route("")]
        public IEnumerable<CourseListItem> GetCourceList()
        {
            return courseService.GetAll();

        }
        [HttpDelete, Route("{id}")]
        public void Delete([FromRoute] int id)
        {
            courseService.Delete(id);
        }

        [HttpPost, Route("")]
        public int AddCourse([FromBody]AddCourceDTO addCourceDTO)
        {
            return courseService.Create(addCourceDTO);
        }

        [HttpPut, Route("{id}")]
        public void UpdateCourse([FromRoute]int id, [FromBody] UpdateCourceDTO updateCourceDTO)
        {
             courseService.Update(id, updateCourceDTO);
        }




    }
}
