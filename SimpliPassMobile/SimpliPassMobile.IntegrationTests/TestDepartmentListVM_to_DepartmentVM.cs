using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SimpliPassMobile.Models;
using SimpliPassMobile.TestDoubles;
using SimpliPassMobile.ViewModels;

namespace SimpliPassMobile.IntegrationTests
{
    [TestClass]
    public class TestDepartmentListVM_to_DepartmentVM
    {
        [TestMethod]
        public void Test_GetContextedDeptVM_with_ValidDept()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();
            List<CourseModel> test_courseList = new List<CourseModel>();

            CourseModel dummy_courseToAttach1 = new CourseModel();
            dummy_courseToAttach1.Id = "1000";
            dummy_courseToAttach1.Department = "STAT";
            dummy_courseToAttach1.Name = "Should be in final list";
            dummy_courseToAttach1.Difficulty = 5.55;
            dummy_courseToAttach1.DifficultyCount = 9;
            dummy_courseToAttach1.SectionRatings = new Dictionary<string, Dictionary<string, double>>
            {
                {"test_person1", new Dictionary<string, double> { {"rating", 6.9}, {"count", 10} }
}
            };

            CourseModel dummy_courseToAttach2 = new CourseModel();
            dummy_courseToAttach2.Id = "2000";
            dummy_courseToAttach2.Department = "STAT";
            dummy_courseToAttach2.Name = "Should be final list";
            dummy_courseToAttach2.Difficulty = 7.9;
            dummy_courseToAttach2.DifficultyCount = 7;
            dummy_courseToAttach2.SectionRatings = new Dictionary<string, Dictionary<string, double>>
            {
                {"test_person2", new Dictionary<string, double> { {"rating", 3.4}, {"count", 15} } }
            };

            test_courseList.Add(dummy_courseToAttach1);
            test_courseList.Add(dummy_courseToAttach2);

            stub_connection.SetDummyResponse(JsonConvert.SerializeObject(test_courseList));

            DepartmentListViewModel deptListVmToTest = new DepartmentListViewModel(stub_connection);

            // Act

            DepartmentViewModel deptVmToTest = deptListVmToTest.GetContextedDeptVM(new DepartmentModel() { Name = "STAT" }); ;

            // Assert

            Assert.IsTrue(deptVmToTest.DepartmentName.Equals("STAT"), "returned department not the same as requested");
            Assert.IsFalse(deptVmToTest  == null, "department was null even with valid data");
            Assert.IsFalse(deptVmToTest.CourseList == null, "course list was null for valid data");
            Assert.IsFalse(deptVmToTest.CourseList.Count == 0, "courses not generated for valid department");
        }

        [TestMethod]
        public void Test_GetContextedDeptVM_with_InvalidArgs()
        {
            // Arrange
            
            StubHttpConnection stub_connection = new StubHttpConnection();
            DepartmentListViewModel deptListVmToTest = new DepartmentListViewModel(stub_connection);

            // Act

            DepartmentViewModel deptVmToTest = deptListVmToTest.GetContextedDeptVM(new CourseModel()); ;

            // Assert

            Assert.IsTrue(deptVmToTest == null, "contexted department was not null even with invalid data");
           
        }

        [TestMethod]
        public void Test_GetContextedDeptVM_with_NullArgs()
        {
            // Arrange

            StubHttpConnection stub_connection = new StubHttpConnection();
            DepartmentListViewModel deptListVmToTest = new DepartmentListViewModel(stub_connection);

            // Act

            DepartmentViewModel deptVmToTest = deptListVmToTest.GetContextedDeptVM(null);

            // Assert

            Assert.IsTrue(deptVmToTest == null, "contexted department was not null even with null data");

        }
    }
}