using System;
using System.Linq;
using HelloWorld.Data.Repositories;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Services;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Api.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repo;
        private readonly ILogger<MessageService> _logger;

        public MessageService(IMessageRepository repo, ILogger<MessageService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public ServiceResponse<Message> Get(Guid id)
        {
            _logger.LogInformation("Retrieving message {@Id}", id);

            var response = new ServiceResponse<Message>();
            response.Data = _repo.Messages.SingleOrDefault(m => m.Id == id);

            if (response.Data == null)
            {
                _logger.LogInformation("Message not found: {@Id}", id);
            }

            return response;
        }
    }
}
