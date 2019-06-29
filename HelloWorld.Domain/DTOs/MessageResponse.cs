using System;
using System.Linq.Expressions;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Domain.DTOs
{
    public class MessageResponse : IHasId<Guid>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public static Expression<Func<Message, MessageResponse>> Projection =>
            m => new MessageResponse
            {
                Id = m.Id,
                Content = m.Content
            };

        public static MessageResponse FromEntity(Message message)
        {
            return message == null ? null : Projection.Compile().Invoke(message);
        }
    }
}
