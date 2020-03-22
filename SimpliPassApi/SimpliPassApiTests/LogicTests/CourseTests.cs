using NUnit.Framework;
using SimpliPassApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpliPassApiTests.LogicTests
{
    class CourseTests
    {
        private Course testCourse1;
        private Course testCourse2;
        private List<Course> testCourseList;

        [SetUp]
        public void Setup()
        {

            testCourseList = new List<Course>();

            var ratings1 = new Dictionary<string, Dictionary<string, double>>();
            var pairs1 = new Dictionary<string, double>();

            pairs1.Add("count", 1);
            pairs1.Add("rating", 1.0);
            ratings1.Add("Instructor 1", pairs1);

            var ratings2 = new Dictionary<string, Dictionary<string, double>>();
            var pairs2 = new Dictionary<string, double>();

            pairs2.Add("count", 2);
            pairs2.Add("rating", 2.0);
            ratings2.Add("Instructor 2", pairs2);

            testCourse1 = new Course
            {
                Id = "Test Id 1",
                Department = "Test Department 1",
                Difficulty = 6.0,
                DifficultyCount = 1,
                Name = "Test Name 1",
                SectionRatings = ratings1
            };

            testCourse2 = new Course
            {
                Id = "Test Id 2",
                Department = "Test Department 2",
                Difficulty = 4.0,
                DifficultyCount = 2,
                Name = "Test Name 2",
                SectionRatings = ratings2
            };

            testCourseList.Add(testCourse1);
            testCourseList.Add(testCourse2);
        }

        [Test]
        public void TestGetAllDepartmentsNull()
        {
            List<string> result = Course.GetAllDepartments(null);
            Assert.IsNull(result);
        }

        [Test]
        public void TestGetAllDepartments()
        {
            List<string> result = Course.GetAllDepartments(testCourseList);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("Test Department 1"));
            Assert.IsTrue(result.Contains("Test Department 2"));
        }

        [Test]
        public void TestGetCoursesForDeptNull()
        {
            List<Course> result = Course.GetCoursesForDept(null, "Test Department 1");
            Assert.IsNull(result);
        }

        [Test]
        public void TestGetCoursesForDept()
        {
            List<Course> result1 = Course.GetCoursesForDept(testCourseList, "Test Department 1");
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1.Contains(testCourse1));
            List<Course> result2 = Course.GetCoursesForDept(testCourseList, "Test Department 2");
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2.Contains(testCourse2));

        }

        [Test]
        public void TestGetRecommendationsListNull()
        {
            List<Course> result = Course.GetRecommendationsList(null);
            Assert.IsNull(result);
        }

        [Test]
        public void TestGetRecommendationsList()
        {
            List<Course> result = Course.GetRecommendationsList(testCourseList);
            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Contains(testCourse1));
            Assert.IsTrue(result.Contains(testCourse2));
        }

        [Test]
        public void TestUpdateDifficulty()
        {
            int updateDiff = 5;
            double initDiff = testCourse1.Difficulty;
            int initDiffCount = testCourse1.DifficultyCount;
            double expectedDiff = ((initDiff * initDiffCount) + updateDiff) / (initDiffCount + 1);
            expectedDiff = Math.Round(expectedDiff, 1);
            testCourse1.UpdateDifficulty(updateDiff);
            Assert.AreEqual(testCourse1.DifficultyCount, initDiffCount + 1);
            Assert.AreEqual(testCourse1.Difficulty, expectedDiff);
        }

        [Test]
        public void TestUpdateSectionRatingSameInstructor()
        {
            int updateRating = 3;
            double initRating = testCourse1.SectionRatings["Instructor 1"]["rating"];
            double initCount = testCourse1.SectionRatings["Instructor 1"]["count"];
            double expectedRating = ((initRating * initCount) + updateRating) / (initCount + 1);
            expectedRating = Math.Round(expectedRating, 1);
            testCourse1.UpdateSectionRating("Instructor 1", updateRating);
            Assert.AreEqual(testCourse1.SectionRatings["Instructor 1"]["count"], initCount + 1);
            Assert.AreEqual(testCourse1.SectionRatings["Instructor 1"]["rating"], expectedRating);
        }

        [Test]
        public void TestUpdateSectionRatingNewInstructor()
        {
            int updateRating = 3;
            string newInstructor = "Test Instructor 42";
            testCourse1.UpdateSectionRating(newInstructor, updateRating);
            Assert.IsTrue(testCourse1.SectionRatings.ContainsKey("Test Instructor 42"));
            Assert.AreEqual(testCourse1.SectionRatings["Test Instructor 42"]["count"], 1);
            Assert.AreEqual(testCourse1.SectionRatings["Test Instructor 42"]["rating"], updateRating);
        }
    }
}  
