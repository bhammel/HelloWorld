using System.Threading.Tasks;
using HelloWorld.Domain.Constants;
using HelloWorld.Domain.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HelloWorld.Api.Services
{
    public class JsonExceptionHandlerService : IJsonExceptionHandlerService
    {
        private readonly ILogger<JsonExceptionHandlerService> _logger;

        public JsonExceptionHandlerService(ILogger<JsonExceptionHandlerService> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exception = errorFeature?.Error;
            var problemDetails = new ProblemDetails
            {
                Title = ErrorTypes.ApiError,
                Status = StatusCodes.Status500InternalServerError
            };

            if (exception != null)
            {
                problemDetails.Detail = exception.GetFullMessage();
            }

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = MediaTypeNames.Application.ProblemDetails.Json;

            _logger.LogWarning("Internal Server Error {@Error}", problemDetails);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }
    }
}
