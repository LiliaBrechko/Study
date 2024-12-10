using CourseProject.BL;
using CourseProject.BL.TeacherServices;
using CourseProject.BL.TeacherServices.DTO;
using CourseProject.DAL;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CourseProject.IntegrationTests
{
    public class TeacherServiceTests
    {
        private readonly ITeacherService teacherservice;
        private readonly IRepository<Teacher> _teacherrepository;
        private readonly IRepository<Course> _courserepository;

        public TeacherServiceTests()
        {
            var provider = new ServiceCollection().RegisterRepositories().RegisterServices().BuildServiceProvider();
            teacherservice = provider.GetService<ITeacherService>();
            _teacherrepository = provider.GetService<IRepository<Teacher>>();
            _courserepository = provider.GetService<IRepository<Course>>();
        }

        [Fact]

        public void AddTeacherIsSuccessful()
        {
            //arrange
            var teacherDTO = new AddTeacherDTO() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() };
            //act
            var result = teacherservice.Create(teacherDTO);
            //assert
            var actualTeacher = _teacherrepository.Get(result);
            actualTeacher.Name.Should().Be(teacherDTO.Name);
            actualTeacher.Speciality.Should().Be(teacherDTO.Speciality);
        }
        [Fact]

        public void UpdateTeacherIsSuccessful()
        {
            //arrange
            var someteacher = _teacherrepository.Get(1);
            var updateTeacherDTO = new UpdateTeacherDTO() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() };

            //act
            teacherservice.Update(someteacher.ID, updateTeacherDTO);

            //assert
            var updatedteacher = _teacherrepository.Get(someteacher.ID);
            updatedteacher.Name.Should().Be(updateTeacherDTO.Name);
            updatedteacher.Speciality.Should().Be(updateTeacherDTO.Speciality);

        }

        [Fact]
        public void DeleteTeacherIsSuccessful()
        {
            //arrange
            var newteacherId = _teacherrepository.Create(new Teacher() { Name = Guid.NewGuid().ToString(), Speciality = Guid.NewGuid().ToString() });

            //act
            teacherservice.Delete(newteacherId);
            //assert
            Action act = () => _teacherrepository.Get(newteacherId);
            act.Should().Throw<InvalidOperationException>().WithMessage("Sequence contains no elements");
        }

        [Fact]
        public void GetTeacherIsSuccessful()
        {
            //arrange
            var teacherName = Guid.NewGuid().ToString();
            var teacherSpeciality = Guid.NewGuid().ToString();
            var newteacherId = _teacherrepository.Create(new Teacher() { Name = teacherName, Speciality = teacherSpeciality });

            //act
            var teacher = _teacherrepository.Get(newteacherId);

            //assert
            teacher.Name.Should().Be(teacherName);
            teacher.Speciality.Should().Be(teacherSpeciality);
        }

        [Fact]
        public void GetAllByFilterReturnsCorrectData()
        {
            //arrange
            var teacherName = Guid.NewGuid().ToString();
            var teacherSpeciality = Guid.NewGuid().ToString();
            var newteacherId = _teacherrepository.Create(new Teacher() { Name = teacherName, Speciality = teacherSpeciality });
            var teacherName2 = Guid.NewGuid().ToString();
            var teacherSpeciality2 = Guid.NewGuid().ToString();
            var newteacherId2 = _teacherrepository.Create(new Teacher() { Name = teacherName2, Speciality = teacherSpeciality2 });

            //act
            var result = teacherservice.GetAll(new[] { newteacherId, newteacherId2 });
            //assert
            result.Should().HaveCount(2);
            var teacher1 = result.FirstOrDefault(x => x.Id == newteacherId);
            var teacher2 = result.FirstOrDefault(x => x.Id == newteacherId2);
            teacher1.Name.Should().Be(teacherName);
            teacher1.Speciality.Should().Be(teacherSpeciality);

            teacher2.Name.Should().Be(teacherName2);
            teacher2.Speciality.Should().Be(teacherSpeciality2);
        }

        [Fact]
        public void GetAllCoursesIsCorrect()
        {
            //arrange
            var teacherName = Guid.NewGuid().ToString();
            var teacherSpeciality = Guid.NewGuid().ToString();
            var newteacherId = _teacherrepository.Create(new Teacher() { Name = teacherName, Speciality = teacherSpeciality });

            var courceName = Guid.NewGuid().ToString();
            var courceId = _courserepository.Create(new Course() { Name = courceName, TeacherId = newteacherId });
            var courceName2 = Guid.NewGuid().ToString();
            var courceId2 = _courserepository.Create(new Course() { Name = courceName2, TeacherId = newteacherId });
            //act
            var result = teacherservice.GetAllCource(newteacherId);

            //assert
            result.Should().HaveCount(2);

            var cource1 = result.First(x => x.Id == courceId);
            var cource2 = result.First(x => x.Id == courceId2);

            cource1.Name.Should().Be(courceName);
            cource1.TeacherId.Should().Be(newteacherId);
            cource1.TeacherName.Should().Be(teacherName);

            cource2.Name.Should().Be(courceName2);
            cource2.TeacherId.Should().Be(newteacherId);
            cource2.TeacherName.Should().Be(teacherName);




        }
    }
}
