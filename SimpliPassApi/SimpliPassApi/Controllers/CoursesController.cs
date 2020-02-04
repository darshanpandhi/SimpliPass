using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Http;
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
            throw new Exception("dfdfd");
            _logger.LogInformation("Begin CoursesController Get");
            var items = await _dbClient.GetCourses();
            _logger.LogInformation("Finish CoursesController Get");
            return items;
        }

        [HttpGet("{id}", Name = "GetCourse")]
        public async Task<Course> GetCourse(string id)
        {
            _logger.LogInformation("Begin CoursesController Get id");
            var item = await _dbClient.GetCourse(id);
            _logger.LogInformation("Finish CoursesController Get id");
            return item;
        }
    }
}
