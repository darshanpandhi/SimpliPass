using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SimpliPassApi.Exceptions;
using SimpliPassApi.Middleware;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpliPassApiTests.MiddlewareTests
{
    class ExceptionHandlerTest
    {
        private Mock<ILogger<ErrorHandlerMiddleware>> logger;
        private ErrorHandlerMiddleware middleware;
        private HttpContext httpContext;

        [SetUp]
        public void Setup()
        {
            logger = new Mock<ILogger<ErrorHandlerMiddleware>>();
            httpContext = new DefaultHttpContext();
        }
        [Test]
        public async Task TestUnhandledExceptionHandler()
        {
            middleware = new ErrorHandlerMiddleware(
                next: (innerHttpContext) => Task.FromException(new Exception("Test Exception")), logger.Object);

            await middleware.Invoke(httpContext);

            int statusCode = httpContext.Response.StatusCode;

            Assert.AreEqual(statusCode, (int) HttpStatusCode.InternalServerError);
        }

        [Test]
        public async Task TestHandledExceptionHandler()
        {
            middleware = new ErrorHandlerMiddleware(
                next: (innerHttpContext) => Task.FromException(new SimpliPassException("Test Exception")), logger.Object);

            await middleware.Invoke(httpContext);

            int statusCode = httpContext.Response.StatusCode;

            Assert.AreEqual(statusCode, (int) HttpStatusCode.BadRequest);
        }
    }
}
