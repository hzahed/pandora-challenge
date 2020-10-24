using Challenge.WebApi.Controllers;
using Challenge.WebApi.Interfaces;
using Challenge.WebApi.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace Challenge.WebApi.Tests
{
    public class TaskControllerTests
    {
        [Fact]
        public void PostInputTextShouldReturnAccepted()
        {
            // Arrange
            var backgroundQueue = A.Fake<IBackgroundQueue<string>>();
            var tasksController = new TasksController(backgroundQueue);
            var dto = new TaskDto { InputText = "Test 1" };

            // Act
            var responseResult = tasksController.Post(dto) as ObjectResult;

            // Assert
            Assert.IsType<AcceptedResult>(responseResult);
            Assert.NotNull(responseResult.StatusCode);
            Assert.Equal(HttpStatusCode.Accepted, (HttpStatusCode)responseResult.StatusCode);
        }

        [Fact]
        public void PostNullShouldReturnBadRequest()
        {
            // Arrange
            var backgroundQueue = A.Fake<IBackgroundQueue<string>>();
            var tasksController = new TasksController(backgroundQueue);
            var dto = new TaskDto { InputText = null };

            // Act
            var responseResult = tasksController.Post(dto) as ObjectResult;

            // Assert
            Assert.IsType<BadRequestObjectResult>(responseResult);
            Assert.NotNull(responseResult.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)responseResult.StatusCode);
        }
    }
}