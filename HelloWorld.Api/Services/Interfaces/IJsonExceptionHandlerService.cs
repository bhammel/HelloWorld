using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloWorld.Api.Services
{
    public interface IJsonExceptionHandlerService
    {
        Task InvokeAsync(HttpContext context);
    }
}
