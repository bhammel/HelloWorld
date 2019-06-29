using System.Collections.Generic;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Data.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<Message> Messages { get; set; }
    }
}
