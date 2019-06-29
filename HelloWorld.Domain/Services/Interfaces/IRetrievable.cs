using System;

namespace HelloWorld.Domain.Services
{
    public interface IRetrievable<T>
    {
        ServiceResponse<T> Get(Guid id);
    }
}
