using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using SimpliPassApi.Exceptions;
using SimpliPassApi.Models;

namespace SimpliPassApi.Clients
{
    public interface IDynamoDBClient
    {
        public Task<List<Course>> GetCourses();

        public Task<Course> GetCourse(string key);

        public Task<List<string>> GetAllDepartments();

        public Task<List<Course>> GetCoursesForDept(string key);

        public void UpdateCourseDifficulty(string key, int newDifficulty);
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
                departmentList = Course.GetAllDepartments(courses);
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
                list = Course.GetCoursesForDept(courses, key);
            }
            else
            {
                throw new SimpliPassException("Failed to get Courses Table.");
            }

            return list;
        }

        public async void UpdateCourseDifficulty(string key, int newDifficulty)
        {
            var item = await _context.LoadAsync<Course>(key);

            if (item != null)
            {
                item.Difficulty = item.ComputeUpdatedDifficulty(newDifficulty);
                item.DifficultyCount = item.DifficultyCount + 1;

                await _context.SaveAsync(item);
            }
            else
            {
                throw new SimpliPassException("Failed to update course difficulty: failed to find the course.");
            }
        }
    }
}