using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.Models
{
    public class Student : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Course>? Courses { get; set; }
       
    }
}
