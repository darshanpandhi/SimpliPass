using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpliPassMobile.Models;

namespace SimpliPassMobile.ViewModels
{
    /// <summary>
    /// ViewModel for Course recommendations page
    /// </summary>
    public class CourseRecommendationsViewModel
    {
        private readonly ISimpliPassHttpConnection CurrHttpConnection;
        public ObservableCollection<CourseModel> RecommendationsList { get; set; }
        private List<object> courseList;

        public CourseRecommendationsViewModel(ISimpliPassHttpConnection argHttpConnection)
        {
            RecommendationsList = new ObservableCollection<CourseModel>();
            CurrHttpConnection = argHttpConnection;
        }

        /// <summary>
        /// Method that requests the list of all course recommendations
        /// </summary>
        public void GenerateRecommendationsList()
        {
            RecommendationsList = new ObservableCollection<CourseModel>();
            var response = CurrHttpConnection.GetResource(Constants.COURSE + Constants.RECOMMENDATIONS);
            if (response == null)
            {
                return;
            }
            courseList = JsonConvert.DeserializeObject<List<object>>(response);

            foreach (var crs in courseList)
            {
                var id = JObject.Parse(crs.ToString())["id"]?.ToObject<string>();
                var name = JObject.Parse(crs.ToString())["name"]?.ToObject<string>();
                var dept = JObject.Parse(crs.ToString())["department"]?.ToObject<string>();
                var diff = JObject.Parse(crs.ToString())["difficulty"]?.ToObject<double>();
                var diffCount = JObject.Parse(crs.ToString())["difficultyCount"]?.ToObject<int>();
                var secRatings = JObject.Parse(crs.ToString())["sectionRatings"]?.ToObject<Dictionary<string, Dictionary<string, double>>>();

                if (id == null || name == null || dept == null || diff == null || diffCount == null || secRatings == null)
                    continue;
                RecommendationsList.Add(new CourseModel { Id = id, Name = name, Department = dept, Difficulty = (double)diff, DifficultyCount = (int)diffCount, SectionRatings = secRatings });
            }
        }
    }
}
