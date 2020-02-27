using System;
using System.Collections;
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

        public static List<string> GetAllDepartments(List<Course> courseList)
        {
            List<string> result = null;

            if (courseList != null)
            {
                result = new List<string>();

                foreach (var course in courseList)
                {
                    if (!result.Contains(course.Department))
                    {
                        result.Add(course.Department);
                    }
                }
            }

            return result;
        }

        public static List<Course> GetCoursesForDept(List<Course> courseList, string key)
        {
            List<Course> result = null;

            if (courseList != null && key != null && key.Length != 0)
            {
                result = new List<Course>();

                foreach (var course in courseList)
                {
                    if (course.Department.ToUpper() == key.ToUpper())
                    {
                        result.Add(course);
                    }
                }
            }

            return result;
        }

        public void UpdateDifficulty(int newDifficulty)
        {
            Difficulty = ComputeUpdatedDifficulty(newDifficulty);
            DifficultyCount = DifficultyCount + 1;
        }

        private double ComputeUpdatedDifficulty(double newDifficulty)
        {
            double result = ((Difficulty * DifficultyCount) + newDifficulty) / (DifficultyCount + 1);
            result = Math.Round(result, 1);

            return result;
        }

        public void UpdateSectionRating(string instructorName, int newRating)
        {
            foreach (var item in SectionRatings)
            {
                if (item.Key.ToUpper() == instructorName.ToUpper())
                {
                    item.Value["rating"] = ComputeUpdatedRating(item.Value["rating"], newRating, item.Value["count"]);
                    item.Value["count"] = item.Value["count"] + 1;

                }
            }
        }

        private double ComputeUpdatedRating(double oldRating, double newRating, double count)
        {
            double result = ((oldRating * count) + newRating) / (count + 1);
            result = Math.Round(result, 1);

            return result;
        }

    }
}