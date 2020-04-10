using System.Collections.ObjectModel;
using SimpliPassMobile.Models;

namespace SimpliPassMobile.ViewModels
{
    /// <summary>
    /// ViewModel for Course Details page
    /// </summary>
    public class CourseDetailsViewModel
    {
        private CourseModel AttachedCourse { get; set; }

        public ObservableCollection<SectionModel> SectionRatings { get; set; }

        public string NameAndId => $"{AttachedCourse.Id} - {AttachedCourse.Name}";

        public string DepartmentName => $"Department of {AttachedCourse.Department}";

        public string DifficultyLevelText => "Difficulty Level";

        public double DifficultyLevel => AttachedCourse.Difficulty;

    public string DifficultyCount => $"Based on {AttachedCourse.DifficultyCount} reviews";

        public CourseDetailsViewModel(CourseModel argCourse)
        {
            AttachedCourse = argCourse;
            SectionRatings = new ObservableCollection<SectionModel>();
        }

        /// <summary>
        /// Method that extracts Section ratings from CourseModels
        /// </summary>
        public void ExtractSectionRatings()
        {
            if(AttachedCourse == null || AttachedCourse.SectionRatings == null)
            {
                return;
            }
            foreach (var secRating in AttachedCourse.SectionRatings)
            {
                if(secRating.Value.ContainsKey("rating") && secRating.Value.ContainsKey("count"))
                {
                    SectionRatings.Add(new SectionModel { Name = secRating.Key, Rating = secRating.Value["rating"], Count = (int)secRating.Value["count"] });
                }
            }
        }
    }
}
