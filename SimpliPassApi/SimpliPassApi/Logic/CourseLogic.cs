using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.DataModel;
using SimpliPassApi.Models;

namespace SimpliPassApi.Logic
{
    public static class CourseLogic
    {
        private const int MAX_DIFFICULTY = 5;

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

        public static List<Course> GetRecommendationsList(List<Course> courseList)
        {
            List<Course> result = null;

            if (courseList != null)
            {
                result = new List<Course>();

                foreach (var course in courseList)
                {
                    if (course.Difficulty < MAX_DIFFICULTY)
                    {
                        result.Add(course);
                    }
                }
                result = result.OrderBy(o => o.Difficulty).ToList();
            }
            return result;
        }

        public static void UpdateDifficulty(int newDifficulty, Course item)
        {
            item.Difficulty = ComputeUpdatedDifficulty(newDifficulty, item);
            item.DifficultyCount = item.DifficultyCount + 1;
        }

        private static double ComputeUpdatedDifficulty(double newDifficulty, Course item)
        {
            double result = ((item.Difficulty * item.DifficultyCount) + newDifficulty) / (item.DifficultyCount + 1);
            result = Math.Round(result, 1);

            return result;
        }

        public static void UpdateSectionRating(string instructorName, int newRating, Course crs)
        {
            Boolean flag = false;

            foreach (var item in crs.SectionRatings)
            {
                if (item.Key.ToUpper() == instructorName.ToUpper())
                {
                    item.Value["rating"] = ComputeUpdatedRating(item.Value["rating"], newRating, item.Value["count"]);
                    item.Value["count"] = item.Value["count"] + 1;
                    flag = true;
                }
            }

            if (!flag) // This is a new instructor, add new item to section ratings list
            {
                var pairs = new Dictionary<string, double>();

                pairs.Add("count", 1);
                pairs.Add("rating", newRating);

                crs.SectionRatings.Add(instructorName, pairs);
            }
        }

        private static double ComputeUpdatedRating(double oldRating, double newRating, double count)
        {
            double result = ((oldRating * count) + newRating) / (count + 1);
            result = Math.Round(result, 1);

            return result;
        }
    }
}