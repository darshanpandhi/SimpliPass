using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpliPassMobile.Models;
using SimpliPassMobile.ViewModels;

namespace SimpliPassMobile.UnitTests
{
    [TestClass]
    public class TestCourseDetailsVM
    {
        [TestMethod]
        public void Test_ExtractSectionRatings_with_ValidCourse()
        {
            // Arrange

            CourseModel dummy_courseToAttach = new CourseModel();
            dummy_courseToAttach.Id = "1010";
            dummy_courseToAttach.Department = "COMP";
            dummy_courseToAttach.Difficulty = 7.62;
            dummy_courseToAttach.DifficultyCount = 1;
            dummy_courseToAttach.SectionRatings = new Dictionary<string, Dictionary<string, double>>
            {
                {"test_person", new Dictionary<string, double> { {"rating", 9.76}, {"count", 4} } }
            };

            var testCourseDetailsVM = new CourseDetailsViewModel(dummy_courseToAttach);

            // Act

            testCourseDetailsVM.ExtractSectionRatings();

            // Assert
            Assert.IsTrue(testCourseDetailsVM.SectionRatings.Count == dummy_courseToAttach.SectionRatings.Count, "Not all section ratings were extracted in VM");
            Assert.IsTrue(testCourseDetailsVM.SectionRatings.Any(s => s.Name == "test_person" && s.Rating == 9.76 && s.Count == 4), "Could not find a section rating with provided test dummy data");
        }

        [TestMethod]
        public void Test_ExtractSectionRatings_with_NullCourse()
        {
            // Arrange

            var testCourseDetailsVM = new CourseDetailsViewModel(null);
            
            // Act

            testCourseDetailsVM.ExtractSectionRatings();

            // Assert
            Assert.IsTrue(testCourseDetailsVM.SectionRatings.Count == 0, "Sections cannot exist for a null course");
        }

        [TestMethod]
        public void Test_ExtractSectionRatings_with_NullSections()
        {
            // Arrange

            CourseModel dummy_courseToAttach = new CourseModel();
            dummy_courseToAttach.Id = "1010";
            dummy_courseToAttach.Department = "COMP";
            dummy_courseToAttach.Difficulty = 7.62;
            dummy_courseToAttach.DifficultyCount = 1;
            dummy_courseToAttach.SectionRatings = null;

            var testCourseDetailsVM = new CourseDetailsViewModel(dummy_courseToAttach);

            // Act

            testCourseDetailsVM.ExtractSectionRatings();

            // Assert
            Assert.IsTrue(testCourseDetailsVM.SectionRatings.Count == 0, "Sections should not exist for course with null sections");
        }

        [TestMethod]
        public void Test_ExtractSectionRatings_with_InvalidSections()
        {
            // Arrange

            CourseModel dummy_courseToAttach = new CourseModel();
            dummy_courseToAttach.Id = "1010";
            dummy_courseToAttach.Department = "COMP";
            dummy_courseToAttach.Difficulty = 7.62;
            dummy_courseToAttach.DifficultyCount = 1;
            dummy_courseToAttach.SectionRatings = new Dictionary<string, Dictionary<string, double>>
            {
                {"test_person", new Dictionary<string, double> { {"NOrating", 9.76}, {"NOcount", 4} } }
            };

            var testCourseDetailsVM = new CourseDetailsViewModel(dummy_courseToAttach);

            // Act

            testCourseDetailsVM.ExtractSectionRatings();

            // Assert
            Assert.IsTrue(testCourseDetailsVM.SectionRatings.Count == 0, "Sections should not exist for course with invalid section data");
        }
    }
}
