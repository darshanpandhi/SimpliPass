using System.Collections.Generic;
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
        private Course testCourse;
        private List<Course> testCourseList;

        [SetUp]
        public void Setup()
        {
            _context = new Mock<IDynamoDBContext>();

            var ratings = new Dictionary<string, Dictionary<string, double>>();
            var pairs = new Dictionary<string, double>();

            pairs.Add("count", 7);
            pairs.Add("rating", 4.2);
            ratings.Add("Some Instructor Name", pairs);

            testCourse = new Course
            {
                Id = "Test Id",
                Department = "Test Department",
                Difficulty = 6.1,
                DifficultyCount = 3,
                Name = "Test Name",
                SectionRatings = ratings
            };

            testCourseList = new List<Course>();
            testCourseList.Add(testCourse);

            _context
                .Setup(c => c.LoadAsync<Course>(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(testCourse));

            _client = new DynamoDBClient(_context.Object);
        }

        [Test]
        public async Task TestGetCourse()
        {
            var result = await _client.GetCourse("any key");

            ValidateCourse(result);
        }

        private void ValidateCourse(Course course)
        {
            Assert.NotNull(course);
            Assert.AreEqual(testCourse.Id, course.Id);
            Assert.AreEqual(testCourse.Department, course.Department);
            Assert.AreEqual(testCourse.Difficulty, course.Difficulty);
            Assert.AreEqual(testCourse.DifficultyCount, course.DifficultyCount);
            Assert.AreEqual(testCourse.Name, course.Name);
            Assert.IsTrue(course.SectionRatings.ContainsKey("Some Instructor Name"));

            foreach (var item in course.SectionRatings.Values)
            {
                Assert.AreEqual(7, item["count"]);
                Assert.AreEqual(4.2, item["rating"]);
            }
        }
    }
}