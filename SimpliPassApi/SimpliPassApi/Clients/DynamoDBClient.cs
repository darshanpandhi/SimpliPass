using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using SimpliPassApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpliPassApi.Clients
{
    public class DynamoDBClient
    {
        private readonly DynamoDBContext _context;
        private readonly IAmazonDynamoDB _dbService;

        public DynamoDBClient(IAmazonDynamoDB dynamoDbService)
        {
            _dbService = dynamoDbService;
            _context = new DynamoDBContext(_dbService);
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

        public async void UpdateCourseDifficulty(string key, int newDifficulty)
        {
            var item = await _context.LoadAsync<Course>(key);

            if (item != null)
            {
                item.Difficulty = item.ComputeUpdatedDifficulty(newDifficulty);
                item.DifficultyCount = item.DifficultyCount + 1;

                await _context.SaveAsync(item);
            }
        }
    }
}
