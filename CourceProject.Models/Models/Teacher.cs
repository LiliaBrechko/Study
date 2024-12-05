using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.Models
{
    public class Teacher : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
