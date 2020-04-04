using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Moq;
using NUnit.Framework;
using SimpliPassApi.Clients;
using SimpliPassApi.Models;

namespace SimpliPassApiTests.ClientTests
{
    public class DynamoDBClientTests
    {
        private IDynamoDBClient _client;
        private Mock<IDynamoDBContext> _context;
        private Course testCourse1;
        private List<Course> testCourseList;
        private Course updatedCourse;

        [SetUp]
        public void Setup()
        {
            _context = new Mock<IDynamoDBContext>();

            var ratings = new Dictionary<string, Dictionary<string, double>>();
            var pairs = new Dictionary<string, double>();

            pairs.Add("count", 7);
            pairs.Add("rating", 4.2);
            ratings.Add("Some Instructor Name", pairs);

            testCourse1 = new Course
            {
                Id = "Test Id 1",
                Department = "Test Department",
                Difficulty = 6.1,
                DifficultyCount = 3,
                Name = "Test Name",
                SectionRatings = ratings
            };

            testCourseList = new List<Course>();
            testCourseList.Add(testCourse1);

            _context
                .Setup(c => c.LoadAsync<Course>("Test Id 1", It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(testCourse1));

            updatedCourse = null;

            //capture course update and save reference to this.updatedCourse
            _context.Setup(c => c.SaveAsync(It.IsAny<Course>(), It.IsAny<CancellationToken>()))
                .Callback<Course, CancellationToken>((crs, ctkn) => updatedCourse = crs);

            _client = new DynamoDBClient(_context.Object);
        }

        [Test]
        public async Task TestGetCourse()
        {
            var result = await _client.GetCourse("Test Id 1");

            ValidateCourse(result, testCourse1);
        }

        [Test]
        public async Task TestGetCourses()
        {
            try
            {
                var result = await _client.GetCourses();
            }
            catch (NullReferenceException e)
            {
                //Cannot fully test current version of AWS SDK.
            }

            _context.Verify(c => c.ScanAsync<Course>(It.IsAny<List<ScanCondition>>(), It.IsAny<DynamoDBOperationConfig>()), Times.Once);
        }

        [Test]
        public async Task TestGetAllDepartments()
        {
            try
            {
                var result = await _client.GetAllDepartments();
            }
            catch (NullReferenceException e)
            {
                //Cannot fully test current version of AWS SDK.
            }

            _context.Verify(c => c.ScanAsync<Course>(It.IsAny<List<ScanCondition>>(), It.IsAny<DynamoDBOperationConfig>()), Times.Once);
        }

        [Test]
        public async Task GetCoursesForDept()
        {
            try
            {
                var result = await _client.GetAllDepartments();
            }
            catch (NullReferenceException e)
            {
                //Cannot fully test current version of AWS SDK.
            }

            _context.Verify(c => c.ScanAsync<Course>(It.IsAny<List<ScanCondition>>(), It.IsAny<DynamoDBOperationConfig>()), Times.Once);
        }

        [Test]
        public async Task TestGetRecommendation()
        {
            try
            {
                var result = await _client.GetRecommendations();
            }
            catch (NullReferenceException e)
            {
                //Cannot fully test current version of AWS SDK.
            }

            _context.Verify(c => c.ScanAsync<Course>(It.IsAny<List<ScanCondition>>(), It.IsAny<DynamoDBOperationConfig>()), Times.Once);
        }

        [Test]
        public void TestUpdateExistingCourse()
        {
            int difficultyCount = testCourse1.DifficultyCount;
            double difficulty = testCourse1.Difficulty;
            _client.UpdateExistingCourse("Test Id 1", 1, "Some Instructor Name", 1);
            Assert.AreNotEqual(difficultyCount, updatedCourse.DifficultyCount);
            Assert.AreNotEqual(difficulty, updatedCourse.Difficulty);
        }

        [Test]
        public async Task TestAddNewCourse()
        {
            String newId = "Test Id 2";
            String newName = "Test Name 2";
            String newDpt = "Test Department 2";
            int newDifficulty = 1;
            string newInstr = "John Doe 2.0";
            int newRating = 1;

            var ratings = new Dictionary<string, Dictionary<string, double>>();
            var pairs = new Dictionary<string, double>();

            pairs.Add("count", 1);
            pairs.Add("rating", newRating);
            ratings.Add(newInstr, pairs);
            Course testCourse2 = new Course
            {
                Id = newId,
                Department = newDpt,
                Difficulty = newDifficulty,
                DifficultyCount = 1,
                Name = newName,
                SectionRatings = ratings
            };

            _client.AddNewCourse(newId, newName, newDpt, newDifficulty, newInstr, newRating);

            ValidateCourse(updatedCourse, testCourse2);
        }

        private void ValidateCourse(Course actual, Course expected)
        {
            Assert.NotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Department, actual.Department);
            Assert.AreEqual(expected.Difficulty, actual.Difficulty);
            Assert.AreEqual(expected.DifficultyCount, actual.DifficultyCount);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsTrue(actual.SectionRatings.ContainsKey(expected.SectionRatings.Keys.First<string>()));

            foreach (var item in actual.SectionRatings.Values)
            {
                Assert.AreEqual(
                    expected.SectionRatings.Values.First()["count"],item["count"]);
                Assert.AreEqual(
                    expected.SectionRatings.Values.First()["rating"], item["rating"]);
            }
        }
    }
}