using System;
using System.Collections.Generic;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public MessageRepository()
        {
            Messages = new List<Message>
            {
                new Message
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Content = "Hello World!"
                }
            };
        }

        public IEnumerable<Message> Messages { get; set; }
    }
}
