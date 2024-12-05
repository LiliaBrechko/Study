using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.StudentServices.DTO
{
    public class StudentDTO
    {
        public string? Name { get; set; }
        public IEnumerable<Course>? Courses { get; set; }
    }
}
