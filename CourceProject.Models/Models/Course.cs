using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.Models
{
    public class Course : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId {  get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
