using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SimpliPassMobile.Models;
using SimpliPassMobile.TestDoubles;
using SimpliPassMobile.ViewModels;
using SimpliPassMobile.Views;

namespace SimpliPassMobile.IntegrationTests
{
    [TestClass]
    public class TestDepartmentVM_to_CourseDetailsVM
    {
        [TestMethod]
        public void Test_GetContextedCourseVM_with_ValidCourse()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();
            List<CourseModel> test_courseList = new List<CourseModel>();

            CourseModel dummy_courseToAttach = new CourseModel();
            dummy_courseToAttach.Id = "1000";
            dummy_courseToAttach.Department = "STAT";
            dummy_courseToAttach.Name = "Should be in final list";
            dummy_courseToAttach.Difficulty = 5.55;
            dummy_courseToAttach.DifficultyCount = 9;
            dummy_courseToAttach.SectionRatings = new Dictionary<string, Dictionary<string, double>>
            {
                {"test_person1", new Dictionary<string, double> { {"rating", 6.9}, {"count", 10} }}
            };

            DepartmentViewModel deptVmToTest = new DepartmentViewModel("TEST", stub_connection);

            // Act

            CourseDetailsViewModel courseVmToTest = deptVmToTest.GetContextedCourseVM(dummy_courseToAttach);

            // Assert

            Assert.IsTrue(courseVmToTest.DepartmentName.Equals("Department of "+dummy_courseToAttach.Department), "Returned contexted course had different department");
            Assert.IsTrue(courseVmToTest.DifficultyLevel.Equals(dummy_courseToAttach.Difficulty), "Returned contexted course had difficulty level");
            Assert.IsTrue(courseVmToTest.DifficultyCount.Equals("Based on "+dummy_courseToAttach.DifficultyCount+" reviews"), "Returned contexted course had difficulty count");
            Assert.IsTrue(courseVmToTest.NameAndId.Equals(dummy_courseToAttach.Id +" - "+dummy_courseToAttach.Name), "Returned contexted course had different course name and id");
        }

        [TestMethod]
        public void Test_GetContextedDeptVM_with_InvalidArgs()
        {
            // Arrange
            
            StubHttpConnection stub_connection = new StubHttpConnection();
            DepartmentViewModel deptVmToTest = new DepartmentViewModel("FAKE", stub_connection);

            // Act

            CourseDetailsViewModel courseVmToTest = deptVmToTest.GetContextedCourseVM(new SectionModel()); ;

            // Assert

            Assert.IsTrue(courseVmToTest == null, "contexted course was not null even with invalid data");
           
        }

        [TestMethod]
        public void Test_GetContextedDeptVM_with_NullArgs()
        {
            // Arrange

            StubHttpConnection stub_connection = new StubHttpConnection();
            DepartmentViewModel deptVmToTest = new DepartmentViewModel("FAKE", stub_connection);

            // Act

            CourseDetailsViewModel courseVmToTest = deptVmToTest.GetContextedCourseVM(null);

            // Assert

            Assert.IsTrue(courseVmToTest == null, "contexted course was not null even with null data");

        }
    }
}