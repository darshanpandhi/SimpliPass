using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using SimpliPassApi.Exceptions;
using SimpliPassApi.Logic;
using SimpliPassApi.Models;

namespace SimpliPassApi.Clients
{
    public interface IDynamoDBClient
    {
        public Task<List<Course>> GetCourses();

        public Task<Course> GetCourse(string key);

        public Task<List<string>> GetAllDepartments();

        public Task<List<Course>> GetCoursesForDept(string key);

        public Task<List<Course>> GetRecommendations();

        public void UpdateExistingCourse(string key, int newDifficulty, string instructorName, int newRating);

        public void AddNewCourse(string id, string name, string department, int difficulty, string instructorName, int rating);
    }

    public class DynamoDBClient : IDynamoDBClient
    {
        private readonly IDynamoDBContext _context;

        public DynamoDBClient(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCourses()
        {
            var courses = await _context.ScanAsync<Course>(new List<ScanCondition>()).GetRemainingAsync();
            return courses;
        }

        public async Task<Course> GetCourse(string key)
        {
            var item = await _context.LoadAsync<Course>(key);
            return item;
        }

        public async Task<List<string>> GetAllDepartments()
        {
            List<string> departmentList = new List<string>();

            var courses = await _context.ScanAsync<Course>(new List<ScanCondition>()).GetRemainingAsync();

            if (courses != null)
            {
                departmentList = CourseLogic.GetAllDepartments(courses);
            }
            else
            {
                throw new SimpliPassException("Failed to get Courses Table.");
            }

            return departmentList;
        }

        public async Task<List<Course>> GetCoursesForDept(string key)
        {
            List<Course> list = new List<Course>();

            var courses = await _context.ScanAsync<Course>(new List<ScanCondition>()).GetRemainingAsync();

            if (courses != null)
            {
                list = CourseLogic.GetCoursesForDept(courses, key);
            }
            else
            {
                throw new SimpliPassException("Failed to get Courses Table.");
            }

            return list;
        }

        public async Task<List<Course>> GetRecommendations()
        {

            List<Course> list = new List<Course>();

            var courses = await _context.ScanAsync<Course>(new List<ScanCondition>()).GetRemainingAsync();

            if (courses != null)
            {
                list = CourseLogic.GetRecommendationsList(courses);
            }
            else
            {
                throw new SimpliPassException("Failed to get Courses Table.");
            }

            return list;
        }

        public async void UpdateExistingCourse(string key, int newDifficulty, string instructorName, int newRating)
        {
            var item = await _context.LoadAsync<Course>(key);

            if (item != null)
            {
                item.UpdateDifficulty(newDifficulty);
                item.UpdateSectionRating(instructorName, newRating);

                await _context.SaveAsync(item);
            }
            else
            {
                throw new SimpliPassException("Failed to update existing course: course not found in database.");
            }
        }

        public async void AddNewCourse(string id, string name, string department, int difficulty, string instructorName, int rating)
        {
            Course crs;
            var ratings = new Dictionary<string, Dictionary<string, double>>();
            var pairs = new Dictionary<string, double>();

            pairs.Add("count", 1);
            pairs.Add("rating", rating);
            ratings.Add(instructorName, pairs);

            crs = new Course
            {
                Id = id,
                Department = department,
                Difficulty = difficulty,
                DifficultyCount = 1,
                Name = name,
                SectionRatings = ratings
            };

            await _context.SaveAsync(crs);
        }
    }
}