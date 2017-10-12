namespace LoggingMicroservice.Tests.Controllers
{
    using System.Net;
    using LoggingMicroservice.Controllers;
    using LoggingMicroservice.Core;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;

    public class MessageLogControllerTests
    {
        private MessageLogController controller;

        public MessageLogControllerTests()
        {
            controller = new MessageLogController();
        }

        [Fact]
        public void Log_InvalidModelState_ReturnsBadRequest()
        {
            controller.ModelState.AddModelError("Id", "Invalid");

            var result = controller.Log(new Message()) as ObjectResult;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void Log_ValidModelState_ReturnsOkResult()
        {
            var result = controller.Log(new Message()) as StatusCodeResult;

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }
    }
}
