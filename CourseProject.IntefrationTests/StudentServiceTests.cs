using CourseProject.BL;
using CourseProject.BL.StudentServices;
using CourseProject.BL.StudentServices.DTO;
using CourseProject.DAL;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CourseProject.IntegrationTests
{
    public class StudentServiceTests
    {
        private readonly IStudentService _studentService;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Teacher> _teacherRepository;

        public StudentServiceTests()
        {
            var provider = new ServiceCollection().RegisterRepositories().RegisterServices().BuildServiceProvider();
            _studentService = provider.GetRequiredService<IStudentService>();
            _studentRepository = provider.GetRequiredService<IRepository<Student>>();
            _courseRepository = provider.GetRequiredService<IRepository<Course>>();
            _teacherRepository = provider.GetRequiredService<IRepository<Teacher>>();
        }

        [Fact]
        public void EnrollStudentIsCorrect()
        {
            //arrange

            var studentID = _studentRepository.Create(new Student() { Name = Guid.NewGuid().ToString() });
            var teacherID = _teacherRepository.Create(new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() });
            var courseName = Guid.NewGuid().ToString();
            var courseID = _courseRepository.Create(new Course() { Name = courseName, TeacherId = teacherID });
            //act

            _studentService.EnrollToTheCource(studentID, courseID);

            //assert
            var student = _studentRepository.Get(studentID, s => s.Include(c => c.Courses));
            student.Courses.Should().HaveCount(1);
            student.Courses.First().Name.Should().Be(courseName);
        }

        [Fact]
        public void UnEnrollStudentIsCorrect()
        {
            //arrange
            var teacherID = _teacherRepository.Create(new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() });
            var student = new Student()
            {
                Name = Guid.NewGuid().ToString(),
                Courses = new List<Course>()
                {
                    new Course() { Name = Guid.NewGuid().ToString(), TeacherId = teacherID }
                }
            };
            var studentID = _studentRepository.Create(student);
            var courseID = student.Courses.First().ID;

            //act

            _studentService.UnEnrollToTheCource(studentID, courseID);


            //assert
            var actualstudent = _studentRepository.Get(studentID, s => s.Include(c => c.Courses));
            student.Courses.Should().HaveCount(0);
            
        }

        [Fact]
        public void GetStudentIsCorrect()
        {
            //arrange

            var teacherName = Guid.NewGuid().ToString();
            var teacherID = _teacherRepository.Create(new Teacher() { Name = teacherName, Speciality = Guid.NewGuid().ToString() });
            var student = new Student()
            {
                Name = Guid.NewGuid().ToString(),
                Courses = new List<Course>()
                {
                    new Course() { Name = Guid.NewGuid().ToString(), TeacherId = teacherID }
                }
            };
            var studentID = _studentRepository.Create(student);
            var courseID = student.Courses.First().ID;
            //act
            var actualstudent = _studentService.Get(studentID);
            //assert
            actualstudent.Name.Should().Be(student.Name);
            actualstudent.Courses.Should().HaveCount(1);
            actualstudent.Courses.First().Name.Should().Be(student.Courses.First().Name);
            actualstudent.Courses.First().Id.Should().Be(courseID);
            actualstudent.Courses.First().TeacherName.Should().Be(teacherName);
            actualstudent.Courses.First().TeacherId.Should().Be(teacherID);
        }

        [Fact]
        public void CreateStudentIsCorrect()
        {
            //arrange
            var studentDTO = new AddStudentDTO() { Name = Guid.NewGuid().ToString() };
            //act
            var actualstudentId = _studentService.Create(studentDTO);
            
            //assert
            var actualstudent = _studentRepository.Get(actualstudentId);
            actualstudent.Name.Should().Be(studentDTO.Name);
        }

        [Fact]
        public void UpdateStudentIsCorrect()
        {
            //arrange
            var studentID = _studentRepository.Create(new Student() { Name = Guid.NewGuid().ToString() });
            var updateDTO = new UpdateStudentDTO() { Name = Guid.NewGuid().ToString() };
            //act
            _studentService.Update(studentID, updateDTO);
            //assert
            var actualstudent = _studentRepository.Get(studentID);
            actualstudent.Name.Should().Be(updateDTO.Name);



        }

        [Fact]
        public void DeleteStudentIsCorrect()
        {
            //arrange
            var studentID = _studentRepository.Create(new Student() { Name = Guid.NewGuid().ToString() });
        
            //act
            _studentService.Delete(studentID);
            //assert
            Action act = () => _studentRepository.Get(studentID);
            act.Should().Throw<InvalidOperationException>().WithMessage("Sequence contains no elements");


        }
    }
}
