using CourseProject.BL.Primitives;
using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.TeacherServices.DTO
{
    public class TeacherCard
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public IEnumerable<IdName> Courses { get; set; } = Enumerable.Empty<IdName>();
    }
}
