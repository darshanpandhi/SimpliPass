using System.Collections.ObjectModel;
using SimpliPassMobile.Models;

namespace SimpliPassMobile.ViewModels
{
    /// <summary>
    /// ViewModel for Course Details page
    /// </summary>
    class CourseDetailsViewModel
    {
        private CourseModel AttachedCourse { get; set; }

        public ObservableCollection<SectionModel> SectionRatings { get; set; }

        public string NameAndId => $"{AttachedCourse.Id} - {AttachedCourse.Name}";

        public string DepartmentName => $"Department of {AttachedCourse.Department}";

        public string DifficultyLevel => $"Difficulty Level {AttachedCourse.Difficulty}";

        public string DifficultyCount => $"Based on {AttachedCourse.DifficultyCount} reviews";

        public CourseDetailsViewModel(CourseModel arg_course)
        {
            AttachedCourse = arg_course;
            SectionRatings = new ObservableCollection<SectionModel>();
            ExtractSectionRatings();
        }

        /// <summary>
        /// Method that extracts Section ratings from CourseModels
        /// </summary>
        public void ExtractSectionRatings()
        {
            foreach (var secRating in AttachedCourse.SectionRatings)
            {
                SectionRatings.Add(new SectionModel { Name = secRating.Key, Rating = secRating.Value["rating"], Count = secRating.Value["count"] });
            }
        }
    }
}
