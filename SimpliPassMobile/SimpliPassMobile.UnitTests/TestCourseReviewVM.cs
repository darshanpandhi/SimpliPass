using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpliPassMobile.TestDoubles;
using SimpliPassMobile.ViewModels;

namespace SimpliPassMobile.UnitTests
{
    [TestClass]
    public class TestCourseReviewVM
    {
        [TestMethod]
        public void Test_HandleReviewSubmission_with_NewValidData()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();

            stub_connection.SetDummyResponse("[{\"id\":\"STAT 2000\",\"department\":\"Statistics\",\"difficulty\":8,\"difficultyCount\":1,\"name\":\"Intro to Statistics 2\",\"sectionRatings\":{\"Ariana Grande\":{\"count\":1,\"rating\":3}}}]");
            CourseReviewViewModel vmToTest = new CourseReviewViewModel(stub_connection)
            {
                CourseDeptCode = "TEST",
                CourseNum = "1000",
                Department = "Test Science",
                CourseName = "Intro to Testing",
                DifficultyLevel = 6,
                Instructor = "Cool Person",
                InstructorRating = 4
            };

            // Act
            vmToTest.HandleReviewSubmission();

            // Assert

            Assert.IsTrue(stub_connection.GetResource("").Contains("Test.POST"), "Review was not submitted for new course");
            Assert.IsFalse(stub_connection.GetResource("").Contains("Test.PUT"), "Review was submitted as existing course for new course");
        }

        [TestMethod]
        public void Test_HandleReviewSubmission_with_ExistingValidData()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();

            stub_connection.SetDummyResponse("[{\"id\":\"TEST 1000\",\"department\":\"Test Science\",\"difficulty\":8,\"difficultyCount\":1,\"name\":\"Intro to Testing\",\"sectionRatings\":{\"Ariana Grande\":{\"count\":1,\"rating\":3}}}]");
            CourseReviewViewModel vmToTest = new CourseReviewViewModel(stub_connection)
            {
                CourseDeptCode = "TEST",
                CourseNum = "1000",
                Department = "Test Science",
                CourseName = "Intro to Testing",
                DifficultyLevel = 6,
                Instructor = "Cool Person",
                InstructorRating = 4
            };

            // Act
            vmToTest.HandleReviewSubmission();

            // Assert

            Assert.IsTrue(stub_connection.GetResource("").Contains("Test.PUT"), "Review was not submitted for existing course");
            Assert.IsFalse(stub_connection.GetResource("").Contains("Test.POST"), "Review was submitted as a new course for existing course");
        }

        [TestMethod]
        public void Test_HandleReviewSubmission_with_InvalidData()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();

            stub_connection.SetDummyResponse("[{\"id\":\"TEST 1000\",\"department\":\"Test Science\",\"difficulty\":8,\"difficultyCount\":1,\"name\":\"Intro to Testing\",\"sectionRatings\":{\"Ariana Grande\":{\"count\":1,\"rating\":3}}}]");
            CourseReviewViewModel vmToTest = new CourseReviewViewModel(stub_connection)
            {
                CourseDeptCode = "TEST",
                CourseNum = "",
                Department = null,
                CourseName = null,
                DifficultyLevel = -5,
                Instructor = "Cool Person",
                InstructorRating = -5
            };

            // Act
            vmToTest.HandleReviewSubmission();

            // Assert

            Assert.IsFalse(stub_connection.GetResource("").Contains("Test.PUT"), "Review was submitted as existing course with invalid course data");
            Assert.IsFalse(stub_connection.GetResource("").Contains("Test.POST"), "Review was submitted as new course with invalid course data");
        }

        [TestMethod]
        public void Test_HandleReviewSubmission_with_NullServerResponse()
        {
            StubHttpConnection stub_connection = new StubHttpConnection();

            stub_connection.SetDummyResponse(null);
            CourseReviewViewModel vmToTest = new CourseReviewViewModel(stub_connection)
            {
                CourseDeptCode = "TEST",
                CourseNum = "1000",
                Department = "Test Science",
                CourseName = "Intro to Testing",
                DifficultyLevel = 6,
                Instructor = "Cool Person",
                InstructorRating = 4
            };

            // Act
            vmToTest.HandleReviewSubmission();

            // Assert

            Assert.IsTrue(stub_connection.GetResource("") == null, "Review was submitted without a valid response from server");
        }
    }
}
