using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Services;

namespace HelloWorld.Api.Services
{
    public interface IMessageService : IRetrievable<Message>
    {
    }
}
