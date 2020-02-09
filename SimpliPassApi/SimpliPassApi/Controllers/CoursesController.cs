using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpliPassApi.Clients;
using SimpliPassApi.Models;

namespace SimpliPassApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IAmazonDynamoDB _dbService;
        private readonly DynamoDBClient _dbClient;

        public CourseController(
            ILogger<CourseController> logger,
            IAmazonDynamoDB dbService)
        {
            _logger = logger;
            _dbService = dbService;
            _dbClient = new DynamoDBClient(_dbService);
        }

        [HttpGet]
        public async Task<List<Course>> Get()
        {
            _logger.LogInformation("Begin CoursesController GET");
            var items = await _dbClient.GetCourses();
            _logger.LogInformation("Finish CoursesController GET");

            return items;
        }

        [HttpGet("{id}", Name = "GetCourse")]
        public async Task<Course> GetCourse(string id)
        {
            _logger.LogInformation("Begin CoursesController GET id");
            var item = await _dbClient.GetCourse(id.ToUpper());
            _logger.LogInformation("Finish CoursesController GET id");

            return item;
        }

        [HttpPut("{id}/updateDifficulty/{newDifficulty}", Name = "UpdateCourseDifficulty")]
        public async void UpdateCourseDifficulty(string id, int newDifficulty)
        {
            _logger.LogInformation("Begin CoursesController PUT Update Course Difficulty");
            _dbClient.UpdateCourseDifficulty(id.ToUpper(), newDifficulty);
            _logger.LogInformation("Finish CoursesController PUT Update Course Difficulty");
        }
    }
}
