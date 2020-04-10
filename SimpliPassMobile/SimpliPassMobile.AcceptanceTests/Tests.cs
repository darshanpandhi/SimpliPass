using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace SimpliPassMobile.AcceptanceTests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        // User Story 1: View a course to know its difficulty level
        [Test]
        public void Test_ViewingCourseDifficulty()
        {
            app.WaitForElement(e => e.Text("Home"));
            var homeTab = app.Query(e => e.Text("Home"));
            Assert.IsTrue(homeTab.Length > 0, "Home page was not found!");
            app.Tap(homeTab.First().Text);

            app.WaitForElement(e => e.Text("Select a Department"));
            var content = app.Query(e => e.Text("Select a Department"));
            Assert.IsTrue(content.Length > 0, "Home page has incorrect content");

            app.WaitForElement(e => e.Text("Statistics"));
            var testDeptElem = app.Query(e => e.Text("Statistics"));
            Assert.IsTrue(testDeptElem.Length > 0, "Department element was not found");
            app.Tap(testDeptElem.First().Text);

            app.WaitForElement(e => e.Text("Select a Course"));
            var testCourseElem = app.Query(e => e.Text("STAT 1000"));
            Assert.IsTrue(testCourseElem.Length > 0, "Course element was not found");
            app.Tap(testCourseElem.First().Text);

            app.WaitForElement(e => e.Text("Difficulty Level"));
            var difficultyElem = app.Query(e => e.Property("Text").Contains("Difficulty Level"));
            Assert.IsTrue(difficultyElem.Length > 0, "Difficulty element was not found for selected course");
        }

        // User Story 2: View course-specific instructor ratings
        [Test]
        public void Test_ViewingInstructorRatings()
        {
            app.WaitForElement(e => e.Text("Home"));
            var homeTab = app.Query(e => e.Text("Home"));
            Assert.IsTrue(homeTab.Length > 0, "Home page was not found!");
            app.Tap(homeTab.First().Text);

            app.WaitForElement(e => e.Text("Select a Department"));
            var content = app.Query(e => e.Text("Select a Department"));
            Assert.IsTrue(content.Length > 0, "Home page has incorrect content");

            app.WaitForElement(e => e.Text("Computer Science"));
            var testDeptElem = app.Query(e => e.Text("Computer Science"));
            Assert.IsTrue(testDeptElem.Length > 0, "Department element was not found");
            app.Tap(testDeptElem.First().Text);

            app.WaitForElement(e => e.Text("Select a Course"));
            var testCourseElem = app.Query(e => e.Text("COMP 1010"));
            Assert.IsTrue(testCourseElem.Length > 0, "Course element was not found");
            app.Tap(testCourseElem.First().Text);

            app.WaitForElement(e => e.Text("Section Ratings"));
            var sectionRatingsElem = app.Query(e => e.Text("Section Ratings"));
            Assert.IsTrue(sectionRatingsElem.Length > 0, "Section ratings element was not found!");
        }

        // User Story 3: Review a Course and its Section
        [Test]
        public void Test_ReviewingACourse()
        {
            app.WaitForElement(e => e.Text("Review a course"));
            var reviewTab = app.Query(e => e.Text("Review a course"));
            Assert.IsTrue(reviewTab.Length > 0, "Review page was not found!");
            app.Tap(reviewTab.First().Text);

            app.Tap("COMP");
            app.EnterText("CHEM");
            app.DismissKeyboard();

            app.Tap("1010");
            app.EnterText("1300");
            app.DismissKeyboard();

            app.Tap("Intro to Computer Science 1");
            app.EnterText("Structure and Modelling in Chemistry");
            app.DismissKeyboard();

            app.Tap("Computer Science");
            app.EnterText("Chemistry");
            app.DismissKeyboard();

            Random random = new Random();

            app.Tap("1 - Very Easy, 10 - Extremely Difficult");
            app.Tap(""+random.Next(6,9));

            app.Tap("John Smith");
            app.EnterText("Michael Scott");
            app.DismissKeyboard();

            app.Tap("1 - Poor, 10 - Excellent");
            app.Tap("" + random.Next(7, 10));
            app.Tap("Submit Review");

            app.WaitForElement(e => e.Id("alertTitle"));

            var successAlert = app.Query(e => e.Id("alertTitle"));
            Assert.IsTrue(successAlert.First().Text.Equals("Success!"));
            Assert.IsTrue(successAlert.Length > 0, "No success alert was given!");

            app.Tap("OK");

            app.WaitForElement(e => e.Text("Home"));
            var homeTab = app.Query(e => e.Text("Home"));
            Assert.IsTrue(homeTab.Length > 0, "Home page was not found!");
            app.Tap(homeTab.First().Text);

            app.WaitForElement(e => e.Text("Select a Department"));
            var content = app.Query(e => e.Text("Select a Department"));
            Assert.IsTrue(content.Length > 0, "Home page has incorrect content");

            app.WaitForElement(e => e.Text("Chemistry"));
            var testDeptElem = app.Query(e => e.Text("Chemistry"));
            Assert.IsTrue(testDeptElem.Length > 0, "Department element was not found");
            app.Tap(testDeptElem.First().Text);

            app.WaitForElement(e => e.Text("Select a Course"));
            var testCourseElem = app.Query(e => e.Text("CHEM 1300"));
            Assert.IsTrue(testCourseElem.Length > 0, "Course element was not found");
            app.Tap(testCourseElem.First().Text);

            app.WaitForElement(e => e.Text("Michael Scott"));
            var sectionRatingsElem = app.Query(e => e.Text("Michael Scott"));
            Assert.IsTrue(sectionRatingsElem.Length > 0, "Recently added review was not found!");
        }

        // User Story 4: Get recommendations for popular elective courses
        [Test]
        public void Test_CourseRecommendations()
        {
            app.WaitForElement(e => e.Text("Course Recommendations"));
            var recommendTab = app.Query(e => e.Text("Course Recommendations"));
            Assert.IsTrue(recommendTab.Length > 0, "Recommendations Page was not found!");
            app.Tap(recommendTab.First().Text);

            app.WaitForElement(e => e.Text("Recommended Popular Courses"));
            var difficultyElem = app.Query(e => e.Property("Text").Contains("Difficulty Level"));
            Assert.IsTrue(difficultyElem.Length > 0, "No course recommendation found!");
        }
    }
}
