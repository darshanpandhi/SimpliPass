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
    }
}