using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.TeacherServices.DTO
{
    public class TeacherDTO
    {
        public string? Name { get; set; }
        public string? Speciality { get; set; }
        public IEnumerable<Course>? Courses { get; set; }
    }
}
