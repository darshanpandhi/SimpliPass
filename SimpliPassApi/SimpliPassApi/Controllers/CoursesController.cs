using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet("departmentCourses/{name}", Name = "GetCoursesForDept")]
        public async Task<List<Course>> GetCoursesForDept(string name)
        {
            _logger.LogInformation("Begin CoursesController GET All Courses For Department");
            var items = await _dbClient.GetCoursesForDept(name);
            _logger.LogInformation("Finish CoursesController GET All Courses For Department");

            return items;
        }

        [HttpPut("{id}/updateExistingCourse/{newDifficulty}/{instructorName}/{newRating}", Name = "UpdateExistingCourse")]
        public async void UpdateExistingCourse(string id, int newDifficulty, string instructorName, int newRating)
        {
            _logger.LogInformation("Begin CoursesController PUT Update Existing Course");
            _dbClient.UpdateExistingCourse(id.ToUpper(), newDifficulty, instructorName, newRating);
            _logger.LogInformation("Finish CoursesController PUT Update Existing Course");
        }

        [HttpPost("new/{id}/{name}/{department}/{difficulty}/{instructorName}/{rating}", Name = "AddNewCourse")]
        public async void AddNewCourse(string id, string name, string department, int difficulty, string instructorName, int rating)
        {
            _logger.LogInformation("Begin CoursesController POST Add New Course");
            _dbClient.AddNewCourse(id.ToUpper(), name, department, difficulty, instructorName, rating);
            _logger.LogInformation("Finish CoursesController POST Add New Course");
        }

    }
}