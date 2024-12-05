using CourseProject.BL.CourceService.DTO;
using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.StudentServices.DTO
{
    public class StudentCard
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CourseListItem> Courses { get; set; } = Enumerable.Empty<CourseListItem>();
    }
}
