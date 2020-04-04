using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace SimpliPassApi.Models
{
    public class Course
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("id")]
        public string Id { get; set; }

        [DynamoDBProperty("department")]
        public string Department { get; set; }

        [DynamoDBProperty("difficulty")]
        public double Difficulty { get; set; }

        [DynamoDBProperty("difficulty_count")]
        public int DifficultyCount { get; set; }

        [DynamoDBProperty("name")]
        public string Name { get; set; }

        [DynamoDBProperty("section_ratings")]
        public Dictionary<string, Dictionary<string, double>> SectionRatings { get; set; }
    }
}