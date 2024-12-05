using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.CourceService.DTO
{
    public class CourceDTO
    {
        public string? Name { get; set; }
        public Teacher? Teacher { get; set; }
        public IEnumerable<Student>? Students { get; set; }
    }
}
