using System;
using System.Collections.Generic;
using HelloWorld.Api.Services;
using HelloWorld.Data.Repositories;
using HelloWorld.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HelloWorld.Api.Test
{
    public class MessageServiceTests
    {
        [Fact]
        public void Get_ReturnsAMessageObject_ForValidId()
        {
            var id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var mockRepo = new Mock<IMessageRepository>();
            mockRepo.Setup(repo => repo.Messages)
                .Returns(GetTestMessages());

            var mockLogger = new Mock<ILogger<MessageService>>();
            var service = new MessageService(mockRepo.Object, mockLogger.Object);
            var response = service.Get(id);

            Assert.NotNull(response.Data);
            Assert.Equal(id, response.Data.Id);
            Assert.Equal("Hello World!", response.Data.Content);
        }

        [Fact]
        public void Get_ReturnsNull_ForInvalidId()
        {
            var id = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var mockRepo = new Mock<IMessageRepository>();
            mockRepo.Setup(repo => repo.Messages)
                .Returns(GetTestMessages());

            var mockLogger = new Mock<ILogger<MessageService>>();
            var service = new MessageService(mockRepo.Object, mockLogger.Object);
            var response = service.Get(id);

            Assert.Null(response.Data);
        }

        private static IEnumerable<Message> GetTestMessages()
        {
            return new List<Message>
            {
                new Message
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Content = "Hello World!"
                }
            };
        }
    }
}
