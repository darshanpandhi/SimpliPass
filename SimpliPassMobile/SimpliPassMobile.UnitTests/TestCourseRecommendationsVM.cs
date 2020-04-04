using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SimpliPassMobile.Models;
using SimpliPassMobile.ViewModels;
using SimpliPassMobile.TestDoubles;

namespace SimpliPassMobile.UnitTests
{
    [TestClass]
    public class TestCourseRecommendationsVM
    {
        [TestMethod]
        public void Test_GenerateRecommendationsList_with_ValidCourse()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();
            List<CourseModel> test_recommendations = new List<CourseModel>();
            CourseModel dummy_courseToAttach1 = new CourseModel();
            dummy_courseToAttach1.Id = "1010";
            dummy_courseToAttach1.Department = "COMP";
            dummy_courseToAttach1.Name = "Should be in final list as it is valid";
            dummy_courseToAttach1.Difficulty = 7.62;
            dummy_courseToAttach1.DifficultyCount = 1;
            dummy_courseToAttach1.SectionRatings = new Dictionary<string, Dictionary<string, double>>
            {
                {"test_person1", new Dictionary<string, double> { {"rating", 5.4}, {"count", 10} } }
            };

            test_recommendations.Add(dummy_courseToAttach1);

            stub_connection.SetDummyResponse(JsonConvert.SerializeObject(test_recommendations));

            CourseRecommendationsViewModel vmToTest = new CourseRecommendationsViewModel(stub_connection);

            // Test with valid server response and data

            vmToTest.GenerateRecommendationsList();

            // Assert

            Assert.IsTrue(vmToTest.RecommendationsList.Any(c =>
                c.Name.Equals(dummy_courseToAttach1.Name) &&
                c.Id.Equals(dummy_courseToAttach1.Id) &&
                c.Department.Equals(dummy_courseToAttach1.Department) &&
                c.Difficulty == dummy_courseToAttach1.Difficulty &&
                c.DifficultyCount == dummy_courseToAttach1.DifficultyCount &&
                c.SectionRatings["test_person1"]["rating"] == 5.4), "Expected course was not found");

            Assert.IsTrue(vmToTest.RecommendationsList.Count == 1);
        }

        [TestMethod]
        public void Test_GenerateRecommendationsList_with_InvalidCourse()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();
            List<CourseModel> test_recommendations = new List<CourseModel>();

            CourseModel dummy_courseToAttach2 = new CourseModel();
            dummy_courseToAttach2.Id = null;
            dummy_courseToAttach2.Department = null;
            dummy_courseToAttach2.Name = "Should not be final list as it invalid";
            dummy_courseToAttach2.Difficulty = 4.56;
            dummy_courseToAttach2.DifficultyCount = 7;
            dummy_courseToAttach2.SectionRatings = new Dictionary<string, Dictionary<string, double>>
            {
                {"test_person2", new Dictionary<string, double> { {"rating", 3.4}, {"count", 15} } }
            };

            test_recommendations.Add(dummy_courseToAttach2);

            stub_connection.SetDummyResponse(JsonConvert.SerializeObject(test_recommendations));

            CourseRecommendationsViewModel vmToTest = new CourseRecommendationsViewModel(stub_connection);

            // Test with valid JSON object but invalid data

            vmToTest.GenerateRecommendationsList();

            // Assert

            Assert.IsFalse(vmToTest.RecommendationsList.Any(c =>
                c.Name.Equals(dummy_courseToAttach2.Name)), "Invalid course was added to list");
        }

        [TestMethod]
        public void Test_GenerateRecommendationsList_with_InvalidServerResponse()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();

            stub_connection.SetDummyResponse("[{\"NOId\":\"1010\",\"NOdepartment\":\"COMP\",\"NOdifficulty\":7.62,\"NOdifficultyCount\":1,\"NOname\":\"Should be in final list as it is valid\",\"NOsectionRatings\":{\"test_person1\":{\"NOrating\":5.4,\"NOcount\":10.0}}}]");

            CourseRecommendationsViewModel vmToTest = new CourseRecommendationsViewModel(stub_connection);

            // Test with invalid JSON responses from server

            vmToTest.GenerateRecommendationsList();

            // Assert

            Assert.IsTrue(vmToTest.RecommendationsList.Count == 0, "Invalid course added with invalid server response");

        }

        [TestMethod]
        public void Test_GenerateRecommendationsList_with_NullServerResponse()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();

            stub_connection.SetDummyResponse(null);

            CourseRecommendationsViewModel vmToTest = new CourseRecommendationsViewModel(stub_connection);

            // Test with null JSON responses from server

            vmToTest.GenerateRecommendationsList();

            // Assert

            Assert.IsTrue(vmToTest.RecommendationsList.Count == 0, "Invalid course added with null server response");

        }

        [TestMethod]
        public void Test_GenerateRecommendationsList_with_MultipleCourses()
        {
            // Arrange
            StubHttpConnection stub_connection = new StubHttpConnection();
            List<CourseModel> test_recommendations = new List<CourseModel>();
            
            CourseModel dummy_courseToAttach1 = new CourseModel();
            dummy_courseToAttach1.Id = "1010";
            dummy_courseToAttach1.Department = "COMP";
            dummy_courseToAttach1.Name = "Should be in final list";
            dummy_courseToAttach1.Difficulty = 7.62;
            dummy_courseToAttach1.DifficultyCount = 1;
            dummy_courseToAttach1.SectionRatings = new Dictionary<string, Dictionary<string, double>>
            {
                {"test_person1", new Dictionary<string, double> { {"rating", 5.4}, {"count", 10} } }
            };

            CourseModel dummy_courseToAttach2 = new CourseModel();
            dummy_courseToAttach2.Id = "2020";
            dummy_courseToAttach2.Department = "MATH";
            dummy_courseToAttach2.Name = "Should be final list";
            dummy_courseToAttach2.Difficulty = 4.56;
            dummy_courseToAttach2.DifficultyCount = 7;
            dummy_courseToAttach2.SectionRatings = new Dictionary<string, Dictionary<string, double>>
            {
                {"test_person2", new Dictionary<string, double> { {"rating", 3.4}, {"count", 15} } }
            };

            test_recommendations.Add(dummy_courseToAttach1);
            test_recommendations.Add(dummy_courseToAttach2);

            stub_connection.SetDummyResponse(JsonConvert.SerializeObject(test_recommendations));

            CourseRecommendationsViewModel vmToTest = new CourseRecommendationsViewModel(stub_connection);

            // Test with multiple courses

            vmToTest.GenerateRecommendationsList();

            // Assert

            Assert.IsTrue(vmToTest.RecommendationsList.Any(c =>
                c.Name.Equals(dummy_courseToAttach1.Name) &&
                c.Id.Equals(dummy_courseToAttach1.Id) &&
                c.Department.Equals(dummy_courseToAttach1.Department) &&
                c.Difficulty == dummy_courseToAttach1.Difficulty &&
                c.DifficultyCount == dummy_courseToAttach1.DifficultyCount &&
                c.SectionRatings["test_person1"]["rating"] == 5.4), "Expected course was not found multiple courses sent");

            Assert.IsTrue(vmToTest.RecommendationsList.Any(c =>
                c.Name.Equals(dummy_courseToAttach2.Name) &&
                c.Id.Equals(dummy_courseToAttach2.Id) &&
                c.Department.Equals(dummy_courseToAttach2.Department) &&
                c.Difficulty == dummy_courseToAttach2.Difficulty &&
                c.DifficultyCount == dummy_courseToAttach2.DifficultyCount &&
                c.SectionRatings["test_person2"]["rating"] == 3.4), "Expected course was not found when multiple courses sent");

            Assert.IsTrue(vmToTest.RecommendationsList.Count == 2, "not all courses were added");

        }

    }
}
