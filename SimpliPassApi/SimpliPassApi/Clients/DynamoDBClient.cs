using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using SimpliPassApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Course> GetCourse(string key)
        {
            var item = await _context.LoadAsync<Course>(key);
            return item;
        }

        public async Task<List<Course>> GetCourses()
        {
            var courses = await _context.ScanAsync<Course>(new List<ScanCondition>()).GetRemainingAsync();
            return courses;
        }
    }
}
