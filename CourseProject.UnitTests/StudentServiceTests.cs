using AutoMapper;
using CourseProject.BL.StudentServices;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CourseProject.UnitTests
{
    public class StudentServiceTests
    {
        private readonly IStudentService studentService;
        private readonly Mock<IRepository<Student>> studentRepositoryMock;
        private readonly Mock<IRepository<Course>> courseRepositoryMock;
        private readonly Mock<IMapper> mapperMock;

        public StudentServiceTests()
        {
            studentRepositoryMock = new Mock<IRepository<Student>>();
            courseRepositoryMock = new Mock<IRepository<Course>>();
            mapperMock = new Mock<IMapper>();
            studentService = new StudentService(courseRepositoryMock.Object, studentRepositoryMock.Object, mapperMock.Object);
        }

        [Fact]
        public void EnrollToTheCource_WithNotExistingStudent_ThrowExactError()
        {
            //arrange
            studentRepositoryMock.Setup(x =>
                x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Student>, IQueryable<Student>>?>()))
                .Returns((int id, Func<IQueryable<Student>, IQueryable<Student>>? includeFunc) => { return null; });

            //act
            var act = () => studentService.EnrollToTheCource(1, 2);

            //assert
            act.Should().Throw<Exception>().WithMessage($"Student with ID 1 not found.");
        }

        [Fact]
        public void EnrollToTheCource_WithNotExistingCource_ThrowExactError()
        {
            //arrange
            studentRepositoryMock.Setup(x =>
                x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Student>, IQueryable<Student>>?>()))
                .Returns((int id, Func<IQueryable<Student>, IQueryable<Student>>? includeFunc) => { return new Student(); });

            courseRepositoryMock.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Course>, IQueryable<Course>>?>()))
                .Returns((int id, Func<IQueryable<Course>, IQueryable<Course>>? includeFunc) => { return null; });

            //act
            var act = () => studentService.EnrollToTheCource(1, 2);

            //assert
            act.Should().Throw<Exception>().WithMessage($"Course with ID 2 not found.");
        }

        [Fact]
        public void EnrollToTheCource_StudentAlreadyOnTheCourse_ThrowExactError()
        {
            //arrange
            studentRepositoryMock.Setup(x =>
                x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Student>, IQueryable<Student>>?>()))
                .Returns((int id, Func<IQueryable<Student>, IQueryable<Student>>? includeFunc) =>
                {
                    return new Student()
                    {
                        Courses = new List<Course>() { new Course() { ID = 2 } }
                    };
                });

            courseRepositoryMock.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Course>, IQueryable<Course>>?>()))
                .Returns((int id, Func<IQueryable<Course>, IQueryable<Course>>? includeFunc) => { return new Course(); });

            //act
            var act = () => studentService.EnrollToTheCource(1, 2);

            //assert
            act.Should().Throw<Exception>().WithMessage($"Student is already enrolled in the course with ID 2.");
        }

        [Fact]
        public void UnEnrollToTheCource_NotExistingStudent_ThrowExactError()
        {
            //arrange
            studentRepositoryMock.Setup(x =>
                x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Student>, IQueryable<Student>>?>()))
                .Returns((int id, Func<IQueryable<Student>, IQueryable<Student>>? includeFunc) => { return null; });

            //act
            var act = () => studentService.UnEnrollToTheCource(1, 2);

            //assert
            act.Should().Throw<Exception>().WithMessage($"Student or Course not found.");

        }
        [Fact]
        public void UnEnrollToTheCource_NotExistingCourse_ThrowExactError()
        {
            //arrange
            studentRepositoryMock.Setup(x =>
                x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Student>, IQueryable<Student>>?>()))
                .Returns((int id, Func<IQueryable<Student>, IQueryable<Student>>? includeFunc) => { return new Student(); });

            courseRepositoryMock.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Course>, IQueryable<Course>>?>()))
                .Returns((int id, Func<IQueryable<Course>, IQueryable<Course>>? includeFunc) => { return null; });

            //act
            var act = () => studentService.UnEnrollToTheCource(1, 2);

            //assert
            act.Should().Throw<Exception>().WithMessage($"Student or Course not found.");

        }

        [Fact]
        public void UnEnrollToTheCource_StudentNotEnrolled_ThrowExactError()
        {
            //arrange
            studentRepositoryMock.Setup(x =>
              x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Student>, IQueryable<Student>>?>()))
              .Returns((int id, Func<IQueryable<Student>, IQueryable<Student>>? includeFunc) =>
              {
                  return new Student()
                  {
                      Courses = new List<Course>() { new Course() { ID = 2 } }
                  };
              });

            courseRepositoryMock.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Course>, IQueryable<Course>>?>()))
                .Returns((int id, Func<IQueryable<Course>, IQueryable<Course>>? includeFunc) => { return new Course(); });

            //act
            var act = () => studentService.UnEnrollToTheCource(1, 3);

            //assert
            act.Should().Throw<Exception>().WithMessage($"Student is not enrolled in the course.");

        }

        [Fact]
        public void EnrollToTheCource_StudentAlreadyEnrollOnMaxCountCourses_ThrowExactError()
        {
            //arrange
            studentRepositoryMock.Setup(x =>
                x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Student>, IQueryable<Student>>?>()))
                .Returns((int id, Func<IQueryable<Student>, IQueryable<Student>>? includeFunc) =>
                {
                    return new Student()
                    {
                        Courses = new List<Course>() 
                        {
                            new Course() { ID = 2 } ,
                            new Course() { ID = 3 } ,
                            new Course() { ID = 4 } ,
                            new Course() { ID = 5 } ,
                            new Course() { ID = 6 } ,
                            new Course() { ID = 7 } 
                        }
                    };
                });

            courseRepositoryMock.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Course>, IQueryable<Course>>?>()))
                .Returns((int id, Func<IQueryable<Course>, IQueryable<Course>>? includeFunc) => { return new Course(); });

            //act
            var act = () => studentService.EnrollToTheCource(1, 8);

            //assert
            act.Should().Throw<Exception>().WithMessage($"Student is already enrolled to 5 courses.");
        }
    }
}
