using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpliPassApi.Models
{
    public class Course
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("id")]
        public string Id { get; set; }
        [DynamoDBProperty("department")]
        public string Department { get; set; }
        [DynamoDBProperty("difficulty")]
        public int Difficulty { get; set; }
        [DynamoDBProperty("name")]
        public string Name { get; set; }
        [DynamoDBProperty("section_ratings")]
        public Dictionary<string, int> Section_ratings { get; set; }
    }
}
