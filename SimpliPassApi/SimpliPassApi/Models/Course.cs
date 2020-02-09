using System;
using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

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
        public Dictionary<string, int> SectionRatings { get; set; }


        public double ComputeUpdatedDifficulty(double newDifficulty)
        {
            double result = ((Difficulty * DifficultyCount) + newDifficulty) / (DifficultyCount + 1);
            result = Math.Round(result, 1);

            return result;
        }
    }
}
