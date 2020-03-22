using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpliPassMobile.Models
{
    /// <summary>
    /// Model class for a Course
    /// </summary>
    public class CourseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("difficulty")]
        public double Difficulty { get; set; }

        [JsonProperty("difficultyCount")]
        public int DifficultyCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sectionRatings")]
        public Dictionary<string, Dictionary<string, double>> SectionRatings { get; set; }
    }
}
