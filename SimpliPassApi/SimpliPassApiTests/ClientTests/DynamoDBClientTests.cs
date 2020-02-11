using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Moq;
using NUnit.Framework;

namespace SimpliPassApiTests.ClientTests
{
    public class DynamoDBClientTests
    {
        private Mock<IAmazonDynamoDB> _dbService;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}