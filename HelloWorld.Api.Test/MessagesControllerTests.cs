using System;
using HelloWorld.Api.Controllers.V1;
using HelloWorld.Api.Services;
using HelloWorld.Domain.DTOs;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HelloWorld.Api.Test
{
    public class MessagesControllerTests
    {
        [Fact]
        public void Get_ReturnsAnOkObjectResult_ForValidId()
        {
            var id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var mockService = new Mock<IMessageService>();
            mockService.Setup(service => service.Get(id))
                .Returns(GetTestResponse());

            var controller = new MessagesController(mockService.Object);
            var result = controller.Get(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var message = Assert.IsType<MessageResponse>(okResult.Value);

            Assert.Equal(id, message.Id);
            Assert.Equal("Hello World!", message.Content);
        }

        [Fact]
        public void Get_ReturnsANotFoundResult_ForInvalidId()
        {
            var id = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var mockService = new Mock<IMessageService>();
            mockService.Setup(service => service.Get(id))
                .Returns(GetEmptyTestResponse());

            var controller = new MessagesController(mockService.Object);
            var result = controller.Get(id);

            Assert.IsType<NotFoundResult>(result);
        }

        private static ServiceResponse<Message> GetTestResponse()
        {
            return new ServiceResponse<Message>
            {
                Data = new Message
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Content = "Hello World!"
                }
            };
        }

        private static ServiceResponse<Message> GetEmptyTestResponse()
        {
            return new ServiceResponse<Message>();
        }
    }
}
