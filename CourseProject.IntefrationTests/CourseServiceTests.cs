using CourseProject.BL.CourceService;
using CourseProject.DAL;
using CourseProject.BL;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using CourseProject.BL.StudentServices.DTO;
using CourseProject.BL.CourceService.DTO;

namespace CourseProject.IntegrationTests
{
    public class CourseServiceTests
    {
        private readonly ICourseService _courseService;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Teacher> _teacherRepository;

        public CourseServiceTests()
        {
            var provider = new ServiceCollection().RegisterRepositories().RegisterServices().BuildServiceProvider();
            _courseService = provider.GetRequiredService<ICourseService>();
            _courseRepository = provider.GetRequiredService<IRepository<Course>>();
            _studentRepository = provider.GetRequiredService<IRepository<Student>>();
            _teacherRepository = provider.GetRequiredService<IRepository<Teacher>>();
        }

        [Fact]
        public void CreateCourseIsCorrect()
        {
            //arrange
            var teacherID = _teacherRepository.Create(new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() });
            var courseDTO = new AddCourceDTO() { Name = Guid.NewGuid().ToString(), TeacherId = teacherID };
            //act
            var actualCourseId = _courseService.Create(courseDTO);

            //assert
            var actualCourse = _courseRepository.Get(actualCourseId);
            actualCourse.Name.Should().Be(courseDTO.Name);
            actualCourse.TeacherId.Should().Be(teacherID);
        }

        [Fact]
        public void DeleteCourseIsCorrect()
        {
            var teacherId = _teacherRepository.Create(new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() });
            //arrange
            var courseId = _courseRepository.Create(new Course() { Name = Guid.NewGuid().ToString(), TeacherId = teacherId });
            //act
            _courseService.Delete(courseId);
            //assert
            Action act = () => _courseRepository.Get(courseId);
            act.Should().Throw<InvalidOperationException>().WithMessage("Sequence contains no elements");

        }

        [Fact]
        public void UpdateCourseIsCorrect()
        {
            //arrange
            var teacherId1 = _teacherRepository.Create(new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() });

            var courceID = _courseRepository.Create(new Course() { Name = Guid.NewGuid().ToString(), TeacherId = teacherId1 });
            var teacherId2 = _teacherRepository.Create(new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() });
            var updateDTO = new UpdateCourceDTO() { Name = Guid.NewGuid().ToString(), TeacherId = teacherId2 };
            //act
            _courseService.Update(courceID, updateDTO);
            //assert
            var actualCourse = _courseRepository.Get(courceID);
            actualCourse.Name.Should().Be(updateDTO.Name);
            actualCourse.TeacherId.Should().Be(updateDTO.TeacherId);
        }

        [Fact]
        public void GetCourseIsCorrect()
        {
            //arrange
            
            var teacher = new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() };
            var courseName = Guid.NewGuid().ToString();


            var student1 = new Student() { Name = Guid.NewGuid().ToString() };
            var student2 = new Student() { Name = Guid.NewGuid().ToString() };

            var courceID = _courseRepository.Create(new Course()
            {
                Name = courseName,
                Teacher = teacher,
                Students = new[] { student1, student2 }
            });

            //act
            var actualCourse = _courseService.Get(courceID);
            //assert
            actualCourse.Name.Should().Be(courseName);
            actualCourse.TeacherId.Should().Be(teacher.ID);
            actualCourse.TeacherName.Should().Be(teacher.Name);
            actualCourse.Students.Should().HaveCount(2);
            actualCourse.Students.First(x => x.Id== student1.ID).Name.Should().Be(student1.Name);
            actualCourse.Students.First(x => x.Id == student2.ID).Name.Should().Be(student2.Name);
        }

        [Fact]
        public void GetAllCoursesIsCorrect()
        {
            //arrange
            var teacher1 = new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() };
            var teacher2 = new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() };
            var courseName1 = Guid.NewGuid().ToString();
            var courseName2 = Guid.NewGuid().ToString();

            var courceID1 = _courseRepository.Create(new Course()
            {
                Name = courseName1,
                Teacher = teacher1,

            });
            var courceID2 = _courseRepository.Create(new Course()
            {
                Name = courseName2,
                Teacher = teacher2,

            });

            //act
            var allcourses = _courseService.GetAll(new[] { courceID1, courceID2 });
            //assert
            allcourses.Should().HaveCount(2);
            allcourses.First(x => x.Id == courceID1).Name.Should().Be(courseName1);
            allcourses.First(x => x.Id == courceID2).Name.Should().Be(courseName2);
            allcourses.First(x => x.Id == courceID1).TeacherName.Should().Be(teacher1.Name);
            allcourses.First(x => x.Id == courceID2).TeacherName.Should().Be(teacher2.Name);
        }

        [Fact]
        public void GetAllStudentsIsCorrect()
        {
            //arrange
            var teacher = new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() };
            var courseName = Guid.NewGuid().ToString();


            var student1 = new Student() { Name = Guid.NewGuid().ToString() };
            var student2 = new Student() { Name = Guid.NewGuid().ToString() };

            var courceID = _courseRepository.Create(new Course()
            {
                Name = courseName,
                Teacher = teacher,
                Students = new[] { student1, student2 }
            });

            //act

            var allstudents = _courseService.GetAllStudents(courceID);

            //assert
            allstudents.Should().HaveCount(2);
            allstudents.First(x => x.Id == student1.ID).Name.Should().Be(student1.Name);
            allstudents.First(x => x.Id == student2.ID).Name.Should().Be(student2.Name);

        }
    }
}
