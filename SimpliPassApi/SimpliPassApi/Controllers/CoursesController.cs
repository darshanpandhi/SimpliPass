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
        private readonly IDynamoDBClient _dbClient;

        public CourseController(
            ILogger<CourseController> logger,
            IDynamoDBClient dbClient)
        {
            _logger = logger;
            _dbClient = dbClient;
        }

        [HttpGet]
        public async Task<List<Course>> Get()
        {
            _logger.LogInformation("Begin CoursesController GET All Courses");
            var items = await _dbClient.GetCourses();
            _logger.LogInformation("Finish CoursesController GET All Courses");

            return items;
        }

        [HttpGet("{id}", Name = "GetCourse")]
        public async Task<Course> GetCourse(string id)
        {
            _logger.LogInformation("Begin CoursesController GET Course by id");
            var item = await _dbClient.GetCourse(id.ToUpper());
            _logger.LogInformation("Finish CoursesController GET Course by id");

            return item;
        }

        [HttpGet("departments", Name = "GetAllDepartments")]
        public async Task<List<string>> GetAllDepartments()
        {
            _logger.LogInformation("Begin CoursesController GET All Departments");
            var items = await _dbClient.GetAllDepartments();
            _logger.LogInformation("Finish CoursesController GET All Departments");

            return items;
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