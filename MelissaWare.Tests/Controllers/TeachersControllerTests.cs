using Microsoft.VisualStudio.TestTools.UnitTesting;
using MelissaWare.API.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.EntityFrameworkCore;
using MelissaWare.Context;
using MelissaWare.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MelissaWare.Tests;

namespace MelissaWare.API.Controllers.Tests
{
    [TestClass()]
    public class TeachersControllerTests
    {
        private MelissaWareDBContext _inMemoryDBContext;
        public TeachersControllerTests()
        {
            _inMemoryDBContext = SeedTeacherTest();
        }

        [TestMethod()]
        public void TeachersControllerTest()
        {
            //Arrange
            Moq.Mock<MelissaWareDBContext> teacherMockContext = new Mock<MelissaWareDBContext>();

            //Act
            TeachersController teachersController = new TeachersController(teacherMockContext.Object);
            //Assert
            Assert.IsInstanceOfType(teachersController, typeof(TeachersController));
        }

        [TestMethod()]
        public async Task GetTeachersTest()
        {
            //Arrange
            TeachersController teachersController = new TeachersController(_inMemoryDBContext);
            
            //Act
            ActionResult<IEnumerable<Teacher>> teacherList = await teachersController.GetTeachers();

            //Assert
            Assert.IsTrue(teacherList.Value.Count<Teacher>() >= 2);
        }

        [TestMethod()]
        public async Task GetTeacherTest()
        {
            //Arrange
            TeachersController teachersController = new TeachersController(_inMemoryDBContext);

            //Act
            ActionResult<Teacher> teacherItem = await teachersController.GetTeacher(1);

            //Assert
            Assert.IsTrue(teacherItem.Value.TeacherName == "Mr. Test Teacher");
        }

        [TestMethod()]
        public async Task PutTeacherTest()
        {
            //Arrange
            TeachersController teachersController = new TeachersController(_inMemoryDBContext);
            Teacher teacher = new Teacher();
            teacher.TeacherName = "Señor Maestro";
            teacher.TeacherKey = 1;

            //Act
            IActionResult putTeacheResult =   await teachersController.PutTeacher(1, teacher);
            ActionResult<Teacher> newTeacher = await teachersController.GetTeacher(1);

            //Assert
            Assert.IsTrue(newTeacher.Value.TeacherName == "Señor Maestro");
        }

        [TestMethod()]
        public async Task PostTeacherTest()
        {
            //Arrange
            TeachersController teachersController = new TeachersController(_inMemoryDBContext);
            ActionResult<IEnumerable<Teacher>> _teacherList = await teachersController.GetTeachers();
            int startingCount = _teacherList.Value.Count<Teacher>();

            Teacher teacher = new Teacher();
            teacher.TeacherName = "Señora Maestra";

            //Act
            ActionResult<Teacher> newTeacher = await teachersController.PostTeacher(teacher);

            //Assert
            CreatedAtActionResult postResult = (CreatedAtActionResult)newTeacher.Result;
            Teacher createdTeacher = (Teacher)postResult.Value;
            Assert.IsTrue(createdTeacher.TeacherKey  > startingCount);
        }

        [TestMethod()]
        public void DeleteTeacherTest()
        {
           
        }

        private InMemoryDbContext SeedTeacherTest()
        {
            DbContextOptions options = new DbContextOptions<InMemoryDbContext>();
            InMemoryDbContext _testingContext = new InMemoryDbContext(options);

            Teacher testTeacherOne = new Teacher();
            testTeacherOne.TeacherName = "Mr. Test Teacher";

            Teacher testTeacherTwo = new Teacher();
            testTeacherTwo.TeacherName = "Mrs. Test Teacher";

            _testingContext.AddRange(testTeacherOne, testTeacherTwo);
            _testingContext.SaveChanges();

            return _testingContext;

        }
    }
}