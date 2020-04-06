using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpliPassMobile.ViewModels;
using SimpliPassMobile.TestDoubles;

namespace SimpliPassMobile.UnitTests
{
    [TestClass]
    public class TestDepartmentListVM
    {
        [TestMethod]
        public void Test_GenerateDepartmentList_with_NullServerResponse()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();

            stub_connection.SetDummyResponse(null);

            DepartmentListViewModel vmToTest = new DepartmentListViewModel(stub_connection);

            // Act
            vmToTest.GenerateDepartmentList();

            // Assert
            Assert.IsTrue(vmToTest.DepartmentList.Count == 0, "Department was added with null server response");

        }

        [TestMethod]
        public void Test_GenerateDepartmentList_with_ValidServerResponse()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();

            stub_connection.SetDummyResponse("[\"TestDept1\",\"TestDept2\",\"TestDept3\"]");

            DepartmentListViewModel vmToTest = new DepartmentListViewModel(stub_connection);

            // Act

            vmToTest.GenerateDepartmentList();

            // Assert
            Assert.IsTrue(vmToTest.DepartmentList.Any(d => d.Name.Equals("TestDept1")), "Expected department not found");
            Assert.IsTrue(vmToTest.DepartmentList.Any(d => d.Name.Equals("TestDept2")), "Expected department not found");
            Assert.IsTrue(vmToTest.DepartmentList.Any(d => d.Name.Equals("TestDept3")), "Expected department not found");

            Assert.IsTrue(vmToTest.DepartmentList.Count == 3, "Not all departments were added");
        }
    }
}
