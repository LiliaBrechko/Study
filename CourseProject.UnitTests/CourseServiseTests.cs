using AutoMapper;
using CourseProject.BL.CourceService;
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
    public class CourseServiseTests
    {
        private readonly ICourseService courseService;
        private readonly Mock<IRepository<Course>> mockCourseRepository;
        private readonly Mock<IRepository<Student>> mockStudentRepository;
        private readonly Mock<IMapper> mockMapper;

        public CourseServiseTests()
        {
            mockCourseRepository = new Mock<IRepository<Course>>();
            mockStudentRepository = new Mock<IRepository<Student>>();
            mockMapper = new Mock<IMapper>();
            courseService = new CourseService(mockCourseRepository.Object, mockStudentRepository.Object, mockMapper.Object);

        }
        [Fact]
        public void UpdateCourse_AlreadyHasStudents_ThrowExactError()
        {
            //arrange
            mockCourseRepository.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<Func<IQueryable<Course>, IQueryable<Course>>?>()))
                .Returns((int id, Func<IQueryable<Course>, IQueryable<Course>>? func) =>
                {
                    return new Course()
                    {
                        Students = new[] { new Student() { } }
                    };
                });
            //act
            var act =()=> courseService.Update(1, null);
            //assert
            act.Should().Throw<Exception>().WithMessage("You cant update course with students");
        }
    }
}
