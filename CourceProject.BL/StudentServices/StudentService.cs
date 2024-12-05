using AutoMapper;
using CourseProject.BL.CourceService.DTO;
using CourseProject.BL.StudentServices.DTO;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BL.StudentServices
{
    public class StudentService(IRepository<Course> _courserepository, IRepository<Student> _studentrepository, IMapper mapper) : IStudentService
    {
        public int Create(AddStudentDTO addStudentDTO)
        {
            var student = mapper.Map<Student>(addStudentDTO);
            return _studentrepository.Create(student);
        }

        public void Delete(int id)
        {
            _studentrepository.Delete(id);
        }

        public void EnrollToTheCource(int studentid, int courseId)
        {
            var student = _studentrepository.Get(studentid, c => c.Courses!);
            if (student == null)
                throw new Exception($"Student with ID {studentid} not found.");

            var course = _courserepository.Get(courseId);
            if (course == null)
                throw new Exception($"Course with ID {courseId} not found.");

            if (student.Courses != null && student.Courses.Any(c => c.ID == courseId))
                throw new Exception($"Student is already enrolled in the course with ID {courseId}.");
            

            if (student.Courses == null)
                student.Courses = new List<Course>();
            

            student.Courses.Add(course);
            _studentrepository.Update(studentid, student);

        }

        public StudentCard Get(int id)
        {
            var currentStudent = _studentrepository.Get(id);
            return mapper.Map<StudentCard>(currentStudent);
        }

        public IEnumerable<StudentCard> GetAll()
        {
            return _studentrepository.GetAll().Select(mapper.Map<StudentCard>); ;
        }

        public IEnumerable<CourceCard> GetAllCource()
        {
            return _studentrepository.GetAll().Select(mapper.Map<CourceCard>);
        }

        public void UnEnrollToTheCource(int studentid, int courseId)
        {
            var student = _studentrepository.Get(studentid, c => c.Courses!);
            if (student == null)
                throw new Exception($"Student with ID {studentid} not found.");

            var course = _courserepository.Get(courseId);
            if (course == null)
                throw new Exception($"Course with ID {courseId} not found.");

            if (student.Courses == null || !student.Courses.Any(c => c.ID == courseId))
                throw new Exception($"Student is not enrolled in the course with ID {courseId}.");

            student.Courses.Remove(course);
            _studentrepository.Update(courseId, student);



        }

        public void Update(int id, UpdateStudentDTO updateStudentDTO)
        {
            var studentToUpdate = _studentrepository.Get(id);
            studentToUpdate.Name = updateStudentDTO.Name;

            _studentrepository.Update(id, studentToUpdate);
        }
    }
}
