using AutoMapper;
using CourseProject.BL.TeacherServices;
using CourseProject.BL.TeacherServices.DTO;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace CourseProject.UnitTests
{
    public class TeacherServiceTests
    {
        private readonly ITeacherService teacherService;
        private readonly Mock<IMapper> mapperMock;
        private readonly Mock<IRepository<Teacher>> teacherRepositoryMock;

        public TeacherServiceTests()
        {
            mapperMock = new Mock<IMapper>();   
            teacherRepositoryMock = new Mock<IRepository<Teacher>>();
            teacherService = new TeacherService(teacherRepositoryMock.Object, mapperMock.Object);
            
        }

        [Fact]
        public void CreateTeacher_WithShortName_ThrowExactError()
        {
            //arrange
            var teacherDTO = new AddTeacherDTO() { Name = "TE", Speciality = "Algebra" };
            //act
            Action act =()=> teacherService.Create(teacherDTO);
            //assert
            act.Should().Throw<Exception>().WithMessage("Name must be longer");
        }

        [Fact]
        public void CreateTeacher_WithLongName_ThrowExactError()
        {
            //arrange
            var teacherDTO = new AddTeacherDTO() { Name = Guid.NewGuid().ToString().Concat(Guid.NewGuid().ToString()).Take(21).ToString(), Speciality = "Algebra" };
            //act
            Action act = () => teacherService.Create(teacherDTO);
            //assert
            act.Should().Throw<Exception>().WithMessage("Name must be shorter");
        }

        [Fact]
        public void UpdateTeacher_WithShortName_ThrowExactError()
        {
            //arrange
            
            var teacherDTO = new UpdateTeacherDTO() { Name = "TE", Speciality = "Algebra" };
            //act
            Action act = () => teacherService.Update(1, teacherDTO);
            //assert
            act.Should().Throw<Exception>().WithMessage("Name must be longer");
        }

        [Fact]
        public void UpdateTeacher_WithLongName_ThrowExactError()
        {
            //arrange
            var teacherDTO = new UpdateTeacherDTO() { Name = Guid.NewGuid().ToString().Concat(Guid.NewGuid().ToString()).Take(21).ToString(), Speciality = "Algebra" };
            //act
            Action act = () => teacherService.Update(1, teacherDTO);
            //assert
            act.Should().Throw<Exception>().WithMessage("Name must be shorter");
        }

    }
}
